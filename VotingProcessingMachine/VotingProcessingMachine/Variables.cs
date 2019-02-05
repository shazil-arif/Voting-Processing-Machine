using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VotingProcessingMachine
{
    class Variables
    {
        //bunch of global variables
        public List<string> FirstName = new List<string>();
        public List<string> LastName = new List<string>();
        public List<string> ID = new List<string>();
        public List<string> Gender = new List<string>();
        public List<string> Age = new List<string>();
        public List<string> Grade = new List<string>();
        public Boolean Loaded = false;
        public Boolean LoadedVotes = false;
        public List<string> DisposedFirstName = new List<string>();
        public List<string> DisposedLastName = new List<string>();
        public List<string> DisposedID = new List<string>();
        public string[,] Votes = new string[1, 1];
        public string FilePath = null;
        public int MaleCount = 0;
        public int FemaleCount = 0;
        public List<string> DuplicateListID = new List<string>();
        public List<string> DuplicateListFirst = new List<string>();
        public List<string> DuplicateListLast = new List<string>();
        public int DuplicateCount = 0;
        public List<string> DuplicateIDLastEntry = new List<string>();




    }
}
