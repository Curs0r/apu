namespace APU
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnApply = new System.Windows.Forms.Button();
            this.lvwCars = new System.Windows.Forms.ListView();
            this.pbxCarImage = new System.Windows.Forms.PictureBox();
            this.lblCarName = new System.Windows.Forms.Label();
            this.gbxPlaces = new System.Windows.Forms.GroupBox();
            this.chkShed = new System.Windows.Forms.CheckBox();
            this.chkJunk = new System.Windows.Forms.CheckBox();
            this.chkSalon = new System.Windows.Forms.CheckBox();
            this.chkAuction = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarImage)).BeginInit();
            this.gbxPlaces.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApply.Location = new System.Drawing.Point(0, 241);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(491, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lvwCars
            // 
            this.lvwCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwCars.Location = new System.Drawing.Point(0, 0);
            this.lvwCars.Name = "lvwCars";
            this.lvwCars.Size = new System.Drawing.Size(491, 90);
            this.lvwCars.TabIndex = 1;
            this.lvwCars.UseCompatibleStateImageBehavior = false;
            this.lvwCars.View = System.Windows.Forms.View.List;
            this.lvwCars.SelectedIndexChanged += new System.EventHandler(this.lvwCars_SelectedIndexChanged);
            // 
            // pbxCarImage
            // 
            this.pbxCarImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbxCarImage.Location = new System.Drawing.Point(0, 90);
            this.pbxCarImage.Name = "pbxCarImage";
            this.pbxCarImage.Size = new System.Drawing.Size(289, 151);
            this.pbxCarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCarImage.TabIndex = 6;
            this.pbxCarImage.TabStop = false;
            // 
            // lblCarName
            // 
            this.lblCarName.AutoSize = true;
            this.lblCarName.BackColor = System.Drawing.Color.Black;
            this.lblCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarName.ForeColor = System.Drawing.Color.White;
            this.lblCarName.Location = new System.Drawing.Point(12, 221);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(0, 20);
            this.lblCarName.TabIndex = 7;
            // 
            // gbxPlaces
            // 
            this.gbxPlaces.Controls.Add(this.chkShed);
            this.gbxPlaces.Controls.Add(this.chkJunk);
            this.gbxPlaces.Controls.Add(this.chkSalon);
            this.gbxPlaces.Controls.Add(this.chkAuction);
            this.gbxPlaces.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxPlaces.Location = new System.Drawing.Point(291, 90);
            this.gbxPlaces.Name = "gbxPlaces";
            this.gbxPlaces.Size = new System.Drawing.Size(200, 151);
            this.gbxPlaces.TabIndex = 8;
            this.gbxPlaces.TabStop = false;
            this.gbxPlaces.Text = "Allowed Places";
            // 
            // chkShed
            // 
            this.chkShed.AutoSize = true;
            this.chkShed.Location = new System.Drawing.Point(109, 30);
            this.chkShed.Name = "chkShed";
            this.chkShed.Size = new System.Drawing.Size(53, 17);
            this.chkShed.TabIndex = 9;
            this.chkShed.Text = "Barns";
            this.chkShed.UseVisualStyleBackColor = true;
            this.chkShed.CheckedChanged += new System.EventHandler(this.chkShed_CheckedChanged);
            // 
            // chkJunk
            // 
            this.chkJunk.AutoSize = true;
            this.chkJunk.Location = new System.Drawing.Point(109, 53);
            this.chkJunk.Name = "chkJunk";
            this.chkJunk.Size = new System.Drawing.Size(69, 17);
            this.chkJunk.TabIndex = 8;
            this.chkJunk.Text = "Junkyard";
            this.chkJunk.UseVisualStyleBackColor = true;
            this.chkJunk.CheckedChanged += new System.EventHandler(this.chkJunk_CheckedChanged);
            // 
            // chkSalon
            // 
            this.chkSalon.AutoSize = true;
            this.chkSalon.Location = new System.Drawing.Point(23, 53);
            this.chkSalon.Name = "chkSalon";
            this.chkSalon.Size = new System.Drawing.Size(53, 17);
            this.chkSalon.TabIndex = 7;
            this.chkSalon.Text = "Salon";
            this.chkSalon.UseVisualStyleBackColor = true;
            this.chkSalon.CheckedChanged += new System.EventHandler(this.chkSalon_CheckedChanged);
            // 
            // chkAuction
            // 
            this.chkAuction.AutoSize = true;
            this.chkAuction.Location = new System.Drawing.Point(23, 30);
            this.chkAuction.Name = "chkAuction";
            this.chkAuction.Size = new System.Drawing.Size(62, 17);
            this.chkAuction.TabIndex = 6;
            this.chkAuction.Text = "Auction";
            this.chkAuction.UseVisualStyleBackColor = true;
            this.chkAuction.CheckedChanged += new System.EventHandler(this.chkAuction_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 264);
            this.Controls.Add(this.gbxPlaces);
            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.pbxCarImage);
            this.Controls.Add(this.lvwCars);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AllowedPlaces Utility For CMS2018";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCarImage)).EndInit();
            this.gbxPlaces.ResumeLayout(false);
            this.gbxPlaces.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView lvwCars;
        private System.Windows.Forms.PictureBox pbxCarImage;
        private System.Windows.Forms.Label lblCarName;
        private System.Windows.Forms.GroupBox gbxPlaces;
        private System.Windows.Forms.CheckBox chkShed;
        private System.Windows.Forms.CheckBox chkJunk;
        private System.Windows.Forms.CheckBox chkSalon;
        private System.Windows.Forms.CheckBox chkAuction;
    }
}

