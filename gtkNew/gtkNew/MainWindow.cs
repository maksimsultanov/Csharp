using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Gdk;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public static Boolean stsp = false;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void btn_StartStop_Click(object sender, EventArgs e)
    {
        stsp = !stsp;
        if (stsp)
        {
            Uri url = new Uri("http://cam.mnc.ru/axis-cgi/mjpg/video.cgi?camera=1");
            TaskAsync(url).GetAwaiter();
        }
    }
    protected async Task TaskAsync(Uri url)
    {
        WebRequest webRequest = WebRequest.Create(url);
        WebResponse response = await webRequest.GetResponseAsync();
        try
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    while (stsp)
                    {
                        Pixbuf pixbuf = new Pixbuf(streamReader.ReadLine());
                        Icon pixbuf1 = (Icon)pixbuf;
                    }
                }
            }
        }
        catch (WebException ex)
        {
            WebExceptionStatus status = ex.Status;

            if (status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                Console.WriteLine("Статусный код ошибки: {0} - {1}",
                        (int)httpResponse.StatusCode, httpResponse.StatusCode);
            }
        }
        finally
        {

            response.Close();
        }
    }


}
