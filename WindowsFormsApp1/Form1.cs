using System;
using System.Collections;
using System.Collections.Generic;
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
                 BinaryReader binaryReader = new BinaryReader(stream);
                byte buf1 = new byte();
                byte buf2 = new byte();
                bool startF = false;
                bool stopF = false;
                List<byte> arrayList = new List<byte>();
                buf1 = binaryReader.ReadByte();
                 while (buf1 != null)
                 {

                    if (startF)
                    {
                        if (buf1 == 0xff)
                        {
                            buf2 = (byte)binaryReader.ReadByte();
                            if (buf2 == 0xd9)
                            {
                                arrayList.Add(buf1);
                                arrayList.Add(buf2);
                                stopF = true;
                            }
                        }
                        else
                        {
                            arrayList.Add(buf1);
                        }


                    }
                    else
                    {
                        if (buf1 == 0xff)
                        {
                            buf2 = (byte)binaryReader.ReadByte();
                            if (buf2 == 0xd8)
                            {
                                arrayList.Add(buf1);
                                arrayList.Add(buf2);
                                startF = true;
                            }
                        }
                    }
                    if (startF && stopF)
                    {
                        startF = false;
                        stopF = false;
                        /*
                         * write out image                      
                        */
                        byte[] imgBytes = arrayList.ToArray();
                        System.IO.File.WriteAllBytes("/home/maksim/Projects/WindowsFormsApp1/newframe.jpeg", imgBytes);
                        //Bitmap bitmap;
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            Image bitimg = Image.FromStream(ms);
                            pictureBox1.Image = new Bitmap(bitimg);
                        }
                        arrayList.Clear();
                        buf2 = 0x00;
                        buf1 = binaryReader.ReadByte();
                    }
                    if (buf2 == 0xff)
                    {
                        if (startF) arrayList.Add(buf1);
                        buf1 = buf2;
                        buf2 = 0x00;
                    }
                    else
                    {
                        buf1 = binaryReader.ReadByte();
                    }
                }
                
             }
             //close the response
             response.Close();
        }
    }
}
