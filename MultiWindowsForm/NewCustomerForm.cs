using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiWindowsForm
{
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount = 0;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount++;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            // create a customer and load it with data from the form
            Customer customer = new Customer
            {
                CustomerId = CustomerCount,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,

            };
            // send that data to the AddCustomer function on the parent from
            _mainForm.AddCustomer(customer);
            CustomerCount++;

            // clear the new customer form\
            ClearForm();
            // close the form

        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
        }

        public void LoadCustomer(Customer customer)
        {
            txtName.Text= customer.Name;
            txtPhoneNumber.Text= customer.PhoneNumber;
            txtEmail.Text= customer.Email;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
