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
        private int CustomerCount;
        private bool IsEditing;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
        }

        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
            
            // tell the main form what our customer looks like
            _mainForm.EditCustomer(0,new Customer());
        }

        private void CreateCustomer()
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
        }

        private void EditCustomer()
        {
            MessageBox.Show("Form is being edited.");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {


                // edit item in place
                EditCustomer();
            }
            else
            {
                // create a new customer
                CreateCustomer();

            }
           

            // clear the new customer form\
            ClearForm();
            // close the form
            Hide();

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
