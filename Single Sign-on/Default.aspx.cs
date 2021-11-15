using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Single_Sign_on
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve login details from Sign-in.aspx and check that they are not null
            if (Session["username"] != null && Session["password"] != null && Session["LDAPconnString"] != null)
            try
            {
                // Find the AD details using the LDAP connection string and login credentials
                DirectoryEntry directoryEntry = new DirectoryEntry( Session["LDAPconnString"].ToString(),
                                                                    Session["username"].ToString(),
                                                                    Session["password"].ToString()
                                                                   );
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);

                // Defining which info we want to pull
                searcher.PropertiesToLoad.Add("name"); // Full name
                searcher.PropertiesToLoad.Add("userPrincipalName"); // Username
                searcher.PropertiesToLoad.Add("distinguishedName"); // DN

                //Filtering just users
                searcher.Filter = "(&(objectCategory=User))";

                // Storing results in allUsers
                SearchResultCollection allUsers;
                allUsers = searcher.FindAll();

                // Clearing the Label values
                AllUsers.Text = "";

                // Printing the results from allUsers
                foreach (SearchResult sr in allUsers)
                {
                        if (sr.Properties["name"].Count > 0)
                            AllUsers.Text += $"Name: {sr.Properties["name"][0]},  ";

                        if (sr.Properties["userPrincipalName"].Count > 0)
                            AllUsers.Text += $"Username: {sr.Properties["userPrincipalName"][0]},  ";

                        if (sr.Properties["name"].Count > 0)
                            AllUsers.Text += $"Distinguished Name: {sr.Properties["distinguishedName"][0]}  ";
                        
                        AllUsers.Text += "<br />";
                }
            }
            catch (Exception)
            {
                    AllUsers.Text = "Can't get all users.";
            }

        }
    }
}