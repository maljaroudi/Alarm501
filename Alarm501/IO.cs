using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Alarm501
{
    public class IO
    {

        /// <summary>
        /// Write the alarm and the status enum to the file, seperated by double space
        /// </summary>
        /// <param name="alarm"></param>
        public static void FileWriter(Alarm alarm)
        {
            TextWriter tw = new StreamWriter("alarms.txt", true);
            tw.WriteLine($"{alarm.DateTime}  {alarm.AlarmStatus}  {alarm.AlarmTone}  {alarm.SnoozeLength}");
            tw.Close();
        }



        /// <summary>
        /// Reads the alarm file, parses the string to a DateTime and status to AlarmStatus, and make struct instance.
        /// Add it to list and refresh list
        /// </summary>
        public static void FileReader(BindingList<Alarm> Alarms)
        {
            if (File.Exists("alarms.txt"))
            {
                TextReader tr = new StreamReader("alarms.txt");
                string line = String.Empty;

                while ((line = tr.ReadLine()) != null)
                {
                    Alarm alarmInstance = new Alarm();
                    string[] tess = line.Split(new[] { "  " }, StringSplitOptions.None);
                    alarmInstance.DateTime = DateTime.Parse(tess[0]);
                    alarmInstance.AlarmStatus = (AlarmStatus)Enum.Parse(typeof(AlarmStatus), tess[1]);
                    alarmInstance.AlarmTone = (AlarmTone)Enum.Parse(typeof(AlarmTone), tess[2]);
                    alarmInstance.SnoozeLength = uint.Parse(tess[3]);
                    alarmInstance.DisplayString = alarmInstance.DateTime.ToString("%h:mm tt");

                    Alarms.Add(alarmInstance);
                }
                tr.Close();
            }
            

        }

        /// <summary>
        /// Edit the Alarm from the file. 
        /// </summary>
        /// <param name="alarm"></param>
        public static void AlarmFileEditor(Alarm alarm, Alarm view)
        {
            if (File.Exists("alarms.txt"))
            {
                var tempFile = Path.GetTempFileName();
                string[] file = File.ReadAllLines("alarms.txt");
                string oldAlarm = $"{view.DateTime}  {view.AlarmStatus}  {view.AlarmTone}  {view.SnoozeLength}";
                file = file.Select(x => x == oldAlarm ? x.Replace(oldAlarm, $"{alarm.DateTime}  {alarm.AlarmStatus}  {alarm.AlarmTone}  {alarm.SnoozeLength}") : x).ToArray();
                File.WriteAllLines("alarms.txt", file);

            }
        }

        /// <summary>
        /// Disabler method to change the alarm in the file.
        /// </summary>
        /// <param name="alarm"></param>
        public static void AlarmFileRemover(Alarm alarm, Alarm view)
        {
            if (File.Exists("alarms.txt"))
            {
                var tempFile = Path.GetTempFileName();
                string[] file = File.ReadAllLines("alarms.txt");
                string oldAlarm = $"{view.DateTime}  {AlarmStatus.Off}  {view.AlarmTone}  {view.SnoozeLength}";
                file = file.Select(x => x == oldAlarm ? x.Replace(oldAlarm, $"{alarm.DateTime}  {alarm.AlarmStatus}  {alarm.AlarmTone}  {alarm.SnoozeLength}") : x).ToArray();
                File.WriteAllLines("alarms.txt", file);

            }
        }

        /// <summary>
        /// Remover for the alarm in the txt file. duplicate the same file except for the alarm to be removed. 
        /// </summary>
        /// <param name="alarm"></param>
        public static void FileAlarmRemover(Alarm alarm)
        {
            if (File.Exists("alarms.txt"))
            {
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines("alarms.txt").Where(l => l != $"{alarm.DateTime}  {alarm.AlarmStatus}  {alarm.AlarmTone}  {alarm.SnoozeLength}");

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete("alarms.txt");
                File.Move(tempFile, "alarms.txt");
            }
        }

    }
}
