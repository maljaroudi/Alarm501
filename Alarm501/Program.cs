using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public delegate void Handler(Alarm a, State s);
    public delegate void Status(State s,Alarm a);

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            alarmGUI view = new alarmGUI();
            Alarm model = new Alarm();
            Controller controller = new Controller(model, State.Start);
            controller.SetView(view);
            view.SetController(controller.handleEvents);
            Application.Run(view);

        }
    }
}
