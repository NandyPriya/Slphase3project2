using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sl_phase3project2.Models
{
    public class SubjectModel
    {
        private int _subjectid;

        public int Subjectid
        {
            get { return _subjectid; }
            set { _subjectid = value; }
        }

        private string _subname;

        public string Subname
        {
            get { return _subname; }
            set { _subname = value; }
        }
        private string _class1;

        public string Class1
        {
            get { return _class1; }
            set { _class1 = value; }
        }
    }
}