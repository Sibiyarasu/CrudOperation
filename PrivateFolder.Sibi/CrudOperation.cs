using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace PrivateFolder.Sibi
{

    public class CourseDetails
    {

        public string coursename { get; set; }
        public int Duration { get; set; }
        public string University { get; set; }
        public string startDate { get; set; }
        public int seats { get; set; }


    }


    public class CourseInformation

    {
        public readonly string conectionstring;

        public CourseDetails Info()
        {

            CourseDetails S = new CourseDetails();

            Console.WriteLine("Enter Course Name");
            S.coursename = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter  Duration");
            S.Duration = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name of the University");
            S.University = Convert.ToString(Console.ReadLine());


            Console.WriteLine("Enter the course Start Date");
            S.startDate = Convert.ToString(Console.ReadLine());


            Console.WriteLine("Enter  the Number of seats Available");
            S.seats = Convert.ToInt32(Console.ReadLine());
            return S;
        }

        public CourseInformation()
        {
            conectionstring = @"Data source=DESKTOP-TKPKUBE\SQLEXPRESS;Initial catalog=SQL QUERIES;User Id=sa;Password=Anaiyaan@123";
        }


        public void Insert(CourseDetails A)
        {
            try
            {

                SqlConnection con = new SqlConnection(conectionstring);

                con.Open();
                con.Execute($"exec InsertInfo '{A.coursename}',{A.Duration},'{A.University}','{A.startDate}',{A.seats}");

                con.Close();

            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDetails> Select()

        {

            try

            {

                List<CourseDetails> c = new List<CourseDetails>();
                var connection = new SqlConnection(conectionstring);
                connection.Open();
                c = connection.Query<CourseDetails>("select * from CourseDetails").ToList();

                connection.Close();
                foreach (var a in c)
                {
                    Console.WriteLine($" Course Name is - {a.coursename } Duration of the Course is - {a.Duration}   Name of the University is - {a.University}  Course Starting Date is - {a.startDate} Number of Seats Available For the Course is - {a.seats}");
                }

                return c;
            }

            catch (Exception ex)

            {

                throw ex;

            }
        }
    

        public void StoredProcedure()
        {
            int a;

            do
            {

                Console.WriteLine("Choose a option");

                Console.WriteLine("1.InsertSP");
                Console.WriteLine("2.ListSP");
                Console.WriteLine("3.Exit");
            

                a = Convert.ToInt32(Console.ReadLine());


                switch (a)
                {
                    case 1:

                        CourseInformation obj1 = new CourseInformation();

                        var SIBI = obj1.Info();
                        obj1.Insert(SIBI);
                        break;

                    case 2:
                        CourseInformation obj = new CourseInformation();
                        obj.Select();
                        break;

                    default:

                        Console.WriteLine("You are choosing a wrong option for CRUD Operation please select the option any one option ");
                        break;

                }

            } while (a != 0);


        }
    }
}
