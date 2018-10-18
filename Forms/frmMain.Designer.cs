namespace MovieRecommenderSystem.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lbInitialize = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.recommenderGroup = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rbUserGenrePreferences = new System.Windows.Forms.RadioButton();
            this.rbUsersWithSimilarTastes = new System.Windows.Forms.RadioButton();
            this.rbMostPopularUser = new System.Windows.Forms.RadioButton();
            this.rbMostPopularMovies = new System.Windows.Forms.RadioButton();
            this.rbMostWatchedMovies = new System.Windows.Forms.RadioButton();
            this.btnExecuteSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClearDatabase = new System.Windows.Forms.Button();
            this.btnChooseFoldor = new System.Windows.Forms.Button();
            this.recommenderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\Aviad\\לימודים\\שנה רביעית סמסטר א\\C#\\תרגילי בית\\תרגיל מסכם\\dbFiles\\test";
            // 
            // lbInitialize
            // 
            this.lbInitialize.AutoSize = true;
            this.lbInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInitialize.Location = new System.Drawing.Point(520, 13);
            this.lbInitialize.Name = "lbInitialize";
            this.lbInitialize.Size = new System.Drawing.Size(164, 24);
            this.lbInitialize.TabIndex = 2;
            this.lbInitialize.Text = "Initialize DataBase:";
            // 
            // tbUserName
            // 
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserName.Font = new System.Drawing.Font("Aharoni", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserName.Location = new System.Drawing.Point(47, 35);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(146, 22);
            this.tbUserName.TabIndex = 4;
            this.tbUserName.Enter += new System.EventHandler(this.tbUserName_Enter);
            this.tbUserName.Leave += new System.EventHandler(this.tbUserName_Leave);
            // 
            // recommenderGroup
            // 
            this.recommenderGroup.BackColor = System.Drawing.Color.Silver;
            this.recommenderGroup.Controls.Add(this.pictureBox2);
            this.recommenderGroup.Controls.Add(this.rbUserGenrePreferences);
            this.recommenderGroup.Controls.Add(this.rbUsersWithSimilarTastes);
            this.recommenderGroup.Controls.Add(this.rbMostPopularUser);
            this.recommenderGroup.Controls.Add(this.rbMostPopularMovies);
            this.recommenderGroup.Controls.Add(this.rbMostWatchedMovies);
            this.recommenderGroup.Controls.Add(this.btnExecuteSearch);
            this.recommenderGroup.Controls.Add(this.tbUserName);
            this.recommenderGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recommenderGroup.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.recommenderGroup.Location = new System.Drawing.Point(30, 191);
            this.recommenderGroup.Name = "recommenderGroup";
            this.recommenderGroup.Size = new System.Drawing.Size(724, 230);
            this.recommenderGroup.TabIndex = 5;
            this.recommenderGroup.TabStop = false;
            this.recommenderGroup.Text = "Available Recommendations";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MovieRecommenderSystem.Properties.Resources.Gender_Neutral_User_000000_100;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(13, 31);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 26);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // rbUserGenrePreferences
            // 
            this.rbUserGenrePreferences.AutoSize = true;
            this.rbUserGenrePreferences.Location = new System.Drawing.Point(33, 182);
            this.rbUserGenrePreferences.Name = "rbUserGenrePreferences";
            this.rbUserGenrePreferences.Size = new System.Drawing.Size(204, 20);
            this.rbUserGenrePreferences.TabIndex = 9;
            this.rbUserGenrePreferences.TabStop = true;
            this.rbUserGenrePreferences.Tag = "5";
            this.rbUserGenrePreferences.Text = "User Genre Preferences";
            this.rbUserGenrePreferences.UseVisualStyleBackColor = true;
            // 
            // rbUsersWithSimilarTastes
            // 
            this.rbUsersWithSimilarTastes.AutoSize = true;
            this.rbUsersWithSimilarTastes.Location = new System.Drawing.Point(33, 158);
            this.rbUsersWithSimilarTastes.Name = "rbUsersWithSimilarTastes";
            this.rbUsersWithSimilarTastes.Size = new System.Drawing.Size(212, 20);
            this.rbUsersWithSimilarTastes.TabIndex = 8;
            this.rbUsersWithSimilarTastes.TabStop = true;
            this.rbUsersWithSimilarTastes.Tag = "4";
            this.rbUsersWithSimilarTastes.Text = "Users With Similar Tastes";
            this.rbUsersWithSimilarTastes.UseVisualStyleBackColor = true;
            // 
            // rbMostPopularUser
            // 
            this.rbMostPopularUser.AutoSize = true;
            this.rbMostPopularUser.Location = new System.Drawing.Point(33, 134);
            this.rbMostPopularUser.Name = "rbMostPopularUser";
            this.rbMostPopularUser.Size = new System.Drawing.Size(166, 20);
            this.rbMostPopularUser.TabIndex = 7;
            this.rbMostPopularUser.TabStop = true;
            this.rbMostPopularUser.Tag = "3";
            this.rbMostPopularUser.Text = "Most Popular User";
            this.rbMostPopularUser.UseVisualStyleBackColor = true;
            // 
            // rbMostPopularMovies
            // 
            this.rbMostPopularMovies.AutoSize = true;
            this.rbMostPopularMovies.Location = new System.Drawing.Point(33, 110);
            this.rbMostPopularMovies.Name = "rbMostPopularMovies";
            this.rbMostPopularMovies.Size = new System.Drawing.Size(185, 20);
            this.rbMostPopularMovies.TabIndex = 6;
            this.rbMostPopularMovies.TabStop = true;
            this.rbMostPopularMovies.Tag = "2";
            this.rbMostPopularMovies.Text = "Most Popular Movies";
            this.rbMostPopularMovies.UseVisualStyleBackColor = true;
            // 
            // rbMostWatchedMovies
            // 
            this.rbMostWatchedMovies.AutoSize = true;
            this.rbMostWatchedMovies.Location = new System.Drawing.Point(33, 86);
            this.rbMostWatchedMovies.Name = "rbMostWatchedMovies";
            this.rbMostWatchedMovies.Size = new System.Drawing.Size(191, 20);
            this.rbMostWatchedMovies.TabIndex = 5;
            this.rbMostWatchedMovies.TabStop = true;
            this.rbMostWatchedMovies.Tag = "1";
            this.rbMostWatchedMovies.Text = "Most Watched Movies";
            this.rbMostWatchedMovies.UseVisualStyleBackColor = true;
            // 
            // btnExecuteSearch
            // 
            this.btnExecuteSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExecuteSearch.BackgroundImage")));
            this.btnExecuteSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExecuteSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExecuteSearch.Location = new System.Drawing.Point(584, 173);
            this.btnExecuteSearch.Name = "btnExecuteSearch";
            this.btnExecuteSearch.Size = new System.Drawing.Size(134, 51);
            this.btnExecuteSearch.TabIndex = 3;
            this.btnExecuteSearch.UseVisualStyleBackColor = true;
            this.btnExecuteSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 179);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnClearDatabase
            // 
            this.btnClearDatabase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearDatabase.BackgroundImage")));
            this.btnClearDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearDatabase.Font = new System.Drawing.Font("Aharoni", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClearDatabase.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClearDatabase.Location = new System.Drawing.Point(538, 104);
            this.btnClearDatabase.Name = "btnClearDatabase";
            this.btnClearDatabase.Size = new System.Drawing.Size(220, 54);
            this.btnClearDatabase.TabIndex = 1;
            this.btnClearDatabase.UseVisualStyleBackColor = true;
            this.btnClearDatabase.Click += new System.EventHandler(this.btnClearDatabase_Click);
            // 
            // btnChooseFoldor
            // 
            this.btnChooseFoldor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChooseFoldor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChooseFoldor.BackgroundImage")));
            this.btnChooseFoldor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChooseFoldor.Font = new System.Drawing.Font("Aharoni", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnChooseFoldor.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChooseFoldor.Location = new System.Drawing.Point(538, 40);
            this.btnChooseFoldor.Name = "btnChooseFoldor";
            this.btnChooseFoldor.Size = new System.Drawing.Size(220, 50);
            this.btnChooseFoldor.TabIndex = 0;
            this.btnChooseFoldor.UseVisualStyleBackColor = false;
            this.btnChooseFoldor.Click += new System.EventHandler(this.btnChooseFoldor_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(798, 481);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.recommenderGroup);
            this.Controls.Add(this.lbInitialize);
            this.Controls.Add(this.btnClearDatabase);
            this.Controls.Add(this.btnChooseFoldor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Recommender System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.recommenderGroup.ResumeLayout(false);
            this.recommenderGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFoldor;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnClearDatabase;
        private System.Windows.Forms.Label lbInitialize;
        private System.Windows.Forms.Button btnExecuteSearch;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.GroupBox recommenderGroup;
        private System.Windows.Forms.RadioButton rbUserGenrePreferences;
        private System.Windows.Forms.RadioButton rbUsersWithSimilarTastes;
        private System.Windows.Forms.RadioButton rbMostPopularUser;
        private System.Windows.Forms.RadioButton rbMostPopularMovies;
        private System.Windows.Forms.RadioButton rbMostWatchedMovies;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}