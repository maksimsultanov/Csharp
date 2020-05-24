using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using WindowsFormsApp1;
using static System.Windows.Forms.DataFormats;

namespace WindowsFormsApp1
{
    public class Camera
    {
        protected string name;
        protected string text_id;
        protected string url;
        protected void SetCam()
        {
            string defUrl = "http://demo.macroscop.com:8080/mobile?login=root&channelid={0}&resolutionX=640&resolutionY=480&fps=25";
            this.url = string.Format(defUrl, this.text_id);
            /*
             * create url here           
            */
        }
        public string GetCam()
        {
            return this.url;
        }
        public string GetCamName()
        {
            return this.name;
        }
        public Camera(string name, string text_id)
        {
            this.name = name;
            this.text_id = text_id;
            this.SetCam();
        }
        /*public async Task GetStream(ref Form1 form)
        {
            //Creaate url
            //Uri url = new Uri("http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25");
            //create request
            HttpWebRequest request = WebRequest.CreateHttp(this.url);
            //get response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // create strem
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader binaryReader = new StreamReader(stream);
                string s = "";
                ArrayList arrayList = new ArrayList();
                while ((s = binaryReader.ReadLine()) != null)
                {
                    if (s.Contains("Content-Length"))
                    {
                        var sTmp = s.Split(' ');
                        binaryReader.ReadLine();
                        Console.WriteLine(sTmp[1]);
                        while (s.Contains("--myboundary") == false)
                        {
                            s = binaryReader.ReadLine();
                            string s1 = "";

                            if (s.EndsWith("--myboundary"))
                            {
                                s1 = s.Replace("--myboundary", "");
                                arrayList.AddRange(System.Text.Encoding.UTF8.GetBytes(s1));
                            }
                            else
                            {
                                arrayList.AddRange(System.Text.Encoding.UTF8.GetBytes(s));
                            }
                        }
                        byte[] buffer = new byte[arrayList.Count];
                        arrayList.CopyTo(buffer);
                        arrayList.Clear();
                        MemoryStream mStream = new MemoryStream();
                        mStream.Write(buffer, 0, Convert.ToInt32(buffer.Length));
                        Bitmap bm = new Bitmap(mStream, false);
                        mStream.Dispose();
                        form.pictureBox1.Image = null;
                        form.pictureBox1.Image = bm;
                        stream.Flush();
                        
                    }
                }

            }
            //close the response
            response.Close();
        }*/
    }
}
