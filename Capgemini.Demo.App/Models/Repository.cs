using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;
using System.DirectoryServices;
using System.Diagnostics;

namespace Capgemini.Demo.App.Models
{
    public class Repository
    {
        
        public void checkuser(out User objUsr)
        {

            string username = string.Empty;
            string userlogon = HttpContext.Current.Request.LogonUserIdentity.Name;
            string LoginId = userlogon.Substring(userlogon.LastIndexOf("\\") + 1);

            objUsr = new User();
            objUsr.Name = userlogon;
            objUsr.LoginId = LoginId;
            objUsr.IsActive = true;
            objUsr.Role = "User";
            

        }
      
        public Byte[] GetUserPicture()

        {
            string username = UserPrincipal.Current.Name;

            //try
            //{ 
            //EventLog.WriteEntry("RACE", string.Format("Principal : {0}, LogonUserIdentify: {1}", username, HttpContext.Current.Request.LogonUserIdentity));
            //}
            //catch(Exception)
            //{ }

            using (var dsSearcher = new DirectorySearcher())
            {
                var idx = username.IndexOf('\\');
                if (idx > 0)
                    username = username.Substring(idx + 1);
                dsSearcher.Filter = string.Format("(&(objectClass=user)(samaccountname={0}))", username);
                SearchResult result = dsSearcher.FindOne();

                if (result != null)
                {
                    byte[] thumbnail = null;

                    using (var user = new DirectoryEntry(result.Path))
                    {
                        thumbnail = user.Properties["thumbnailPhoto"].Value as byte[];
                        //try
                        //{
                        //    EventLog.WriteEntry("RACE", string.Format("Principal : {0}. Thumbnail : {1}", username, Convert.ToBase64String(thumbnail)));
                        //}
                        //catch(Exception)
                        //{ }
                        return thumbnail;
                    }
                }
                else
                {
                    //try
                    //{
                    //    EventLog.WriteEntry("RACE", string.Format("Principal : {0}. dsSearcher.FindOne() returned null", username));
                    //}
                    //catch(Exception)
                    //{ }

                }
                return null;
            }
        }
    }

         public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }

    }

    

}

 
