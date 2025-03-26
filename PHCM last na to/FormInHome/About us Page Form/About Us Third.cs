﻿using PHCM_last_na_to.Forms;
using PHCM_last_na_to.HomeForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHCM_last_na_to.FormInHome.About_us_Page_Form
{
    public partial class About_Us_Third: Form
    {
        private Form currentChildForm;
        public About_Us_Third()
        {
            InitializeComponent();
            nextbutton.Parent = HomePic;
            previousbutton.Parent = HomePic;
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) //if the curret form is still open
            {
                currentChildForm.Close(); // Close the current form before opening a new one.
            }
            currentChildForm = childForm; // Set the new form as the current one.
            childForm.TopLevel = false; // Makes the new form a child of the current form.
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes borders around the child form.
            childForm.Dock = DockStyle.Fill; // Makes the child form fill the space available.
            this.Controls.Add(childForm); // Adds the child form to the parent form.
            this.Tag = childForm; // Assigns a tag to the child form for identification.
            childForm.BringToFront(); // Brings the child form to the front of the other controls.
            childForm.Show(); // Displays the child form.            
        }
        private void clicked(object sender, EventArgs e)
        {
            if (sender is PictureBox pc)
            {
                if (pc.Name == "nextbutton")
                {
                    OpenChildForm(new About_Us());
                }
                else if (pc.Name == "previousbutton")
                {
                    OpenChildForm(new About_Us_Second());
                }
            }
            else if (sender is Label lbl)
            {
                if (lbl.Name == "ReturnButton")
                {
                    OpenChildForm(new Home());
                }
            }
        }

        private void entered(object sender, EventArgs e)
        {
            if (sender is PictureBox pc)
            {
                if (pc.Name == "nextbutton")
                {
                    pc.Image = Properties.Resources.nextButtonAboutUsFinal__3_;
                    Cursor = Cursors.Hand;
                }
                else if (pc.Name == "previousbutton")
                {
                    pc.Image = Properties.Resources.rightButtonAboutusFinal;
                    Cursor = Cursors.Hand;
                }
                //else if (pc.Name == "DwayneProfile")
                //{
                //    pc.Image = Properties.Resources.HoveredDwayne;
                //    Cursor = Cursors.Hand;
                //}
                //else if (pc.Name == "ElposProfile")
                //{
                //    pc.Image = Properties.Resources.HoveredElpos;
                //    Cursor = Cursors.Hand;
                //}
                //else if (pc.Name == "GuiterrezProfile")
                //{
                //    pc.Image = Properties.Resources.HoveredGuiterrez;
                //    Cursor = Cursors.Hand;
                //}
                //else if (pc.Name == "MacasangProfile")
                //{
                //    pc.Image = Properties.Resources.HoveredMacasang;
                //    Cursor = Cursors.Hand;
                //}
            }
            else if (sender is Label lbl)
            {
                if (lbl.Name == "ReturnButton")
                {
                    lbl.ForeColor = SystemColors.ControlDarkDark;
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void leaved(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            nextbutton.Image = Properties.Resources.nextButtonAboutUsFinal;
            previousbutton.Image = Properties.Resources.nextButtonAboutUsFinal__2_;
            DwayneProfile.Image = Properties.Resources.DefaultDwayne_1;
            ElposProfile.Image = Properties.Resources.DefaultElpos;
            GuiterrezProfile.Image = Properties.Resources.DefaultGuiterrez;
            MacasangProfile.Image = Properties.Resources.DefaultMacasang;
            ReturnButton.ForeColor = Color.Black;
        }
    }
}
