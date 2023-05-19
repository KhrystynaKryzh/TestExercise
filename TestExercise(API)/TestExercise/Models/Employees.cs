using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace TestExercise.Models
{   public class Employees
    {
        SqlConnection con = new SqlConnection("server=(LocalDb)\\TestExercise; database=TEST; integrated security= true");
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DateofBirth { get; set; }
        public int SSN { get; set; }


        public List<Employees> GetEmployees() {
            SqlCommand cmd_allemployees = new SqlCommand("Select * from Employees", con);
            List<Employees> employees = new List<Employees>();
            SqlDataReader readAllEmployees = null;
            try
            {
                con.Open();
                readAllEmployees = cmd_allemployees.ExecuteReader();
                while (readAllEmployees.Read())
                {
                    employees.Add(new Employees()
                    {
                        PersonID = Convert.ToInt32(readAllEmployees[0]),
                        FirstName = readAllEmployees[1].ToString(),
                        MiddleInitial = readAllEmployees[2].ToString(),
                        LastName = readAllEmployees[3].ToString(),
                        Address = readAllEmployees[4].ToString(),
                        DateofBirth = readAllEmployees[5].ToString(),
                        SSN = Convert.ToInt32(readAllEmployees[6].ToString())
                    });
                    
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                readAllEmployees.Close();
                con.Close();
            }
            return employees;
        }



        public int AddEmployee
            (string FirstName, string MiddleInitial, string LastName, string Address, string DateOfBirth, Int32 SSN)
        {
            //string Customer_Full_Name = @Customer_First_Name + " "+ Customer_Last_Name;
            SqlCommand cmd_addEmployee = new SqlCommand
                ("INSERT INTO Employees VALUES ( @FirstName, @MiddleInitial,@LastName,@Address,@DateOfBirth,@SSN)", con);
            cmd_addEmployee.Parameters.AddWithValue("@FirstName", FirstName);
            cmd_addEmployee.Parameters.AddWithValue("@MiddleInitial", MiddleInitial);
            cmd_addEmployee.Parameters.AddWithValue("@LastName", LastName);
            cmd_addEmployee.Parameters.AddWithValue("@Address", Address);
            cmd_addEmployee.Parameters.AddWithValue("@DateOfBirth",Convert.ToDateTime( DateOfBirth));
            cmd_addEmployee.Parameters.AddWithValue("@SSN", SSN);
            try
            {
                con.Open();
                return cmd_addEmployee.ExecuteNonQuery();

                //return FirstName + ", Your Account was successfully created!";
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
          
        }

        #region DELETE employee
        public int DeleteEmp(int PersonId)
        {
            SqlCommand cmd_DeleteEmp = new SqlCommand("delete  from Employees where PersonId = @PersonId;", con);
            cmd_DeleteEmp.Parameters.AddWithValue("@PersonId", PersonId);
            try
            {
                con.Open();
                return cmd_DeleteEmp.ExecuteNonQuery();
                
                    //"Deleted Successfully!";
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
                
            }
            finally
            {
                con.Close();
            }
            //return "Deleted Successfully!";
        }
        #endregion

        #region EDIT Employee
        public int EditEmp(int PersonID, string FirstName, string MiddleInitial, string LastName, string Address, 
            string DateOfBirth, Int32 SSN)
        {
            SqlCommand cmd_EditEmp = new SqlCommand
                ("UPDATE Employees SET FirstName=@FirstName,MiddleInitial=@MiddleInitial,LastName=@LastName,Address=@Address,DateOfBirth=@DateOfBirth,SSN=@SSN  WHERE PersonID=@PersonID;", con);
            cmd_EditEmp.Parameters.AddWithValue("@FirstName", FirstName);
            cmd_EditEmp.Parameters.AddWithValue("@MiddleInitial", MiddleInitial);
            cmd_EditEmp.Parameters.AddWithValue("@LastName", LastName);
            cmd_EditEmp.Parameters.AddWithValue("@Address", Address);
            cmd_EditEmp.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(DateOfBirth));
            cmd_EditEmp.Parameters.AddWithValue("@SSN", SSN);
            cmd_EditEmp.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                con.Open();
                return cmd_EditEmp.ExecuteNonQuery();
                //return "Edited Successfully!";
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return "Edited Successfully!";
        }
        #endregion





    }
}
