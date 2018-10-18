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
    public partial class frmDisplayMovies : Form
    {
        private Form mainWindow { get; set; }

        IQueryable query;
        public frmDisplayMovies()
        {
            InitializeComponent();
        }

        public frmDisplayMovies(Form m, IQueryable qury)
        {
            InitializeComponent();
            mainWindow = m;
            query = qury;
        }

        private void frmDisplayMovies_Load(object sender, EventArgs e)
        {

            MoviesGridView.DataSource = query;

            MoviesGridView.Columns[0].Width = 50;
            MoviesGridView.Columns[2].Width = 50;

            foreach (DataGridViewRow row in MoviesGridView.Rows)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                linkCell.Value = row.Cells[row.Cells.Count-1] as DataGridViewLinkCell;
                row.Cells[row.Cells.Count-1] = linkCell;
            }


        }

        private void frmDisplayMovies_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }

        private void MoviesGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string movieName = this.MoviesGridView.CurrentRow.Cells[1].Value.ToString();
            Forms.frmMovieTrailer movieTrailer = new frmMovieTrailer(movieName);
            movieTrailer.Show();
        }
    }
}
