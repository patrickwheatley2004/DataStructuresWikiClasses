namespace DataStructuresWikiClasses
{
    partial class frmMain
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbNonLinear = new System.Windows.Forms.RadioButton();
            this.tbxDefinition = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.lvDataStructures = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(12, 12);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(149, 20);
            this.tbxName.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Array",
            "List",
            "Hash",
            "Graph"});
            this.cbCategory.Location = new System.Drawing.Point(12, 38);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(149, 21);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.Text = "Array";
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(12, 65);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(54, 17);
            this.rbLinear.TabIndex = 3;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            // 
            // rbNonLinear
            // 
            this.rbNonLinear.AutoSize = true;
            this.rbNonLinear.Location = new System.Drawing.Point(12, 88);
            this.rbNonLinear.Name = "rbNonLinear";
            this.rbNonLinear.Size = new System.Drawing.Size(77, 17);
            this.rbNonLinear.TabIndex = 4;
            this.rbNonLinear.TabStop = true;
            this.rbNonLinear.Text = "Non-Linear";
            this.rbNonLinear.UseVisualStyleBackColor = true;
            // 
            // tbxDefinition
            // 
            this.tbxDefinition.Location = new System.Drawing.Point(12, 111);
            this.tbxDefinition.Name = "tbxDefinition";
            this.tbxDefinition.Size = new System.Drawing.Size(149, 20);
            this.tbxDefinition.TabIndex = 5;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(14, 166);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 6;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            // 
            // lvDataStructures
            // 
            this.lvDataStructures.HideSelection = false;
            this.lvDataStructures.Location = new System.Drawing.Point(167, 12);
            this.lvDataStructures.Name = "lvDataStructures";
            this.lvDataStructures.Size = new System.Drawing.Size(186, 417);
            this.lvDataStructures.TabIndex = 7;
            this.lvDataStructures.UseCompatibleStateImageBehavior = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvDataStructures);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.tbxDefinition);
            this.Controls.Add(this.rbNonLinear);
            this.Controls.Add(this.rbLinear);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.RadioButton rbNonLinear;
        private System.Windows.Forms.TextBox tbxDefinition;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.ListView lvDataStructures;
    }
}

