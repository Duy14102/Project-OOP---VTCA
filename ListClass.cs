using System;
using System.Collections.Generic;
namespace Dotnet
{
    interface ListClass
    {
        void DisplayClassInformation(ClassInput c);
        void DisplayClassList(Dictionary<int, ClassInput> showdisplayclass);
        void DisplayClass(ClassInput k);
        void DisplayClassClosed(Dictionary<int, ClassInput> showdisplayclass);
        void DisplayClassCompleted(Dictionary<int, ClassInput> showdisplayclass);
        void DisplayClassStudying(Dictionary<int, ClassInput> showdisplayclass);
        int ClassID { set; get; }
        string ClassRoom { set; get; }
        string StatusClass { set; get; }
        string Falcuty { set; get; }
        string StudyDay { set; get; }
        DateTime StudyTime { set; get; }
        DateTime StudyTime2 { set; get; }
        string ClassName { set; get; }
    }
}