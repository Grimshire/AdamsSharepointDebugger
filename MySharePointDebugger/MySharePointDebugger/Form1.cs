using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Threading;
using System.Collections;
using System.IO;
using System.Reflection;

namespace MySharePointDebugger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        

        



        private bool check4checks()
        {
            foreach (object TN in checkedListBox1.Items)
            {
                txtBoxOutput.Text += "Item: " + TN.ToString() + "Value: " + checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(TN)).ToString();
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(TN))==CheckState.Checked)
                {                    
                    return true; 
                }        
            }
            return false;
        }

        private void btnFindSiteCollectionName_Click(object sender, EventArgs e)
        {
            try
            {
                txtBoxOutput.Text += "Loading from Sharepoint...";
                string SiteURL = txtBoxInput.Text;
                using (SPSite _site = new SPSite(SiteURL))
                {
                    using (SPWeb web = _site.OpenWeb())
                    {
                        if (web.Exists)
                        {
                            txtBoxOutput.Text += "Site Collection URL: " + _site.Url;
                            txtBoxOutput.Text += "Site Collection Title: " + web.Site.ServerRelativeUrl.Substring(web.Site.ServerRelativeUrl.LastIndexOf("/") + 1);
                            txtBoxOutput.Text += "Site Collection Master Page URL: " + _site.RootWeb.MasterUrl;
                            txtBoxOutput.Text += "Site Collection Name: " + web.Name;
                            txtBoxOutput.Text += "Top Level Site?: " + _site.RootWeb.IsRootWeb.ToString();
                            txtBoxOutput.Text += "Site Collection GUID: " + _site.RootWeb.ID;
                            if (_site.RootWeb.ParentWeb != null)
                            {
                                txtBoxOutput.Text += "Site Collection Parent Web Name: " + _site.RootWeb.ParentWeb.Name;
                                txtBoxOutput.Text += "Site Collection Parent Web URL: " + _site.RootWeb.ParentWeb.Url;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtBoxOutput.Text += Environment.NewLine + "Inner Exception: " + ex.InnerException;
                txtBoxOutput.Text += Environment.NewLine + "Message: " + ex.Message;
                txtBoxOutput.Text += Environment.NewLine + "Stack Trace: " + ex.StackTrace;
                txtBoxOutput.Text += Environment.NewLine + "Source: " + ex.Source;

            }
        }

        private void btnSiteCollectionLists_Click(object sender, EventArgs e)
        {
            try
            {

                toolStripStatusLabel1.Text = "Loading from Sharepoint...";
                string SiteURL = txtBoxInput.Text.TrimEnd().TrimStart();
                using (SPSite _site = new SPSite(SiteURL))
                {
                    txtBoxOutput.Text += Environment.NewLine + "Site URL: " + _site.Url;
                    txtBoxOutput.Text += Environment.NewLine + "Site Application Name: " + _site.WebApplication.Name;
                    txtBoxOutput.Text += Environment.NewLine + "----------------------LISTS----------------------";
                    using (SPWeb web = _site.OpenWeb())
                    {
                        if (web.Exists)
                        {
                            //SPQuery activeQuery = new SPQuery();
                            //activeQuery.Query = "<Where><EQ><FieldRef Name='Status'/>" +
                            //        "<Value Type='Text'>ActiveControl</Value></EqualityComparer></Where>";
                            foreach (SPList spList in web.Lists)
                            {
                                txtBoxOutput.Text += Environment.NewLine + spList.Title;
                            }
                        }
                    }
                    txtBoxOutput.Text += Environment.NewLine + "-------------------------------------------------";
                }
                toolStripStatusLabel1.Text = "Ready Player 1.";
            }
            catch (Exception ex)
            {
                txtBoxOutput.Text += Environment.NewLine + "Inner Exception: " + ex.InnerException;
                txtBoxOutput.Text += Environment.NewLine + "Message: " + ex.Message;
                txtBoxOutput.Text += Environment.NewLine + "Stack Trace: " + ex.StackTrace;
                txtBoxOutput.Text += Environment.NewLine + "Source: " + ex.Source;

            }
        }

        private void txtBoxListName_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtBoxInput.Text))
                {
                    txtBoxOutput.Text += "Name of list is blank. It must not be, duh.";
                    return;
                }
                if (String.IsNullOrEmpty(txtBoxInput.Text))
                {
                    txtBoxOutput.Text += "Name of site is blank. It must not be, duh.";
                    return;
                }
                toolStripStatusLabel1.Text = "Loading from Sharepoint...";
                Thread.Sleep(100);
                string SiteURL = txtBoxInput.Text.TrimEnd().TrimStart();
                string listURL = SiteURL + "/lists/" + txtBoxInput.Text.TrimEnd().TrimStart();

                using (SPSite _site = new SPSite(SiteURL))
                {
                    txtBoxOutput.Text += Environment.NewLine + "List URL: " + listURL;
                    txtBoxOutput.Text += Environment.NewLine + "Site Application Name: " + _site.WebApplication.Name;
                    txtBoxOutput.Text += Environment.NewLine + "--------------------LIST-ITEMS--------------------";
                    using (SPWeb web = _site.OpenWeb())
                    {
                        if (web.Exists)
                        {
                            SPList _list = web.Lists[txtBoxInput.Text.TrimEnd().TrimStart()];
                            foreach (SPListItem SPI in _list.Items)
                            {
                                txtBoxOutput.Text += Environment.NewLine + SPI.Name;
                            }
                        }
                    }
                    txtBoxOutput.Text += Environment.NewLine + "-------------------------------------------------";
                }
                toolStripStatusLabel1.Text = "Ready Player 1.";
            }
            catch (Exception ex)
            {
                txtBoxOutput.Text += Environment.NewLine + "Inner Exception: " + ex.InnerException;
                txtBoxOutput.Text += Environment.NewLine + "Message: " + ex.Message;
                txtBoxOutput.Text += Environment.NewLine + "Stack Trace: " + ex.StackTrace;
                txtBoxOutput.Text += Environment.NewLine + "Source: " + ex.Source;
                toolStripStatusLabel1.Text = "Game over.";

            }

        }

        private void btnDebugInit_Click(object sender, EventArgs e)
        {
            string SiteURL = txtBoxInput.Text.TrimEnd().TrimStart();

            using (SPSite _site = new SPSite(SiteURL))
            {
                txtBoxOutput.Text += Environment.NewLine + "Portal URL: " + _site.PortalUrl;
                txtBoxOutput.Text += Environment.NewLine + "Primary URi:" + _site.PrimaryUri;
                txtBoxOutput.Text += Environment.NewLine + "Web App Name" + _site.WebApplication.Name;
                foreach (SPSite SPS in _site.WebApplication.Sites)
                {
                    Thread.Sleep(10);
                    txtBoxOutput.Text += "Portal Name:" + SPS.PortalName;
                    foreach (SPWeb SPW in SPS.AllWebs)
                    {
                        Thread.Sleep(1);
                        txtBoxOutput.Text += Environment.NewLine + "Site Name: " + SPW.Name;
                        txtBoxOutput.Text += Environment.NewLine + "Site URL: " + SPW.Url;
                    }
                }
            }


        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (check4checks()==false)
            {
                txtBoxOutput.Text += Environment.NewLine + "No checkboxes selected!";
                return;
            }
            try
            {
                txtBoxOutput.Text += lblURLName.Text;

                foreach (object TN in checkedListBox1.Items)
                    {                           
                                
                        if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(TN))==CheckState.Checked)
                        {
                            if (checkedListBox1.GetItemText(TN) == "Site")
                            {
                                lblURLName.Text = txtBoxInput.Text;
                                //checkedListBox1.Items[checkedListBox1.Items.IndexOf(TN)] = web.Name;
                            }
                            if (checkedListBox1.GetItemText(TN) == "Lists")
                            {
                                lblListName.Text = txtBoxInput.Text;
                            }
                            if (checkedListBox1.GetItemText(TN) == "Items")
                            {
                                lblItemName.Text = txtBoxInput.Text;
                            }
                            if (checkedListBox1.GetItemText(TN) == "Properties")
                            {
                                txtBoxOutput.Text += "Cannot store value in properties.";
                                return;
                            }
                        }
                    }
                    txtBoxOutput.Text += Environment.NewLine + "Finished storing values.";

                }
                catch (Exception ex)
                {
                    txtBoxOutput.Text += Environment.NewLine + "Inner Exception: " + ex.InnerException;
                    txtBoxOutput.Text += Environment.NewLine + "Message: " + ex.Message;
                    txtBoxOutput.Text += Environment.NewLine + "Stack Trace: " + ex.StackTrace;
                    txtBoxOutput.Text += Environment.NewLine + "Source: " + ex.Source;
                    txtBoxOutput.Text += Environment.NewLine + "Values failed to store in selection tree.";
                }               
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string listURL;
            string SiteURL;
            try
            {

                SiteURL = lblURLName.Text;               

                toolStripStatusLabel1.Text = "Loading from Sharepoint...";
                Thread.Sleep(100);
                if (check4checks()==false)
                {
                    txtBoxOutput.Text += Environment.NewLine + "No checkboxes selected!";
                    toolStripStatusLabel1.Text = "Ready Player 2.";
                    return;
                }
                if (lblURLName.Text == "URL" || String.IsNullOrEmpty(lblURLName.Text)==true)
                {
                    txtBoxOutput.Text += Environment.NewLine + "Site must be stored first!";
                    toolStripStatusLabel1.Text = "Ready Player 2.";
                    return;
                }
                
                #region SITE INFO
                //////////////SITE INFO/////////
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf("Site")) == CheckState.Checked)
                {
                    using (SPSite _site = new SPSite(SiteURL))
                    {
                        using (SPWeb web = _site.OpenWeb())
                        {
                            if (web.Exists)
                            {
                                txtBoxOutput.Text += Environment.NewLine + " Site Collection URL: " + _site.Url;
                                txtBoxOutput.Text += Environment.NewLine + " Site Collection Title: " + web.Site.ServerRelativeUrl.Substring(web.Site.ServerRelativeUrl.LastIndexOf("/") + 1);
                                txtBoxOutput.Text += Environment.NewLine + " Site Collection Master Page URL: " + _site.RootWeb.MasterUrl;
                                txtBoxOutput.Text += Environment.NewLine + " Site Collection Name: " + web.Name;
                                txtBoxOutput.Text += Environment.NewLine + " Top Level Site?: " + _site.RootWeb.IsRootWeb.ToString();
                                txtBoxOutput.Text += Environment.NewLine + " Site Collection GUID: " + _site.RootWeb.ID;
                                if (_site.RootWeb.ParentWeb != null)
                                {
                                    txtBoxOutput.Text += Environment.NewLine + " Site Collection Parent Web Name: " + _site.RootWeb.ParentWeb.Name;
                                    txtBoxOutput.Text += Environment.NewLine + " Site Collection Parent Web URL: " + _site.RootWeb.ParentWeb.Url;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Lists
                ///////////LISTS////////////
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf("Lists")) == CheckState.Checked)
                {
                    using (SPSite _site = new SPSite(SiteURL))
                    {
                        txtBoxOutput.Text += Environment.NewLine + "Site URL: " + _site.Url;
                        txtBoxOutput.Text += Environment.NewLine + "Site Application Name: " + _site.WebApplication.Name;
                        txtBoxOutput.Text += Environment.NewLine + "----------------------LISTS----------------------";
                        using (SPWeb web = _site.OpenWeb())
                        {
                            if (web.Exists)
                            {
                                //SPQuery activeQuery = new SPQuery();
                                //activeQuery.Query = "<Where><EQ><FieldRef Name='Status'/>" +
                                //        "<Value Type='Text'>ActiveControl</Value></EqualityComparer></Where>";
                                foreach (SPList spList in web.Lists)
                                {
                                    txtBoxOutput.Text += Environment.NewLine + spList.Title;
                                }
                            }
                        }
                        txtBoxOutput.Text += Environment.NewLine + "-------------------------------------------------";
                    }

                }
                #endregion
                #region Items
                ///////////Items////////////
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf("Items")) == CheckState.Checked)
                {
                    listURL = SiteURL + "/lists/" + lblListName.Text;

                    using (SPSite _site = new SPSite(SiteURL))
                    {
                        txtBoxOutput.Text += Environment.NewLine + "List URL: " + listURL;
                        txtBoxOutput.Text += Environment.NewLine + "Site Application Name: " + _site.WebApplication.Name;
                        txtBoxOutput.Text += Environment.NewLine + "--------------------LIST-ITEMS--------------------";
                        using (SPWeb web = _site.OpenWeb())
                        {
                            if (web.Exists)
                            {
                                SPList _list = web.Lists[lblListName.Text];
                                foreach (SPListItem SPI in _list.Items)
                                {
                                    txtBoxOutput.Text += Environment.NewLine + SPI.Name;
                                }
                            }
                        }
                        txtBoxOutput.Text += Environment.NewLine + "-------------------------------------------------";
                    }
                }
                #endregion
                #region Properties
                ///////////Properties////////////
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf("Properties")) == CheckState.Checked)
                {
                    listURL = SiteURL + "/lists/" + lblListName.Text;

                    using (SPSite _site = new SPSite(SiteURL))
                    {
                        txtBoxOutput.Text += Environment.NewLine + "List URL: " + listURL;
                        txtBoxOutput.Text += Environment.NewLine + "Site Application Name: " + _site.WebApplication.Name;
                        txtBoxOutput.Text += Environment.NewLine + "---------------------Properties---------------------";
                        using (SPWeb web = _site.OpenWeb())
                        {
                            if (web.Exists)
                            {
                                SPList _list = web.Lists[lblListName.Text];
                                txtBoxOutput.Text += Environment.NewLine + "-------------------------URLS-----------------------";
                                txtBoxOutput.Text += Environment.NewLine + "Display Form URL: " + _list.DefaultDisplayFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "New Form URL: " + _list.DefaultNewFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Edit Form URL: " + _list.DefaultEditFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "View Form URL: " + _list.DefaultViewUrl;                                     
                                txtBoxOutput.Text += Environment.NewLine + "Image Form URL: " + _list.ImageUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Mobile Display Form URL: " + _list.MobileDefaultDisplayFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Mobile New Form URL: " + _list.MobileDefaultNewFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Mobile Edit Form URL: " + _list.MobileDefaultEditFormUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Mobile View Form URL: " + _list.MobileDefaultViewUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Send To Location URL: " + _list.SendToLocationUrl;
                                txtBoxOutput.Text += Environment.NewLine + "Parent Web URL: " + _list.ParentWebUrl;
                                txtBoxOutput.Text += Environment.NewLine + "-----------------END DEFAULT URLS/BEGIN XML---------";
                                txtBoxOutput.Text += Environment.NewLine + _list.PropertiesXml;
                                foreach (SPListItem SPI in _list.Items)
                                {
                                    txtBoxOutput.Text += Environment.NewLine + "Name: " + SPI.Name + " Title: " + SPI.Title;
                                }

                                //foreach (SPListItem SPI in _list.Items) //for iterating through the properties of an item
                                //{
                                //    if(SPI.Name==lblItemName.Text)
                                //    {
                                //        if (SPI.Properties.Count > 0)
                                //        {
                                //            Hashtable ht = SPI.Properties;
                                //            foreach(DictionaryEntry de in ht)
                                //            {
                                //                txtBoxOutput.Text += Environment.NewLine + "Key=" + de.Key + "Value=" + de.Value;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            txtBoxOutput.Text += Environment.NewLine + "No properties found for this item!";
                                //        }
                                //    }
                                    
                                //}
                            }
                        }
                        txtBoxOutput.Text += Environment.NewLine + "-------------------------------------------------";
                    }
                }
                #endregion
#region On Exit
                ///////////On Exit////////////
                txtBoxOutput.Text += Environment.NewLine + "Finished retrieval of data.";
                toolStripStatusLabel1.Text = "Ready Player 1.";
#endregion
            }
            catch (Exception ex)
            {
                txtBoxOutput.Text += Environment.NewLine + "Inner Exception: " + ex.InnerException;
                txtBoxOutput.Text += Environment.NewLine + "Message: " + ex.Message;
                txtBoxOutput.Text += Environment.NewLine + "Stack Trace: " + ex.StackTrace;
                txtBoxOutput.Text += Environment.NewLine + "Source: " + ex.Source;
            }

        }
        bool IsDumpDown = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if(IsDumpDown==true)
            {
                button1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"dumpTruckUp.png"));
                txtBoxOutput.Text = "Cleared.";
                toolStripStatusLabel1.Text = "Text Reset! Ready player 1!";
                IsDumpDown = false;
            }
            else
            {
                button1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "dumpTruckDown.png")); 
                IsDumpDown = true;
            }
        }
    }
}




