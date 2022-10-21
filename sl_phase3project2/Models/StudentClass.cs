using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sl_phase3project2.Models
{
    public class StudentClass
    {
        private int _studentid;
        public int Studentid
        {
            get { return _studentid; }
            set { _studentid = value; }
        }
        private string _studname;

        public string Studname
        {
            get { return _studname; }
            set { _studname = value; }
        }
        private string _class;

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}