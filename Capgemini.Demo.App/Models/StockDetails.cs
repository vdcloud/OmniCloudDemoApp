using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capgemini.RACE.Platform.Common;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace Capgemini.Demo.App
{
    public class StockDetails:TableEntry
    {
        public string StockId { get; set; }

        public string StockName { get; set; }

        public double Price { get; set; }
        
        public double Quantity { get; set; }
        
        public DateTime CreatedDateTime { get; set; } 

        public bool StockStatus { get; set; }

        public bool Flag { get; set; }

        public string tempDate { get; set; }

        //public string getusername()
        //{
        //    string userName = string.Empty;
        //    try
        //    {
        //        string userlogon = HttpContext.Current.Request.LogonUserIdentity.Name;
        //        string LoginId = userlogon.Substring(userlogon.LastIndexOf("\\") + 1);
        //        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, userlogon.Substring(0, userlogon.IndexOf("\\"))))
        //        {
        //            UserPrincipal user = new UserPrincipal(pc);
        //            user = UserPrincipal.FindByIdentity(pc, LoginId);
        //            if (user != null)
        //            {
        //                userName = user.GivenName + " " + user.Surname;
        //            }
        //            else
        //            {
        //                //return string.Empty;
        //                userName = "User Not Found";
        //            }
        //        }
        //    }
        //    catch
        //    { }

        //    return userName;
        //}

        //public Byte[] GetUserPicture()

        //{
        //    string username = UserPrincipal.Current.Name;

        //    //try
        //    //{ 
        //    //EventLog.WriteEntry("RACE", string.Format("Principal : {0}, LogonUserIdentify: {1}", username, HttpContext.Current.Request.LogonUserIdentity));
        //    //}
        //    //catch(Exception)
        //    //{ }

        //    using (var dsSearcher = new DirectorySearcher())
        //    {
        //        var idx = username.IndexOf('\\');
        //        if (idx > 0)
        //            username = username.Substring(idx + 1);
        //        dsSearcher.Filter = string.Format("(&(objectClass=user)(samaccountname={0}))", username);
        //        SearchResult result = dsSearcher.FindOne();

        //        if (result != null)
        //        {
        //            byte[] thumbnail = null;

        //            using (var user = new DirectoryEntry(result.Path))
        //            {
        //                thumbnail = user.Properties["thumbnailPhoto"].Value as byte[];
        //                //try
        //                //{
        //                //    EventLog.WriteEntry("RACE", string.Format("Principal : {0}. Thumbnail : {1}", username, Convert.ToBase64String(thumbnail)));
        //                //}
        //                //catch(Exception)
        //                //{ }
        //                return thumbnail;
        //            }
        //        }
        //        else
        //        {
        //            //try
        //            //{
        //            //    EventLog.WriteEntry("RACE", string.Format("Principal : {0}. dsSearcher.FindOne() returned null", username));
        //            //}
        //            //catch(Exception)
        //            //{ }

        //        }
        //        return null;
        //    }
        //}
    }
}