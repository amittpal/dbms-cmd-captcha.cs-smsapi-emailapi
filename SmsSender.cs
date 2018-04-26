using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

/// <summary>
/// Summary description for SmsSender
/// </summary>
public class SmsSender
{
  //  string UserID, Password, SenderID, Priority, SMSType;
    string MySenderId, MyUserId, MySecurityCode;
	public SmsSender()
	{
         //UserID = "Softpro";
         //Password = "sam@123";
         //SenderID = "SPILKO";
         //Priority = "sdnd";
         //SMSType = "normal";
        /*
         * Thanks for showing interest in our " + TrainingName + " program. You are successfully registered. Your Registration Number is: " + SrNo + " Regards- Softpro India Computer Technologies(P) Ltd. Lucknow(U.P.)
         */
        MySenderId = "SPILKO";
        MyUserId = "BRIJESH";
        MySecurityCode = "8620e45a26XX";
	}
    public bool SendSMS(string MobileNo, string Message)
    {
        string API = "http://sms.bulkssms.com/submitsms.jsp?user=" + MyUserId + "&key=" + MySecurityCode + "&mobile=" + MobileNo + "&message=" + Message + "&senderid=" + MySenderId + "&accusage=1";
        WebClient wc = new WebClient();
        try
        {
            wc.DownloadString(API);
            return true;
        }
        catch
        {
            return false;
        }

    }
    
}