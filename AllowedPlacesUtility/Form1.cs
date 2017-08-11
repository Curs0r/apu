using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU
{
    public partial class Form1 : Form
    {
        ImageList il = new ImageList();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                string[] lines = File.ReadAllLines(c.Path);
                int i = 0;
                foreach (var line in lines)
                {
                    if (line.StartsWith("allowedPlaces"))
                    {
                        lines[i] = line.Replace("Junkyard","").Replace("Auction", "").Replace("Shed", "").Replace("Salon", "").Replace(",", "");
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            foreach (var carpath in Directory.EnumerateDirectories(Properties.Settings.Default.GamePath))
            {
                string cp = carpath + "\\";
                string name = File.ReadAllText(carpath + "\\name.txt");
                foreach (var file in Directory.EnumerateFiles(cp))
                {
                    if (file.Substring(file.LastIndexOf('\\')+1).ToLower().StartsWith("config"))
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
                        foreach (var image in Directory.EnumerateFiles(carpath + "\\PartThumb\\"))
                        {
                            string ifname = image.Substring(image.LastIndexOf('\\') + 1);
                            if (ifname.Substring(ifname.IndexOf('-') + 1).ToLower().StartsWith("car"))
                            {
                                c.Image = Image.FromFile(image);
                                break;
                            }
                        }
                        lvwCars.Items.Add(lvi);
;                    }
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
            }
        }

        private void chkSalon_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Salon = (sender as CheckBox).Checked;
            }
        }

        private void chkJunk_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Junkyard = (sender as CheckBox).Checked;
            }
        }

        private void chkShed_CheckedChanged(object sender, EventArgs e)
        {
            if (lvwCars.SelectedItems.Count > 0)
            {
                Car c = (lvwCars.SelectedItems[0].Tag as Car);
                c.Shed = (sender as CheckBox).Checked;
            }
        }
    }
}
