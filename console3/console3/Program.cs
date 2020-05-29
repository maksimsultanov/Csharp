using System;
using System.Collections;
using System.IO;
using System.Net;

namespace console3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Creaate url
            Uri url = new Uri("http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25");
            //create request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //get response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // create strem
            byte[] buf = new byte[1024 * 1024];
            Stream stream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(stream);
            int count = 0;
            count = reader.BaseStream.Read(buf, 0, buf.Length);
            while (count>0)
            {
                Console.WriteLine(buf);
                //Console.ReadLine();
                count = reader.BaseStream.Read(buf, 0, buf.Length);
            }

            /*using (Stream stream = response.GetResponseStream())
            {
                StreamReader binaryReader = new StreamReader(stream);
                byte[] buffer = new byte[1024 * 1024];
                //buffer = (byte)binaryReader.ReadLine();
                //string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                string s = "";
                Boolean startFlag = false;
                int nextpos = 0;
                ArrayList arrayList = new ArrayList();
                while((s = binaryReader.ReadLine()) != null)
                {
                    if (s.Contains("Content-Length"))
                    {
                        startFlag = true;
                        var sTmp = s.Split(' ');
                        binaryReader.ReadLine();
                        Console.WriteLine(sTmp[1]);
                        while (s.Contains("--myboundary") == false)
                        {
                            s = binaryReader.ReadLine();
                            string s1 = "";

                            if (s.EndsWith("--myboundary"))
                            {
                                Console.WriteLine("ok");
                                s1 = s.Replace("--myboundary", "");
                                arrayList.AddRange(System.Text.Encoding.UTF8.GetBytes(s1));
                                Console.WriteLine(s1);
                            }
                            else
                            {
                                arrayList.AddRange(System.Text.Encoding.UTF8.GetBytes(s));
                                Console.WriteLine(s);
                            }


                            Console.WriteLine(arrayList.Count);
                            Console.WriteLine(sTmp[1]);
                            //Console.ReadLine();
                        }
                        Console.WriteLine(arrayList.Count);
                        Console.ReadLine();
                    }
                    /*if (s == "--myboundary")
                    {
                        /*
                         * call the show method and clear the arrayList                       
                        

                        startFlag = false;
                    }
                    if (startFlag == true)
                    {
                        arrayList.AddRange(System.Text.Encoding.UTF8.GetBytes(s));
                    }
                    if (s == "")
                    {
                        startFlag = true;
                    }
                    buffer =  System.Text.Encoding.UTF8.GetBytes(s);

                    Console.WriteLine(s);

                    Console.WriteLine(s.Length);
                    Console.ReadLine();
                }

            }*/
            //close the response
            stream.Close();
            response.Close();

        }
        /*static int search(byte[] haystack, byte[] needle)
        {
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (match(haystack, needle, i))
                {
                    return i;
                }
            }
            return -1;
        }

        static bool match(byte[] haystack, byte[] needle, int start)
        {
            if (needle.Length + start > haystack.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < needle.Length; i++)
                {
                    if (needle[i] != haystack[i + start])
                    {
                        return false;
                    }
                }
                return true;
            }
        }*/
    }
}
