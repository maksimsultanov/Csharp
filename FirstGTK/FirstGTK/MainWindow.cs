using System;
using Gtk;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    FilterInfoCollection filterInfoCollection;
    VideoCaptureDevice videoCaptureDevice;

    protected void btnstart_Click(object sender, EventArgs e)
    {
        videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[combocam.SelectedIndex].MonikerString);
        videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
        videoCaptureDevice.Start();
    }

    void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
        TextPixbuf pixbuf = bitmap;
        image2.FromPixbuf(pixbuf);
    }


    protected void fixed1_shown(object sender, EventArgs e)
    {
        filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in filterInfoCollection)
            combocam.Items.Add(filterInfo.Name);
        combocam.SelectedIndex = 0;
        videoCaptureDevice = new VideoCaptureDevice();

    }
}
