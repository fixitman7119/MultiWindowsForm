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
        private int CurrentSelectionId;
        private bool IsEmptyText;
        private bool CheckValidity;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
            CurrentSelectionId = - 1;
        }

        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
            
            
        }

        private void CreateCustomer()
        {
            // validation
            
            
                // show an error
                if (Validators.IsEmptyText(txtName))
                {
                    MessageBox.Show("Name is empty.  Please enter a name.");
                    return;
                }

                if (Validators.IsEmptyText(txtEmail))
                {
                    MessageBox.Show("Email is empty.  Please enter an Email.");
                    return;
                }

                if (Validators.IsEmptyText(txtPhoneNumber))
                {
                MessageBox.Show("Phone number is empty.  Please enter a Phone number.");
                }

                //  retun and try again
            

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

        //private bool CheckValidity()
        //{
        //    //some logic here to validate the vareouse imputs
            
        //}

        private void EditCustomer()
        {
            //validater here exit early if invalid
            if (Validators.IsEmptyText(txtName))
            {
                MessageBox.Show("Name is empty.  Please enter a name.");
                return;
            }

            if (Validators.IsEmptyText(txtEmail))
            {
                MessageBox.Show("Email is empty.  Please enter an Email.");
                return;
            }

            if (Validators.IsEmptyText(txtPhoneNumber))
            {
                MessageBox.Show("Phone number is empty.  Please enter a Phone number.");
            }

            MessageBox.Show("Form is being edited.");
            // tell the main form what our customer looks like
            _mainForm.EditCustomer(CurrentSelectionId, new Customer
            {
                CustomerId = CurrentSelectionId,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,

            });

            CurrentSelectionId = -1;
            ToggleEdit(false);
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
            CurrentSelectionId = customer.CustomerId;
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
