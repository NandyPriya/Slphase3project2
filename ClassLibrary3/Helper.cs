using ClassLibrary1;
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Helper
    {
        DAL dl = null;
        public Helper()
        {
            dl = new DAL();
        }
        public bool addstudent(BAL book1)
        {
            bool status = dl.InsertStudent(book1);
            Console.WriteLine(status);
            return status;
            //return 
        }
        public bool editstudent(BAL book1)
        {
            bool status = dl.UpdateStudent(book1);
            Console.WriteLine(status);
            return status;
            //return 
        }
        public List<BAL> ShowStudentList()
        {
            return dl.StudentList();
        }
        public BAL SearchEmployee(int empid)
        {
            return dl.FindStudent(empid);
        }
        public bool RemoveEmployee(int employee_id)
        {
            return dl.DeleteEmployee(employee_id);
        }
        public bool addsubject(BAL book1)
        {
            bool status = dl.InsertSubject(book1);
            Console.WriteLine(status);
            return status;
            
        }
        public List<BAL> ShowSubjectList()
        {
            return dl.SubjectList();
        }
        public bool RemoveSubject(int employee_id)
        {
            return dl.DeleteSubject(employee_id);
        }
        public BAL SearchSubject(int empid)
        {
            return dl.FindSubject(empid);
        }
        public bool editsubject(BAL book1)
        {
            bool status = dl.UpdateSubject(book1);
            Console.WriteLine(status);
            return status;
            
        }
        public List<BAL> ShowClassesList()
        {
            return dl.ClassesList();
        }
        public bool addclasses(BAL book1)
        {
            bool status = dl.InsertClasses(book1);
            Console.WriteLine(status);
            return status;

        }
        public BAL SearchClasses(string empid)
        {
            return dl.FindClasses(empid);
        }
        public bool RemoveClasses(string employee_id)
        {
            return dl.DeleteClasses(employee_id);
        }
        public bool editclasses(BAL book1)
        {
            bool status = dl.UpdateClasses(book1);
            Console.WriteLine(status);
            return status;

        }
        public bool addmarks(BAL book1)
        {
            bool status = dl.InsertMarks(book1);
            Console.WriteLine(status);
            return status;
            //return 
        }
        public bool editmarks(BAL book1)
        {
            bool status = dl.UpdateMarks(book1);
            Console.WriteLine(status);
            return status;
            //return 
        }
        public List<BAL> ShowMarkList()
        {
            return dl.MarksList();
        }
        public BAL SearchMark(int empid)
        {
            return dl.FindMark(empid);
        }
        public bool RemoveMark(int employee_id)
        {
            return dl.DeleteMarks(employee_id);
        }

    }
}
