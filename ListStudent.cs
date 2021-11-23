using System;
using System.Collections.Generic;
namespace Dotnet
{
    interface ListStudent
    {
        void StudentListClass(Dictionary<int, StudentInput> showdisplayclass2);
        void DisplayInformation(StudentInput y);
        void DisplayStudentList(Dictionary<int, StudentInput> showdisplay);
        void DisplayStudent(StudentInput i);
        void DisplayStudentListWithClass(Dictionary<int, StudentInput> showdisplayclass2, string inputname);
        int ID { set; get; }
        string IDsearch { set; get; }
        int StudentID { set; get; }
        string FirstName { set; get; }
        string MiddleName { set; get; }
        string LastName { set; get; }
        string BirthDay { set; get; }
        string Address { set; get; }
        string Phone { set; get; }
        string Email { set; get; }
        string ClassNameStudent { set; get; }
        string Note { set; get; }
        string Status { set; get; }

    }

}