using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Net.NetworkInformation;


namespace MacAddrChanger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces().Where(
                    a => Adapter.IsValidMac(a.GetPhysicalAddress().GetAddressBytes(), true)
                ).OrderByDescending(a => a.Speed))
            {
                Cmb_Adapter.Items.Add(new Adapter(adapter));
            }

            Cmb_Adapter.SelectedIndex = 0;
        }


        private void Cmb_Adapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddresses();
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            UpdateAddresses();
        }

        private void Btn_RandomGen_Click(object sender, EventArgs e)
        {
            Txt_ChangedMac.Text = Adapter.GetNewMac();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (!Adapter.IsValidMac(Txt_ChangedMac.Text, false))
            {
                MessageBox.Show("输入的Mac地址错误!");
                return;
            }

            SetRegistryMac(Txt_ChangedMac.Text);
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            SetRegistryMac("");
        }

        private void UpdateAddresses()
        {
            Adapter a = Cmb_Adapter.SelectedItem as Adapter;
            this.Txt_ChangedMac.Text = a.RegistryMac;
            this.Txt_CurrentMac.Text = a.Mac;
        }

        private void SetRegistryMac(string mac)
        {
            Adapter a = Cmb_Adapter.SelectedItem as Adapter;

            if (a.SetRegistryMac(mac))
            {
                System.Threading.Thread.Sleep(50);
                UpdateAddresses();
                MessageBox.Show("Mac地址修改成功!");
            }
        }

        
    }
}
