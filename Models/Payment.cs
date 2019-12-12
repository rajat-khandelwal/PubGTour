using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Nancy.Json;
using paytm;

namespace Asp.MVCCoreWeb.Models
{
    public class Payment
    {
        //----------- testing -------------
        private readonly string _Merchant_Key = "65CudS9IncIICVMw";
        private readonly string _Merchant_id = "YtLZPg33074291670613";
       
        //---------------- production ------------
       // private readonly string _Merchant_Key = "Vwg4A0EW%uM3MPJB";
       // private readonly string _Merchant_id = "soHknp97561421088473";

        [Key]
        public long Id { get; set; }

        public string UserId { get; set; }

        [DisplayName("Selected Tounament")]
        public long TournamentID { get; set; }

        [DisplayName("PatTm Number")]
        [MaxLength(10)]
        [RegularExpression(@"^\(?([0-9]{10})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DisplayName("Amount")]
        [DataType(DataType.Currency)]
        public double amount { get; set; }

        public string Sataus { get; set; }

        public string PAYMENTMODE { get; set; }
   
        public long TXNID { get; set; }

        public string RESPCODE { get; set; }

        public DateTime time { get; set; }

        [DataType(DataType.Url)]
        public string CallBacklurl { get; set; }

        public string TransactionStatus()
        {


            /* initialize a Dictionary object */
            Dictionary<String, String> paytmParams = new Dictionary<String, String>();

            /* Find your MID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
            paytmParams.Add("MID", "YOUR_MID_HERE");

            /* Enter your order id which needs to be check status for */
            paytmParams.Add("ORDERID", "YOUR_ORDER_ID_HERE");

            /**
            * Generate checksum by parameters we have in body
            * You can get Checksum DLL from https://developer.paytm.com/docs/checksum/
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
*/
            String checksum = paytm.CheckSum.generateCheckSum("YOUR_KEY_HERE", paytmParams);

            /* put generated checksum value here */
            paytmParams.Add("CHECKSUMHASH", checksum);

            /* prepare JSON string for request */
            String post_data = new JavaScriptSerializer().Serialize(paytmParams);

            /* for Staging */
            String url = "https://securegw-stage.paytm.in/order/status";

            /* for Production */
            // String url = "https://securegw.paytm.in/order/status";

            try
            {
                HttpWebRequest connection = (HttpWebRequest)WebRequest.Create(url);
                connection.Headers.Add("ContentType", "application/json");
                connection.Method = "POST";
                using (StreamWriter requestWriter = new StreamWriter(connection.GetRequestStream()))
                {
                    requestWriter.Write(post_data);
                }
                string responseData = string.Empty;
                using (StreamReader responseReader = new StreamReader(connection.GetResponse().GetResponseStream()))
                {
                    responseData = responseReader.ReadToEnd();
                }
                // Response.Write(responseData);
                return responseData;
                // Response.Write("Request: " + post_data);
            }
            catch (Exception ex)
            {
                return ex.Message;
                /// Nancy.Response.Write(ex.Message.ToString());
            }

        }

        public string StartPayment(Payment user)
        {

            try
            {

                /* initialize a TreeMap object */
                Dictionary<String, String> paytmParams = new Dictionary<String, String>();

                /* Find your MID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
                paytmParams.Add("MID", _Merchant_id);

                /* Find your WEBSITE in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
                paytmParams.Add("WEBSITE", "WEBSTAGING");

                /* Find your INDUSTRY_TYPE_ID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
                paytmParams.Add("INDUSTRY_TYPE_ID", "Retail");

                /* WEB for website and WAP for Mobile-websites or App */
                paytmParams.Add("CHANNEL_ID", "WEB");

                /* Enter your unique order id */
                paytmParams.Add("ORDER_ID", user.Id.ToString());

                /* unique id that belongs to your customer */
                paytmParams.Add("CUST_ID", user.UserId.ToString());

                /* customer's mobile number */
                paytmParams.Add("MOBILE_NO", user.Phone);

                /* customer's email */
             //   paytmParams.Add("EMAIL", user.email);

                /**
                * Amount in INR that is payble by customer
                * this should be numeric with optionally having two decimal points
*/
                paytmParams.Add("TXN_AMOUNT", user.amount.ToString());

                /* on completion of transaction, we will send you the response on this URL */
                paytmParams.Add("CALLBACK_URL", user.CallBacklurl);

                /**
                * Generate checksum for parameters we have
                * You can get Checksum DLL from https://developer.paytm.com/docs/checksum/
                * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
*/
                String checksum = paytm.CheckSum.generateCheckSum(_Merchant_Key, paytmParams);

                /* for Staging */
                //String url = "https://securegw-stage.paytm.in/order/process";

               
                /* for Production */
                 String url = "https://securegw.paytm.in/order/process";


                /* Prepare HTML Form and Submit to Paytm */
                String outputHtml = "";
                outputHtml += "<html>";
                outputHtml += "<head>";
                outputHtml += "<title>Merchant Checkout Page</title>";
                outputHtml += "</head>";
                outputHtml += "<body>";
                outputHtml += "<center><h1>Please do not refresh this page...</h1></center>";
                outputHtml += "<form method='post' action='" + url + "' name='paytm_form'>";
                foreach (string key in paytmParams.Keys)
                {
                    outputHtml += "<input type='hidden' name='" + key + "' value='" + paytmParams[key] + "'>";
                }
                outputHtml += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
                outputHtml += "</form>";
                outputHtml += "<script type='text/javascript'>";
                outputHtml += "document.paytm_form.submit();";
                outputHtml += "</script>";
                outputHtml += "</body>";
                outputHtml += "</html>";
                return outputHtml;
            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public void SaveFinalAmountHistory(string OrderId) {

            /* initialize a Dictionary object */
            Dictionary<String, String> paytmParams = new Dictionary<String, String>();

            /* Find your MID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
            paytmParams.Add("MID", _Merchant_id);

            /* Enter your order id which needs to be check status for */
            paytmParams.Add("ORDERID", OrderId);

            /**
            * Generate checksum by parameters we have in body
            * You can get Checksum DLL from https://developer.paytm.com/docs/checksum/
            * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
*/
            String checksum = paytm.CheckSum.generateCheckSum(_Merchant_Key, paytmParams);

            /* put generated checksum value here */
            paytmParams.Add("CHECKSUMHASH", checksum);

            /* prepare JSON string for request */
            String post_data = new JavaScriptSerializer().Serialize(paytmParams);

            /* for Staging */
            String url = "https://securegw-stage.paytm.in/order/status";

            /* for Production */
            // String url = "https://securegw.paytm.in/order/status";

            try
            {
                HttpWebRequest connection = (HttpWebRequest)WebRequest.Create(url);
                connection.Headers.Add("ContentType", "application/json");
                connection.Method = "POST";
                using (StreamWriter requestWriter = new StreamWriter(connection.GetRequestStream()))
                {
                    requestWriter.Write(post_data);
                }
                string responseData = string.Empty;
                using (StreamReader responseReader = new StreamReader(connection.GetResponse().GetResponseStream()))
                {
                    responseData = responseReader.ReadToEnd();
                }


              //  Response.Write(responseData);
                // Response.Write("Request: " + post_data);
            }
            catch (Exception ex)
            {
              //  Response.Write(ex.Message.ToString());
            }

        }


    }

}
