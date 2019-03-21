
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework.NewFolder1
{
    //CRUD: CREATE, READ , UPDATE, DELETE
    class CustomerCRUD
    {
        private NorthwindEntities entities = new NorthwindEntities();

        public List<Customer> GetCustomers()
        {
            return entities.Customers.ToList();
        }

        public Customer GetCustomerById(String id)
        {
            return entities.Customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public void CreateCustomer(Customer customer)
        {   
            entities.Customers.Add(customer);
            entities.SaveChanges();
            
        }


        public void UpdateCustomer(Customer newCustomer)
        {
            var customer = GetCustomerById(newCustomer.CustomerID);
            if(customer != null)
            {
                customer.CompanyName = newCustomer.CompanyName;
                customer.Address = newCustomer.Address;
                customer.City = newCustomer.City;
                customer.ContactName = newCustomer.ContactName;
                customer.ContactTitle = newCustomer.ContactTitle;
                customer.Country = newCustomer.Country;
                customer.Region = newCustomer.Region;
                customer.Fax = newCustomer.Fax;
                customer.Phone = newCustomer.Phone;
                customer.PostalCode = newCustomer.PostalCode;

                entities.SaveChanges();
            }
        }

        public void DeleteCustomer(String id)
        {
            var customer = GetCustomerById(id);
            if(customer != null)
            {
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }
    }
}
