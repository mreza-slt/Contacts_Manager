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
    public partial class FrmAdd_or_Edit : Form
    {

        IContactsRepository repository;
        public FrmAdd_or_Edit()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void FrmAdd_or_Edit_Load(object sender, EventArgs e)
        {
            this.Text = "افزودن شخص جدید";
        }

        bool ValidateInput()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید","هشدار",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
               bool isSuccess =repository.Insert(txtName.Text, txtFamily.Text,(int)txtAge.Value, txtEmail.Text,txtMobile.Text,  txtAddress.Text);

                if (isSuccess==true)
                {
                    MessageBox.Show("اطلاعات با موفقیت ثبت شد", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult=DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("اطلاعات ثبت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
