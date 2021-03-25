using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alarm501;
namespace Alarm501
{

    public enum State
    {
        Start,
        Ticking,
        Added,
        Removed,
        Edited,
        Snoozed,
        GoesOff,
        Disabled,
    }

    public class Controller
    {
        /// <summary>
        /// List of alarms linked to the list in GUI
        /// </summary>
        /// 
        private BindingList<Alarm> Alarms = new BindingList<Alarm>();
        
        /// <summary>
        /// Get current time
        /// </summary>
        private DateTime CurrentTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Snooze Time, modified later
        /// </summary>
        public DateTime SnoozeTime { get; set; }

        Alarm model;
        alarmGUI view;
        State status;

        Status statusDel;

        public Controller(Alarm a, State s)
        {
            model = a;
            status = s;
            FileReader();
            

        }
        public void SetView(alarmGUI v)
        {
            view = v;
            view.AlarmListUpdater(Alarms);
            statusDel = v.StateViewer;
        }

        public void handleEvents(Alarm alarm, State state)
        {
            switch (state)
            {
                case State.Start:
                    FileReader();
                    break;
                case State.Ticking:
                    TickingFunc();
                    break;
                case State.Added:
                    AlarmAdder(alarm);
                    break;
                case State.Edited:
                    AlarmEditor(alarm);
                    break;
                case State.Snoozed:
                    AlarmSnoozer(alarm);
                    break;
                case State.Removed:
                    AlarmRemover(alarm);
                    break;
                case State.Disabled:
                    AlarmDisabler(alarm);
                    break;

                case State.GoesOff:
                    Alarm_Goes_Off(view.SelectedIndex);
                    break;
                default: break;



            }
            view.AlarmListUpdater(Alarms);
        }


        private void TickingFunc()
        {
            for (int i = 0; i < Alarms.Count; i++)
            {
                if (Alarms[i].AlarmStatus == AlarmStatus.Off)
                {

                    if (Alarms[i].DateTime.Hour == CurrentTime.Hour && CurrentTime.Minute == Alarms[i].DateTime.Minute && Alarms[i].DateTime.Second == CurrentTime.Second)
                    {
                        //status = State.GoesOff;
                        Alarm_Goes_Off(i);
                        view.SelectedIndex = i;
                    }

                }
                else if (Alarms[i].AlarmStatus == AlarmStatus.Snooze)
                {
                    //Works well
                    if ((CurrentTime - SnoozeTime).TotalMinutes >= Alarms[i].SnoozeLength)
                    {


                        //handlerDel(new Alarm(), State.GoesOff);
                        //status = State.GoesOff;
                        Alarm_Goes_Off(i);
                        view.SelectedIndex = i;
                    }
                }
                //Not needed due to implementation of States.


                //else if (Alarms[i].AlarmStatus == AlarmStatus.On)
                //{
                //    statusText.Text = $"{Alarms[i].DisplayString} Alarm! {Alarms[i].AlarmTone}";
                //}


            }
        }

        private void AlarmAdder(Alarm alarm)
        {
            Alarms.Add(alarm);
            IO.FileWriter(alarm);
        }


        




        private void AlarmEditor(Alarm a)
        {
            
            Alarm selected = Alarms[view.SelectedIndex];
            AdderRemover editor = new AdderRemover();
            editor.Time = selected;
            editor.ShowDialog();
            if (editor.Time != null)
            {
                Alarm time = editor.Time.GetValueOrDefault();
                IO.AlarmFileEditor(time,view.SelectedAlarm);
                Alarms[view.SelectedIndex] = time;

                //(from values in Alarms select values.Key).ToList() //A little dirty solution but won't have reference to the key.
            }
        }
        private void AlarmSnoozer(Alarm a)
        {
            Alarm disabled = Alarms[view.SelectedIndex];
            disabled.AlarmStatus = AlarmStatus.Snooze;
            Alarms[view.SelectedIndex] = disabled;
            // FIX!
            statusDel(State.Snoozed, disabled);
            SnoozeTime = DateTime.Now;
            //SnoozeTime.AddSeconds(5);
        }

        private void AlarmRemover(Alarm a)
        {
            if (Alarms.Count > 0)
            {
                IO.FileAlarmRemover(a);
                Alarms.Remove(a);
                // FIX!
                statusDel(State.Removed, a);

            }
        }

        /// <summary>
        /// Reads the alarm file, parses the string to a DateTime and status to AlarmStatus, and make struct instance.
        /// Add it to list and refresh list
        /// </summary>
        private void FileReader()
        {
            IO.FileReader(Alarms);
        }


        
        



        /// <summary>
        /// When tick function land on an alarm that's set to be going off. Changes the status of the alarm and indicate that in the status text.
        /// </summary>
        /// <param name="i"></param>
        private void Alarm_Goes_Off(int i)
        {
            Alarm newAlarm = Alarms[i];
            newAlarm.AlarmStatus = AlarmStatus.On;
            Alarms[i] = newAlarm;
            //FIX!
            statusDel(State.GoesOff, newAlarm);


        }

        private void AlarmDisabler(Alarm a)
        {
            Alarm disabled = a;
            disabled.AlarmStatus = AlarmStatus.Disabled;
            //disabled.AlarmStatus = AlarmStatus.Disabled;
            IO.AlarmFileRemover(disabled,view.SelectedAlarm);
            Alarms[view.SelectedIndex] = disabled;
            //FIX!
            statusDel(State.Disabled, disabled);
        }

        


    }
}
