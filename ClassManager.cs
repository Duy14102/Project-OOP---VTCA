using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Dotnet
{
    class ClassManager
    {
        static Dictionary<int, ClassInput> ClassListCount = new Dictionary<int, ClassInput>();
        public bool AddClass(ClassInput ClassStudent)
        {
            if (ClassStudent == null) return false;
            else
            {
                ClassListCount.Add(ClassStudent.ClassID, ClassStudent);
                return true;
            }
        }

    }
}