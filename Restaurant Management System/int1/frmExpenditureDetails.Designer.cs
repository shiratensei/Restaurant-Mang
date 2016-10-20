namespace int1
{
    partial class frmExpenditureDetails
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblExpenditureDetails = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerateEmpSalary = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(153, 72);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 26;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(51, 115);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(51, 75);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(72, 13);
            this.lblAmount.TabIndex = 23;
            this.lblAmount.Text = "Amount (RM):";
            // 
            // lblExpenditureDetails
            // 
            this.lblExpenditureDetails.AutoSize = true;
            this.lblExpenditureDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenditureDetails.Location = new System.Drawing.Point(27, 19);
            this.lblExpenditureDetails.Name = "lblExpenditureDetails";
            this.lblExpenditureDetails.Size = new System.Drawing.Size(199, 25);
            this.lblExpenditureDetails.TabIndex = 27;
            this.lblExpenditureDetails.Text = "Expenditure Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(153, 152);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(259, 20);
            this.txtDescription.TabIndex = 29;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(51, 155);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 28;
            this.lblDescription.Text = "Description:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(427, 253);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 31;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerateEmpSalary
            // 
            this.btnGenerateEmpSalary.Location = new System.Drawing.Point(180, 225);
            this.btnGenerateEmpSalary.Name = "btnGenerateEmpSalary";
            this.btnGenerateEmpSalary.Size = new System.Drawing.Size(127, 51);
            this.btnGenerateEmpSalary.TabIndex = 32;
            this.btnGenerateEmpSalary.Text = "Generate Monthly Salary";
            this.btnGenerateEmpSalary.UseVisualStyleBackColor = true;
            this.btnGenerateEmpSalary.Click += new System.EventHandler(this.btnGenerateEmpSalary_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(153, 110);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(185, 20);
            this.dtpDate.TabIndex = 33;
            // 
            // frmExpenditureDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 290);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnGenerateEmpSalary);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblExpenditureDetails);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmount);
            this.Name = "frmExpenditureDetails";
            this.Text = "Expenditure Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblExpenditureDetails;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateEmpSalary;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}