using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace MyMovieDatabaseConsole
{
    public partial class MyMovieDatabaseForm : Form
    {
        public MyMovieDatabaseForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String movieTitle = txtMovieTitle.Text.ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.omdbapi.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                string response = client.GetStringAsync("?t=" + movieTitle + "&r=xml").Result;
                if (!(response.Contains("error")))
                {
                    errorLabel.Text = "";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(response);
                    XmlNode MovieNode = doc.SelectNodes("//movie").Item(0);
                    txtMovieTitle.Text = MovieNode.Attributes["title"].Value;
                    txtYear.Text = MovieNode.Attributes["year"].Value;
                    txtRated.Text = MovieNode.Attributes["rated"].Value;
                    txtReleased.Text = MovieNode.Attributes["released"].Value;
                    txtRuntime.Text = MovieNode.Attributes["runtime"].Value;
                    txtGenre.Text = MovieNode.Attributes["genre"].Value;
                    txtDirector.Text = MovieNode.Attributes["director"].Value;
                    txtScriptwriter.Text = MovieNode.Attributes["writer"].Value;
                    txtActor.Text = MovieNode.Attributes["actors"].Value;
                    richTextBox1.Text = MovieNode.Attributes["plot"].Value;
                    txtLanguage.Text = MovieNode.Attributes["language"].Value;
                    txtCountry.Text = MovieNode.Attributes["country"].Value;
                    txtAwards.Text = MovieNode.Attributes["awards"].Value;
                    txtMetascore.Text = MovieNode.Attributes["metascore"].Value;
                    txtIMDBRating.Text = MovieNode.Attributes["imdbRating"].Value;
                    txtIMDBVotes.Text = MovieNode.Attributes["imdbVotes"].Value;
                    txtIMDBID.Text = MovieNode.Attributes["imdbID"].Value;
                    txtType.Text = MovieNode.Attributes["type"].Value;
                    pictureBox1.ImageLocation = MovieNode.Attributes["poster"].Value;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    errorLabel.Text = "Movie Not Found !!!";
                    txtMovieTitle.Text = "";
                    txtYear.Text = "";
                    txtRated.Text = "";
                    txtReleased.Text = "";
                    txtRuntime.Text = "";
                    txtGenre.Text = "";
                    txtDirector.Text = "";
                    txtScriptwriter.Text = "";
                    txtActor.Text = "";
                    richTextBox1.Text = "";
                    txtLanguage.Text = "";
                    txtCountry.Text = "";
                    txtAwards.Text = "";
                    txtMetascore.Text = "";
                    txtIMDBRating.Text = "";
                    txtIMDBVotes.Text = "";
                    txtIMDBID.Text = "";
                    txtType.Text = "";
                    pictureBox1.ImageLocation = "";
                }
            }
        }

    }
}
