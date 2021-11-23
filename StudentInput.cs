using System;
using System.Collections.Generic;
namespace Dotnet
{
    class StudentInput : ListStudent
    {
        Dictionary<int, StudentInput> StudentListCount = new Dictionary<int, StudentInput>();
        string _ClassNameStudent;
        int id;
        string _IDsearch;
        int _StudentID;
        string _FirstName;
        string _MiddleName;
        string _LastName;
        string _BirthDay;
        string _Address;
        string _Phone;
        string _Email;
        string _Note;
        string _Status;
        public string ClassNameStudent
        {
            get
            {
                return _ClassNameStudent;
            }
            set
            {
                _ClassNameStudent = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string IDsearch
        {
            get
            {
                return _IDsearch;
            }
            set
            {
                _IDsearch = value;
            }

        }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }
        public int StudentID
        {
            get
            {
                return _StudentID;
            }
            set
            {
                _StudentID = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public string BirthDay
        {
            get
            {
                return _BirthDay;
            }
            set
            {
                _BirthDay = value;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }
        public void DisplayStudentList(Dictionary<int, StudentInput> showdisplay)
        {
            Console.Write("+-----------------------------------------------------------------------------------------------------+\n" + "|  Student ID           | Full Name             | Class     | Phone           | Email                 |\n" + "+-----------------------------------------------------------------------------------------------------+\n");
            foreach (StudentInput i in showdisplay.Values)
            {
                Console.Write("| {0, -22}| {1, -22}| {2, -10}| {3, -16}| {4, -22}|\n", i.StudentID, i.FullName, i.ClassNameStudent, i.Phone, i.Email);
            }
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayInformation(StudentInput y)
        {
            Console.Write("==================================================\n" + "  \t\tSTUDENT INFORMATION                       \n" + "==================================================\n");
            Console.Write("Student ID : {0}\n", y.StudentID);
            Console.Write("First Name : {0}\n", y.FirstName);
            Console.Write("Middle Name : {0}\n", y.MiddleName);
            Console.Write("Last Name : {0}\n", y.LastName);
            Console.Write("BirthDay : {0}\n", y.BirthDay);
            Console.Write("Address : {0}\n", y.Address);
            Console.Write("Phone : {0}\n", y.Phone);
            Console.Write("Email : {0}\n", y.Email);
            Console.Write("Class Name : {0}\n", y.ClassNameStudent);
            Console.Write("Note : {0}\n", y.Note);
            Console.Write("Status : {0}\n", y.Status);
            Console.Write("==================================================\n");
        }
        public void DisplayStudent(StudentInput i)
        {
            Console.Write("+-----------------------------------------------------------------------------------------------------+\n" + "|  Student ID           | Full Name             | Class     | Phone           | Email                 |\n" + "+-----------------------------------------------------------------------------------------------------+\n");
            Console.Write(String.Format("| {0, -22}| {1, -22}| {2, -10}| {3, -16}| {4, -22}|\n", i.StudentID, i.FullName, i.ClassNameStudent, i.Phone, i.Email));
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+\n");
        }
        public void DisplayStudentListWithClass(Dictionary<int, StudentInput> showdisplayclass2, string inputname)
        {
            Console.Write("+-----------------------------------------------------------------------------------------------------+\n" + "|  Student ID           | Full Name             | Class     | Phone           | Email                 |\n" + "+-----------------------------------------------------------------------------------------------------+\n");
            foreach (StudentInput i in showdisplayclass2.Values)
            {
                if (i.ClassNameStudent == inputname)
                {
                    Console.Write("| {0, -22}| {1, -22}| {2, -10}| {3, -16}| {4, -22}|\n", i.StudentID, i.FullName, i.ClassNameStudent, i.Phone, i.Email);
                }
            }
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+\n");
        }
        public void StudentListClass(Dictionary<int, StudentInput> showdisplayclass2)
        {
            Console.Write("+----------------------------------------------------------------------------------------------------------------+\n" + "\t\t\t\tStudent List\t\t\t\t\n" + "+----------------------------------------------------------------------------------------------------------------+\n");
            foreach (StudentInput u in showdisplayclass2.Values)
            {
                Console.Write("|{-25, 0, -25}|\n", u.FullName);
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------+\n");
        }
    }
}
