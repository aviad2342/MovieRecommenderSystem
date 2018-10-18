namespace MovieRecommenderSystem.Forms
{
    partial class frmDisplayMovies
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayMovies));
            this.MoviesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MoviesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MoviesGridView
            // 
            this.MoviesGridView.AllowUserToAddRows = false;
            this.MoviesGridView.AllowUserToDeleteRows = false;
            this.MoviesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MoviesGridView.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Aharoni", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MoviesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MoviesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MoviesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoviesGridView.Location = new System.Drawing.Point(0, 0);
            this.MoviesGridView.MultiSelect = false;
            this.MoviesGridView.Name = "MoviesGridView";
            this.MoviesGridView.ReadOnly = true;
            this.MoviesGridView.RowHeadersVisible = false;
            this.MoviesGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.MoviesGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.MoviesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MoviesGridView.Size = new System.Drawing.Size(897, 389);
            this.MoviesGridView.TabIndex = 0;
            this.MoviesGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MoviesGridView_CellMouseClick);
            // 
            // frmDisplayMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 389);
            this.Controls.Add(this.MoviesGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisplayMovies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recommended Movies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDisplayMovies_FormClosing);
            this.Load += new System.EventHandler(this.frmDisplayMovies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoviesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MoviesGridView;
    }
}