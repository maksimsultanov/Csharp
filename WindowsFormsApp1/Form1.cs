using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Uri url = new Uri("http://demo.macroscop.com:8080/configex?login=root");
            this.GetList(url);
        }
        protected void GetList(Uri url)
        {
            ArrayList arrayList = new ArrayList();
            HttpWebRequest request = WebRequest.CreateHttp(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string info_source = "";
                        string channel = "";
                        string name = "";

                        while ((info_source = reader.ReadLine()) != null)
                        {
                            if (info_source.Contains("<ChannelInfo"))
                            {
                                string[] sourceArray = info_source.Split('=');
                                channel = sourceArray[1].Substring(sourceArray[1].IndexOf("\"") + 1, sourceArray[1].LastIndexOf("\"") - 1);
                                name = sourceArray[2].Substring(sourceArray[2].IndexOf("\"") + 1, sourceArray[2].LastIndexOf("\"") - 1);
                                arrayList.Add(new Camera(name, channel));
                            }
                        }
                    }
                }
                int iter = 0;
                Camera[] cameras = new Camera[arrayList.Count];
                foreach (Camera cam in arrayList)
                {
                    cameras[iter] = cam;
                    comboBox1.Items.Add(cam.GetCamName());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creaate url
             Uri url = new Uri("http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25");
             //create request
             HttpWebRequest request = WebRequest.CreateHttp(url);
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
                        pictureBox1.Image = null;
                        pictureBox1.Image = bm;
                        stream.Flush();
                    }
                }

             }
             //close the response
             response.Close();
        }
    }
}
