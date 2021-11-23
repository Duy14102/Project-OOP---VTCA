using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Dotnet
{
    class StudentManager
    {
        static Dictionary<int, StudentInput> StudentListCount = new Dictionary<int, StudentInput>();
        public bool Add(StudentInput studentnew)
        {
            if (studentnew == null) return false;
            else
            {
                StudentListCount.Add(studentnew.ID, studentnew);
                return true;
            }

        }
    }
}