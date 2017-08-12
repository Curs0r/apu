using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace APU
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void SaveCar(Car c)
        {
            string[] lines = File.ReadAllLines(c.Path);
            int i = 0;
            foreach (var line in lines)
            {
                if (line.StartsWith("allowedPlaces"))
                {
                    lines[i] = line.Replace("Junkyard", "").Replace("Auction", "").Replace("Shed", "").Replace("Salon", "").Replace(",", "");
                    if (c.Junkyard)
                    {
                        lines[i] += ",Junkyard";
                    }
                    if (c.Auction)
                    {
                        lines[i] += ",Auction";
                    }
                    if (c.Salon)
                    {
                        lines[i] += ",Salon";
                    }
                    if (c.Shed)
                    {
                        lines[i] += ",Shed";
                    }
                }
                i++;
            }
            File.WriteAllLines(c.Path, lines);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Properties.Settings.Default.GamePath))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select your Car Mechanic Simulator 2018 Installation Folder.";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.GamePath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            foreach (var carpath in Directory.EnumerateDirectories(Properties.Settings.Default.GamePath + "\\cms2018_Data\\StreamingAssets\\Cars\\"))
            {
                string cp = carpath + "\\";
                string name = File.ReadAllText(carpath + "\\name.txt");
                foreach (var file in Directory.EnumerateFiles(cp, "config*.txt"))
                {
                    Car c = new Car();
                    c.Path = file;
                    string[] cfg = File.ReadAllLines(file);
                    foreach (var line in cfg)
                    {
                        if (line.StartsWith("carVersionName"))
                        {
                            c.Name = name + " " + line.Substring(line.IndexOf('=') + 1);
                        }
                        if (line.StartsWith("allowedPlaces"))
                        {
                            string[] places = line.Substring(line.IndexOf('=') + 1).Split(',');
                            foreach (var place in places)
                            {
                                switch (place)
                                {
                                    case "Shed":
                                        c.Shed = true;
                                        break;
                                    case "Junkyard":
                                        c.Junkyard = true;
                                        break;
                                    case "Auction":
                                        c.Auction = true;
                                        break;
                                    case "Salon":
                                        c.Salon = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = c.Name;
                    lvi.Tag = c;
                    IEnumerable<string> files = Directory.EnumerateFiles(carpath + "\\PartThumb\\", "*-car*");
                    if (files.Count() > 0)
                    {
                        c.Image = Image.FromFile(files.SingleOrDefault());
                    }
                    lvwCars.Items.Add(lvi);
                }
            }
        }

        private void lvwCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView view = (sender as ListView);
            if (view.SelectedIndices.Count > 0)
            {
                Car c = (view.Items[view.SelectedIndices[0]].Tag as Car);
                chkAuction.Checked = c.Auction;
                chkJunk.Checked = c.Junkyard;
                chkSalon.Checked = c.Salon;
                chkShed.Checked = c.Shed;
                pbxCarImage.Image = c.Image;
                lblCarName.Text = c.Name;
            }
        }

        private void chkAuction_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Auction = (sender as CheckBox).Checked;
                SaveCar(c);
            }
        }

        private void chkSalon_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Salon = (sender as CheckBox).Checked;
                SaveCar(c);
            }
        }

        private void chkJunk_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Junkyard = (sender as CheckBox).Checked;
                SaveCar(c);
            }
        }

        private void chkShed_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Shed = (sender as CheckBox).Checked;
                SaveCar(c);
            }
        }

        private void tsbSalonAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Salon = true;
                SaveCar(c);
                chkSalon.Checked = true;
            }
        }

        private void tsbSalonNone_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Salon = false;
                SaveCar(c);
                chkSalon.Checked = false;
            }
        }

        private void tsbAuctionAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Auction = true;
                SaveCar(c);
                chkAuction.Checked = true;
            }
        }

        private void tsbAuctionNone_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Auction = false;
                SaveCar(c);
                chkAuction.Checked = false;
            }
        }

        private void tsbJunkyardAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Junkyard = true;
                SaveCar(c);
                chkJunk.Checked = true;
            }
        }

        private void tsbJunkyardNone_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Junkyard = false;
                SaveCar(c);
                chkJunk.Checked = false;
            }
        }

        private void tsbBarnsAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Shed = true;
                SaveCar(c);
                chkShed.Checked = true;
            }
        }

        private void tsbBarnsNone_Click(object sender, EventArgs e)
        {
            foreach (var item in lvwCars.Items)
            {
                Car c = (item as ListViewItem).Tag as Car;
                c.Shed = false;
                SaveCar(c);
                chkShed.Checked = false;
            }
        }
    }
}
