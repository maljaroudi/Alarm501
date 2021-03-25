using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alarm501;
namespace Alarm501
{
    public partial class TimeAddr : UserControl
    {
        public Alarm? ConfirmAlarm 
        {
            get;

            set;
            
        }

        //public Nullable<DateTime> Time { get; set; } = null;
        public TimeAddr()
        {
            InitializeComponent();
            alarmTonePicker.DataSource = Enum.GetValues(typeof(AlarmTone));

        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            AlarmStatus status;
            if (disabledCheckBox.Checked) status = AlarmStatus.Disabled;
            else status = AlarmStatus.Off;
            
            ConfirmAlarm = new Alarm(timePicker.Value.ToString("%h:mm tt"), status, timePicker.Value, (AlarmTone)alarmTonePicker.SelectedItem, Convert.ToUInt32(snoozeTime.Value));
            //Time = timePicker.Value;
            ((Form)this.TopLevelControl).Close();
        }

        private void TimeAddr_Load(object sender, EventArgs e)
        {

        }

        public void TimePickerUpdater()
        {
            if (ConfirmAlarm.HasValue)
            {
                if (ConfirmAlarm.Value.AlarmStatus == AlarmStatus.Disabled)
                {
                    timePicker.Value = ConfirmAlarm.Value.DateTime;
                    disabledCheckBox.Checked = true;
                }
                else timePicker.Value = ConfirmAlarm.Value.DateTime;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void SnoozeUpdater()
        {
            if (ConfirmAlarm.HasValue)
            {
                if (ConfirmAlarm.Value.SnoozeLength != 0)
                {
                    snoozeTime.Value = ConfirmAlarm.Value.SnoozeLength;
                }
                else snoozeTime.Value = ConfirmAlarm.Value.SnoozeLength;

            }
        }

        public void ToneUpdater()
        {
            if (ConfirmAlarm.HasValue)
            {
                if (ConfirmAlarm.Value.AlarmTone != AlarmTone.Radar)
                {
                    alarmTonePicker.SelectedItem = ConfirmAlarm.Value.AlarmTone;
                }
                else alarmTonePicker.SelectedItem = ConfirmAlarm.Value.AlarmTone;

            }
        }

    }
}
