using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcApiApp.App_Code
{

  public   class CustomerDTO
    {
        int 
            CustomerId;
        string 
            CustomerFirstName,
            CustomerMiddleName,
            CustomerLastName;
        string 
            CustmerPaymentDetails,
            EmailId,
            MobileNumber,
            Password;
        DateTime 
            LastLogin;
    }

    public class SubscriptionMaster{
        int subscriptionId,
            customerId, 
            planId, 
            paymentId;
        DateTime 
            startDate, 
            EndDate;
        string 
            status, 
            autopayStatus;
        decimal 
            DiscountApplied;
    }


    public class TelecomCustomerDetails
    {

    }
}