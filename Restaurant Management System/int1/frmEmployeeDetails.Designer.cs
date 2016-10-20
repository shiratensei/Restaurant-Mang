namespace int1
{
    partial class frmEmployeeDetails
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
            this.lblAddEmp = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblEmpContact = new System.Windows.Forms.Label();
            this.lblEmpPostcode = new System.Windows.Forms.Label();
            this.lblEmpAddress = new System.Windows.Forms.Label();
            this.lblEmpState = new System.Windows.Forms.Label();
            this.cbEmpState = new System.Windows.Forms.ComboBox();
            this.txtEmpAddress = new System.Windows.Forms.TextBox();
            this.txtEmpContact = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpPostcode = new System.Windows.Forms.TextBox();
            this.lblEmpSalary = new System.Windows.Forms.Label();
            this.lblEmpPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtEmpSalary = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtEmpCity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAddEmp
            // 
            this.lblAddEmp.AutoSize = true;
            this.lblAddEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEmp.Location = new System.Drawing.Point(28, 19);
            this.lblAddEmp.Name = "lblAddEmp";
            this.lblAddEmp.Size = new System.Drawing.Size(179, 25);
            this.lblAddEmp.TabIndex = 5;
            this.lblAddEmp.Text = "Employee Details";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(465, 418);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(49, 70);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(38, 13);
            this.lblEmpName.TabIndex = 13;
            this.lblEmpName.Text = "Name:";
            // 
            // lblEmpContact
            // 
            this.lblEmpContact.AutoSize = true;
            this.lblEmpContact.Location = new System.Drawing.Point(49, 110);
            this.lblEmpContact.Name = "lblEmpContact";
            this.lblEmpContact.Size = new System.Drawing.Size(47, 13);
            this.lblEmpContact.TabIndex = 14;
            this.lblEmpContact.Text = "Contact:";
            // 
            // lblEmpPostcode
            // 
            this.lblEmpPostcode.AutoSize = true;
            this.lblEmpPostcode.Location = new System.Drawing.Point(49, 190);
            this.lblEmpPostcode.Name = "lblEmpPostcode";
            this.lblEmpPostcode.Size = new System.Drawing.Size(55, 13);
            this.lblEmpPostcode.TabIndex = 15;
            this.lblEmpPostcode.Text = "Postcode:";
            // 
            // lblEmpAddress
            // 
            this.lblEmpAddress.AutoSize = true;
            this.lblEmpAddress.Location = new System.Drawing.Point(49, 150);
            this.lblEmpAddress.Name = "lblEmpAddress";
            this.lblEmpAddress.Size = new System.Drawing.Size(48, 13);
            this.lblEmpAddress.TabIndex = 16;
            this.lblEmpAddress.Text = "Address:";
            // 
            // lblEmpState
            // 
            this.lblEmpState.AutoSize = true;
            this.lblEmpState.Location = new System.Drawing.Point(49, 270);
            this.lblEmpState.Name = "lblEmpState";
            this.lblEmpState.Size = new System.Drawing.Size(35, 13);
            this.lblEmpState.TabIndex = 17;
            this.lblEmpState.Text = "State:";
            // 
            // cbEmpState
            // 
            this.cbEmpState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpState.FormattingEnabled = true;
            this.cbEmpState.Items.AddRange(new object[] {
            "Johor",
            "Kedah",
            "Kelantan",
            "Kuala Lumpur",
            "Labuan",
            "Melaka",
            "Negeri Sembilan",
            "Pahang",
            "Perak",
            "Perlis",
            "Pulau Pinang",
            "Putrajaya",
            "Sabah",
            "Sarawak",
            "Selangor",
            "Terrenganu"});
            this.cbEmpState.Location = new System.Drawing.Point(154, 267);
            this.cbEmpState.Name = "cbEmpState";
            this.cbEmpState.Size = new System.Drawing.Size(121, 21);
            this.cbEmpState.TabIndex = 18;
            // 
            // txtEmpAddress
            // 
            this.txtEmpAddress.Location = new System.Drawing.Point(154, 147);
            this.txtEmpAddress.Name = "txtEmpAddress";
            this.txtEmpAddress.Size = new System.Drawing.Size(327, 20);
            this.txtEmpAddress.TabIndex = 19;
            // 
            // txtEmpContact
            // 
            this.txtEmpContact.Location = new System.Drawing.Point(154, 107);
            this.txtEmpContact.Name = "txtEmpContact";
            this.txtEmpContact.Size = new System.Drawing.Size(100, 20);
            this.txtEmpContact.TabIndex = 21;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(154, 67);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(327, 20);
            this.txtEmpName.TabIndex = 22;
            // 
            // txtEmpPostcode
            // 
            this.txtEmpPostcode.Location = new System.Drawing.Point(154, 187);
            this.txtEmpPostcode.MaxLength = 5;
            this.txtEmpPostcode.Name = "txtEmpPostcode";
            this.txtEmpPostcode.Size = new System.Drawing.Size(100, 20);
            this.txtEmpPostcode.TabIndex = 24;
            // 
            // lblEmpSalary
            // 
            this.lblEmpSalary.AutoSize = true;
            this.lblEmpSalary.Location = new System.Drawing.Point(49, 350);
            this.lblEmpSalary.Name = "lblEmpSalary";
            this.lblEmpSalary.Size = new System.Drawing.Size(65, 13);
            this.lblEmpSalary.TabIndex = 23;
            this.lblEmpSalary.Text = "Salary (RM):";
            // 
            // lblEmpPosition
            // 
            this.lblEmpPosition.AutoSize = true;
            this.lblEmpPosition.Location = new System.Drawing.Point(49, 310);
            this.lblEmpPosition.Name = "lblEmpPosition";
            this.lblEmpPosition.Size = new System.Drawing.Size(47, 13);
            this.lblEmpPosition.TabIndex = 25;
            this.lblEmpPosition.Text = "Position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(154, 307);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(100, 20);
            this.txtPosition.TabIndex = 26;
            // 
            // txtEmpSalary
            // 
            this.txtEmpSalary.Location = new System.Drawing.Point(154, 347);
            this.txtEmpSalary.Name = "txtEmpSalary";
            this.txtEmpSalary.Size = new System.Drawing.Size(100, 20);
            this.txtEmpSalary.TabIndex = 20;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(49, 230);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 27;
            this.lblCity.Text = "City: ";
            // 
            // txtEmpCity
            // 
            this.txtEmpCity.Location = new System.Drawing.Point(154, 227);
            this.txtEmpCity.Name = "txtEmpCity";
            this.txtEmpCity.Size = new System.Drawing.Size(100, 20);
            this.txtEmpCity.TabIndex = 28;
            // 
            // frmEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 453);
            this.Controls.Add(this.txtEmpCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblEmpPosition);
            this.Controls.Add(this.txtEmpPostcode);
            this.Controls.Add(this.lblEmpSalary);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtEmpContact);
            this.Controls.Add(this.txtEmpSalary);
            this.Controls.Add(this.txtEmpAddress);
            this.Controls.Add(this.cbEmpState);
            this.Controls.Add(this.lblEmpState);
            this.Controls.Add(this.lblEmpAddress);
            this.Controls.Add(this.lblEmpPostcode);
            this.Controls.Add(this.lblEmpContact);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAddEmp);
            this.Name = "frmEmployeeDetails";
            this.Text = "Add Employee";
            this.Load += new System.EventHandler(this.frmEmployeeDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAddEmp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblEmpContact;
        private System.Windows.Forms.Label lblEmpPostcode;
        private System.Windows.Forms.Label lblEmpAddress;
        private System.Windows.Forms.Label lblEmpState;
        private System.Windows.Forms.ComboBox cbEmpState;
        private System.Windows.Forms.TextBox txtEmpAddress;
        private System.Windows.Forms.TextBox txtEmpContact;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtEmpPostcode;
        private System.Windows.Forms.Label lblEmpSalary;
        private System.Windows.Forms.Label lblEmpPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtEmpSalary;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtEmpCity;
    }
}