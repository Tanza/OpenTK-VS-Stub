using GLStub.GLRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLStub
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (MainWindow window = new MainWindow())
            {
                window.Run(30.0, 0.0);
            }
        }
    }
}
