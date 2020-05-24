using System;
namespace ConsoleApp2
{
    public class VideoCam
    {
        protected string name;
        protected string text_id;
        protected string url;
        protected void SetCam()
        {
            /*
             * create url here           
            */
        }
        public string GetCam()
        {
            return this.url;
        }
        public VideoCam(string name, string text_id)
        {
            this.name = name;
            this.text_id = text_id;
            this.SetCam();
            /*
             * join string in to url in setcam method           
             */           
        }
    }
}
