using System;

namespace testapp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String str = "";
            System.Text.StringBuilder strb = new System.Text.StringBuilder(str);
            strb.Append('-', 10);
            strb.ToString();
            Console.WriteLine(strb);
        }
    }
}
