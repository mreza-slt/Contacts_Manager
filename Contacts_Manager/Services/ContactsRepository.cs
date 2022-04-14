using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Manager
{


    internal class ContactsRepository : IContactsRepository
    {

        private string connectionString = "Data Source=.;Initial Catalog=Contact_db;Integrated Security=true";

        public bool Insert(string name, string family, int age, string email, string mobile, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "Insert Into My_Contact(Name,Family,Age,Email,Mobile,Address) values(@Name,@Family,@Age,@Email,@Mobile,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
       
        public DataTable SelectAll()
        {
            string query = "select * from My_Contact";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();

            adapter.Fill(data);

            return data;
        }

        public bool Delete(int contactId)
        {SqlConnection connection=new SqlConnection(connectionString);
            try
            {
                string query = "Delete From My_Contact Where ContactId=@ID";
                SqlCommand command =new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectRow(int contactId)
        {
            string query = "select * from My_Contact Where ContactId="+contactId;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();

            adapter.Fill(data);

            return data;
        }

        public bool Update(int contactId, string name, string family,int age, string email,string mobile,   string address)
        {

            SqlConnection connection=new SqlConnection(connectionString);

            try
            {
                string query = "Update My_Contact Set Name=@Name,Family=@Family,Age=@Age,Email=@Email,Mobile=@Mobile,Address=@Address where  ContactId=@ID";
                SqlCommand command =new SqlCommand(query,connection);

                command.Parameters.AddWithValue("@ID", contactId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string parmeter)
        {
            string query = "select * from My_Contact Where Name Like @Parameter or Family Like @Parameter";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.SelectCommand.Parameters.AddWithValue("@Parameter", "%" + parmeter + "%");

            DataTable data = new DataTable();

            adapter.Fill(data);

            return data;
        }
    }
}
