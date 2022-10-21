using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sl_phase3project2.Models
{
    public class ClassesModel
    {
        private string _classname;

        public string Classname
        {
            get { return _classname; }
            set { _classname = value; }
        }
        private int _noofstudents;

        public int Noofstudents
        {
            get { return _noofstudents; }
            set { _noofstudents = value; }
        }
    }
}