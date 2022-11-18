using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace MacAddrChanger
{
    class Adapter
    {
        public ManagementObject adapter;
        public string adaptername;
        public string customname;
        public int devnum;

        public Adapter(ManagementObject a, string aname, string cname, int n)
        {
            this.adapter = a;
            this.adaptername = aname;
            this.customname = cname;
            this.devnum = n;
        }

        public Adapter(NetworkInterface i) : this(i.Description) { }

        public Adapter(string aname)
        {
            this.adaptername = aname;

            var searcher = new ManagementObjectSearcher("select * from win32_networkadapter where Name='" + adaptername + "'");
            var found = searcher.Get();
            this.adapter = found.Cast<ManagementObject>().FirstOrDefault();

            try
            {
                var match = Regex.Match(adapter.Path.RelativePath, "\\\"(\\d+)\\\"$");
                this.devnum = int.Parse(match.Groups[1].Value);
            }
            catch
            {
                return;
            }

            this.customname = NetworkInterface.GetAllNetworkInterfaces().Where(
                i => i.Description == adaptername
            ).Select(
                i => " (" + i.Name + ")"
            ).FirstOrDefault();
        }

        public NetworkInterface ManagedAdapter
        {
            get
            {
                return NetworkInterface.GetAllNetworkInterfaces().Where(
                    nic => nic.Description == this.adaptername
                ).FirstOrDefault();
            }
        }

        public string Mac
        {
            get
            {
                try
                {
                    return BitConverter.ToString(this.ManagedAdapter.GetPhysicalAddress().GetAddressBytes()).Replace("-", "").ToUpper();
                }
                catch { return null; }
            }
        }

        public string RegistryKey
        {
            get
            {
                return String.Format(@"SYSTEM\ControlSet001\Control\Class\{{4D36E972-E325-11CE-BFC1-08002BE10318}}\{0:D4}", this.devnum);
            }
        }

        public string RegistryMac
        {
            get
            {
                try
                {
                    using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, false))
                    {
                        return regkey.GetValue("NetworkAddress").ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        
        public bool SetRegistryMac(string value)
        {
            bool shouldReenable = false;

            try
            {
                if (value.Length > 0 && !Adapter.IsValidMac(value, false))
                    throw new Exception(value + " is not a valid mac address");

                using (RegistryKey regkey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, true))
                {
                    if (regkey == null)
                        throw new Exception("Failed to open the registry key");

                    if (regkey.GetValue("AdapterModel") as string != this.adaptername
                        && regkey.GetValue("DriverDesc") as string != this.adaptername)
                        throw new Exception("Adapter not found in registry");

                    string question = value.Length > 0 ?
                        "Changing MAC-adress of adapter {0} from {1} to {2}. Proceed?" :
                        "Clearing custom MAC-address of adapter {0}. Proceed?";
                    DialogResult proceed = MessageBox.Show(
                        String.Format(question, this.ToString(), this.Mac, value),
                        "Change MAC-address?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (proceed != DialogResult.Yes)
                        return false;

                    var result = (uint)adapter.InvokeMethod("Disable", null);
                    if (result != 0)
                        throw new Exception("Failed to disable network adapter.");

                    shouldReenable = true;

                    if (value.Length > 0)
                        regkey.SetValue("NetworkAddress", value, RegistryValueKind.String);
                    else
                        regkey.DeleteValue("NetworkAddress");

                    return true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            finally
            {
                if (shouldReenable)
                {
                    uint result = (uint)adapter.InvokeMethod("Enable", null);
                    if (result != 0)
                        MessageBox.Show("Failed to re-enable network adapter.");
                }
            }
        }

        public override string ToString()
        {
            return this.adaptername + this.customname;
        }

        public static string GetNewMac()
        {
            System.Random r = new System.Random();

            byte[] bytes = new byte[6];
            r.NextBytes(bytes);

            bytes[0] = (byte)(bytes[0] | 0x02);
            bytes[0] = (byte)(bytes[0] & 0xfe);

            return MacToString(bytes);
        }

        public static bool IsValidMac(string mac, bool actual)
        {
            if (mac.Length != 12)
                return false;

            if (mac != mac.ToUpper())
                return false;

            if (!Regex.IsMatch(mac, "^[0-9A-F]*$"))
                return false;

            if (actual)
                return true;

            char c = mac[1];
            return (c == '2' || c == '6' || c == 'A' || c == 'E');
        }

        public static bool IsValidMac(byte[] bytes, bool actual)
        {
            return IsValidMac(Adapter.MacToString(bytes), actual);
        }

        public static string MacToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
        }

    }
}
