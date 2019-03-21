using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestEntityFramework.NewFolder1;

namespace TestEntityFramework
{
    public partial class Form1 : Form
    {
        
        CustomerCRUD customerCRUD = new CustomerCRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer() ;

            customer = customerCRUD.GetCustomerById(txtSearchID.Text);
            if (customer != null)
            {
                ShowCustomers(customer);
            }
            else
                MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowCustomers(Customer customer)
        {
            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            txtCompany.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName;
            txtContactTitle.Text = customer.ContactTitle;
            txtCountry.Text = customer.Country;
            txtFax.Text = customer.Fax;
            txtPhone.Text = customer.Phone;
            txtPostalCode.Text = customer.PostalCode;
            txtRegion.Text = customer.Region;
        }

        private void ClearFields()
        {
            txtAddress.Clear();
            txtCity.Clear();
            txtCompany.Clear();
            txtContactName.Clear();
            txtContactTitle.Clear();
            txtCountry.Clear();
            txtFax.Clear();
            txtPhone.Clear();
            txtPostalCode.Clear();
            txtRegion.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private String GenerateID(Customer customer)
        {
            char[] array = customer.CompanyName.ToCharArray();
            var random = new Random();
            String id = "";

            for( int i = 0; i < 5;i++)
            {
                id += array[random.Next(array.Length)];
            }

            return id.ToUpper();
        }

        private void btnCreateCustomer_Click_1(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            if (textFieldFilled())
            {
                customer.ContactName = txtContactName.Text;
                customer.ContactTitle = txtContactTitle.Text;
                customer.CompanyName = txtCompany.Text;
                customer.Address = txtAddress.Text;
                customer.Country = txtCountry.Text;
                customer.City = txtCity.Text;
                customer.Region = txtRegion.Text;
                customer.PostalCode = txtPostalCode.Text;
                customer.Phone = txtPhone.Text;
                customer.Fax = txtFax.Text;
                customer.CustomerID = GenerateID(customer);
                customerCRUD.CreateCustomer(customer);
                MessageBox.Show("Customer Added! ID = " + customer.CustomerID + "!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Please, fill the missing fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private bool textFieldFilled()
        {
            var controls = new[] {txtAddress, txtCity, txtCompany, txtContactName, txtContactTitle, txtCountry, txtFax,
                                  txtPhone, txtPostalCode, txtRegion};
            foreach(var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                return false;
            }
            return true;
        }
        
    }
}
