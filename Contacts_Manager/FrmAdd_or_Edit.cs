using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_Manager
{
    public partial class FrmAdd_or_Edit : Form
    {

        Contact_dbEntities db = new Contact_dbEntities();

        public int contactId = 0;
        public FrmAdd_or_Edit()
        {
            InitializeComponent();
        }

        private void FrmAdd_or_Edit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";

            }
            else
            {
                this.Text = "ویرایش";
                My_Contact contact = db.My_Contact.Find(contactId);
                txtName.Text = contact.Name;
                txtFamily.Text = contact.Family;
                txtAge.Text = contact.Age.ToString();
                txtEmail.Text = contact.Email;
                txtMobile.Text = contact.Mobile;
                txtAddress.Text = contact.Address;
                btnSubmit.Text = "ویرایش";
            }
        }

        bool ValidateInput()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا شماره موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {




                if (contactId == 0)
                {
                    My_Contact contact = new My_Contact();
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Mobile = txtMobile.Text;
                    contact.Email = txtEmail.Text;
                    contact.Address = txtAddress.Text;
                    db.My_Contact.Add(contact);
                }
                else
                {
                    var contact = db.My_Contact.Find(contactId);
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Mobile = txtMobile.Text;
                    contact.Email = txtEmail.Text;
                    contact.Address = txtAddress.Text;
                }
                db.SaveChanges();

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
