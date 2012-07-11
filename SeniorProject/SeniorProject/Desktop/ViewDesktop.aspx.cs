using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SeniorProject
{
    public partial class ViewDesktop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string compID = Session["CurrentComputer"].ToString();
                string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;

                Desktop dTop = new Desktop();
                dTop = DesktopDA.getDesktop(compID, connString);

                txtBoxServiceTag.Text = dTop.SerialNo;
                txtBoxSMSUTag.Text = dTop.SMSUtag;
                txtBoxManufacturer.Text = dTop.Manufacturer;
                txtBoxModel.Text = dTop.Model;
                txtBoxBuilding.Text = dTop.Building;
                txtBoxRoomNumber.Text = dTop.RoomNo;
                txtBoxPrimaryUser.Text = dTop.PrimaryUser;
                txtBoxName.Text = dTop.Name;
                txtBoxPurchaseDate.Text = dTop.PurchaseDate;
                txtBoxPurchasePrice.Text = dTop.PurchasePrice;
                txtBoxWarrantyExpires.Text = dTop.WarrantyExpires;
                txtBoxPoNo.Text = dTop.PONum;
                txtBoxCPU.Text = dTop.CPU;
                txtBoxVideoCard.Text = dTop.VideoCard;
                txtBoxHardDrive.Text = dTop.HardDrive;
                txtBoxMemory.Text = dTop.Memory;
                txtBoxOpticalDrive.Text = dTop.OpticalDrive;
                txtBoxRemovableMedia.Text = dTop.RemovableMedia;
                txtBoxUSBPorts.Text = dTop.USBports;
                txtBoxOtherConnectivity.Text = dTop.OtherConnectivity;
                txtBoxSize.Text = dTop.Size;
                txtBoxNotes.Text = dTop.Notes;
                
                //txtBoxAttachedMonitor.Text = dTop.Monitor;
                if (dTop.Monitor.ID == 0)
                {
                    ddlMonitor.Text = "None Selected";
                }
                else
                {
                    ddlMonitor.SelectedValue = dTop.Monitor.ID.ToString();
                }
                           
            }
        }

        protected void btnUpdateDesktop_Click(object sender, EventArgs e)
        {
            string compID = Session["CurrentComputer"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
            Desktop oTop = new Desktop();
            oTop = DesktopDA.getDesktop(compID, connString);
            
            Desktop dTop = new Desktop();
            dTop.ID = Convert.ToInt32(compID);
            dTop.SerialNo = txtBoxServiceTag.Text;
            dTop.SMSUtag = txtBoxSMSUTag.Text;
            dTop.Manufacturer = txtBoxManufacturer.Text;
            dTop.Model = txtBoxModel.Text;
            dTop.Building = txtBoxBuilding.Text;
            dTop.RoomNo = txtBoxRoomNumber.Text;
            dTop.PrimaryUser = txtBoxPrimaryUser.Text;
            dTop.PurchaseDate = txtBoxPurchaseDate.Text;
            dTop.PurchasePrice = txtBoxPurchasePrice.Text;
            dTop.WarrantyExpires = txtBoxWarrantyExpires.Text;
            dTop.PONum = txtBoxPoNo.Text;
            dTop.CPU = txtBoxCPU.Text;
            dTop.VideoCard = txtBoxVideoCard.Text;
            dTop.HardDrive = txtBoxHardDrive.Text;
            dTop.Memory = txtBoxMemory.Text;
            dTop.OpticalDrive = txtBoxOpticalDrive.Text;
            dTop.RemovableMedia = txtBoxRemovableMedia.Text;
            dTop.USBports = txtBoxUSBPorts.Text;
            dTop.OtherConnectivity = txtBoxOtherConnectivity.Text;
            dTop.Size = txtBoxSize.Text;
            dTop.Name = txtBoxName.Text;
            dTop.Notes = txtBoxNotes.Text;
            
            dTop.Monitor = MonitorDA.getMonitor(Convert.ToInt32(ddlMonitor.SelectedValue), connString); 
            
            lblMessage.Text = DesktopDA.updateDesktop(oTop ,dTop, connString);

        }
    }
}