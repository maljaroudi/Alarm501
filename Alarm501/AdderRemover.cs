using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class AdderRemover : Form
    {
        public Alarm? Time
        {
            get
            {
                return timeAddr1.ConfirmAlarm;
            }
            set
            {
                Alarm? t = value;
                timeAddr1.ConfirmAlarm = t;
                timeAddr1.TimePickerUpdater();
                timeAddr1.SnoozeUpdater();
                timeAddr1.ToneUpdater();
            }
        }

        
        public AdderRemover()
        {

            InitializeComponent();
            
        }

        private void AdderRemover_Load(object sender, EventArgs e)
        {

        }

        private void timeAddr1_Load(object sender, EventArgs e)
        {

        }
    }
}
