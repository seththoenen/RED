using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

namespace SeniorProject
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList monList = new ArrayList();
                string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
                monList = MonitorDA.getMonitors(connString);

                for (int i = 0; i < monList.Count; i++)
                {
                    Monitor mon = new Monitor();
                    mon = (Monitor)monList[i];
                    //ddlMonitor.Items.Add(mon.toString());
                }
                
            }
        }

        protected void btnAddDesktop_Click(object sender, EventArgs e)
        {

            string serviceTags = txtBoxServiceTags.Text;

            string[] tags = serviceTags.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            ArrayList desktops = new ArrayList();
            string connString = ConfigurationManager.ConnectionStrings["EquipmentConnectionString"].ConnectionString;
            
            for (int i = 0; i < tags.Length; i++)
            {
                Desktop dTop = new Desktop();
                dTop.SerialNo = tags[i];
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
                dTop.Monitor = MonitorDA.getMonitor(Convert.ToInt32(ddlMonitor.SelectedValue), connString);
                dTop.Notes = txtBoxNotes.Text;

                desktops.Add(dTop);
            }

            lblMessage.Text = DesktopDA.saveDesktop(desktops, connString);

        }
    }
}
