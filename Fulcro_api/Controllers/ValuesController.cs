using Fulcro_api.DAL;
using Fulcro_api.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace Fulcro_api.Controllers
{
    public class ValuesController : Controller
    {
        static List<string> strings = new List<string>() { "value1", "value2", "value3" };
        Address_Dal address_DAL = new Address_Dal();
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return strings;
        //}

        // GET api/values/5
        public JsonResult GetPincodes([FromBody]Input input)
        {
            //var isValidProduct=address_DAL.Check_product(input.product_code);
            //if(!isValidProduct)
            //{
            //    return new JsonResult(){ Data =new { error= "Invalid Product" } };
            //}
            Address address = address_DAL.Get_Address(input);
            if(address.data == null)
            {
                return new JsonResult() { Data = new { error = "Invalid Product" } };
            }
            return Json(address);
            
        }


        // POST api/values
        public void Post([FromBody] int id, [FromBody] int product_code)
        {
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
