using QuestPond.Models;
using System.Web;
using System.Web.Mvc;
namespace QuestPond.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Create Context to get the Request data 
            HttpContextBase objContext = controllerContext.HttpContext;

            //Get the data from the request 
            string custCode = objContext.Request.Form["txtCustomerCode"];
            string custName = objContext.Request.Form["txtCustomerName"];
            Customer obj = new Customer()
            {
                CustomerCode = custCode,
                CustomerName = custName
            };
            return obj;
        }
    }


    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer obj =
                new Customer
                {
                    CustomerCode = "1001",
                    CustomerName = "Shiv"
                };

            return View("Customer", obj);
        }
        public ActionResult Enter()
        {
            return View("EnterCustomer", new Customer()); // pass empty customer object so @model will process in view
        }
        //public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] // Attribute data validation runs and are sent to MODELSTATE
        //                        Customer obj)
        public ActionResult Submit(Customer obj) // Attribute data validation runs and are sent to ModelState
        {
            if (ModelState.IsValid)
            {
                return View("Customer", obj);
            }
            else
            {
                return View("EnterCustomer", obj);
            }
        }
    }
}