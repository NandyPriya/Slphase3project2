using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary2
{
    public class DAL
    {
        public bool InsertStudent(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into student values(@studid,@studname,@class,@email,@address)", cn);
            cmd.Parameters.AddWithValue("@studid", book1.Studentid);
            cmd.Parameters.AddWithValue("@studname", book1.Studname);
            cmd.Parameters.AddWithValue("@class", book1.Class);
            cmd.Parameters.AddWithValue("@email", book1.Email);
            cmd.Parameters.AddWithValue("@address", book1.Address);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }

        public bool UpdateStudent(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdUpdate = new SqlCommand($" update student set studentid = @p_studentid,studname=@p_studname,class =@p_class,email=@p_email,address=@p_address where studentid={book1.Studentid} "
                , cn);

           

            cmdUpdate.Parameters.AddWithValue("@p_studentid", book1.Studentid);
            cmdUpdate.Parameters.AddWithValue("@p_studname", book1.Studname);
            cmdUpdate.Parameters.AddWithValue("@p_class", book1.Class);
            cmdUpdate.Parameters.AddWithValue("@p_email", book1.Email);
            cmdUpdate.Parameters.AddWithValue("@p_address", book1.Address);
            cn.Open();
            int i = cmdUpdate.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }
        public List<BAL> StudentList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  student", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Studentid = Convert.ToInt32(dr["studentid"]);
                    bal.Studname = dr["studname"].ToString();
                    bal.Class = dr["class"].ToString();
                    bal.Email = dr["email"].ToString();
                    bal.Address = dr["address"].ToString();
                    //bal.Availability = Convert.ToInt32(dr["Availibility"]);
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public BAL FindStudent(int empid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand($"select * from student where studentid={empid}", cn);
            

            

            

            cn.Open();
            SqlDataReader dr = cmdSelect.ExecuteReader();
            BAL empfound = new BAL();
            while (dr.Read())
            {
               
                empfound.Studentid = Convert.ToInt32(dr["studentid"]);
                empfound.Studname = dr["studname"].ToString() ;
                empfound.Class = dr["class"].ToString();
                empfound.Email = dr["email"].ToString();
                empfound.Address = dr["address"].ToString();



            }



            cn.Close();
            cn.Dispose();


            return empfound;



        }

        public bool DeleteEmployee(int employee_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand($"delete from student where studentid={employee_id}", cn);
            
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
        public bool InsertSubject(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into subject values(@subid,@subname,@class)", cn);
            cmd.Parameters.AddWithValue("@subid", book1.Subjectid);
            cmd.Parameters.AddWithValue("@subname", book1.Subname);
            cmd.Parameters.AddWithValue("@class", book1.Class1);
           
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }
        public List<BAL> SubjectList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  subject", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Subjectid = Convert.ToInt32(dr["subjectid"]);
                    bal.Subname = dr["subname"].ToString();
                    bal.Class1 = dr["class"].ToString();
                   
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool DeleteSubject(int employee_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand($"delete from subject where subjectid={employee_id}", cn);

            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
        public BAL FindSubject(int empid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand($"select * from subject where subjectid={empid}", cn);






            cn.Open();
            SqlDataReader dr = cmdSelect.ExecuteReader();
            BAL empfound = new BAL();
            while (dr.Read())
            {

                empfound.Subjectid = Convert.ToInt32(dr["subjectid"]);
                empfound.Subname = dr["subname"].ToString();
                empfound.Class1 = dr["class"].ToString();
                



            }



            cn.Close();
            cn.Dispose();


            return empfound;



        }
        public bool UpdateSubject(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdUpdate = new SqlCommand($" update subject set subjectid = @p_subject,subname=@p_subname,class = @p_class1  where subjectid={book1.Subjectid} "
                , cn);



            cmdUpdate.Parameters.AddWithValue("@p_subject", book1.Subjectid);
            cmdUpdate.Parameters.AddWithValue("@p_subname", book1.Subname);
            cmdUpdate.Parameters.AddWithValue("@p_class1", book1.Class1);
            
            cn.Open();
            int i = cmdUpdate.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }

        public List<BAL> ClassesList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  classes", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Classname = dr["classname"].ToString();
                    bal.Noofstudents = Convert.ToInt32(dr["noofstudents"]);
                   
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool InsertClasses(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into classes values(@classname,@noofstudents)", cn);
            cmd.Parameters.AddWithValue("@classname", book1.Classname);
           
            cmd.Parameters.AddWithValue("@noofstudents", book1.Noofstudents);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }
        public BAL FindClasses(string empid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand($"select * from classes where classname='{empid}'", cn);






            cn.Open();
            SqlDataReader dr = cmdSelect.ExecuteReader();
            BAL empfound = new BAL();
            while (dr.Read())
            {

                empfound.Classname = dr["classname"].ToString();
               
                empfound.Noofstudents = Convert.ToInt32(dr["noofstudents"]);




            }



            cn.Close();
            cn.Dispose();


            return empfound;



        }
        public bool DeleteClasses(string employee_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand($"delete from classes where classname='{employee_id}'", cn);

            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
        public bool UpdateClasses(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdUpdate = new SqlCommand($" update classes set classname = @p_classname,noofstudents= @p_noofstudent where classname='{book1.Classname}' "
                , cn);

            cmdUpdate.Parameters.AddWithValue("@p_classname", book1.Classname);
            
            cmdUpdate.Parameters.AddWithValue("@p_noofstudent", book1.Noofstudents);

            cn.Open();
            int i = cmdUpdate.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }
        public bool InsertMarks(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Marks values(@marks,@subjectid,@studentid)", cn);
            cmd.Parameters.AddWithValue("@marks", book1.Marks);
            cmd.Parameters.AddWithValue("@subjectid", book1.Subjectid);
            cmd.Parameters.AddWithValue("@studentid", book1.Studentid);

            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }
        public List<BAL> MarkList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  Marks", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Marks = Convert.ToInt32(dr["marks"]);
                    bal.Subjectid = Convert.ToInt32(dr["subjectid"].ToString());
                    bal.Studentid = Convert.ToInt32(dr["studentid"].ToString());

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool DeleteMarks(int employee_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand($"delete from Marks where marks={employee_id}", cn);

            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
        public BAL FindMark(int empid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand($"select * from marks where marks={empid}", cn);






            cn.Open();
            SqlDataReader dr = cmdSelect.ExecuteReader();
            BAL empfound = new BAL();
            while (dr.Read())
            {

                empfound.Marks = Convert.ToInt32(dr["marks"]);
                empfound.Subjectid = Convert.ToInt32(dr["subjectid"]);
                empfound.Subjectid = Convert.ToInt32(dr["studentid"]);




            }



            cn.Close();
            cn.Dispose();


            return empfound;



        }
        public bool UpdateMarks(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);
            SqlCommand cmdUpdate = new SqlCommand($" update marks set marks = @p_marks,subjectid=@p_subjectid,studentid = @p_studentid  where marks={book1.Marks} "
                , cn);



            cmdUpdate.Parameters.AddWithValue("@p_marks", book1.Marks);
            cmdUpdate.Parameters.AddWithValue("@p_subjectid", book1.Subjectid);
            cmdUpdate.Parameters.AddWithValue("@p_studentid", book1.Studentid);

            cn.Open();
            int i = cmdUpdate.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }

        public List<BAL> MarksList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Schooldb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  marks", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Marks = Convert.ToInt32(dr["marks"]);
                    bal.Subjectid = Convert.ToInt32(dr["subjectid"]);
                    bal.Studentid = Convert.ToInt32(dr["studentid"]);

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }


    }
}

