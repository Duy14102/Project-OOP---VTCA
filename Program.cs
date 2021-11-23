using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;
namespace Dotnet
{
    class Program
    {
        static Dictionary<int, StudentInput> StudentListCount = new Dictionary<int, StudentInput>();
        static Dictionary<int, ClassInput> ClassListCount = new Dictionary<int, ClassInput>();
        static ClassInput NewClass(Dictionary<int, ClassInput> contacts)
        {
            Console.Clear();
            ClassInput CLassnew = new ClassInput();
            string input1, inputstatus;
            DateTime inputfrom, inputto;
            CLassnew.ClassID = ClassListCount.Count + 1;
            Console.Write("Class Name : ");
            while (true)
            {
                input1 = Console.ReadLine();
                if (IsExistsClass(input1, contacts))
                    Console.Write("Re-Enter : ");
                else { break; }
            }
            CLassnew.ClassName = input1;
            Console.Write("Study Day : ");
            CLassnew.StudyDay = Console.ReadLine();
            Console.Write("Study Time\nFrom(00:00) : ");
            while (true)
            {
                var chess1 = DateTime.TryParse(Console.ReadLine(), out inputfrom);
                if (!chess1)
                {
                    Console.WriteLine("Invalid format!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            CLassnew.StudyTime = inputfrom;
            Console.Write("To(00:00) : ");
            while (true)
            {
                var chess2 = DateTime.TryParse(Console.ReadLine(), out inputto);
                if (!chess2)
                {
                    Console.WriteLine("Invalid format!");
                    Console.Write("Re-enter : ");
                }
                else if (inputto < inputfrom)
                {
                    Console.WriteLine("Study Time Invalid!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            CLassnew.StudyTime2 = inputto;
            Console.Write("Class Room : ");
            string inputroom;
            while (true)
            {
                inputroom = Console.ReadLine();
                if (IsExistsClassroom(inputroom, contacts))
                {
                    Console.WriteLine("This room has it owner!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            CLassnew.ClassRoom = inputroom;
            Console.Write("(closed/completed/studying)\nStatus : ");
            while (true)
            {
                inputstatus = Console.ReadLine();
                if (!CheckClassStatus(inputstatus))
                {
                    Console.WriteLine("3 status available!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            CLassnew.StatusClass = inputstatus;
            Console.Write("Falcuty : ");
            CLassnew.Falcuty = Console.ReadLine();
            ClassListCount.Add(CLassnew.ClassID, CLassnew);
            return CLassnew;
        }
        static StudentInput NewStudent(Dictionary<int, StudentInput> contact)
        {
            Console.Clear();
            StudentInput studentnew = new StudentInput();
            int input;
            string inputfname, inputmname, inputlname;
            studentnew.ID = StudentListCount.Count + 1;
            Console.Write("Student ID : ");
            while (true)
            {
                var isnumber = int.TryParse(Console.ReadLine(), out input);
                if (IsExists(input, contact))
                {
                    Console.WriteLine("ID already exists!");
                    Console.Write(" Re-enter: ");
                }
                else if (!isnumber)
                {
                    Console.WriteLine("Student ID cannot have letter!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            studentnew.StudentID = input;
            Console.Write("FirstName : ");
            while (true)
            {
                inputfname = Console.ReadLine();
                if (Regex.IsMatch(inputfname, @"\d"))
                {
                    Console.WriteLine("Name cannot have number!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            studentnew.FirstName = inputfname;
            Console.Write("MiddleName : ");
            while (true)
            {
                inputmname = Console.ReadLine();
                if (Regex.IsMatch(inputmname, @"\d"))
                {
                    Console.WriteLine("Name cannot have number!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            studentnew.MiddleName = inputmname;
            Console.Write("LastName : ");
            while (true)
            {
                inputlname = Console.ReadLine();
                if (Regex.IsMatch(inputlname, @"\d"))
                {
                    Console.WriteLine("Name cannot have number!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            studentnew.LastName = inputlname;
            Console.Write("BirthDay : ");
            studentnew.BirthDay = Console.ReadLine();
            Console.Write("Address : ");
            studentnew.Address = Console.ReadLine();
            Console.Write("Phone : ");
            string inputphone;
            while (true)
            {
                inputphone = Console.ReadLine();
                if (Regex.IsMatch(inputphone, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Phone number cannot have letter!");
                    Console.Write(" Re-enter: ");
                }
                else if (IsExistsPhone(inputphone, contact))
                {
                    Console.WriteLine("Phone number already exists!");
                    Console.WriteLine("Phone number cannot have letter!");
                    Console.Write(" Re-enter : ");
                }
                else { break; }
            }
            studentnew.Phone = inputphone;
            Console.Write("Email : ");
            string inputmail;
            while (true)
            {
                inputmail = Console.ReadLine();
                if (CheckRegexEmail(inputmail))
                {
                    Console.WriteLine("Email must have [....]@[....].com!");
                    Console.Write("Re-enter : ");
                }
                else if (IsExistsEmail(inputmail, contact))
                {
                    Console.Write("Email already exists!");
                    Console.Write("Re-enter : ");
                }
                else { break; }
            }
            studentnew.Email = inputmail;
            Console.Write("Note : ");
            studentnew.Note = Console.ReadLine();
            StudentListCount.Add(studentnew.ID, studentnew);
            return studentnew;
        }
        static int Menu(string titleup, string title, string[] menu)
        {
            Console.Clear();
            string str;
            int choice;
            Console.WriteLine(titleup);
            Console.WriteLine(title);
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(menu[i]);
            }
            Console.Write("Your Choice : ");
            str = Console.ReadLine();
            int.TryParse(str, out choice);
            while (choice < 1 || choice > menu.Length)
            {
                Console.Write("Wrong Input, Try Again : ");
                str = Console.ReadLine();
                int.TryParse(str, out choice);

            }
            return choice;
        }
        static void MenuStudent()
        {
            StudentManager studentManager = new StudentManager();
            StudentInput inputManager = new StudentInput();
            string fileName = "Students.json";
            string stri;
            int yesno, Inputview;
            int choice, choose;
            string titleup = ("============================================");
            string title = ("  ---  VTC ACADEMY STUDENT MANAGEMENT  ---  ");
            string[] menu = new string[] { "  STUDENT LIST MANAGEMENT", "============================================", "1. ADD STUDENTS", "2. SEARCH STUDENTS", "3. SHOW ALL STUDENTS", "4. BACK TO MAIN MENU", "============================================" };
            string searchmenu1 = "  STUDENT LIST MANAGEMENT";
            string searchmenu2 = "============================================";
            do
            {
                choice = Menu(titleup, title, menu);
                switch (choice)
                {
                    case 1:
                        do
                        {
                            if (studentManager.Add(NewStudent(StudentListCount)))
                            {
                                Console.WriteLine("ADDED SUCCESSFULLY !!!");
                                WriteFileStudent(fileName, StudentListCount);
                            }
                            else Console.WriteLine("ADDED INCOMPLETE");
                            Console.Write("Do You Want To Continue ? (1/2) : ");
                            stri = Console.ReadLine();
                            int.TryParse(stri, out yesno);
                        } while (yesno != 2);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(titleup);
                        Console.WriteLine(title);
                        Console.WriteLine(searchmenu1);
                        Console.WriteLine(searchmenu2);
                        Console.WriteLine(" 1. SEARCH BY NAME\n" + " 2. SEARCH BY ID\n" + " 3. BACK TO MENU");
                        Console.Write("   Your choice : ");
                        choose = int.Parse(Console.ReadLine());
                        while (choose < 1 || choose > 3)
                        {
                            Console.WriteLine("Try Again : ");
                            choose = int.Parse(Console.ReadLine());
                        }
                        if (choose == 1)
                        {
                            Console.Clear();
                            StudentListCount = ReadFileStudent(fileName);
                            while (true)
                            {
                                Console.Write("Input Student Name To View Detail Or Input 0 To Back To Menu : ");
                                string searchbyname = Console.ReadLine();
                                if (searchbyname == "0")
                                {
                                    break;
                                }
                                else
                                {
                                    StudentInput updatedit = new StudentInput();
                                    bool exists3 = false;
                                    foreach (StudentInput i in StudentListCount.Values)
                                    {
                                        if (i.FirstName.Equals(searchbyname) || i.MiddleName.Equals(searchbyname) || i.LastName.Equals(searchbyname))
                                        {
                                            Console.Clear();
                                            updatedit = i;
                                            inputManager.DisplayInformation(i);
                                            exists3 = true;
                                        }
                                    }
                                    if (exists3)
                                    {
                                        Console.Write(" 1. Update Student Information\n" + " 2. Change Student Status\n" + " 3. Change Class\n" + " 4. Back To !STUDENT LIST MANAGEMENT!\n" + "==================================================\n" + " Your Choice : ");
                                        string detailstr = Console.ReadLine();
                                        int detailchoose;
                                        int.TryParse(detailstr, out detailchoose);
                                        while (detailchoose < 1 || detailchoose > 4)
                                        {
                                            Console.Write("Try Again : ");
                                            detailstr = Console.ReadLine();
                                            int.TryParse(detailstr, out detailchoose);
                                        }
                                        switch (detailchoose)
                                        {
                                            case 1:
                                                Console.Write(" 1. Student ID\n" + " 2. First Name\n" + " 3. Middle Name\n" + " 4. Last Name\n" + " 5. BirthDay\n" + " 6. Address\n" + " 7. Phone\n" + " 8. Email\n" + " 9. Note\n" + " 10. Back To Menu\n");
                                                Console.Write("Your Choice : ");
                                                int ninedetail = int.Parse(Console.ReadLine());
                                                switch (ninedetail)
                                                {
                                                    case 1:
                                                        Console.Write("New Student ID : ");
                                                        int input;
                                                        string inputfname, inputmname, inputlname, inputphone, inputmail;
                                                        while (true)
                                                        {
                                                            var isnumber = int.TryParse(Console.ReadLine(), out input);
                                                            if (IsExists(input, StudentListCount))
                                                            {
                                                                Console.WriteLine("ID already exists!");
                                                                Console.Write(" Re-enter: ");
                                                            }
                                                            else if (!isnumber)
                                                            {
                                                                Console.WriteLine("Student ID cannot have letter!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.StudentID = input;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        Console.Write("New First Name : ");
                                                        while (true)
                                                        {
                                                            inputfname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputfname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.FirstName = inputfname;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        Console.Write("New Middle Name : ");
                                                        while (true)
                                                        {
                                                            inputmname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputmname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.MiddleName = inputmname;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        Console.Write("New Last Name : ");
                                                        while (true)
                                                        {
                                                            inputlname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputlname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.LastName = inputlname;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 5:
                                                        Console.Write("New BirthDay : ");
                                                        updatedit.BirthDay = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 6:
                                                        Console.Write("New Address : ");
                                                        updatedit.Address = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 7:
                                                        Console.Write("New Phone : ");
                                                        while (true)
                                                        {
                                                            inputphone = Console.ReadLine();
                                                            if (Regex.IsMatch(inputphone, @"^[a-zA-Z]+$"))
                                                            {
                                                                Console.WriteLine("Phone number cannot have letter!");
                                                                Console.Write(" Re-enter: ");
                                                            }
                                                            else if (IsExistsPhone(inputphone, StudentListCount))
                                                            {
                                                                Console.WriteLine("Phone number already exists!");
                                                                Console.WriteLine("Phone number cannot have letter!");
                                                                Console.Write(" Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.Phone = inputphone;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 8:
                                                        Console.Write("New Email : ");
                                                        while (true)
                                                        {
                                                            inputmail = Console.ReadLine();
                                                            if (CheckRegexEmail(inputmail))
                                                            {
                                                                Console.WriteLine("Email must have [....]@[....].com!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else if (IsExistsEmail(inputmail, StudentListCount))
                                                            {
                                                                Console.Write("Email already exists!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updatedit.Email = inputmail;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 9:
                                                        Console.Write("New Note : ");
                                                        updatedit.Email = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 10:
                                                        break;
                                                }
                                                WriteFileStudent(fileName, StudentListCount);
                                                break;
                                            case 2:
                                                Console.Write("New Status : ");
                                                updatedit.Status = Console.ReadLine();
                                                WriteFileStudent(fileName, StudentListCount);
                                                Console.WriteLine("Change Completed!");
                                                Console.Write("Press Any Key To Continue");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.Write("New Class : ");
                                                updatedit.ClassNameStudent = Console.ReadLine();
                                                WriteFileStudent(fileName, StudentListCount);
                                                Console.WriteLine("Change Completed!");
                                                Console.Write("Press Any Key To Continue");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student Name Invalid!");
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        if (choose == 2)
                        {
                            Console.Clear();
                            StudentListCount = ReadFileStudent(fileName);
                            while (true)
                            {
                                Console.Write("Input Student ID To Search Or Input 0 To Back To Menu : ");
                                int.TryParse(Console.ReadLine(), out Inputview);
                                if (Inputview == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    StudentInput updated = new StudentInput();
                                    bool exists2 = false;
                                    foreach (StudentInput i in StudentListCount.Values)
                                    {
                                        if (i.StudentID == Inputview)
                                        {
                                            Console.Clear();
                                            updated = i;
                                            inputManager.DisplayInformation(i);
                                            exists2 = true;
                                        }
                                    }
                                    if (exists2)
                                    {
                                        Console.Write(" 1. Update Student Information\n" + " 2. Change Student Status\n" + " 3. Change Class\n" + " 4. Back To !STUDENT LIST MANAGEMENT!\n" + "==================================================\n" + " Your Choice : ");
                                        string detailstr = Console.ReadLine();
                                        int detailchoose;
                                        int.TryParse(detailstr, out detailchoose);
                                        while (detailchoose < 1 || detailchoose > 4)
                                        {
                                            Console.Write("Try Again : ");
                                            detailstr = Console.ReadLine();
                                            int.TryParse(detailstr, out detailchoose);
                                        }
                                        switch (detailchoose)
                                        {
                                            case 1:
                                                Console.Write(" 1. Student ID\n" + " 2. First Name\n" + " 3. Middle Name\n" + " 4. Last Name\n" + " 5. BirthDay\n" + " 6. Address\n" + " 7. Phone\n" + " 8. Email\n" + " 9. Note\n" + " 10. Back To Menu\n");
                                                Console.Write("Your Choice : ");
                                                int ninedetail = int.Parse(Console.ReadLine());
                                                switch (ninedetail)
                                                {
                                                    case 1:
                                                        Console.Write("New Student ID : ");
                                                        int input;
                                                        string inputfname, inputmname, inputlname, inputphone, inputmail;
                                                        while (true)
                                                        {
                                                            var isnumber = int.TryParse(Console.ReadLine(), out input);
                                                            if (IsExists(input, StudentListCount))
                                                            {
                                                                Console.WriteLine("ID already exists!");
                                                                Console.Write(" Re-enter: ");
                                                            }
                                                            else if (!isnumber)
                                                            {
                                                                Console.WriteLine("Student ID cannot have letter!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.StudentID = input;
                                                        break;
                                                    case 2:
                                                        Console.Write("New First Name : ");
                                                        while (true)
                                                        {
                                                            inputfname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputfname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.FirstName = inputfname;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        Console.Write("New Middle Name : ");
                                                        while (true)
                                                        {
                                                            inputmname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputmname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.FirstName = inputmname;
                                                        updated.MiddleName = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        Console.Write("New Last Name : ");
                                                        while (true)
                                                        {
                                                            inputlname = Console.ReadLine();
                                                            if (Regex.IsMatch(inputlname, @"\d"))
                                                            {
                                                                Console.WriteLine("Name cannot have number!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.LastName = inputlname;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 5:
                                                        Console.Write("New BirthDay : ");
                                                        updated.BirthDay = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 6:
                                                        Console.Write("New Address : ");
                                                        updated.Address = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 7:
                                                        Console.Write("New Phone : ");
                                                        while (true)
                                                        {
                                                            inputphone = Console.ReadLine();
                                                            if (Regex.IsMatch(inputphone, @"^[a-zA-Z]+$"))
                                                            {
                                                                Console.WriteLine("Phone number cannot have letter!");
                                                                Console.Write(" Re-enter: ");
                                                            }
                                                            else if (IsExistsPhone(inputphone, StudentListCount))
                                                            {
                                                                Console.WriteLine("Phone number already exists!");
                                                                Console.WriteLine("Phone number cannot have letter!");
                                                                Console.Write(" Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.Phone = inputphone;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 8:
                                                        Console.Write("New Email : ");
                                                        while (true)
                                                        {
                                                            inputmail = Console.ReadLine();
                                                            if (CheckRegexEmail(inputmail))
                                                            {
                                                                Console.WriteLine("Email must have [....]@[....].com!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else if (IsExistsEmail(inputmail, StudentListCount))
                                                            {
                                                                Console.Write("Email already exists!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        updated.Email = inputmail;
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 9:
                                                        Console.Write("New Note : ");
                                                        updated.Email = Console.ReadLine();
                                                        Console.WriteLine("Update Completed!");
                                                        Console.Write("Press Any Key To Continue");
                                                        Console.ReadLine();
                                                        break;
                                                    case 10:
                                                        break;
                                                }
                                                WriteFileStudent(fileName, StudentListCount);
                                                Console.WriteLine("Update Completed!");
                                                Console.Write("Press Any Key To Continue");
                                                Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.Write("New Status : ");
                                                updated.Status = Console.ReadLine();
                                                WriteFileStudent(fileName, StudentListCount);
                                                Console.WriteLine("Change Completed!");
                                                Console.Write("Press Any Key To Continue");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.Write("New Class : ");
                                                updated.ClassNameStudent = Console.ReadLine();
                                                WriteFileStudent(fileName, StudentListCount);
                                                Console.WriteLine("Change Completed!");
                                                Console.Write("Press Any Key To Continue");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student ID Invalid!");
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        int detailchooseview, ninedetailview;
                        StudentListCount = ReadFileStudent(fileName);
                        if (StudentListCount.Count <= 0)
                        {
                            Console.WriteLine(" Student not found!");
                            Console.Write("Press enter key to continue...");
                            Console.ReadLine();
                            continue;
                        }
                        Console.Clear();
                        StudentInput updatestudent = new StudentInput();
                        inputManager.DisplayStudentList(StudentListCount);
                        while (true)
                        {
                            Console.Write("Input Student ID To View Detail Or Input 0 To Back To Menu : ");
                            int.TryParse(Console.ReadLine(), out Inputview);
                            if (Inputview == 0)
                            {
                                break;
                            }
                            else
                            {
                                bool exists = false;
                                foreach (StudentInput i in StudentListCount.Values)
                                {
                                    if (i.StudentID == Inputview)
                                    {
                                        Console.Clear();
                                        updatestudent = i;
                                        inputManager.DisplayInformation(i);
                                        exists = true;
                                    }
                                }
                                if (exists)
                                {
                                    Console.Write(" 1. Update Student Information\n" + " 2. Change Student Status\n" + " 3. Change Class\n" + " 4. Back To !STUDENT LIST MANAGEMENT!\n" + "==================================================\n" + " Your Choice : ");
                                    int.TryParse(Console.ReadLine(), out detailchooseview);
                                    while (detailchooseview < 1 || detailchooseview > 4)
                                    {
                                        Console.Write("Try Again : ");
                                        int.TryParse(Console.ReadLine(), out detailchooseview);
                                    }
                                    switch (detailchooseview)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.Write(" 1. Student ID\n" + " 2. First Name\n" + " 3. Middle Name\n" + " 4. Last Name\n" + " 5. BirthDay\n" + " 6. Address\n" + " 7. Phone\n" + " 8. Email\n" + " 9. Note\n" + " 10. Back To Menu\n" + " Your Choice : ");
                                            int.TryParse(Console.ReadLine(), out ninedetailview);
                                            switch (ninedetailview)
                                            {
                                                case 1:
                                                    Console.Write("New Student ID : ");
                                                    int input;
                                                    string inputfname, inputmname, inputlname, inputphone, inputmail;
                                                    while (true)
                                                    {
                                                        var isnumber = int.TryParse(Console.ReadLine(), out input);
                                                        if (IsExists(input, StudentListCount))
                                                        {
                                                            Console.WriteLine("ID already exists!");
                                                            Console.Write(" Re-enter: ");
                                                        }
                                                        else if (!isnumber)
                                                        {
                                                            Console.WriteLine("Student ID cannot have letter!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.StudentID = input;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.Write("New First Name : ");
                                                    while (true)
                                                    {
                                                        inputfname = Console.ReadLine();
                                                        if (Regex.IsMatch(inputfname, @"\d"))
                                                        {
                                                            Console.WriteLine("Name cannot have number!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.FirstName = inputfname;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 3:
                                                    Console.Write("New Middle Name : ");
                                                    while (true)
                                                    {
                                                        inputmname = Console.ReadLine();
                                                        if (Regex.IsMatch(inputmname, @"\d"))
                                                        {
                                                            Console.WriteLine("Name cannot have number!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.MiddleName = inputmname;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 4:
                                                    Console.Write("New Last Name : ");
                                                    while (true)
                                                    {
                                                        inputlname = Console.ReadLine();
                                                        if (Regex.IsMatch(inputlname, @"\d"))
                                                        {
                                                            Console.WriteLine("Name cannot have number!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.LastName = inputlname;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 5:
                                                    Console.Write("New BirthDay : ");
                                                    updatestudent.BirthDay = Console.ReadLine();
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 6:
                                                    Console.Write("New Address : ");
                                                    updatestudent.Address = Console.ReadLine();
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 7:
                                                    Console.Write("New Phone : ");
                                                    while (true)
                                                    {
                                                        inputphone = Console.ReadLine();
                                                        if (Regex.IsMatch(inputphone, @"^[a-zA-Z]+$"))
                                                        {
                                                            Console.WriteLine("Phone number cannot have letter!");
                                                            Console.Write(" Re-enter: ");
                                                        }
                                                        else if (IsExistsPhone(inputphone, StudentListCount))
                                                        {
                                                            Console.WriteLine("Phone number already exists!");
                                                            Console.WriteLine("Phone number cannot have letter!");
                                                            Console.Write(" Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.Phone = inputphone;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 8:
                                                    Console.Write("New Email : ");
                                                    while (true)
                                                    {
                                                        inputmail = Console.ReadLine();
                                                        if (CheckRegexEmail(inputmail))
                                                        {
                                                            Console.WriteLine("Email must have [....]@[....].com!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else if (IsExistsEmail(inputmail, StudentListCount))
                                                        {
                                                            Console.Write("Email already exists!");
                                                            Console.Write("Re-enter : ");
                                                        }
                                                        else { break; }
                                                    }
                                                    updatestudent.Email = inputmail;
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 9:
                                                    Console.Write("New Note : ");
                                                    updatestudent.Note = Console.ReadLine();
                                                    Console.WriteLine("Update Completed!");
                                                    Console.Write("Press Any Key To Continue");
                                                    Console.ReadLine();
                                                    break;
                                                case 10:
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.Write("New Status : ");
                                            updatestudent.Status = Console.ReadLine();
                                            Console.WriteLine("Change Completed!");
                                            Console.Write("Press Any Key To Continue");
                                            Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.Clear();
                                            Console.Write("New Class : ");
                                            updatestudent.ClassNameStudent = Console.ReadLine();
                                            Console.WriteLine("Change Completed!");
                                            Console.Write("Press Any Key To Continue");
                                            Console.ReadLine();
                                            break;
                                        case 4:
                                            break;
                                    }
                                    WriteFileStudent(fileName, StudentListCount);
                                    break;
                                }
                                else
                                {
                                    Console.Write("Student ID Invalid\nPress any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                    case 4:
                        break;
                }
            } while (choice != 4);
        }
        static void MenuClass()
        {
            ClassManager classManager = new ClassManager();
            ClassInput classinputManager = new ClassInput();
            string classinput;
            string fileName = "Students.json";
            string fileName2 = "Class.json";
            int choice, yesno;
            string stri;
            string titleup = ("============================================");
            string title = ("  ---  VTC ACADEMY STUDENT MANAGEMENT  ---  ");
            string[] menu = new string[] { "  CLASSES MANAGEMENT", "============================================", "1. ADD CLASSES", "2. STUDYING CLASSES", "3. COMPLETED CLASSES", "4. CLOSED CLASSES", "5. ALL CLASSES", "6. BACK TO MAIN MENU", "============================================" };
            do
            {
                choice = Menu(titleup, title, menu);
                switch (choice)
                {
                    case 1:
                        do
                        {
                            if (classManager.AddClass(NewClass(ClassListCount)))
                            {
                                Console.WriteLine("ADDED SUCCESSFULLY !!!");
                                WriteFileClass(fileName2, ClassListCount);
                            }
                            else Console.WriteLine("ADDED INCOMPLETE");
                            Console.Write("Do You Want To Continue ? (1/2) : ");
                            stri = Console.ReadLine();
                            int.TryParse(stri, out yesno);
                        } while (yesno != 2);
                        break;
                    case 2:
                        ClassListCount = ReadFileClass(fileName2);
                        StudentListCount = ReadFileStudent(fileName);
                        ClassInput classstudy = new ClassInput();
                        StudentInput studentstudy = new StudentInput();
                        bool study = false;
                        while (true)
                        {
                            foreach (ClassInput i in ClassListCount.Values)
                            {
                                if (i.StatusClass == "studying")
                                {
                                    Console.Clear();
                                    study = true;
                                    classstudy = i;
                                    i.DisplayClassStudying(ClassListCount);
                                }
                            }
                            if (study)
                            {
                                while (true)
                                {
                                    Console.Write("Input Class To View Detail Or Input 0 To Back To Menu : ");
                                    classinput = Console.ReadLine();
                                    if (classinput == "0")
                                    {
                                        break;
                                    }
                                    bool found8 = false;
                                    bool found77 = false;
                                    foreach (ClassInput y in ClassListCount.Values)
                                    {
                                        if (y.StatusClass == "studying")
                                        {
                                            found77 = true;
                                            if (string.Compare(y.ClassName, classinput, true) == 0)
                                            {
                                                Console.Clear();
                                                found8 = true;
                                                classstudy.DisplayClassInformation(y);
                                            }
                                        }
                                    }
                                    if (!found77)
                                    {
                                        Console.Write("Invalid Class, Re-enter : ");
                                        classinput = Console.ReadLine();
                                    }
                                    if (found8)
                                    {
                                        Console.Write(" 1. Update Class Information\n" + " 2. Change Class Status\n" + " 3. Show Student List\n" + " 4. Back To Classes Management\n" + "==================================================\n" + " Your Choice : ");
                                        int chooseif = int.Parse(Console.ReadLine());
                                        while (chooseif < 1 || chooseif > 4)
                                        {
                                            Console.Write("Try Again : ");
                                            chooseif = int.Parse(Console.ReadLine());
                                        }
                                        switch (chooseif)
                                        {
                                            case 1:
                                                Console.Clear();
                                                DateTime inputfrom, inputto;
                                                string input1, inputstatus, inputclassroom;
                                                Console.Write("Which Type Do You Want To Update ?\n" + " 1. Class Name\n" + " 2. StudyDay\n" + " 3. StudyTime\n" + " 4. ClassRoom\n" + " 5. Falcuty\n" + " 6. Back To Menu\n");
                                                Console.Write("Your Choice : ");
                                                int choicewy = int.Parse(Console.ReadLine());
                                                while (choicewy < 1 || choicewy > 7)
                                                {
                                                    Console.Write("Try Again : ");
                                                    choicewy = int.Parse(Console.ReadLine());
                                                }
                                                switch (choicewy)
                                                {
                                                    case 1:
                                                        Console.Write(" New Class Name : ");
                                                        while (true)
                                                        {
                                                            input1 = Console.ReadLine();
                                                            if (IsExistsClass(input1, ClassListCount))
                                                            {
                                                                Console.WriteLine("Class Name Already Exists!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy.ClassName = input1;
                                                        Console.Write("Update Complete!\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    case 2:
                                                        Console.Write(" New Study Day : ");
                                                        classstudy.StudyDay = Console.ReadLine();
                                                        Console.Write("Update Complete!\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    case 3:
                                                        Console.Write(" New Study Time\nFrom(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess1 = DateTime.TryParse(Console.ReadLine(), out inputfrom);
                                                            if (!chess1)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy.StudyTime = inputfrom;
                                                        Console.Write("To(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess2 = DateTime.TryParse(Console.ReadLine(), out inputto);
                                                            if (!chess2)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else if (inputto < inputfrom)
                                                            {
                                                                Console.WriteLine("Study Time Invalid!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy.StudyTime2 = inputto;
                                                        Console.Write("Update Complete!\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    case 4:
                                                        Console.Write("New ClassRoom : ");
                                                        while (true)
                                                        {
                                                            inputclassroom = Console.ReadLine();
                                                            if (IsExistsClassroom(inputclassroom, ClassListCount))
                                                            {
                                                                Console.WriteLine("This Classroom Has It Owner!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy.ClassRoom = inputclassroom;
                                                        Console.Write("Update Complete!\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    case 5:
                                                        Console.Write("New Falcuty : ");
                                                        classstudy.Falcuty = Console.ReadLine();
                                                        Console.Write("Update Complete!\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    case 6:
                                                        break;
                                                }
                                                WriteFileClass(fileName2, ClassListCount);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.Write("(closed/completed/studying)\nNew Status : ");
                                                while (true)
                                                {
                                                    inputstatus = Console.ReadLine();
                                                    if (!CheckClassStatus(inputstatus))
                                                    {
                                                        Console.WriteLine("Invalid Status! Only (closed/completed/studying)");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                classstudy.StatusClass = inputstatus;
                                                WriteFileClass(fileName2, ClassListCount);
                                                Console.Write("Update Complete!\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                bool found10 = false;
                                                foreach (StudentInput ke in StudentListCount.Values)
                                                {
                                                    foreach (ClassInput ka in ClassListCount.Values)
                                                    {

                                                        if (ka.ClassName == ke.ClassNameStudent)
                                                        {
                                                            Console.Clear();
                                                            found10 = true;
                                                            ke.DisplayStudentListWithClass(StudentListCount, classinput);
                                                        }
                                                    }
                                                }
                                                if (found10)
                                                {
                                                    Console.Write("Press Any Key To Continue....");
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Student Not Found");
                                                    Console.Write("Press Enter To Continue....");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid class!");
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Studying Class Empty!");
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;
                    case 3:
                        ClassListCount = ReadFileClass(fileName2);
                        StudentListCount = ReadFileStudent(fileName);
                        ClassInput classstudy2 = new ClassInput();
                        StudentInput studentstudy2 = new StudentInput();
                        bool study2 = false;
                        while (true)
                        {
                            foreach (ClassInput g in ClassListCount.Values)
                            {
                                if (g.StatusClass == "completed")
                                {
                                    Console.Clear();
                                    study2 = true;
                                    classstudy2 = g;
                                    g.DisplayClassCompleted(ClassListCount);
                                }
                            }
                            if (study2)
                            {
                                while (true)
                                {
                                    Console.Write("Input Class To View Detail Or Input 0 To Back To Menu : ");
                                    classinput = Console.ReadLine();
                                    if (classinput == "0")
                                    {
                                        break;
                                    }
                                    bool found7 = false;
                                    bool found88 = false;
                                    foreach (ClassInput y in ClassListCount.Values)
                                    {
                                        if (y.StatusClass == "completed")
                                        {
                                            found88 = true;
                                            if (string.Compare(y.ClassName, classinput, true) == 0)
                                            {
                                                Console.Clear();
                                                found7 = true;
                                                classstudy2.DisplayClassInformation(y);
                                            }
                                        }
                                    }
                                    if (!found88)
                                    {
                                        Console.Write("Invalid Class, Re-enter : ");
                                        classinput = Console.ReadLine();
                                    }
                                    if (found7)
                                    {
                                        Console.Write(" 1. Update Class Information\n" + " 2. Change Class Status\n" + " 3. Show Student List\n" + " 4. Back To Classes Management\n" + "==================================================\n" + " Your Choice : ");
                                        int chooseif = int.Parse(Console.ReadLine());
                                        while (chooseif < 1 || chooseif > 4)
                                        {
                                            Console.Write("Try Again : ");
                                            chooseif = int.Parse(Console.ReadLine());
                                        }
                                        switch (chooseif)
                                        {
                                            case 1:
                                                Console.Clear();
                                                DateTime inputfrom, inputto;
                                                string input1, inputstatus, inputclassroom;
                                                Console.Write("Which Type Do You Want To Update ?\n" + " 1. Class Name\n" + " 2. StudyDay\n" + " 3. StudyTime\n" + " 4. ClassRoom\n" + " 5. Falcuty\n" + " 6. Back To Menu\n");
                                                Console.Write("Your Choice : ");
                                                int choicewy = int.Parse(Console.ReadLine());
                                                while (choicewy < 1 || choicewy > 7)
                                                {
                                                    Console.Write("Try Again : ");
                                                    choicewy = int.Parse(Console.ReadLine());
                                                }
                                                switch (choicewy)
                                                {
                                                    case 1:
                                                        Console.Write(" New Class Name : ");
                                                        while (true)
                                                        {
                                                            input1 = Console.ReadLine();
                                                            if (IsExistsClass(input1, ClassListCount))
                                                            {
                                                                Console.WriteLine("Class Name Already Exists!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy2.ClassName = input1;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        Console.Write(" New Study Day : ");
                                                        classstudy2.StudyDay = Console.ReadLine();
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        Console.Write(" New Study Time\nFrom(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess1 = DateTime.TryParse(Console.ReadLine(), out inputfrom);
                                                            if (!chess1)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy2.StudyTime = inputfrom;
                                                        Console.Write("To(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess2 = DateTime.TryParse(Console.ReadLine(), out inputto);
                                                            if (!chess2)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else if (inputto < inputfrom)
                                                            {
                                                                Console.WriteLine("Study Time Invalid!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy2.StudyTime2 = inputto;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        Console.Write("New ClassRoom : ");
                                                        while (true)
                                                        {
                                                            inputclassroom = Console.ReadLine();
                                                            if (IsExistsClassroom(inputclassroom, ClassListCount))
                                                            {
                                                                Console.WriteLine("This Classroom Has It Owner!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy2.ClassRoom = inputclassroom;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 5:
                                                        Console.Write("New Falcuty : ");
                                                        classstudy2.Falcuty = Console.ReadLine();
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 6:
                                                        break;
                                                }
                                                WriteFileClass(fileName2, ClassListCount);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.Write("(closed/completed/studying)\nNew Status : ");
                                                while (true)
                                                {
                                                    inputstatus = Console.ReadLine();
                                                    if (!CheckClassStatus(inputstatus))
                                                    {
                                                        Console.WriteLine("Invalid Status! Only (closed/completed/studying)");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                classstudy2.StatusClass = inputstatus;
                                                WriteFileClass(fileName2, ClassListCount);
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                bool found10 = false;
                                                foreach (StudentInput ka in StudentListCount.Values)
                                                {
                                                    foreach (ClassInput ke in ClassListCount.Values)
                                                    {
                                                        if (ke.ClassName.Equals(ka.ClassNameStudent))
                                                        {
                                                            Console.Clear();
                                                            found10 = true;
                                                            ka.DisplayStudentListWithClass(StudentListCount, classinput);
                                                        }
                                                    }
                                                }
                                                if (found10)
                                                {
                                                    Console.Write("Press Any Key To Continue....");
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Student Not Found");
                                                    Console.Write("Press Any Key To Continue....");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid class!");
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Completed Class Empty!");
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;
                    case 4:
                        StudentListCount = ReadFileStudent(fileName);
                        ClassListCount = ReadFileClass(fileName2);
                        ClassInput classstudy3 = new ClassInput();
                        StudentInput studentstudy3 = new StudentInput();
                        bool study3 = false;
                        while (true)
                        {
                            foreach (ClassInput i in ClassListCount.Values)
                            {
                                if (i.StatusClass == "closed")
                                {
                                    Console.Clear();
                                    study3 = true;
                                    i.DisplayClassClosed(ClassListCount);
                                }
                            }
                            if (study3)
                            {
                                while (true)
                                {
                                    Console.Write("Input Class To View Detail Or Input 0 To Back To Menu : ");
                                    classinput = Console.ReadLine();
                                    if (classinput == "0")
                                    {
                                        break;
                                    }
                                    bool found6 = false;
                                    bool found99 = false;
                                    foreach (ClassInput y in ClassListCount.Values)
                                    {
                                        if (y.StatusClass == "closed")
                                        {
                                            found99 = true;
                                            if (string.Compare(y.ClassName, classinput, true) == 0)
                                            {
                                                Console.Clear();
                                                found6 = true;
                                                classstudy3 = y;
                                                classstudy3.DisplayClassInformation(y);
                                            }
                                        }
                                    }
                                    if (!found99)
                                    {
                                        Console.Write("Invalid Class, Re-enter : ");
                                        classinput = Console.ReadLine();
                                    }
                                    if (found6)
                                    {
                                        Console.Write(" 1. Update Class Information\n" + " 2. Change Class Status\n" + " 3. Show Student List\n" + " 4. Back To Classes Management\n" + "==================================================\n" + " Your Choice : ");
                                        int chooseif = int.Parse(Console.ReadLine());
                                        while (chooseif < 1 || chooseif > 4)
                                        {
                                            Console.Write("Try Again : ");
                                            chooseif = int.Parse(Console.ReadLine());
                                        }
                                        switch (chooseif)
                                        {
                                            case 1:
                                                Console.Clear();
                                                DateTime inputfrom, inputto;
                                                string input1, inputstatus, inputclassroom;
                                                Console.Write("Which Type Do You Want To Update ?\n" + " 1. Class Name\n" + " 2. StudyDay\n" + " 3. StudyTime\n" + " 4. ClassRoom\n" + " 5. Falcuty\n" + " 6. Back To Menu\n");
                                                Console.Write("Your Choice : ");
                                                int choicewy = int.Parse(Console.ReadLine());
                                                while (choicewy < 1 || choicewy > 7)
                                                {
                                                    Console.Write("Try Again : ");
                                                    choicewy = int.Parse(Console.ReadLine());
                                                }
                                                switch (choicewy)
                                                {
                                                    case 1:
                                                        Console.Write(" New Class Name : ");
                                                        while (true)
                                                        {
                                                            input1 = Console.ReadLine();
                                                            if (IsExistsClass(input1, ClassListCount))
                                                            {
                                                                Console.WriteLine("Class Name Already Exists!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy3.ClassName = input1;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        Console.Write(" New Study Day : ");
                                                        classstudy3.StudyDay = Console.ReadLine();
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        Console.Write(" New Study Time\nFrom(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess1 = DateTime.TryParse(Console.ReadLine(), out inputfrom);
                                                            if (!chess1)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy3.StudyTime = inputfrom;
                                                        Console.Write("To(00:00) : ");
                                                        while (true)
                                                        {
                                                            var chess2 = DateTime.TryParse(Console.ReadLine(), out inputto);
                                                            if (!chess2)
                                                            {
                                                                Console.WriteLine("Invalid format!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else if (inputto < inputfrom)
                                                            {
                                                                Console.WriteLine("Study Time Invalid!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy3.StudyTime2 = inputto;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        Console.Write("New ClassRoom : ");
                                                        while (true)
                                                        {
                                                            inputclassroom = Console.ReadLine();
                                                            if (IsExistsClassroom(inputclassroom, ClassListCount))
                                                            {
                                                                Console.WriteLine("This Classroom Has It Owner!");
                                                                Console.Write("Re-enter : ");
                                                            }
                                                            else { break; }
                                                        }
                                                        classstudy3.ClassRoom = inputclassroom;
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 5:
                                                        Console.Write("New Falcuty : ");
                                                        classstudy3.Falcuty = Console.ReadLine();
                                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                                        Console.ReadLine();
                                                        break;
                                                    case 6:
                                                        break;
                                                }
                                                WriteFileClass(fileName2, StudentListCount);
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.Write("(closed/completed/studying)\nNew Status : ");
                                                while (true)
                                                {
                                                    inputstatus = Console.ReadLine();
                                                    if (!CheckClassStatus(inputstatus))
                                                    {
                                                        Console.WriteLine("Invalid Status! Only (closed/completed/studying)");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                classstudy3.StatusClass = inputstatus;
                                                WriteFileClass(fileName2, StudentListCount);
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                bool found10 = false;
                                                foreach (StudentInput ke in StudentListCount.Values)
                                                {
                                                    foreach (ClassInput ka in ClassListCount.Values)
                                                    {
                                                        if (ke.ClassNameStudent == ka.ClassName)
                                                        {
                                                            Console.Clear();
                                                            found10 = true;
                                                            ke.DisplayStudentListWithClass(StudentListCount, classinput);
                                                        }
                                                    }
                                                }
                                                if (found10)
                                                {
                                                    Console.Write("Press Any Key To Continue....");
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Student Not Found!");
                                                    Console.Write("Press any key to continue...");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 4:
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid class!");
                                        Console.Write("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Closed Class Empty!");
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;
                    case 5:
                        StudentListCount = ReadFileStudent(fileName);
                        ClassListCount = ReadFileClass(fileName2);
                        if (ClassListCount.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(" Class List Empty!");
                            Console.Write("Press enter key to continue...");
                            Console.ReadLine();
                            continue;
                        }
                        ClassInput ClassShow = new ClassInput();
                        StudentInput StudentShow = new StudentInput();
                        Console.Clear();
                        ClassShow.DisplayClassList(ClassListCount);
                        while (true)
                        {
                            Console.Write("Input Class To View Detail Or Input 0 To Back To Menu : ");
                            classinput = Console.ReadLine();
                            if (classinput == "0")
                            {
                                break;
                            }
                            bool found = false;
                            foreach (ClassInput i in ClassListCount.Values)
                            {
                                if (string.Compare(i.ClassName, classinput, true) == 0)
                                {
                                    Console.Clear();
                                    found = true;
                                    ClassShow = i;
                                    ClassShow.DisplayClassInformation(i);
                                }
                            }
                            if (found)
                            {
                                Console.Write(" 1. Update Class Information\n" + " 2. Change Class Status\n" + " 3. Show Student List\n" + " 4. Back To Classes Management\n" + "==================================================\n" + " Your Choice : ");
                                int chooseif = int.Parse(Console.ReadLine());
                                while (chooseif < 1 || chooseif > 4)
                                {
                                    Console.Write("Try Again : ");
                                    chooseif = int.Parse(Console.ReadLine());
                                }
                                switch (chooseif)
                                {
                                    case 1:
                                        Console.Clear();
                                        DateTime inputfrom, inputto;
                                        string input1, inputstatus, inputclassroom;
                                        Console.Write("Which Type Do You Want To Update ?\n" + " 1. Class Name\n" + " 2. StudyDay\n" + " 3. StudyTime\n" + " 4. ClassRoom\n" + " 5. Falcuty\n" + " 6. Back To Menu\n");
                                        Console.Write("Your Choice : ");
                                        int choicewy = int.Parse(Console.ReadLine());
                                        while (choicewy < 1 || choicewy > 7)
                                        {
                                            Console.Write("Try Again : ");
                                            choicewy = int.Parse(Console.ReadLine());
                                        }
                                        switch (choicewy)
                                        {
                                            case 1:
                                                Console.Write(" New Class Name : ");
                                                while (true)
                                                {
                                                    input1 = Console.ReadLine();
                                                    if (IsExistsClass(input1, ClassListCount))
                                                    {
                                                        Console.WriteLine("Class Name Already Exists!");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                ClassShow.ClassName = input1;
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.Write(" New Study Day : ");
                                                ClassShow.StudyDay = Console.ReadLine();
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.Write(" New Study Time\nFrom(00:00) : ");
                                                while (true)
                                                {
                                                    var chess1 = DateTime.TryParse(Console.ReadLine(), out inputfrom);
                                                    if (!chess1)
                                                    {
                                                        Console.WriteLine("Invalid format!");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                ClassShow.StudyTime = inputfrom;
                                                Console.Write("To(00:00) : ");
                                                while (true)
                                                {
                                                    var chess2 = DateTime.TryParse(Console.ReadLine(), out inputto);
                                                    if (!chess2)
                                                    {
                                                        Console.WriteLine("Invalid format!");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else if (inputto < inputfrom)
                                                    {
                                                        Console.WriteLine("Study Time Invalid!");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                ClassShow.StudyTime2 = inputto;
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                Console.Write("New ClassRoom : ");
                                                while (true)
                                                {
                                                    inputclassroom = Console.ReadLine();
                                                    if (IsExistsClassroom(inputclassroom, ClassListCount))
                                                    {
                                                        Console.WriteLine("This Classroom Has It Owner!");
                                                        Console.Write("Re-enter : ");
                                                    }
                                                    else { break; }
                                                }
                                                ClassShow.ClassRoom = inputclassroom;
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 5:
                                                Console.Write("New Falcuty : ");
                                                ClassShow.Falcuty = Console.ReadLine();
                                                Console.Write("Update Completed!\nPress Enter To Continue...");
                                                Console.ReadLine();
                                                break;
                                            case 6:
                                                break;
                                        }
                                        WriteFileClass(fileName2, ClassListCount);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("(closed/completed/studying)\nNew Status : ");
                                        while (true)
                                        {
                                            inputstatus = Console.ReadLine();
                                            if (!CheckClassStatus(inputstatus))
                                            {
                                                Console.WriteLine("Invalid Status! Only (closed/completed/studying)");
                                                Console.Write("Re-enter : ");
                                            }
                                            else { break; }
                                        }
                                        ClassShow.StatusClass = inputstatus;
                                        WriteFileClass(fileName2, ClassListCount);
                                        Console.Write("Update Completed!\nPress Enter To Continue...");
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        bool found13 = false;
                                        foreach (StudentInput ka in StudentListCount.Values)
                                        {
                                            foreach (ClassInput ke in ClassListCount.Values)
                                            {
                                                if (ke.ClassName == ka.ClassNameStudent)
                                                {
                                                    Console.Clear();
                                                    found13 = true;
                                                    ka.DisplayStudentListWithClass(StudentListCount, classinput);
                                                }
                                            }
                                        }
                                        if (found13)
                                        {
                                            Console.Write("Press any key to continue...");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Student Not Found!");
                                            Console.Write("Press any key to continue...");
                                            Console.ReadKey();
                                        }
                                        break;
                                    case 4:
                                        break;
                                }
                                WriteFileStudent(fileName, StudentListCount);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Class!");
                                Console.Write("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 6:
                        break;
                }
            } while (choice != 6);
        }
        public static bool WriteFileStudent<StudentInput>(string fileName, Dictionary<int, StudentInput> dict)
        {
            if (dict == null)
            {
                return false;
            }
            string FileW = JsonSerializer.Serialize(dict);
            File.WriteAllText(fileName, FileW);
            return true;
        }
        public static bool WriteFileClass<ClassInput>(string fileName2, Dictionary<int, ClassInput> dact)
        {
            if (dact == null)
            {
                return false;
            }
            string FileW = JsonSerializer.Serialize(dact);
            File.WriteAllText(fileName2, FileW);
            return true;
        }
        public static Dictionary<int, StudentInput> ReadFileStudent(string fileName)
        {
            Dictionary<int, StudentInput> dict = new Dictionary<int, StudentInput>();
            if (!File.Exists(fileName))
            {
                return dict;
            }
            else
            {
                string FileR = File.ReadAllText(fileName);
                try
                {
                    dict = JsonSerializer.Deserialize<Dictionary<int, StudentInput>>(FileR);
                }
                catch
                {
                    return dict;
                }
                return dict;
            }
        }
        public static Dictionary<int, ClassInput> ReadFileClass(string fileName2)
        {
            Dictionary<int, ClassInput> dact = new Dictionary<int, ClassInput>();
            if (!File.Exists(fileName2))
            {
                return dact;
            }
            else
            {
                string FileR = File.ReadAllText(fileName2);
                try
                {
                    dact = JsonSerializer.Deserialize<Dictionary<int, ClassInput>>(FileR);
                }
                catch
                {
                    return dact;
                }
                return dact;
            }
        }
        static bool CheckRegexEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.([A-Z]{2,4})$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(email)) return false;
            return true;
        }
        static bool IsExists(int studentID, Dictionary<int, StudentInput> contact)
        {
            foreach (var student in contact.Values)
            {
                if (student.StudentID == studentID) return true;
            }
            return false;
        }
        static bool IsExistsPhone(string phone, Dictionary<int, StudentInput> contact)
        {
            foreach (var phoned in contact.Values)
            {
                if (phoned.Phone == phone) return true;
            }
            return false;
        }
        static bool IsExistsEmail(string email, Dictionary<int, StudentInput> contact)
        {
            foreach (var emails in contact.Values)
            {
                if (emails.Email == email) return true;
            }
            return false;
        }
        static bool IsExistsClass(string className, Dictionary<int, ClassInput> contact)
        {
            foreach (var classnamein in contact.Values)
            {
                if (classnamein.ClassName == className) return true;
            }
            return false;
        }
        static bool IsExistsClassroom(string classname, Dictionary<int, ClassInput> classroom)
        {
            foreach (var classnamed in classroom.Values)
            {
                if (classnamed.ClassRoom == classname) return true;
            }
            return false;
        }
        static bool CheckClassStatus(string status)
        {
            if (status == "closed" || status == "completed" || status == "studying" || status == "Closed" || status == "Completed" || status == "studying") return true;
            return false;
        }
        static void Main(string[] args)
        {
            int choice;
            string titleup = ("============================================");
            string title = ("  ---  VTC ACADEMY STUDENT MANAGEMENT  ---  ");
            string[] menu = new string[] { "============================================", "1. STUDENT LIST MANAGEMENT", "2. CLASSES MANAGEMENT", "3. EXIT APPLICATION", "============================================" };
            do
            {
                choice = Menu(titleup, title, menu);
                switch (choice)
                {
                    case 1:
                        MenuStudent();
                        break;
                    case 2:
                        MenuClass();
                        break;
                    case 3:
                        break;
                }
            } while (choice != 3);
        }
    }
}