using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Single_Sign_on
{
    public partial class Sign_in : System.Web.UI.Page
    {
        //Initializing the connection string for a domain: Single-Sign-on.com
        public string LDAPconnString = "LDAP://192.168.171.129";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnSubmit_OnClick (object sender, EventArgs e)
        {

            // Try to Authenticate user i.e. try to locate user info in AD database
            try
            {
                // Find the AD details using the LDAP connection string and login credentials
                DirectoryEntry directoryEntry = new DirectoryEntry(LDAPconnString, Username.Text, Password.Text);
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);

                //Filtering just users
                searcher.Filter = "(&(objectCategory=User))";

                // Storing results in results
                SearchResult results = null;
                results = searcher.FindOne();
                
                // Save these details for further use i.e. for listing all users in Default.aspx
                Session["username"] = Username.Text;
                Session["password"] = Password.Text;
                Session["LDAPconnString"] = LDAPconnString;

                // If a user is found with the given credentials - redirect them to the Home page
                Response.Redirect("Default.aspx");
                
            }
            catch (Exception)
            {
                // If there is no user on the given domain with the given credentials ask them to enter the correct credentials
                ErrorMessage.Text = "Please enter valid credentials.";
            }
            
        }

        protected void BtnClear_OnClick (object sender, EventArgs e)
        {
            Username.Text = null;
            Password.Text = null;
            ErrorMessage.Text = null;
        }

        
    }
}