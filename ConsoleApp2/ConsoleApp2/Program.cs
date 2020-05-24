using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Net.Http;
using System.Net.Sockets;
using System.Collections;

namespace ConsoleApp2
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            Uri uri = new Uri("http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25");

            HttpWebRequest request = WebRequest.CreateHttp(uri);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                WebHeaderCollection headers = response.Headers;
                for (int i = 0; i < headers.Count; i++)
                {
                    Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
                }

                string contenttype = response.ContentLength.ToString();
                Console.WriteLine(contenttype);

                using (Stream stream = response.GetResponseStream())
                {

                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        ArrayList arrayList = new ArrayList();
                        Boolean flag = true;
                        byte first = 0;
                        byte start = 0;
                        byte stop = 0;
                        int count = 0;
                        while (flag)
                        {
                            var tmp = reader.ReadByte();
                            if ((tmp == 255) && (first != 255))
                            {
                                first = tmp;
                            }
                            if (first == 255)
                            {
                                if (tmp == 216)
                                {
                                    start = tmp;
                                    arrayList.Add(first);
                                    arrayList.Add(start);
                                    count++;
                                    count++;
                                    first = 0;
                                }
                                else if (tmp == 217)
                                {
                                    stop = tmp;
                                    arrayList.Add(first);
                                    arrayList.Add(stop);
                                    count++;
                                    count++;
                                }
                                else if (tmp == 255)
                                {
                                    first = tmp;
                                }
                                else
                                {
                                    first = 0;
                                }
                            }
                            if ((first != 0) && (start != 0) && (stop == 0))
                            {
                                arrayList.Add(tmp);
                                count++;
                            }
                            if ((first != 0) && (start != 0) && (stop != 0))
                            {
                                first = 0;
                                stop = 0;
                                start = 0;
                                flag = false;
                            }

                        }
                        Console.WriteLine(count);
                    }
                }
                response.Close();
            }
        }
        /*public static int IndexOf(this byte[] sequence, byte[] pattern)
        {
            var patternLength = pattern.Length;
            var matchCount = 0;

            for (var i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == pattern[matchCount])
                {
                    matchCount++;
                    if (matchCount == patternLength)
                    {
                        return i - patternLength + 1;
                    }
                }
                else
                {
                    matchCount = 0;
                }
            }

            return -1;
        }*/

    }
}
