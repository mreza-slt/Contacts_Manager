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

        public bool Delete(int contactId)
        {
            throw new NotImplementedException();
        }

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

        public DataTable SelectRow(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int contactId, string name, string family,int age, string email,string mobile,   string address)
        {
            throw new NotImplementedException();
        }
    }
}
