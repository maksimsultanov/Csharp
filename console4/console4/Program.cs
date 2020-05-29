using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace console4
{
    class MainClass
    {
        private static object _streamActive;

        public static void Main(string[] args)
        {
            Uri url = new Uri("http://demo.macroscop.com:8080/mobile?login=root&channelid=2016897c-8be5-4a80-b1a3-7f79a9ec729c&resolutionX=640&resolutionY=480&fps=25");
            getVideoTask(url).GetAwaiter();
        }
        private static async Task getVideoTask(Uri url)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            {
                byte[] buf = new byte[1024 * 1024];
                byte[] imgBuffer = new byte[1024 * 1024];

                Stream stream = httpWebResponse.GetResponseStream();
                BinaryReader streamReader = new BinaryReader(stream);
                streamReader.BaseStream.ReadAsync(buf, 0, buf.Length);
                Console.ReadLine();
            }
        }
    }
}
