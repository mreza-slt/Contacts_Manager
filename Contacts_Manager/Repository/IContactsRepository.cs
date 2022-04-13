using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Manager
{
    internal interface IContactsRepository
    {

        DataTable SelectAll();
        DataTable SelectRow(int contactId);

        bool Inser(string name, string family, string mobile, string email, int age, string address);
        bool Update(int contactId,string name, string family, string mobile, string email, int age, string address);
        bool Delete(int contactId);
    }
}
