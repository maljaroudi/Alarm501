/*
 * NAME: Moheeb Aljaroudi
 * Project: Alarm clock PS-1
 * DISCREPTION: Alarm clock with snooze / disable and a txt reference file to save alarms to. 
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Alarm501
{

    /// <summary>
    /// Shows the status of the alarm
    /// </summary>
    public enum AlarmStatus
    {
        On,
        Off,
        Snooze,
        Disabled,
    }

    public enum AlarmTone
    {
       Radar,
       Beacon,
       Chimes,
       Circuit,
       Reflection
    }

    public partial class alarmGUI : Form
    {

        Handler handlerDel;
        

        /// <summary>
        /// Selected Value index for refrence so controller can take care of the rest
        /// </summary>
        public int SelectedIndex 
        {
            get
            {
                return alarmsList.SelectedIndex;
            }
            set
            {
                alarmsList.SelectedItem = value;
            }
        }

        /// <summary>
        /// Selected Value Item for refrence so controller can take care of the rest
        /// </summary>
        public Alarm SelectedAlarm
        {
            get
            {
                return (Alarm)alarmsList.SelectedItem;
            }
            set
            {
                alarmsList.SelectedItem = value;
            }
        }

        

        public Alarm AlarmController { get; set; } 

        

        /// <summary>
        /// Start timer and read file to populate the alarm list
        /// </summary>
        public alarmGUI()
        {
            InitializeComponent();
            
            timer.Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (alarmsList.Items.Count ==0)
            {
                removeButton.Enabled = false;
                editButton.Enabled = false;
            }
        }

        /// <summary>
        /// Add button action, get alarm from the adderremover class, adds alarm to the list of alarms, 
        /// Refresh the alarm list and writes the alarm using the FileWriter method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            AdderRemover adderRemover = new AdderRemover();
            adderRemover.ShowDialog();
            if (adderRemover.Time != null)
            {
                Alarm time = adderRemover.Time.GetValueOrDefault();
                //Handle by the controller Delegate

                handlerDel(time, State.Added);
                
            }



        }

        public void SetController(Handler c)
        {
            handlerDel = c;
        }



        public void AlarmListUpdater(BindingList<Alarm> al)
        {
            alarmsList.DisplayMember = "DisplayString"; //better solution as it registers both key and value, but only shows the value in GUI.
            alarmsList.DataSource = al;
            if (alarmsList.Items.Count > 0)
            {
                removeButton.Enabled = true;
                editButton.Enabled = true;
            }
        }

        

        public void StateViewer(State state, Alarm alarm)
        {
            switch (state)
            {
                case State.Snoozed:
                    statusText.Text = $"{alarm.DisplayString} Alarm Snoozed";
                    break;
                case State.Removed:
                    statusText.Text = "";
                    break;
                case State.GoesOff:
                    statusText.Text = $"{alarm.DisplayString} Alarm! {alarm.AlarmTone}";
                    break;
                case State.Disabled:
                    statusText.Text = "";
                    break;
                case State.Edited:
                    statusText.Text = "";
                    break;
            }
        }


        




        /// <summary>
        /// disabler / enabler for the interface buttons for certain cases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alarmsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;

                if (item.SelectedItem == null)
                {
                cancelButton.Enabled = false;
                snoozeButton.Enabled = false;
                removeButton.Enabled = false;
                editButton.Enabled = false;
                
                }

                else if (((Alarm)item.SelectedItem).AlarmStatus == AlarmStatus.Disabled || ((Alarm)item.SelectedItem).AlarmStatus == AlarmStatus.Snooze || ((Alarm)item.SelectedItem).AlarmStatus == AlarmStatus.Off)
                {
                
                cancelButton.Enabled = false;
                snoozeButton.Enabled = false;
                removeButton.Enabled = true;
                editButton.Enabled = true;
                currentAlarmStatus.Text = $"Alarm Status: {((Alarm)item.SelectedItem).AlarmStatus}";
            }

                else
                {
                removeButton.Enabled = false;
                cancelButton.Enabled = true;
                snoozeButton.Enabled = true;
                editButton.Enabled = false;
                currentAlarmStatus.Text = $"{((Alarm)item.SelectedItem).DisplayString} Alarm! {((Alarm)item.SelectedItem).AlarmTone}";

            }
            
            
        }

        


        /// <summary>
        /// Removes alarm from the list and the bindlist and the file. update the list afterwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            handlerDel(SelectedAlarm, State.Removed);
            
        }

        /// <summary>
        /// Event handler for each tick to check for the alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if(alarmsList.Items.Count>0) handlerDel(SelectedAlarm, State.Ticking);
            
        }
        

        /// <summary>
        /// Snooze button function, Snoozetime becomes the exact time of hitting the snooze button ( for comparison later).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snoozeButton_Click(object sender, EventArgs e)
        {
            handlerDel(SelectedAlarm, State.Snoozed);
        }
        /// <summary>
        /// Cancel the alarm. sets it to disabled. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            handlerDel(SelectedAlarm, State.Disabled);
        }



        

        /// <summary>
        /// Edit button, changes the struct to the currosponding values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            handlerDel(SelectedAlarm, State.Edited);
        }

        private void currentAlarmStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
