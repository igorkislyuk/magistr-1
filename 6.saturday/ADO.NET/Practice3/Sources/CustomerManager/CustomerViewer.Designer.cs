namespace CustomerManager
{
    partial class CustomerViewer
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
            this.customerList = new System.Windows.Forms.ComboBox();
            this.orderlistBox = new System.Windows.Forms.ListBox();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.textBoxlastname = new System.Windows.Forms.TextBox();
            this.textBoxmail = new System.Windows.Forms.TextBox();
            this.textBoxage = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.CustomerradioButton = new System.Windows.Forms.RadioButton();
            this.OrderradioButton = new System.Windows.Forms.RadioButton();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerList
            // 
            this.customerList.FormattingEnabled = true;
            this.customerList.Location = new System.Drawing.Point(24, 23);
            this.customerList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.customerList.Name = "customerList";
            this.customerList.Size = new System.Drawing.Size(238, 33);
            this.customerList.TabIndex = 0;
            this.customerList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // orderlistBox
            // 
            this.orderlistBox.FormattingEnabled = true;
            this.orderlistBox.ItemHeight = 25;
            this.orderlistBox.Location = new System.Drawing.Point(26, 75);
            this.orderlistBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.orderlistBox.Name = "orderlistBox";
            this.orderlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.orderlistBox.Size = new System.Drawing.Size(236, 179);
            this.orderlistBox.TabIndex = 1;
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(444, 25);
            this.textBoxname.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(196, 31);
            this.textBoxname.TabIndex = 2;
            // 
            // textBoxlastname
            // 
            this.textBoxlastname.Location = new System.Drawing.Point(444, 75);
            this.textBoxlastname.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxlastname.Name = "textBoxlastname";
            this.textBoxlastname.Size = new System.Drawing.Size(196, 31);
            this.textBoxlastname.TabIndex = 3;
            // 
            // textBoxmail
            // 
            this.textBoxmail.Location = new System.Drawing.Point(444, 125);
            this.textBoxmail.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxmail.Name = "textBoxmail";
            this.textBoxmail.Size = new System.Drawing.Size(196, 31);
            this.textBoxmail.TabIndex = 4;
            // 
            // textBoxage
            // 
            this.textBoxage.Location = new System.Drawing.Point(444, 171);
            this.textBoxage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxage.Name = "textBoxage";
            this.textBoxage.Size = new System.Drawing.Size(196, 31);
            this.textBoxage.TabIndex = 5;
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(444, 221);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(200, 44);
            this.buttonFile.TabIndex = 6;
            this.buttonFile.Text = "Выберите файл...";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(698, 21);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 44);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Добавить данные";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.Location = new System.Drawing.Point(860, 21);
            this.buttonOut.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(150, 44);
            this.buttonOut.TabIndex = 8;
            this.buttonOut.Text = "Показать данные";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(1050, 25);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(150, 44);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(698, 77);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(150, 44);
            this.buttonDel.TabIndex = 10;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // CustomerradioButton
            // 
            this.CustomerradioButton.AutoSize = true;
            this.CustomerradioButton.Location = new System.Drawing.Point(12, 33);
            this.CustomerradioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CustomerradioButton.Name = "CustomerradioButton";
            this.CustomerradioButton.Size = new System.Drawing.Size(146, 29);
            this.CustomerradioButton.TabIndex = 11;
            this.CustomerradioButton.TabStop = true;
            this.CustomerradioButton.Text = "Customers";
            this.CustomerradioButton.UseVisualStyleBackColor = true;
            // 
            // OrderradioButton
            // 
            this.OrderradioButton.AutoSize = true;
            this.OrderradioButton.Location = new System.Drawing.Point(12, 83);
            this.OrderradioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OrderradioButton.Name = "OrderradioButton";
            this.OrderradioButton.Size = new System.Drawing.Size(108, 29);
            this.OrderradioButton.TabIndex = 12;
            this.OrderradioButton.TabStop = true;
            this.OrderradioButton.Text = "Orders";
            this.OrderradioButton.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(810, 275);
            this.textBoxCustomer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(196, 31);
            this.textBoxCustomer.TabIndex = 13;
            // 
            // GridView
            // 
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridView.Location = new System.Drawing.Point(0, 350);
            this.GridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.GridView.Name = "GridView";
            this.GridView.Size = new System.Drawing.Size(1224, 250);
            this.GridView.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CustomerradioButton);
            this.groupBox1.Controls.Add(this.OrderradioButton);
            this.groupBox1.Location = new System.Drawing.Point(860, 125);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(376, 133);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор";
            // 
            // labelid
            // 
            this.labelid.AutoSize = true;
            this.labelid.Location = new System.Drawing.Point(758, 281);
            this.labelid.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelid.Name = "labelid";
            this.labelid.Size = new System.Drawing.Size(29, 25);
            this.labelid.TabIndex = 16;
            this.labelid.Text = "id";
            this.labelid.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Last name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Age";
            // 
            // CustomerViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 600);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonOut);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBoxage);
            this.Controls.Add(this.textBoxmail);
            this.Controls.Add(this.textBoxlastname);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.orderlistBox);
            this.Controls.Add(this.customerList);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CustomerViewer";
            this.Text = "Customer Viewer";
            this.Load += new System.EventHandler(this.CustomerViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerList;
        private System.Windows.Forms.ListBox orderlistBox;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.TextBox textBoxlastname;
        private System.Windows.Forms.TextBox textBoxmail;
        private System.Windows.Forms.TextBox textBoxage;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.RadioButton CustomerradioButton;
        private System.Windows.Forms.RadioButton OrderradioButton;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

