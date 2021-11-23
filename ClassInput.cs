using System;
using System.Collections.Generic;
namespace Dotnet
{
    class ClassInput : ListClass
    {
        Dictionary<int, ClassInput> ClassListCount = new Dictionary<int, ClassInput>();
        string _ClassRoom;
        string _StatusClass;
        string _Falcuty;
        string _StudyDay;
        int _ClassID;
        DateTime _StudyTime;
        DateTime _StudyTime2;
        string _ClassName;
        public string ClassRoom
        {
            get
            {
                return _ClassRoom;
            }
            set
            {
                _ClassRoom = value;
            }
        }
        public string StatusClass
        {
            get
            {
                return _StatusClass;
            }
            set
            {
                _StatusClass = value;
            }
        }
        public string Falcuty
        {
            get
            {
                return _Falcuty;
            }
            set
            {
                _Falcuty = value;
            }
        }
        public string StudyDay
        {
            get
            {
                return _StudyDay;
            }
            set
            {
                _StudyDay = value;
            }
        }
        public int ClassID
        {
            get
            {
                return _ClassID;
            }
            set
            {
                _ClassID = value;
            }
        }
        public DateTime StudyTime
        {
            get
            {
                return _StudyTime;
            }
            set
            {
                _StudyTime = value;
            }
        }
        public DateTime StudyTime2
        {
            get
            {
                return _StudyTime2;
            }
            set
            {
                _StudyTime2 = value;
            }
        }
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }
        public void DisplayClassInformation(ClassInput c)
        {
            Console.Write("==================================================\n" + "  \t\tCLASS INFORMATION                       \n" + "==================================================\n");
            Console.Write("Class Name : {0}\n", c.ClassName);
            Console.Write("Study Day : {0}\n", c.StudyDay);
            Console.Write("Study Time : {0}", c.StudyTime.ToString("HH:mm - "));
            Console.Write("{0}\n", c.StudyTime2.ToString("HH:mm"));
            Console.Write("Class Room : {0}\n", c.ClassRoom);
            Console.Write("Status : {0}\n", c.StatusClass);
            Console.Write("Falcuty : {0}\n", c.Falcuty);
            Console.Write("==================================================\n");
        }
        public void DisplayClassList(Dictionary<int, ClassInput> showdisplayclass)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------+\n" + "|  CLass           | Study Day             | Study Time              | ClassRoom           | Status              |\n" + "+----------------------------------------------------------------------------------------------------------------+\n");
            foreach (ClassInput g in showdisplayclass.Values)
            {
                Console.Write("| {0, -17}| {1, -22}| {2} - {3, -16}| {4, -20}| {5, -20}|\n", g.ClassName, g.StudyDay, g.StudyTime.ToString("HH:mm"), g.StudyTime2.ToString("HH:mm"), g.ClassRoom, g.StatusClass);
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayClassClosed(Dictionary<int, ClassInput> showdisplayclass)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------+\n" + "|  CLass           | Study Day             | Study Time              | ClassRoom           | Status              |\n" + "+----------------------------------------------------------------------------------------------------------------+\n");
            foreach (ClassInput g in showdisplayclass.Values)
            {
                if (g.StatusClass == "closed")
                {
                    Console.Write("| {0, -17}| {1, -22}| {2} - {3, -16}| {4, -20}| {5, -20}|\n", g.ClassName, g.StudyDay, g.StudyTime.ToString("HH:mm"), g.StudyTime2.ToString("HH:mm"), g.ClassRoom, g.StatusClass);
                }
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayClassCompleted(Dictionary<int, ClassInput> showdisplayclass)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------+\n" + "|  CLass           | Study Day             | Study Time              | ClassRoom           | Status              |\n" + "+----------------------------------------------------------------------------------------------------------------+\n");
            foreach (ClassInput g in showdisplayclass.Values)
            {
                if (g.StatusClass == "completed")
                {
                    Console.Write("| {0, -17}| {1, -22}| {2} - {3, -16}| {4, -20}| {5, -20}|\n", g.ClassName, g.StudyDay, g.StudyTime.ToString("HH:mm"), g.StudyTime2.ToString("HH:mm"), g.ClassRoom, g.StatusClass);
                }
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayClassStudying(Dictionary<int, ClassInput> showdisplayclass)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------+\n" + "|  CLass           | Study Day             | Study Time              | ClassRoom           | Status              |\n" + "+----------------------------------------------------------------------------------------------------------------+\n");
            foreach (ClassInput g in showdisplayclass.Values)
            {
                if (g.StatusClass == "studying")
                {
                    Console.Write("| {0, -17}| {1, -22}| {2} - {3, -16}| {4, -20}| {5, -20}|\n", g.ClassName, g.StudyDay, g.StudyTime.ToString("HH:mm"), g.StudyTime2.ToString("HH:mm"), g.ClassRoom, g.StatusClass);
                }
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayClass(ClassInput k)
        {
            Console.Write("+-----------------------------------------------------------------------------------------------------+\n" + "|  Class           | StudyDay             | StudyTime             | ClassRoom              | Status                 |\n" + "+-----------------------------------------------------------------------------------------------------+\n");
            Console.Write(String.Format("| {0, -22}| {1, -22}| {2) - {3, -16}| {4, -16}| {5, -22}|\n", k.ClassName, k.StudyDay, k.StudyTime.ToString("HH:mm"), k.StudyTime2.ToString("HH:mm"), k.ClassRoom, k.StatusClass));
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+\n");
        }
    }
}