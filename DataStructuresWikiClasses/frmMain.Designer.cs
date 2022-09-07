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
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbNonLinear = new System.Windows.Forms.RadioButton();
            this.tbxDefinition = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lvDataStructures = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDataStructure = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbxSearchBar = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chbAutoSave = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbDataStructure.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 243);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnAdd_MouseHover);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(12, 28);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(156, 20);
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
            this.cbCategory.Location = new System.Drawing.Point(12, 67);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(156, 21);
            this.cbCategory.TabIndex = 2;
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(6, 19);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(54, 17);
            this.rbLinear.TabIndex = 3;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbNonLinear
            // 
            this.rbNonLinear.AutoSize = true;
            this.rbNonLinear.Location = new System.Drawing.Point(6, 42);
            this.rbNonLinear.Name = "rbNonLinear";
            this.rbNonLinear.Size = new System.Drawing.Size(77, 17);
            this.rbNonLinear.TabIndex = 4;
            this.rbNonLinear.TabStop = true;
            this.rbNonLinear.Text = "Non-Linear";
            this.rbNonLinear.UseVisualStyleBackColor = true;
            this.rbNonLinear.CheckedChanged += new System.EventHandler(this.rbNonLinear_CheckedChanged);
            // 
            // tbxDefinition
            // 
            this.tbxDefinition.Location = new System.Drawing.Point(12, 185);
            this.tbxDefinition.Multiline = true;
            this.tbxDefinition.Name = "tbxDefinition";
            this.tbxDefinition.Size = new System.Drawing.Size(156, 52);
            this.tbxDefinition.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 243);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseHover += new System.EventHandler(this.btnClear_MouseHover);
            // 
            // lvDataStructures
            // 
            this.lvDataStructures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory});
            this.lvDataStructures.ForeColor = System.Drawing.Color.Black;
            this.lvDataStructures.HideSelection = false;
            this.lvDataStructures.Location = new System.Drawing.Point(174, 28);
            this.lvDataStructures.Name = "lvDataStructures";
            this.lvDataStructures.Size = new System.Drawing.Size(235, 423);
            this.lvDataStructures.TabIndex = 7;
            this.lvDataStructures.UseCompatibleStateImageBehavior = false;
            this.lvDataStructures.View = System.Windows.Forms.View.Details;
            this.lvDataStructures.SelectedIndexChanged += new System.EventHandler(this.lvDataStructures_SelectedIndexChanged);
            this.lvDataStructures.DoubleClick += new System.EventHandler(this.lvDataStructures_DoubleClick);
            this.lvDataStructures.MouseHover += new System.EventHandler(this.lvDataStructures_MouseHover);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 104;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 127;
            // 
            // gbDataStructure
            // 
            this.gbDataStructure.Controls.Add(this.rbLinear);
            this.gbDataStructure.Controls.Add(this.rbNonLinear);
            this.gbDataStructure.Location = new System.Drawing.Point(12, 94);
            this.gbDataStructure.Name = "gbDataStructure";
            this.gbDataStructure.Size = new System.Drawing.Size(156, 72);
            this.gbDataStructure.TabIndex = 8;
            this.gbDataStructure.TabStop = false;
            this.gbDataStructure.Text = "Data Structure";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Definition";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.MouseHover += new System.EventHandler(this.btnEdit_MouseHover);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseHover += new System.EventHandler(this.btnDelete_MouseHover);
            // 
            // tbxSearchBar
            // 
            this.tbxSearchBar.Location = new System.Drawing.Point(174, 5);
            this.tbxSearchBar.Name = "tbxSearchBar";
            this.tbxSearchBar.Size = new System.Drawing.Size(156, 20);
            this.tbxSearchBar.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(334, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(432, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseHover += new System.EventHandler(this.btnSave_MouseHover);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 301);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnLoad.MouseHover += new System.EventHandler(this.btnLoad_MouseHover);
            // 
            // chbAutoSave
            // 
            this.chbAutoSave.AutoSize = true;
            this.chbAutoSave.Checked = true;
            this.chbAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAutoSave.Location = new System.Drawing.Point(12, 330);
            this.chbAutoSave.Name = "chbAutoSave";
            this.chbAutoSave.Size = new System.Drawing.Size(76, 17);
            this.chbAutoSave.TabIndex = 19;
            this.chbAutoSave.Text = "Auto Save";
            this.chbAutoSave.UseVisualStyleBackColor = true;
            this.chbAutoSave.MouseHover += new System.EventHandler(this.chbAutoSave_MouseHover);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 492);
            this.Controls.Add(this.chbAutoSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearchBar);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbDataStructure);
            this.Controls.Add(this.lvDataStructures);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxDefinition);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmMain";
            this.Text = "Wiki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDataStructure.ResumeLayout(false);
            this.gbDataStructure.PerformLayout();
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView lvDataStructures;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.GroupBox gbDataStructure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbxSearchBar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox chbAutoSave;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

