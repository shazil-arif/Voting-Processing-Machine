using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
/* Name: Shazil Arif
 * Date: May 15th, 2018
 * Assignment 4, Voting Machine
 */ //Purpose: To create a program that reads a student base and then a file containing the votes for each student and determines the winner.
 //the program is also able to sort the names based off users choice
namespace VotingProcessingMachine
{
    public partial class Main : Form
    {
        Variables Access = new Variables();
        public Main()
        {
            InitializeComponent();
            ClearFile();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            ClearData(); //clear previously stored data upon loading new file
            OpenFile();
            PrintDataTable(true);
        }
        public void OpenFile()
        {
            OpenFileDialog File = new OpenFileDialog();
            if (File.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenFile());
                Access.FilePath = File.FileName;
                Access.Loaded = true;
                ReadDataBase(Access.FilePath);
            }
        }
     
        public void ReadDataBase(string FilePath)
        {
            StreamReader sr = new StreamReader(FilePath);
            int Length = 0;
            while (sr.ReadLine() != null)
            {
                Length++;
            }
            if (Length == 0)
            {
                MessageBox.Show("File was empty.");
            }
            else
            {
                sr.BaseStream.Position = 0; //reset streamreader to first line
                try
                {
                    int i = 0;
                    sr.ReadLine();
                    while (i < Length - 1) //read till end of file
                    {
                        string line = sr.ReadLine(); //read current line
                        string[] Elements = line.Split(','); //store current line into string array splitted between commas
                        Trim(Elements,' ');
                        Trim(Elements, '\"');
                        //simply adding elements to list
                        Access.FirstName.Add((Elements[1]).ToUpper());
                        Access.LastName.Add((Elements[0]).ToUpper());
                        Elements[2] = Elements[2].Replace("-", string.Empty); //trim dashes from student id
                        if (TryParse(Elements[2]) == true) //making sure the student id is a number
                        {
                            Access.ID.Add(Elements[2]);
                        }
                        Access.Gender.Add(Elements[3].ToUpper());
                        Access.Grade.Add((Elements[4]));
                        Access.Age.Add((Elements[5]));
                        i++;
                    }
                }
                catch
                {
                    MessageBox.Show("Unexpected error, please ensure that the file is in correct format.");
                }
            }
            sr.Close();
        }
        public static bool TryParse(string Value)
        {
            //returns whether its string parameter is a number or not
            //return true if number, false if not
            int Test;
            if (int.TryParse(Value, out Test) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PrintDataTable(bool Clear)
        {
            if (Clear == true)
            {
                dataGridResults.Rows.Clear();
            }
            for (int i = 0; i < Access.LastName.Count; i++)
            {
                //output to datagrid view
                int n = dataGridResults.Rows.Add();
                dataGridResults.Rows[n].Cells[0].Value = Access.LastName[i];
                dataGridResults.Rows[n].Cells[1].Value = Access.FirstName[i];
                dataGridResults.Rows[n].Cells[2].Value = Access.ID[i];
                dataGridResults.Rows[n].Cells[3].Value = Access.Gender[i];
                dataGridResults.Rows[n].Cells[4].Value = Access.Age[i];
                dataGridResults.Rows[n].Cells[5].Value = Access.Grade[i];
            }
        }
        private void btnLoadVotes_Click(object sender, EventArgs e)
        {
            ClearFile(); //clear previously recorded winners
            if (Access.Loaded == false) //checks if student databse was loaded, if not user is prompted to load that first
            {
                MessageBox.Show("Please load student Database first.");
            }
            else
            {
                ClearData();
                ReadDataBase(Access.FilePath); //read database
                PrintDataTable(true); //output to datagrid
                string Path = null;
                Access.LoadedVotes = true;
                OpenFileDialog File = new OpenFileDialog();
                if (File.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(File.OpenFile()); //open file
                    Path = File.FileName;
                    int Length = 0;
                    while (sr.ReadLine() != null)
                    {
                        Length++;
                    }
                    if (Length == 0)
                    {
                        MessageBox.Show("File was empty.");
                    }
                    else
                    {
                        string[] Elements = null;
                        string line = null;
                        bool Error = false;
                        try
                        {
                            sr.BaseStream.Position = 0;
                            sr.ReadLine(); //skip first line
                            line = sr.ReadLine();
                            char[] Items = line.ToCharArray();
                            Elements = line.Split(',');
                            int Columns = 0;
                            Trim(Elements, ' ');
                            int Count = 0;
                            for (int i = 0; i < Items.Length; i++)
                            {
                                if (Items[i] == ',')
                                {
                                    Count++; //get number of commas
                                }
                            }
                            Columns = (Count - 2)+1; //number of commas - 2 at start equals total voting positions, adding one row where user ID will be stored
                            Access.Votes = new string[Length, Columns]; //initialize array to number of columns and length which is length of file
                        }
                        catch
                        {
                            MessageBox.Show("An error occured please ensure the file is in the correct format."); //catch any errors
                            Error = true;
                        }
                        sr.Close();
                        if (Error == false)
                        {
                            StreamReader sr2 = new StreamReader(Path);
                            int Loop = 0;
                            int Col = 0;
                            sr2.ReadLine();
                            List<string> DuplicateCheck = new List<string>();
                            while (Loop < Length-1)
                            {
                                Col = 1;
                                line = sr2.ReadLine();
                                Elements = line.Split(',');
                                for (int i = 0; i < Elements.Length; i++)
                                {
                                    Elements[i] = Elements[i].ToUpper(); //converting to upper
                                }
                                Trim(Elements, ' ');
                                if (CheckDataBase(Access.LastName, Access.FirstName, Access.ID, Elements[1], Elements[0], Elements[2]) == true) //check if first name,last name, and id exists in databse
                                { 
                                    //willl return true if not in database
                                    //add to disposed names
                                    Access.DisposedFirstName.Add(Elements[0]); //adding to diposed names list
                                    Access.DisposedLastName.Add(Elements[1]);
                                    Access.DisposedID.Add(Elements[2]);
                                }
                                else
                                {
                                    if (DuplicateCheck.Contains(Elements[2])) //check if current entry was already checked
                                    {
                                        Remove(Elements[2], Access.Votes, Elements, Loop); //if yes call remove method, which makes this users previous entry null and records the current one                                        
                                    }
                                    else {
                                        for (int i = 0; i < Elements.Length; i++)
                                        {
                                            if (i > 2 && Col < Access.Votes.GetLength(1)) //fill 2d array with votes, each column corresponds to each vote, filling after i > 2 since first two commas are ignored 
                                            {
                                                Access.Votes[Loop, Col] = Elements[i]; //fill
                                                Col++; //increment columns
                                            }
                                        }
                                    }
                                    if (!(DuplicateCheck.Contains(Elements[2])))
                                    {
                                        DuplicateCheck.Add(Elements[2]);
                                    }
                                    Access.Votes[Loop, 0] = Elements[2]; //voter id is written in first row of 2d array to keep track of which vote is whose
                                    GenderCount(Elements[2]); //get gender count
                                }
                                Loop++; //incerement loop to move to next line in file
                            }
                            for (int i = 0; i < Access.Votes.GetLength(0); i++)
                            {
                                for (int j = 0; j < Access.Votes.GetLength(1); j++) 
                                {
                                    if (Access.Votes[i,j] == "")  //any  empty spaces are made null
                                    {
                                        Access.Votes[i, j] = null; 
                                    }
                                }
                            }
                            Winner(Access.Votes); //call winner method, determines winner
                            VotingOutput(); //print output
                            sr2.Close();
                        }
                    }
                }
            }
        }
        public void GenderCount(string ID)
        {
            int Index = 0;
            for (int i = 0; i < Access.ID.Count; i++)
            {
                if (Access.ID[i] == ID) //find index at which the ID exists at
                {
                    Index = i; //get index and break
                    break;
                }
            }
            //the index retrieved corresponds to the same index in the gender list since they are parallel, get this persons Gender which occurs at same index
            if (Access.Gender[Index] == "M")
            {
                Access.MaleCount++; //get male count
            }
            else if (Access.Gender[Index] == "F")
            {
                Access.FemaleCount++; //get female count
            }
        }
        public void Remove(string ID, string[,] Votes, string[] Elements, int Loop)
        {
            int Index = 0;
            int RemoveIndex = 0;
            Access.DuplicateCount++;
            for (int i = Access.Votes.GetLength(0)-1; i>=0; i--)
            {
                if (Access.Votes[i,0] == ID) //get index of most recent vote by user, reading array from bottom up
                {
                    RemoveIndex = i;
                    break; //break to get first index
                }
               
            }
            for (int i = 0; i < Access.ID.Count; i++)
            {
                if (Access.ID[i] == ID)
                {
                    Index = i; //get which index in the ID list the ID is at
                }
            }
            for (int j = 1; j < Access.Votes.GetLength(1); j++)
            {
                Access.Votes[RemoveIndex, j] = null; //the ID index corresponds to the users rows in the 2d array where their votes are. Their votes are changed to null
            }
            if (!(Access.DuplicateListID.Contains(ID) && Access.DuplicateListFirst.Contains(Access.FirstName[Index]) && Access.DuplicateListLast.Contains(Access.LastName[Index])))
            {
                Access.DuplicateListID.Add(ID); //add to duplicate list to keep tracking
                Access.DuplicateListFirst.Add(Access.FirstName[Index]); //add to duplicate list to keep tracking
                Access.DuplicateListLast.Add(Access.LastName[Index]); //add to duplicate list to keep tracking
            }
            DuplicateInsert(Elements, Loop); //Duplicate insert, fill the 2d array row with the current line
        }
        public void DuplicateInsert(string [] Elements, int Loop)
        {
            int Col = 1;
            Access.Votes[Loop, 0] = Elements[2];
            for (int i = 0; i < Elements.Length; i++)
            {
                if (i > 2 && Col < Access.Votes.GetLength(1))
                {
                    Access.Votes[Loop, Col] = Elements[i]; //same algorithim
                    Col++; //increment columns
                }
            }
        }
        public string[] Trim(string[] Elements, char Parameter)
        {
            //this method trims elements array based of any character, whether its a space
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = Elements[i].Trim(Parameter); 
            }
            return Elements;
        }
        public bool CheckDataBase(List<string> LastName, List<string>FirstName,List<string> ID,string LastCheck, string FirstCheck, string UserCheck)
        {
            //method checks if inputted data exists in Databse
            int Index = 0;
            bool State = false;
            for (int i = 0; i < LastName.Count; i++)
            {
                if (ID[i] != UserCheck) //if not in database true
                {
                    State = true;
                    Index = i;
                }
                if (ID[i] == UserCheck) //if in databasd make false, and break loop
                {
                    State = false;
                    Index = i;
                    break;
                }
                if (i == LastName.Count - 1) //if end of llst is reached and state is still true, meaning still not found in databse, it is not in database,
                {
                    if (State == true) //return true
                    {
                        return true;
                    }
                }
            }
            if (LastName[Index] == LastCheck && FirstName[Index] == FirstCheck && ID[Index] == UserCheck) //if found in databse, check first and last name at same indices
            {
                //if all data matches return false, since this ID needs not to be removed
                return false;
            }
            else
            {
                //otherwise return true, since not found in databse and program will discard these names
                return true;
            }
        }
        public void ClearFile()
        {
            //clears output file
            File.WriteAllText(@"Output", "");
        }
        public void Winner(string[,] Votes)
        {
           //this method calculates the number of votes each voter receives and determines the winner
           lblWinners.Text = "";
           int Loop = 1;
           while (Loop < Votes.GetLength(1)) //Loop starts from 0 and goes up to the length of the 2nd dimension of 2d array since that length equals number of different voting positions
           {
                string[] VoteList = new string[Votes.GetLength(0)]; //create a array which will contain names of elected candidates for a speciic voting position
                string[] Duplicate = new string[Votes.GetLength(0)]; //create a duplicate array, exact same as Votelist
                int[] Count = new int[Votes.GetLength(0)]; //create a int array which has same indices as votelist and will correspond to the number of votes each candidate gets
                List<string> Checked = new List<string>();
                for (int i = 0; i < Votes.GetLength(0); i++)
                {
                    VoteList[i] = Votes[i, Loop]; //fill votelist with the first column of the 2d array
                    Duplicate[i] = Votes[i,Loop];
                    
                }
                for (int i = 0; i < Duplicate.Length; i++) //create first loop to run through the duplicate array
                {
                    for (int j = 0; j < VoteList.Length; j++) //second loop to run through votelist array
                    {
                        //program will see how many times duplicate equals voteslist. the idea is "how many times does each vote in the votelist equal itself?"
                       if (Duplicate[i] == VoteList[j] && (!(Checked.Contains(Duplicate[i])))) //check if current voter was already checked and if duplicate array equal votelist increment counter
                       {
                            if (!(Duplicate[i] == null && VoteList[j] == null)) //make sure current vote isnt null, since null votes are not counted
                            {
                                Count[i]++; //increment int array with same index as duplicate list
                            }
                       }
                    }
                    Checked.Add(Duplicate[i]); //once a candidate is checked, add to checked list so they are not repeated
                }
                List<int> Winners = new List<int>(); //create list to store the winners, since there may be more than 1
                for (int i = 0; i < Count.Length; i++)
                {
                    if (Count[i] == Count.Max()) //find the index at which count array is at its max, since its indices are parallel to votelist, the index at which the max value occurs corresponds to the index in votelist at which the candidate with most votes is
                    {
                        Winners.Add(i); //add index to list
                    }
                }
                WriteToFile(Count,VoteList, Loop, Winners); //call method to write output to file
                if (Winners.Count > 1)
                {
                    lblWinners.Text += "Tie for Vote: " + (Loop) + "\r\n";
                }
                for (int i = 0; i < Winners.Count; i++) //go throughh list to print winners, print all winners incase of a tie
                {
                    lblWinners.Text += "Winner for vote: " + (Loop) + " is " + VoteList[Winners[i]] + " at " + Count[Winners[i]] + " Votes" + "\r\n"; //output winners
                }
                Loop++; //increment loop to move to next row in the 2d array which will then calculate the winner for the next vote
           }
        }
        public void WriteToFile(int[] Count, string[] VoteList, int Num, List<int> Winners)
        {
            //this method simply writes the same output to a file for the winning candidates
            StreamWriter sw = new StreamWriter(@"Output.txt",true);
            if (Winners.Count > 1)
            {
                lblWinners.Text += "Tie for Vote: " + (Num) + "\r\n";
            }
            for (int i = 0; i < Winners.Count; i++)
            {
                sw.WriteLine("Winner for vote: " + (Num) + " is " + VoteList[Winners[i]] + " at " + Count[Winners[i]] + " Votes" + "\r\n");
            }
            sw.Close();
        }
        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
           //method  bubble sorts student databse
            if (Access.Loaded == false) //check if a databse file was loaded or not
            {
                MessageBox.Show("Please Load student database first."); 
            }
            else
            {
                ClearData(); //call clear data method to empty all lists, variables etc
                ReadDataBase(Access.FilePath); //read the databse , on each click it is read again since to provide accurate timer results the program must sort the raw data from file each time, 
                PrintDataTable(true);
                //following if statements just check which option user picked to sort data and which algorithim they selected to sort the dat, then call corresponding methods
                if (rdoSortByFirst.Checked == true )
                {
                    int Start = 0;
                    int Elapsed = 0;
                    if (rdoQuick.Checked == true)
                    {
                        Start = Environment.TickCount; //starting timer
                        QuickSortString(Access.FirstName, 0, Access.FirstName.Count - 1); //call quicksort with first names list, 0 and length of list being sorted - 1 to start the sort
                        Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else if (rdoBubble.Checked == true)
                    {
                        Start = Environment.TickCount; //starting timer
                        BubbleSort(Access.FirstName, true); //call bubble with first names list, the bool parameter checks whether a number or string is being stored
                        Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }
                }
                else if (rdoSortByLast.Checked == true)
                {
                    if (rdoBubble.Checked == true)
                    {
                        int Start = Environment.TickCount; //starting timer
                        BubbleSort(Access.LastName, true);
                        int elapsed = Environment.TickCount - Start;
                        TimerResult(elapsed, lblSortTime);
                        PrintDataTable(true);
                    }
                    else if (rdoQuick.Checked == true)
                    {
                        int Start = Environment.TickCount; //starting timer
                        QuickSortString(Access.LastName, 0, Access.LastName.Count-1);
                        int elapsed = Environment.TickCount - Start;
                        TimerResult(elapsed, lblSortTime);
                        PrintDataTable(true);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }
                }
                else if (rdoSortByID.Checked == true)
                {
                    if (rdoBubble.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        BubbleSort(Access.ID, false);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else if (rdoQuick.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        QuickSort(Access.ID, 0 ,Access.ID.Count-1);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }
                }
                else if (rdoSortByAge.Checked == true)
                {
                    if (rdoBubble.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        BubbleSort(Access.Age, false);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else if (rdoQuick.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        QuickSort(Access.Age, 0, Access.Age.Count-1);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }
                }
                else if (rdoSortByGrade.Checked == true)
                {
                    if (rdoBubble.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        BubbleSort(Access.Grade, false);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else if (rdoQuick.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        QuickSort(Access.Grade, 0, Access.Grade.Count - 1);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }
                }
                else if (rdoSortByGender.Checked == true)
                {
                    if (rdoBubble.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        BubbleSort(Access.Gender, true);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else if (rdoQuick.Checked == true)
                    {
                        int Start = Environment.TickCount;
                        QuickSortString(Access.Gender, 0, Access.Gender.Count - 1);
                        int Elapsed = Environment.TickCount - Start;
                        PrintDataTable(true);
                        TimerResult(Elapsed, lblSortTime);
                    }
                    else
                    {
                        MessageBox.Show("Select a sorting type.");
                    }

                }
                else
                {
                    MessageBox.Show("Please select a sorting option.");
                }
            }
        }
        public void BubbleSort(List<string> SortList, bool State)
        {
            //method bubble sorts student databse
            //the bool parameter is to check whether a string or number is being sorted
            for (int i = 0; i < SortList.Count; i++) //bubble sorting
            {
                for (int j = 0; j < SortList.Count - 1; j++)
                {
                    int One = 0, Two = 0;
                    if (State == true) //if a string is being sorted, get ascii value of first letter in the string for the two elements being compared
                    {
                        One = GetAscii(SortList[j].Substring(0, 1));
                        Two = GetAscii(SortList[j + 1].Substring(0, 1));
                    }
                    else
                    {
                        //if number is being compared, e.g age or student ID, parse the two elements being compared,
                        One = int.Parse(SortList[j]);
                        Two = int.Parse(SortList[j + 1]);
                    }
                    if (One > Two) //comparing and swapping first letter of name, or number
                    {
                        BubbleSwapIndexes(j); //call swapping method
                    }
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFile();
            Application.Restart();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            ClearFile();
            Application.Exit();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Search = txtSearchValue.Text;
            if (Access.Loaded == false)
            {
                MessageBox.Show("Please load a file first.");
            }
            else if (Search == "" || Search == null)
            {
                MessageBox.Show("Please enter an entry to search.");
            }
            else
            {
                Search = Search.ToUpper(); //change search string to upper, since everything in databse is stored as upper
                ClearData(); //clear all lists, variables etc
                ReadDataBase(Access.FilePath); //on each click file is read again so that each time data is sorted , it is initially raw, provides fair timer resutls
                if (rdoSearchByFirst.Checked == true && TryParse(Search) == false) //check if first name entered is not a number, to save searching time, if input is a number, search wont be performed
                {
                    int Start = Environment.TickCount; //start timer
                    LinearSearch(Access.FirstName, Search); //call linear search to get all first names that match user inputted name
                    int Elapsed = Environment.TickCount - Start; //end timer
                    TimerResult(Elapsed, lblSearchTime); //print timer result
                }
                else if (rdoSearchByLast.Checked == true && TryParse(Search) == false)
                {
                    int Start = Environment.TickCount;
                    LinearSearch(Access.LastName, Search);
                    int Elapsed = Environment.TickCount - Start;
                    TimerResult(Elapsed, lblSearchTime);
                }
                else if (rdoSearchByStudentID.Checked == true)
                {
                    if (TryParse(Search) == true) //check if number was inputted for student ID
                    {
                        int Start = Environment.TickCount; //start timer
                        QuickSort(Access.ID, 0, Access.ID.Count - 1); //call quicksort since binary search needs to be done for student ID and required data to be sorted
                        int i = BinarySearch(Access.ID, Search, false); //binary search method, returns index at which ID was find, if no match returns -1
                        int Elapsed = Environment.TickCount - Start;//end timer
                        TimerResult(Elapsed, lblSearchTime); //print timer result
                        BinarySearchResult(i); //output search results
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid student ID Number.");
                    }
                }
                else if (rdoSearchByAge.Checked == true)
                {
                    if (TryParse(Search) == true)
                    {
                        int Start = Environment.TickCount;
                        LinearSearch(Access.Age, Search);
                        int Elapsed = Environment.TickCount - Start;
                        TimerResult(Elapsed, lblSearchTime);
                    }
                    else
                    {
                        MessageBox.Show("Age must be a number.");
                    }
                   
                }
                else if (rdoSearchByGrade.Checked == true)
                {
                    if (TryParse(Search) == true)
                    {
                        if (int.Parse(Search) >= 9 && int.Parse(Search) <= 12)
                        {
                            int Start = Environment.TickCount;
                            LinearSearch(Access.Grade, Search);
                            int Elapsed = Environment.TickCount - Start;
                            TimerResult(Elapsed, lblSearchTime);
                        }
                        else
                        {
                            MessageBox.Show("Grades must be between 9 and 12 inclusive.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a number for Grade.");
                    }

                }
                else if (rdoSearchByGender.Checked == true)
                {
                    if (Search == "M" || Search == "F")
                    {
                        int Start = Environment.TickCount;
                        LinearSearch(Access.Gender, Search);
                        int Elapsed = Environment.TickCount - Start;
                        TimerResult(Elapsed, lblSearchTime);
                    }
                    else
                    {
                        MessageBox.Show("There are only two genders. Please enter Male or female.");
                    }
                }
                else //if no check box was selected
                {
                    MessageBox.Show("Select Searching option.");
                }
            }
        }
        public void QuickSortString(List<string>Unsorted, int lo, int hi)
        {
            //method quicksorts data for strings
            int i = lo;
            int j = hi;
            string PivotString = Unsorted[lo + (hi - lo) / 2];
            int PivotValue = GetAscii(PivotString); //get first chracter
            while (i - j <= 0)
            {
                while (GetAscii(Unsorted[i]) < PivotValue) //continue incrementing left portion of array being sorted until greater than pivot 
                {
                    i++;
                }
                while (GetAscii(Unsorted[j]) > PivotValue) //continue decrementing right portion of array being sorted until less than pivot
                {
                    j--;
                }
                if (i - j <= 0)
                {
                    QuickSwapIndexes(i, j); //call swapping method
                    i++;
                    j--;
                }
            }
            if (lo < j) //if 'lo' less than j call quicksorted with lo and j, lo being the starting index of the portion of array being sorted and j being the ending index
            {
                QuickSortString(Unsorted, lo, j);
            }
            if (i < hi) //ehck if starting index i is less than ending index hi
            {
                QuickSortString(Unsorted, i, hi); //call with i and hi. i being starting index of portion of array being sorted and hi being ending index of array being sorted
            }
        }
   
        public void QuickSort(List<string>Unsorted,int lo, int hi)
        {
            //method quicksorts data for numbers
            //same algorithim but for numbers
            int i = lo;
            int j = hi;
            int PivotValue = int.Parse(Unsorted[lo + (hi - lo) / 2]); //get first chracter
            while (i - j <= 0)
            {
                while (int.Parse(Unsorted[i]) < PivotValue)
                {
                    i++;
                }
                while (int.Parse(Unsorted[j]) > PivotValue)
                {   
                    j--;
                }
                if (i - j <= 0)
                {
                    QuickSwapIndexes(i,j);
                    i++;
                    j--;
                }
            }
            if (lo < j)
            {
                QuickSort(Unsorted,lo, j);
            }
            if (i < hi)
            {
                QuickSort(Unsorted,i, hi);
            }
        }
        public static int GetAscii(string First)
        {   
            //method gets ascii value of the string passed in and returns it
            byte[] One = Encoding.ASCII.GetBytes(First);
            return One[0];  
        }
        public void LinearSearch(List<string> Elements, string Search)
        {
            //linear search for all entries in student database
            //searches everything except student ID, since that is unique
            bool State = false;
            int Clear = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Search == Elements[i]) //find all elements that match search key
                {
                    State = true;
                    Clear++;
                    if (Clear == 1)
                    {
                        //only clear the first time
                        ClearDataTable();
                    }
                    int n = dataGridResults.Rows.Add();
                    dataGridResults.Rows[n].Cells[0].Value = Access.LastName[i];
                    dataGridResults.Rows[n].Cells[1].Value = Access.FirstName[i];
                    dataGridResults.Rows[n].Cells[2].Value = Access.ID[i];
                    dataGridResults.Rows[n].Cells[3].Value = Access.Gender[i];
                    dataGridResults.Rows[n].Cells[4].Value = Access.Age[i];
                    dataGridResults.Rows[n].Cells[5].Value = Access.Grade[i];

                }
                if (i == Elements.Count - 1 && State == false)
                {
                    MessageBox.Show("No match.");
                }
            }
        }
        public static int BinarySearch(List<string> ID, string SearchValue, bool State)
        {
            //binary search method
            int Top = 0;
            int Bottom = ID.Count - 1;
            while (Top <= Bottom)
            {
                int MidIndex = Top + (Bottom - Top) / 2;
                int Search = int.Parse(SearchValue);
                if (int.Parse(ID[MidIndex]) == Search)
                {
                    return MidIndex;
                }
                else if (Search < int.Parse(ID[MidIndex]))
                {
                    Bottom = MidIndex - 1;
                }
                else if (Search > int.Parse(ID[MidIndex]))
                {
                    Top = MidIndex + 1;
                }
            }
            return -1;
        }
        public void BinarySearchResult(int i)
        {
            //outputs binary search resuts
            if (i < 0) //-1 means no match
            {
                MessageBox.Show( "No Match.");
            }
            else
            {
                ClearDataTable();
                int n = dataGridResults.Rows.Add();
                dataGridResults.Rows[n].Cells[0].Value = Access.LastName[i];
                dataGridResults.Rows[n].Cells[1].Value = Access.FirstName[i];
                dataGridResults.Rows[n].Cells[2].Value = Access.ID[i];
                dataGridResults.Rows[n].Cells[3].Value = Access.Gender[i];
                dataGridResults.Rows[n].Cells[4].Value = Access.Age[i];
                dataGridResults.Rows[n].Cells[5].Value = Access.Grade[i];
            }
        }

        public void QuickSwapIndexes(int i, int j)
        {
            //this method simply swaps the two elements 
            //when elements in one list are swapped, the elements in the other lists must also be swapped since they are parallel and the data must stay consistent
            string temp = Access.LastName[i];
            Access.LastName[i] = Access.LastName[j];
            Access.LastName[j] = temp;

            string temp2 = Access.FirstName[i];
            Access.FirstName[i] = Access.FirstName[j];
            Access.FirstName[j] = temp2;
            
            string x = Access.ID[i];
            Access.ID[i] = Access.ID[j];
            Access.ID[j] = x;
           
            string Gender = Access.Gender[i];
            Access.Gender[i] = Access.Gender[j];
            Access.Gender[j] = Gender;
          
            string Age = Access.Age[i];
            Access.Age[i] = Access.Age[j];
            Access.Age[j] = Age;
            
            string Grade = Access.Grade[i];
            Access.Grade[i] = Access.Grade[j];
            Access.Grade[j] = Grade;
        }
        public void TimerResult(int Elapsed, Label label)
        {
            label.Text = "Time elapsed: " + Elapsed + " ms";
        }
        public void BubbleSwapIndexes(int j)
        {
            //this method simply swaps the two elements 
            //when elements in one list are swapped, the elements in the other lists must also be swapped since they are parallel and the data must stay consistent
            string temp = Access.FirstName[j];
            Access.FirstName[j] = Access.FirstName[j + 1];
            Access.FirstName[j + 1] = temp;

             string temp2 = Access.LastName[j];
             Access.LastName[j] = Access.LastName[j + 1];
             Access.LastName[j + 1] = temp2;

             string x = Access.ID[j]; 
             Access.ID[j] = Access.ID[j + 1];
             Access.ID[j + 1] = x;

             string Gender = Access.Gender[j];
             Access.Gender[j] = Access.Gender[j + 1];
             Access.Gender[j + 1] = Gender;

             string Age = Access.Age[j];
             Access.Age[j] = Access.Age[j + 1];
             Access.Age[j + 1] = Age;

             string Grade = Access.Grade[j];
             Access.Grade[j] = Access.Grade[j + 1];
             Access.Grade[j + 1] = Grade;
        }
        public void VotingOutput()
        {
            //method prints voting results and statisitics
            txtResults.Text = "Voters not found in Database:" + "\r\n";
            for (int i = 0; i < Access.DisposedID.Count; i++)
            {
                txtResults.Text += "First Name: " + Access.DisposedFirstName[i] + "\r\n";
                txtResults.Text += "Last Name: " + Access.DisposedLastName[i] + "\r\n";
                txtResults.Text += "ID (Found in vote file): " + Access.DisposedID[i] + "\r\n";
                txtResults.Text +=  "\r\n";
            }
            txtResults.Text += "\r\n";
            txtResults.Text += "Duplicates found: " + "\r\n";
            for (int i = 0; i < Access.DuplicateListID.Count; i++)
            {
                txtResults.Text += "First Name: " + Access.DuplicateListFirst[i] + "\r\n";
                txtResults.Text += "Last Name: " + Access.DuplicateListLast[i] + "\r\n";
                txtResults.Text += "ID (Found in vote file): " + Access.DuplicateListID[i] + "\r\n";
            }
            txtResults.Text += "\r\n";
            txtResults.Text += "Males: " + Access.MaleCount.ToString() + "\r\n";
            txtResults.Text += "Females: " + Access.FemaleCount + "\r\n";
            MessageBox.Show("Duplicates found: " + Access.DuplicateCount);
        }
        public void ClearData()
        {
            //method clears all variables and data
            Access.MaleCount = 0;
            Access.FemaleCount = 0;
            Access.FirstName.Clear();
            Access.LastName.Clear();
            Access.ID.Clear();
            Access.Grade.Clear();
            Access.Age.Clear();
            Access.Gender.Clear();
            Access.DisposedFirstName.Clear();
            Access.DisposedLastName.Clear();
            Access.DisposedID.Clear();
            Access.DuplicateListID.Clear();
            Access.DuplicateListFirst.Clear();
            Access.DuplicateListLast.Clear();
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            //if user has manipulated data around by sorting, searching etc. and they simply want to view the original from file, they can click this button and it will read file again and output results
            if (Access.Loaded == true)
            {
                ClearData(); //clear previously stored data upon loading new file
                ReadDataBase(Access.FilePath);
                PrintDataTable(true);
            }
            else
            {
                MessageBox.Show("Load a database first.");
            }
        }
        public void ClearDataTable()
        {
            dataGridResults.Rows.Clear();
        }
    }
}
