using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_Manager
{
    public partial class Form1 : Form
    {
        IContactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }
        private void BindGrid()
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.Columns[0].Visible = false;
            dgContacts.DataSource = repository.SelectAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            FrmAdd_or_Edit addForm = new FrmAdd_or_Edit();
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                string name = dgContacts.CurrentRow.Cells[1].Value.ToString();
                string family = dgContacts.CurrentRow.Cells[2].Value.ToString();

                if (MessageBox.Show($"ایا از حذف {name + " "+family} مطمئن هستید؟","توجه",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactId =int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString()) ;
                    repository.Delete(contactId);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را از لیست انتخاب کنید");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());

                FrmAdd_or_Edit frm = new FrmAdd_or_Edit();

                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = repository.Search(txtSearch.Text);
        }
    }
}
