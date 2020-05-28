namespace RobotRecipeManager
{
    partial class AddChart
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
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.listView1 = new DragNDrop.DragAndDropListView();
            this.Station_ID_Link = new System.Windows.Forms.ComboBox();
            this.File_Name = new System.Windows.Forms.TextBox();
            this.Workstation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Select_Image = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.STATION_OUT = new System.Windows.Forms.ComboBox();
            this.CHILD_NODE_NUM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(400, 511);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(117, 30);
            this.btn_del.TabIndex = 4;
            this.btn_del.Text = "Delete";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(207, 511);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(117, 30);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowDrop = true;
            this.listView1.AllowReorder = true;
            this.listView1.HideSelection = false;
            this.listView1.LineColor = System.Drawing.Color.Red;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 366);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Station_ID_Link
            // 
            this.Station_ID_Link.FormattingEnabled = true;
            this.Station_ID_Link.Location = new System.Drawing.Point(385, 404);
            this.Station_ID_Link.Name = "Station_ID_Link";
            this.Station_ID_Link.Size = new System.Drawing.Size(130, 21);
            this.Station_ID_Link.TabIndex = 5;
            // 
            // File_Name
            // 
            this.File_Name.Location = new System.Drawing.Point(134, 404);
            this.File_Name.Name = "File_Name";
            this.File_Name.Size = new System.Drawing.Size(130, 20);
            this.File_Name.TabIndex = 6;
            // 
            // Workstation
            // 
            this.Workstation.AutoSize = true;
            this.Workstation.Location = new System.Drawing.Point(300, 406);
            this.Workstation.Name = "Workstation";
            this.Workstation.Size = new System.Drawing.Size(64, 13);
            this.Workstation.TabIndex = 7;
            this.Workstation.Text = "Workstation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Image Name";
            // 
            // Select_Image
            // 
            this.Select_Image.Location = new System.Drawing.Point(16, 511);
            this.Select_Image.Name = "Select_Image";
            this.Select_Image.Size = new System.Drawing.Size(117, 30);
            this.Select_Image.TabIndex = 9;
            this.Select_Image.Text = "Select _Image";
            this.Select_Image.UseVisualStyleBackColor = true;
            this.Select_Image.Click += new System.EventHandler(this.Select_Image_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Number of Nodes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Station Output";
            // 
            // STATION_OUT
            // 
            this.STATION_OUT.FormattingEnabled = true;
            this.STATION_OUT.Items.AddRange(new object[] {
            "True",
            "False"});
            this.STATION_OUT.Location = new System.Drawing.Point(385, 459);
            this.STATION_OUT.Name = "STATION_OUT";
            this.STATION_OUT.Size = new System.Drawing.Size(130, 21);
            this.STATION_OUT.TabIndex = 12;
            // 
            // CHILD_NODE_NUM
            // 
            this.CHILD_NODE_NUM.Location = new System.Drawing.Point(134, 456);
            this.CHILD_NODE_NUM.Name = "CHILD_NODE_NUM";
            this.CHILD_NODE_NUM.Size = new System.Drawing.Size(130, 20);
            this.CHILD_NODE_NUM.TabIndex = 13;
            // 
            // AddChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 564);
            this.Controls.Add(this.CHILD_NODE_NUM);
            this.Controls.Add(this.STATION_OUT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Select_Image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Workstation);
            this.Controls.Add(this.File_Name);
            this.Controls.Add(this.Station_ID_Link);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Name = "AddChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddChart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddChart_FormClosing);
            this.Load += new System.EventHandler(this.AddChart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        //private System.Windows.Forms.ListView listView1;
        private DragNDrop.DragAndDropListView listView1;
        private System.Windows.Forms.ComboBox Station_ID_Link;
        private System.Windows.Forms.TextBox File_Name;
        private System.Windows.Forms.Label Workstation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Select_Image;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox STATION_OUT;
        private System.Windows.Forms.TextBox CHILD_NODE_NUM;
    }
}