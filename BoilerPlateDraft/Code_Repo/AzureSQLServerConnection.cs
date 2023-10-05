//AppConfig file with the connection string encrypted for added security

<? xml version = "1.0" encoding = "utf-8" ?>
   < configuration >
   
	   < startup >
   
		   < supportedRuntime version = "v4.0" sku = ".NETFramework,Version=v4.7.2" />
	  
		  </ startup >
	  
		  < appSettings >
	  
			  < add key = "connectionstring" value = "w2tVGx1HJy84aWi4ldpJupNLbmx2X1vOq8JiZoQdhB6xC/VOKZvrqhGWpu/ljczU3n3+doNZ3vNuvtaFmbN97CwNwj5gKyQoKAqkZ2MkelgangdSQddbYmQnV4xfbUPn1t1iE31/BmWHcahp4fvkWA==" />
		
				< add key = "encryptKey" value = "f14za5798a4e4353bbce2ea1316z1016" />
		  
			  </ appSettings >
		  </ configuration >

//use the below imports
using Microsoft.SqlServer;
using System.Data.SqlClient;


//Add this to your procudeure to look up info in a database and return one or more records.  If no records are found, provide a Messagebox to 
//inform the user the search did not produce any records. 
  try
{

    //Decrypt ConnectionString - value stored encrypted in App.config file along with unencrypted key for decrypting
    string connectionstring = DecryptString(ConfigurationManager.AppSettings.Get("encryptKey"), ConfigurationManager.AppSettings.Get("connectionstring"));

    using (SqlConnection conn = new SqlConnection(connectionstring))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            var SQLParam = new SqlParameter("SQLParameterName", SqlDbType.Int);
            SQLParam.Value = txtBarCode.Text;
            cmd.Parameters.Add(SQLParam);
            cmd.CommandText = "SQL Statement=@SQLParameterName;";

            Boolean FoundRecords = false; //this logic assumes the user enters the correct value to search the database for. 

            //There are other ways to assign values in a db to variables or text boxes etc. but a datareader allows you to step through
            //the data retruned and assign it to text box or variable in your code. 

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FoundRecords = true;
                txtBarCode.Text = dr["InventoryIdentifierBarCode"].ToString();
                txtMake.Text = dr["Make"].ToString();
                txtModel.Text = dr["ModelNumber"].ToString();
                txtAssignedUser.Text = dr["AssignedUser"].ToString();
                txtSerialNumber.Text = dr["SerialNumber"].ToString();
                txtOSVersion.Text = dr["OSVersion"].ToString();
                txtLicense.Text = dr["OSLicenseNumber"].ToString();
                txtMachineName.Text = dr["MachineName"].ToString();

                txtRAM.Text = dr["RAMInGigabytes"].ToString();
                txtMACAddress.Text = dr["MACAddress"].ToString();
                txtIPAddress.Text = dr["LastLoggedIPAddress"].ToString();
                txtCPU.Text = dr["CPUID"].ToString();
                txtCPUSpeed.Text = dr["CPUSpeed"].ToString();
                txtNoProcessors.Text = dr["NumberOfProcessors"].ToString();
                txtRAMSlots.Text = dr["NumberOfRAMSlots"].ToString();
                cbxBuildingName.Text = dr["BuildingName"].ToString();
                txtRoomNumber.Text = dr["RoomNumber"].ToString();
                cbxAssetType.Text = dr["AssetTypeID"].ToString();
                chkCapitalItem.Text = dr["CapitalItem"].ToString();
                txtPurchaseDate.Text = dr["PurchasedDate"].ToString();

            }

            conn.Close();
            if (!FoundRecords) //If the lookup was not found let the user know.
            {
                conn.close();
                MessageBox.Show("The barcode number was not found in the database.");
                txtBarCode.Text = "";
                txtBarCode.Focus();


            }
        }
    }
}

catch (Exception ex)
{
     catch (Exception ex)
            {
                string connectionstring = DecryptString(ConfigurationManager.AppSettings.Get("encryptKey"), ConfigurationManager.AppSettings.Get("connectionstring"));

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Close();


                    MessageBox.Show(ex.Message);

                }
            }
        }

//Check if the user is Admin on their local computer and prevent users from running an app intended for endpoint. 
//If they are not - close the application after letting them know they cannot run the applicaiton.
//If they feel they should be able to then they can contact the Director of Professional Services for IT/Tech Services 
        private static bool IsAdministrationRules()
{

    try
    {
        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
        {
            bool b = (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);
            if (!b)
            {
                MessageBox.Show("You are not Administrator on your PC.  Contact the help desk and submit a ticket for Professional Services");
                System.Windows.Forms.Application.Exit();
            }
            return b;
        }
    }
    catch
    {
        return false;
    }
}