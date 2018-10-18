using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using MovieRecommenderSystem.Utils;

namespace MovieRecommenderSystem.Forms
{
    public partial class frmMovieTrailer : Form
    {
        string trailers;
        string url1;
        public frmMovieTrailer()
        {
            InitializeComponent();
        }

        public frmMovieTrailer(string trailer)
        {
            InitializeComponent();
            trailers = trailer;
        }

        private void frmMovieTrailer_Load(object sender, EventArgs e)
        {                
            StringBuilder add = new StringBuilder("https://www.youtube.com/results?search_query=");
            var trailerStr = trailers.Split(' ');
            for(int i = 0; i < trailerStr.Length; i++)
            {
                if(i == trailerStr.Length)
                {
                    add.Append(trailerStr[i]);
                }else
                {
                    add.Append(trailerStr[i]+"+");
                }
                
            }
            add.Append("+movie+trailer");
            url1 = add.ToString();
            webBrowser.Navigate(add.ToString()); 
                     
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url != null && e.Url.ToString().Contains("https://www.youtube.com/watch?v="))
            {
                StringBuilder to = new StringBuilder("https://www.youtube.com/v/");
                string url = webBrowser.Url.ToString();
                var youtubeId = url.Split('=');            
                string navigateTo = youtubeId.Last();
                to.Append(navigateTo);
                webBrowser.Navigate(to.ToString());
            }
        }
    }
}
