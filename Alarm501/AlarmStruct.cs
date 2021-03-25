using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    /// <summary>
    /// Struct for each Alarm, it contains the display string, alarm in form of DateTime and the status from the enum
    /// </summary>
    public struct Alarm
    {
        public DateTime DateTime;
        public string DisplayString { get; set; }
        public AlarmStatus AlarmStatus;
        public uint SnoozeLength;
        public AlarmTone AlarmTone;



        /// <summary>
        /// Constructor for the struct
        /// </summary>
        /// <param name="Display">display string</param>
        /// <param name="status">status from enum</param>
        /// <param name="time">DateTime</param>
        public Alarm(string Display, AlarmStatus status, DateTime time, AlarmTone alarmTone, uint snoozeLength) : this()
        {
            DateTime = time;
            DisplayString = Display;
            AlarmStatus = status;
            SnoozeLength = snoozeLength;
            AlarmTone = alarmTone;
        }


    }
}
