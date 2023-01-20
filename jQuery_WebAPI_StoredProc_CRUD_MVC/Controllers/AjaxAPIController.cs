using System;
using System.Web.Http;
using System.Linq;

namespace jQuery_WebAPI_StoredProc_CRUD_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        [Route("api/AjaxAPI/InsertCustomer")]
        [HttpPost]
        public Customer InsertCustomer(Customer _customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                _customer = entities.Customers_PerformCRUD("INSERT", null, _customer.Name, _customer.Country).FirstOrDefault();
            }

            return _customer;
        }

        [Route("api/AjaxAPI/UpdateCustomer")]
        [HttpPost]
        public bool UpdateCustomer(Customer _customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                entities.Customers_PerformCRUD("UPDATE", _customer.CustomerId, _customer.Name, _customer.Country);
            }

            return true;
        }

        [Route("api/AjaxAPI/DeleteCustomer")]
        [HttpPost]
        public void DeleteCustomer(Customer _customer)
        {
            using (CustomersEntities entities = new CustomersEntities())
            {
                entities.Customers_PerformCRUD("DELETE", _customer.CustomerId, null, null);
            }
        }
    }
}
