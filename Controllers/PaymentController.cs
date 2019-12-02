using Asp.MVCCoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using paytm;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.MVCCoreWeb.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly EmployeeContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;
        // GET: /<controller>/
   
        public PaymentController(UserManager<ApplicationUser> usermanager,EmployeeContext context) { 
          
            _usermanager = usermanager;
            _context = context;
        
        }

        [HttpGet]
        public async Task<ActionResult> StartPayment(long id)
        {
            Payment pt = new Payment();
            var loggedin = await _usermanager.GetUserAsync(HttpContext.User);
            //pt.email = loggedin.Email;
            pt.Phone = loggedin.PhoneNumber;
            pt.UserId = loggedin.Id;
            pt.time = new DateTime();
            
            ViewBag.tourinfo =_context.tournment.Find(id);
            pt.TournamentID = id;
            pt.amount = ViewBag.tourinfo.fee;
            pt.Id = 0;
            return View(pt);
        }

        [HttpPost]
        public ActionResult StartPayment(Payment user) {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    Payment pt = new Payment();
                    _context.Payments.Add(user);
                    _context.SaveChanges();
                  
                    user.CallBacklurl = this.Url.Action("checkCheksum", "payment",null,Uri.UriSchemeHttp);

                    string html = pt.StartPayment(user);
              
                    TempData["Rawhtml"] = html;
                    return RedirectToAction("InitiatePayment");
                }
                ModelState.AddModelError("", "Something went wrong!!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
              
            }
            return View(user);
        }

        public ActionResult checkCheksum() {

            String paytmChecksum = "";

            /* Create a Dictionary from the parameters received in POST */
            Dictionary<String, String> paytmParams = new Dictionary<String, String>();
            foreach (string key in Request.Form.Keys)
            {
                if (key.Equals("CHECKSUMHASH"))
                {
                    paytmChecksum = Request.Form[key];
                }
                else
                {
                    paytmParams.Add(key.Trim(), Request.Form[key].ToString().Trim());
                }
            }

            /**
            * Verify checksum
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
*/
            bool isValidChecksum = CheckSum.verifyCheckSum("65CudS9IncIICVMw", paytmParams, paytmChecksum);
            if (isValidChecksum)
            {
                Payment pt = new Payment();
                pt.Id = Convert.ToInt64(paytmParams["ORDERID"]
                    );
                pt =  _context.Payments.Find(pt.Id);
              
                pt.PAYMENTMODE = paytmParams["RESPMSG"];
                pt.RESPCODE = paytmParams["RESPCODE"];
                //pt.TXNID = Convert.ToInt64(paytmParams["TXNID"]);
                pt.Sataus = paytmParams["STATUS"];
             

                _context.Payments.Update(pt);
               
                _context.SaveChanges();
                return RedirectToAction("index","home");
            }

            return RedirectToAction("index", "home");

        }

        /// <summary>
        /// do not delete this method this is the first method which return html for payment start 
        /// </summary>
        /// <returns></returns>
        public ActionResult InitiatePayment() {

            try
            {


            }
            catch (Exception ex)
            {

                
            }

          return View(TempData["Rawhtml"]);
        }


        public async Task<IActionResult> Transactions() {

            var history = _context.Payments.Where(m=>m.UserId == _usermanager.GetUserId(User)).OrderByDescending(o=>o.time);

            return View(history);

        }


    }
}
