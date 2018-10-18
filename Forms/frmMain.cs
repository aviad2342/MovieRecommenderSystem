using MovieRecommenderSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommenderSystem.Forms
{
    public partial class frmMain : Form
    {
        private string folderPath = "";

        ImdbDataClassDataContext context;

        IQueryable query;

        public frmMain()
        {
            InitializeComponent();
            context = new ImdbDataClassDataContext();
        }

        private void btnChooseFoldor_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
                Utils.Services.initiateDataFromFile(folderPath);
                autoComplete();
            }
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you?", "Clear Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string command = "DELETE FROM[MovieGenre]; DELETE FROM[UserMovieRank]; DELETE FROM[Movie]; DELETE FROM[Genre]; DELETE FROM[TwitterUser];";
                context.ExecuteCommand(command);

                string reseed = "DBCC CHECKIDENT ([TwitterUser], RESEED, 0); DBCC CHECKIDENT([Genre], RESEED, 0); DBCC CHECKIDENT([Movie], RESEED, 0);";
                context.ExecuteCommand(reseed);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            

        }

        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            
            String selected_user = this.tbUserName.Text;
            var usersNames = from user in context.TwitterUsers
                            select user.userName;
            if (usersNames.ToArray().Contains(selected_user))
            {
                var checkedButton = recommenderGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (checkedButton == null)
                {
                    MessageBox.Show("Please select a method for searching", "No Selected Method", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {


                    switch (checkedButton.Tag.ToString())
                    {
                        case "1":
                            query = Utils.Services.mostWatchedMovies(selected_user);
                            break;
                        case "2":
                            query = Utils.Services.mostPopularMovies(selected_user);
                            break;
                        case "3":
                            query = Utils.Services.mostPopularUser(selected_user);
                            break;
                        case "4":
                            query = Utils.Services.usersWithSimilarTastes(selected_user);
                            break;
                        case "5":
                            query = Utils.Services.userGenrePreferences(selected_user);
                            break;

                    }
                    this.tbUserName.Text = "Enter User Name";
                    Forms.frmDisplayMovies displayMovies = new frmDisplayMovies(this, query);
                    displayMovies.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Sorry No Such User Exists In The System, Please Try Again", "User Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.tbUserName.Text = "Enter User Name";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tbUserName.Text = "Enter User Name";
            autoComplete();
        }

        private void tbUserName_Enter(object sender, EventArgs e)
        {
            if(tbUserName.Text == "Enter User Name")
            {
                tbUserName.Text = "";
            }
        }

        private void tbUserName_Leave(object sender, EventArgs e)
        {
            if (tbUserName.Text == "")
            {
                tbUserName.Text = "Enter User Name";
            }
        }

        private void autoComplete()
        {
            var source = new AutoCompleteStringCollection();
            var userNames = from user in context.TwitterUsers
                            select user.userName;
            source.AddRange(userNames.ToArray());

            tbUserName.AutoCompleteCustomSource = source;
            tbUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
