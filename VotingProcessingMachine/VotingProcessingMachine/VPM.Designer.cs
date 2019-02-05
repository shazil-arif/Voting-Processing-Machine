namespace VotingProcessingMachine
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadStudentDatabase = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnLoadVotes = new System.Windows.Forms.Button();
            this.lblSortTime = new System.Windows.Forms.Label();
            this.lblSearchTime = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdoSortByFirst = new System.Windows.Forms.RadioButton();
            this.rdoSortByLast = new System.Windows.Forms.RadioButton();
            this.rdoSortByID = new System.Windows.Forms.RadioButton();
            this.rdoSortByAge = new System.Windows.Forms.RadioButton();
            this.rdoSortByGrade = new System.Windows.Forms.RadioButton();
            this.rdoSortByGender = new System.Windows.Forms.RadioButton();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.grpSortOption = new System.Windows.Forms.GroupBox();
            this.rdoSearchByFirst = new System.Windows.Forms.RadioButton();
            this.rdoSearchByGender = new System.Windows.Forms.RadioButton();
            this.rdoSearchByLast = new System.Windows.Forms.RadioButton();
            this.rdoSearchByGrade = new System.Windows.Forms.RadioButton();
            this.rdoSearchByStudentID = new System.Windows.Forms.RadioButton();
            this.rdoSearchByAge = new System.Windows.Forms.RadioButton();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.grpSortType = new System.Windows.Forms.GroupBox();
            this.rdoQuick = new System.Windows.Forms.RadioButton();
            this.rdoBubble = new System.Windows.Forms.RadioButton();
            this.lblWinners = new System.Windows.Forms.TextBox();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpOption.SuspendLayout();
            this.grpSortOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.grpSortType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(574, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "VOTING PROCESSING MACHINE";
            // 
            // btnLoadStudentDatabase
            // 
            this.btnLoadStudentDatabase.Location = new System.Drawing.Point(26, 846);
            this.btnLoadStudentDatabase.Name = "btnLoadStudentDatabase";
            this.btnLoadStudentDatabase.Size = new System.Drawing.Size(223, 32);
            this.btnLoadStudentDatabase.TabIndex = 5;
            this.btnLoadStudentDatabase.Text = "Load Student Database";
            this.btnLoadStudentDatabase.UseVisualStyleBackColor = true;
            this.btnLoadStudentDatabase.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(1385, 390);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(139, 37);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnBubbleSort_Click);
            // 
            // btnLoadVotes
            // 
            this.btnLoadVotes.Location = new System.Drawing.Point(860, 934);
            this.btnLoadVotes.Name = "btnLoadVotes";
            this.btnLoadVotes.Size = new System.Drawing.Size(223, 34);
            this.btnLoadVotes.TabIndex = 8;
            this.btnLoadVotes.Text = "Load Student Votes";
            this.btnLoadVotes.UseVisualStyleBackColor = true;
            this.btnLoadVotes.Click += new System.EventHandler(this.btnLoadVotes_Click);
            // 
            // lblSortTime
            // 
            this.lblSortTime.AutoSize = true;
            this.lblSortTime.Location = new System.Drawing.Point(1382, 430);
            this.lblSortTime.Name = "lblSortTime";
            this.lblSortTime.Size = new System.Drawing.Size(111, 20);
            this.lblSortTime.TabIndex = 9;
            this.lblSortTime.Text = "Time elapsed: ";
            // 
            // lblSearchTime
            // 
            this.lblSearchTime.AutoSize = true;
            this.lblSearchTime.Location = new System.Drawing.Point(1131, 374);
            this.lblSearchTime.Name = "lblSearchTime";
            this.lblSearchTime.Size = new System.Drawing.Size(111, 20);
            this.lblSearchTime.TabIndex = 10;
            this.lblSearchTime.Text = "Time elapsed: ";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(860, 846);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(223, 38);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(860, 890);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(223, 38);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1140, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Vote Results";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(1135, 295);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(166, 26);
            this.txtSearchValue.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1135, 327);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(166, 38);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdoSortByFirst
            // 
            this.rdoSortByFirst.AutoSize = true;
            this.rdoSortByFirst.Location = new System.Drawing.Point(6, 25);
            this.rdoSortByFirst.Name = "rdoSortByFirst";
            this.rdoSortByFirst.Size = new System.Drawing.Size(133, 24);
            this.rdoSortByFirst.TabIndex = 18;
            this.rdoSortByFirst.TabStop = true;
            this.rdoSortByFirst.Text = "By First Name";
            this.rdoSortByFirst.UseVisualStyleBackColor = true;
            // 
            // rdoSortByLast
            // 
            this.rdoSortByLast.AutoSize = true;
            this.rdoSortByLast.Location = new System.Drawing.Point(6, 55);
            this.rdoSortByLast.Name = "rdoSortByLast";
            this.rdoSortByLast.Size = new System.Drawing.Size(133, 24);
            this.rdoSortByLast.TabIndex = 19;
            this.rdoSortByLast.TabStop = true;
            this.rdoSortByLast.Text = "By Last Name";
            this.rdoSortByLast.UseVisualStyleBackColor = true;
            // 
            // rdoSortByID
            // 
            this.rdoSortByID.AutoSize = true;
            this.rdoSortByID.Location = new System.Drawing.Point(5, 85);
            this.rdoSortByID.Name = "rdoSortByID";
            this.rdoSortByID.Size = new System.Drawing.Size(134, 24);
            this.rdoSortByID.TabIndex = 20;
            this.rdoSortByID.TabStop = true;
            this.rdoSortByID.Text = "By Student ID";
            this.rdoSortByID.UseVisualStyleBackColor = true;
            // 
            // rdoSortByAge
            // 
            this.rdoSortByAge.AutoSize = true;
            this.rdoSortByAge.Location = new System.Drawing.Point(5, 118);
            this.rdoSortByAge.Name = "rdoSortByAge";
            this.rdoSortByAge.Size = new System.Drawing.Size(85, 24);
            this.rdoSortByAge.TabIndex = 21;
            this.rdoSortByAge.TabStop = true;
            this.rdoSortByAge.Text = "By Age";
            this.rdoSortByAge.UseVisualStyleBackColor = true;
            // 
            // rdoSortByGrade
            // 
            this.rdoSortByGrade.AutoSize = true;
            this.rdoSortByGrade.Location = new System.Drawing.Point(5, 148);
            this.rdoSortByGrade.Name = "rdoSortByGrade";
            this.rdoSortByGrade.Size = new System.Drawing.Size(101, 24);
            this.rdoSortByGrade.TabIndex = 22;
            this.rdoSortByGrade.TabStop = true;
            this.rdoSortByGrade.Text = "By Grade";
            this.rdoSortByGrade.UseVisualStyleBackColor = true;
            // 
            // rdoSortByGender
            // 
            this.rdoSortByGender.AutoSize = true;
            this.rdoSortByGender.Location = new System.Drawing.Point(3, 178);
            this.rdoSortByGender.Name = "rdoSortByGender";
            this.rdoSortByGender.Size = new System.Drawing.Size(110, 24);
            this.rdoSortByGender.TabIndex = 23;
            this.rdoSortByGender.TabStop = true;
            this.rdoSortByGender.Text = "By Gender";
            this.rdoSortByGender.UseVisualStyleBackColor = true;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.rdoSortByFirst);
            this.grpOption.Controls.Add(this.rdoSortByGender);
            this.grpOption.Controls.Add(this.rdoSortByLast);
            this.grpOption.Controls.Add(this.rdoSortByGrade);
            this.grpOption.Controls.Add(this.rdoSortByID);
            this.grpOption.Controls.Add(this.rdoSortByAge);
            this.grpOption.Location = new System.Drawing.Point(1379, 72);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(151, 217);
            this.grpOption.TabIndex = 24;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Sorting Options";
            // 
            // grpSortOption
            // 
            this.grpSortOption.Controls.Add(this.rdoSearchByFirst);
            this.grpSortOption.Controls.Add(this.rdoSearchByGender);
            this.grpSortOption.Controls.Add(this.rdoSearchByLast);
            this.grpSortOption.Controls.Add(this.rdoSearchByGrade);
            this.grpSortOption.Controls.Add(this.rdoSearchByStudentID);
            this.grpSortOption.Controls.Add(this.rdoSearchByAge);
            this.grpSortOption.Location = new System.Drawing.Point(1135, 72);
            this.grpSortOption.Name = "grpSortOption";
            this.grpSortOption.Size = new System.Drawing.Size(166, 217);
            this.grpSortOption.TabIndex = 25;
            this.grpSortOption.TabStop = false;
            this.grpSortOption.Text = "Searching Options";
            // 
            // rdoSearchByFirst
            // 
            this.rdoSearchByFirst.AutoSize = true;
            this.rdoSearchByFirst.Location = new System.Drawing.Point(6, 25);
            this.rdoSearchByFirst.Name = "rdoSearchByFirst";
            this.rdoSearchByFirst.Size = new System.Drawing.Size(133, 24);
            this.rdoSearchByFirst.TabIndex = 18;
            this.rdoSearchByFirst.TabStop = true;
            this.rdoSearchByFirst.Text = "By First Name";
            this.rdoSearchByFirst.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByGender
            // 
            this.rdoSearchByGender.AutoSize = true;
            this.rdoSearchByGender.Location = new System.Drawing.Point(6, 178);
            this.rdoSearchByGender.Name = "rdoSearchByGender";
            this.rdoSearchByGender.Size = new System.Drawing.Size(110, 24);
            this.rdoSearchByGender.TabIndex = 23;
            this.rdoSearchByGender.TabStop = true;
            this.rdoSearchByGender.Text = "By Gender";
            this.rdoSearchByGender.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByLast
            // 
            this.rdoSearchByLast.AutoSize = true;
            this.rdoSearchByLast.Location = new System.Drawing.Point(6, 55);
            this.rdoSearchByLast.Name = "rdoSearchByLast";
            this.rdoSearchByLast.Size = new System.Drawing.Size(133, 24);
            this.rdoSearchByLast.TabIndex = 19;
            this.rdoSearchByLast.TabStop = true;
            this.rdoSearchByLast.Text = "By Last Name";
            this.rdoSearchByLast.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByGrade
            // 
            this.rdoSearchByGrade.AutoSize = true;
            this.rdoSearchByGrade.Location = new System.Drawing.Point(6, 144);
            this.rdoSearchByGrade.Name = "rdoSearchByGrade";
            this.rdoSearchByGrade.Size = new System.Drawing.Size(101, 24);
            this.rdoSearchByGrade.TabIndex = 22;
            this.rdoSearchByGrade.TabStop = true;
            this.rdoSearchByGrade.Text = "By Grade";
            this.rdoSearchByGrade.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByStudentID
            // 
            this.rdoSearchByStudentID.AutoSize = true;
            this.rdoSearchByStudentID.Location = new System.Drawing.Point(6, 85);
            this.rdoSearchByStudentID.Name = "rdoSearchByStudentID";
            this.rdoSearchByStudentID.Size = new System.Drawing.Size(134, 24);
            this.rdoSearchByStudentID.TabIndex = 20;
            this.rdoSearchByStudentID.TabStop = true;
            this.rdoSearchByStudentID.Text = "By Student ID";
            this.rdoSearchByStudentID.UseVisualStyleBackColor = true;
            // 
            // rdoSearchByAge
            // 
            this.rdoSearchByAge.AutoSize = true;
            this.rdoSearchByAge.Location = new System.Drawing.Point(6, 114);
            this.rdoSearchByAge.Name = "rdoSearchByAge";
            this.rdoSearchByAge.Size = new System.Drawing.Size(85, 24);
            this.rdoSearchByAge.TabIndex = 21;
            this.rdoSearchByAge.TabStop = true;
            this.rdoSearchByAge.Text = "By Age";
            this.rdoSearchByAge.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(1135, 802);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(447, 192);
            this.txtResults.TabIndex = 26;
            // 
            // dataGridResults
            // 
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Last,
            this.First,
            this.StudentID,
            this.Gender,
            this.Age,
            this.Grade});
            this.dataGridResults.Location = new System.Drawing.Point(26, 72);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.RowTemplate.Height = 28;
            this.dataGridResults.Size = new System.Drawing.Size(1057, 768);
            this.dataGridResults.TabIndex = 28;
            // 
            // btnOriginal
            // 
            this.btnOriginal.Location = new System.Drawing.Point(26, 884);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(223, 34);
            this.btnOriginal.TabIndex = 29;
            this.btnOriginal.Text = "Show Original Data";
            this.btnOriginal.UseVisualStyleBackColor = true;
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // grpSortType
            // 
            this.grpSortType.Controls.Add(this.rdoBubble);
            this.grpSortType.Controls.Add(this.rdoQuick);
            this.grpSortType.Location = new System.Drawing.Point(1379, 295);
            this.grpSortType.Name = "grpSortType";
            this.grpSortType.Size = new System.Drawing.Size(151, 89);
            this.grpSortType.TabIndex = 31;
            this.grpSortType.TabStop = false;
            this.grpSortType.Text = "Select Sort Type";
            // 
            // rdoQuick
            // 
            this.rdoQuick.AutoSize = true;
            this.rdoQuick.Location = new System.Drawing.Point(6, 25);
            this.rdoQuick.Name = "rdoQuick";
            this.rdoQuick.Size = new System.Drawing.Size(108, 24);
            this.rdoQuick.TabIndex = 0;
            this.rdoQuick.TabStop = true;
            this.rdoQuick.Text = "Quick Sort";
            this.rdoQuick.UseVisualStyleBackColor = true;
            // 
            // rdoBubble
            // 
            this.rdoBubble.AutoSize = true;
            this.rdoBubble.Location = new System.Drawing.Point(6, 55);
            this.rdoBubble.Name = "rdoBubble";
            this.rdoBubble.Size = new System.Drawing.Size(118, 24);
            this.rdoBubble.TabIndex = 32;
            this.rdoBubble.TabStop = true;
            this.rdoBubble.Text = "Bubble Sort";
            this.rdoBubble.UseVisualStyleBackColor = true;
            // 
            // lblWinners
            // 
            this.lblWinners.Location = new System.Drawing.Point(1135, 500);
            this.lblWinners.Multiline = true;
            this.lblWinners.Name = "lblWinners";
            this.lblWinners.ReadOnly = true;
            this.lblWinners.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lblWinners.Size = new System.Drawing.Size(447, 262);
            this.lblWinners.TabIndex = 33;
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalid.Location = new System.Drawing.Point(1131, 765);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(144, 25);
            this.lblInvalid.TabIndex = 34;
            this.lblInvalid.Text = "Invalid Voters";
            // 
            // Last
            // 
            this.Last.HeaderText = "Last Name";
            this.Last.Name = "Last";
            this.Last.ReadOnly = true;
            this.Last.Width = 117;
            // 
            // First
            // 
            this.First.HeaderText = "First Name";
            this.First.Name = "First";
            this.First.ReadOnly = true;
            this.First.Width = 117;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Width = 117;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 117;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 117;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.Width = 90;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 1050);
            this.Controls.Add(this.lblInvalid);
            this.Controls.Add(this.grpSortType);
            this.Controls.Add(this.lblWinners);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.grpSortOption);
            this.Controls.Add(this.grpOption);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblSearchTime);
            this.Controls.Add(this.lblSortTime);
            this.Controls.Add(this.btnLoadVotes);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnLoadStudentDatabase);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "VPM";
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpSortOption.ResumeLayout(false);
            this.grpSortOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.grpSortType.ResumeLayout(false);
            this.grpSortType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadStudentDatabase;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnLoadVotes;
        private System.Windows.Forms.Label lblSortTime;
        private System.Windows.Forms.Label lblSearchTime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoSortByFirst;
        private System.Windows.Forms.RadioButton rdoSortByLast;
        private System.Windows.Forms.RadioButton rdoSortByID;
        private System.Windows.Forms.RadioButton rdoSortByAge;
        private System.Windows.Forms.RadioButton rdoSortByGrade;
        private System.Windows.Forms.RadioButton rdoSortByGender;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.GroupBox grpSortOption;
        private System.Windows.Forms.RadioButton rdoSearchByFirst;
        private System.Windows.Forms.RadioButton rdoSearchByGender;
        private System.Windows.Forms.RadioButton rdoSearchByLast;
        private System.Windows.Forms.RadioButton rdoSearchByGrade;
        private System.Windows.Forms.RadioButton rdoSearchByStudentID;
        private System.Windows.Forms.RadioButton rdoSearchByAge;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.GroupBox grpSortType;
        private System.Windows.Forms.RadioButton rdoBubble;
        private System.Windows.Forms.RadioButton rdoQuick;
        private System.Windows.Forms.TextBox lblWinners;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn First;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
    }
}

