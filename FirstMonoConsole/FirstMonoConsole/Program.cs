using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FirstMonoConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            IPHostEntry host1 = Dns.GetHostEntry("www.ya.ru");
            Console.WriteLine(host1.HostName);
            foreach (IPAddress iP in host1.AddressList)
            {
                Console.WriteLine(iP.ToString());
            }

            Console.WriteLine();
            IPHostEntry host2 = Dns.GetHostEntry("google.com");
            Console.WriteLine(host2.HostName);
            foreach (IPAddress ip in host2.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }
            WebClient client = new WebClient();
            client.DownloadFile("http://www.maristi.it/ebook-school/medie/leonetti-storia3.pdf", "/home/maksim/myBook.pdf");
            Console.WriteLine("Ok");

            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead("https://github.com/maksimsultanov/Java/blob/master/home.java"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Ok");
            Console.Read();
            DownloadFileAsinc().GetAwaiter();
            Console.WriteLine("Ok");
            WebRequest request = WebRequest.Create("https://github.com/maksimsultanov/Java/blob/master/home.java");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Ok");
            Uri url = new Uri("http://ya.ru");
            PostRequestAsync(url).GetAwaiter();
            Console.Read();*/

            try
            {
                WebRequest request = WebRequest.Create("http://localhost:5374/Home/PostData");
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // получаем статус исключения
                WebExceptionStatus status = ex.Status;

                if (status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                    Console.WriteLine("Статусный код ошибки: {0} - {1}",
                            (int)httpResponse.StatusCode, httpResponse.StatusCode);
                }
            }

        }
        /* private static async Task PostRequestAsync(Uri url)
         {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            string data = "sName=Hello World!";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dateStream = request.GetRequestStream())
            {
                dateStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse response =(HttpWebResponse)await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            Console.WriteLine("Ok");
            WebRequest request = WebRequest.Create("http://localhost:5374/Home/PostData?sName=Иван Иванов&age=31");
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }
        private static async Task RequestAsync(Uri url)
         {
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://loclahost/");
             HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
             using (Stream stream = response.GetResponseStream())
             {
                 using (StreamReader reader = new StreamReader(stream))
                 {
                     Console.WriteLine(reader.ReadToEnd());
                 }
             }
             response.Close();
             ServicePointManager.Expect100Continue = true;
             ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
             | SecurityProtocolType.Tls11
             | SecurityProtocolType.Tls12;
       HttpWebRequest request = WebRequest.CreateHttp(url);
           using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
           {
               WebHeaderCollection headers = response.Headers;
               for (int i = 0; i < headers.Count; i++)
                   {
                       Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
                   }
               response.Close();
           }
           string html = string.Empty;
           HttpWebRequest request = WebRequest.CreateHttp(url);
           using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
           {
               using (Stream stream = response.GetResponseStream())
               {
                   using (StreamReader reader = new StreamReader(stream))
                   {
                       Console.WriteLine(reader.ReadToEnd());
                   }
               }
           }


       }
       private static async Task DownloadFileAsinc()
       {
           WebClient client = new WebClient();
           await client.DownloadFileTaskAsync(new Uri("https://github.com/maksimsultanov/Java/blob/master/home.java"), "my.java");
       }*/
    }
}
