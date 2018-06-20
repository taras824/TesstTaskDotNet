using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class MainPage : System.Web.UI.Page
    {
        private DB db;

        protected HtmlForm form1;

        protected FileUpload FileUpload1;

        protected TextBox TextBox1;

        protected Button Button1;

        protected EntityDataSource EntityDataSource1;

        protected HtmlGenericControl sentenceBD;
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader(this.FileUpload1.FileContent, Encoding.Default))
            {
                try
                {
                    if (this.FileUpload1.HasFiles)
                    {
                        //Search words in sentances.

                        string end = streamReader.ReadToEnd();
                        string[] strArrays = end.Split(new char[] { '.' });
                        for (int num = 0; num < (int)strArrays.Length; num++)
                        {
                            string str = strArrays[num];
                            foreach (Match match in Regex.Matches(str, this.TextBox1.Text))
                            {
                                Data datum = new Data();
                                Label label = new Label()
                                {
                                    Text = string.Format(string.Concat(Regex.Replace(str, this.TextBox1.Text, string.Format("<span style='color:#c55757'>{0}</span>", this.TextBox1.Text)), "."), Array.Empty<object>())
                                };
                                this.form1.Controls.Add(new LiteralControl("<hr>"));
                                this.form1.Controls.Add(label);

                                //Add DataBase value

                                datum.SearchWord = new string((
                                    from i in Enumerable.Range(1, this.TextBox1.Text.Length)
                                    select this.TextBox1.Text[this.TextBox1.Text.Length - i]).ToArray<char>());
                                datum.Sentence = str;

                                this.db.Datas.Add(datum);
                                this.db.SaveChanges();;
                                if (Regex.Matches(str, this.TextBox1.Text).Count > 1)
                                {
                                    break;
                                }
                                
                            }
                        }
                    }
                }
                catch
                {
                    base.Response.Write("Only .txt allowed");
                }
            }
        }

        public void LoadDB()
        {
            this.db = new DB();
            //delete value DataBase

                //this.db.Datas.ToList<Data>().ForEach((Data x) => this.db.Datas.Remove(x));
                //this.db.SaveChanges();

            //insert value DB on page 

            this.db.Datas.ToList().ForEach((Data x) => this.sentenceBD.Controls.Add(new Label()
            {
                Text = Regex.Replace(string.Concat(new string((
                    from i in Enumerable.Range(1, x.Sentence.Length)
                    select x.Sentence[x.Sentence.Length - i]).ToArray<char>()), "<br><hr>"), x.SearchWord, string.Format("<span style='color:#c55757'>{0}</span>", x.SearchWord))
            }));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDB();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //ReloadDB
        }
    }
}