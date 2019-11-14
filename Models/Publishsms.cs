using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;


namespace Asp.MVCCoreWeb.Models
{
    public class Publishsms
    {
        public async Task publisasms(string phonenumber)
        {
            string number = phonenumber;
            string message = "ladki beautiful kar gyi chull";

            string key = "AKIAX6CXUVKFU3R6RJOH";
            string scret = "gaidXXmW6scTqvPCZUfuouQdpaQizyZqH7sY8FWf";

            var client = new AmazonSimpleNotificationServiceClient(key, scret, Amazon.RegionEndpoint.APSoutheast1);
            var request = new PublishRequest
            {
                Message = message,
                PhoneNumber = number,

            };
            request.MessageAttributes["AWS.SNS.SMS.SMSType"] =
            new MessageAttributeValue { StringValue = "Transactional", DataType = "String" };
            //request.MessageAttributes.Add("aws.sns.sms.smstype".ToUpper(), new MessageAttributeValue { StringValue="transactional" ,DataType= "string"});
            try
            {
                var response = await client.PublishAsync(request);

            }
            catch (Exception ex)
            {

            }


        }
    }
}


/*******************************************************************************
* Copyright 2009-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
*
* http://aws.amazon.com/apache2.0/
*
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/
/* Build 
   Don't forget to use the Visual Studio command prompt
   Tested with csc /version == 2.10.0.0
     (C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\bin\Roslyn)
   AWSSDK.Core.dll
     (C:\Users\USERNAME\.nuget\packages\awssdk.core\3.3.100\lib\net45)
   AWSSDK.SimpleNotificationService.dll
     (C:\Users\USERNAME\.nuget\packages\awssdk.simplenotificationservice\3.3.0.11\lib\net45)

   csc SnsPublish.cs -reference:AWSSDK.Core.dll -reference:AWSSDK.SimpleNotificationService.dll

   Get the list of AWSSDK Nuget packages at:
       https://www.nuget.org/packages?q=AWSSDK&prerel=false
 */

