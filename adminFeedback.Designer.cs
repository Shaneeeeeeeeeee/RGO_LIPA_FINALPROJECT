namespace RGO_LIPA_FINALPROJECT
{
    partial class adminFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminFeedback));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rGO_LIPADataSet = new RGO_LIPA_FINALPROJECT.RGO_LIPADataSet();
            this.announcementTableAdapter = new RGO_LIPA_FINALPROJECT.RGO_LIPADataSetTableAdapters.announcementTableAdapter();
            this.announcementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.feedbackBtn = new Guna.UI2.WinForms.Guna2Button();
            this.paymentBtn = new Guna.UI2.WinForms.Guna2Button();
            this.faqBtn = new Guna.UI2.WinForms.Guna2Button();
            this.orderBtn = new Guna.UI2.WinForms.Guna2Button();
            this.productBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.accBtn = new Guna.UI2.WinForms.Guna2Button();
            this.staffBtn = new Guna.UI2.WinForms.Guna2Button();
            this.studentBtn = new Guna.UI2.WinForms.Guna2Button();
            this.announcementBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.logoutBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.fbidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedbacksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedbacksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.viewMyAccountBtn = new Guna.UI2.WinForms.Guna2Button();
            this.feedbacksTableAdapter = new RGO_LIPA_FINALPROJECT.RGO_LIPADataSetTableAdapters.feedbacksTableAdapter();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rGO_LIPADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.announcementBindingSource)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedbacksBindingSource)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rGO_LIPADataSet
            // 
            this.rGO_LIPADataSet.DataSetName = "RGO_LIPADataSet";
            this.rGO_LIPADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // announcementTableAdapter
            // 
            this.announcementTableAdapter.ClearBeforeFill = true;
            // 
            // announcementBindingSource
            // 
            this.announcementBindingSource.DataMember = "announcement";
            this.announcementBindingSource.DataSource = this.rGO_LIPADataSet;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel1.Controls.Add(this.feedbackBtn);
            this.guna2Panel1.Controls.Add(this.paymentBtn);
            this.guna2Panel1.Controls.Add(this.faqBtn);
            this.guna2Panel1.Controls.Add(this.orderBtn);
            this.guna2Panel1.Controls.Add(this.productBtn);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.accBtn);
            this.guna2Panel1.Controls.Add(this.staffBtn);
            this.guna2Panel1.Controls.Add(this.studentBtn);
            this.guna2Panel1.Controls.Add(this.announcementBtn);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(289, 900);
            this.guna2Panel1.TabIndex = 19;
            // 
            // feedbackBtn
            // 
            this.feedbackBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.feedbackBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.BorderRadius = 25;
            this.feedbackBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.feedbackBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.feedbackBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.feedbackBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.feedbackBtn.FillColor = System.Drawing.Color.Transparent;
            this.feedbackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.feedbackBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.feedbackBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.feedbackBtn.Image = ((System.Drawing.Image)(resources.GetObject("feedbackBtn.Image")));
            this.feedbackBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.feedbackBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.feedbackBtn.Location = new System.Drawing.Point(0, 807);
            this.feedbackBtn.Name = "feedbackBtn";
            this.feedbackBtn.Size = new System.Drawing.Size(289, 62);
            this.feedbackBtn.TabIndex = 19;
            this.feedbackBtn.Text = "Feedbacks";
            // 
            // paymentBtn
            // 
            this.paymentBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.BorderRadius = 25;
            this.paymentBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.paymentBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.paymentBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.paymentBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.paymentBtn.FillColor = System.Drawing.Color.Transparent;
            this.paymentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.paymentBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.paymentBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.paymentBtn.Image = ((System.Drawing.Image)(resources.GetObject("paymentBtn.Image")));
            this.paymentBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.paymentBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.paymentBtn.Location = new System.Drawing.Point(0, 671);
            this.paymentBtn.Name = "paymentBtn";
            this.paymentBtn.Size = new System.Drawing.Size(289, 62);
            this.paymentBtn.TabIndex = 17;
            this.paymentBtn.Text = "Payment";
            this.paymentBtn.Click += new System.EventHandler(this.paymentBtn_Click);
            // 
            // faqBtn
            // 
            this.faqBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.BorderRadius = 25;
            this.faqBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.faqBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.faqBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.faqBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.faqBtn.FillColor = System.Drawing.Color.Transparent;
            this.faqBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faqBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.faqBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faqBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.faqBtn.HoverState.Image = global::RGO_LIPA_FINALPROJECT.Properties.Resources.question_mark__1_;
            this.faqBtn.Image = global::RGO_LIPA_FINALPROJECT.Properties.Resources.question_mark;
            this.faqBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.faqBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.faqBtn.Location = new System.Drawing.Point(0, 740);
            this.faqBtn.Name = "faqBtn";
            this.faqBtn.Size = new System.Drawing.Size(289, 62);
            this.faqBtn.TabIndex = 16;
            this.faqBtn.Text = "FAQ";
            this.faqBtn.Click += new System.EventHandler(this.faqBtn_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.BorderRadius = 25;
            this.orderBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.orderBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.orderBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.orderBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.orderBtn.FillColor = System.Drawing.Color.Transparent;
            this.orderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.orderBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.orderBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.orderBtn.Image = ((System.Drawing.Image)(resources.GetObject("orderBtn.Image")));
            this.orderBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.orderBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.orderBtn.Location = new System.Drawing.Point(0, 604);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(289, 62);
            this.orderBtn.TabIndex = 15;
            this.orderBtn.Text = "Orders";
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // productBtn
            // 
            this.productBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.BorderRadius = 25;
            this.productBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.productBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.productBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.productBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.productBtn.FillColor = System.Drawing.Color.Transparent;
            this.productBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.productBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.productBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.productBtn.Image = ((System.Drawing.Image)(resources.GetObject("productBtn.Image")));
            this.productBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.productBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.productBtn.Location = new System.Drawing.Point(0, 534);
            this.productBtn.Name = "productBtn";
            this.productBtn.Size = new System.Drawing.Size(289, 62);
            this.productBtn.TabIndex = 14;
            this.productBtn.Text = "Products";
            this.productBtn.Click += new System.EventHandler(this.productBtn_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::RGO_LIPA_FINALPROJECT.Properties.Resources.image_removebg_preview11;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(62, 133);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(188, 100);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 13;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::RGO_LIPA_FINALPROJECT.Properties.Resources.rgologo21;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(13, 68);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(276, 73);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 12;
            this.guna2PictureBox1.TabStop = false;
            // 
            // accBtn
            // 
            this.accBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.BorderRadius = 25;
            this.accBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.accBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.accBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.accBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.accBtn.FillColor = System.Drawing.Color.Transparent;
            this.accBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.accBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.accBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.accBtn.Image = ((System.Drawing.Image)(resources.GetObject("accBtn.Image")));
            this.accBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.accBtn.ImageOffset = new System.Drawing.Point(18, 0);
            this.accBtn.Location = new System.Drawing.Point(0, 466);
            this.accBtn.Name = "accBtn";
            this.accBtn.Size = new System.Drawing.Size(289, 62);
            this.accBtn.TabIndex = 11;
            this.accBtn.Text = "Accounts";
            this.accBtn.Click += new System.EventHandler(this.accBtn_Click);
            // 
            // staffBtn
            // 
            this.staffBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.BorderRadius = 25;
            this.staffBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.staffBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.staffBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.staffBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.staffBtn.FillColor = System.Drawing.Color.Transparent;
            this.staffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.staffBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.staffBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.staffBtn.Image = ((System.Drawing.Image)(resources.GetObject("staffBtn.Image")));
            this.staffBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.staffBtn.ImageOffset = new System.Drawing.Point(20, 0);
            this.staffBtn.Location = new System.Drawing.Point(0, 398);
            this.staffBtn.Name = "staffBtn";
            this.staffBtn.Size = new System.Drawing.Size(289, 62);
            this.staffBtn.TabIndex = 10;
            this.staffBtn.Text = "Staffs";
            this.staffBtn.Click += new System.EventHandler(this.staffBtn_Click);
            // 
            // studentBtn
            // 
            this.studentBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.BorderRadius = 25;
            this.studentBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.studentBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.studentBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.studentBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.studentBtn.FillColor = System.Drawing.Color.Transparent;
            this.studentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.studentBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.studentBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            this.studentBtn.Image = ((System.Drawing.Image)(resources.GetObject("studentBtn.Image")));
            this.studentBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.studentBtn.ImageOffset = new System.Drawing.Point(20, 0);
            this.studentBtn.Location = new System.Drawing.Point(0, 330);
            this.studentBtn.Name = "studentBtn";
            this.studentBtn.Size = new System.Drawing.Size(289, 62);
            this.studentBtn.TabIndex = 9;
            this.studentBtn.Text = "Students";
            this.studentBtn.Click += new System.EventHandler(this.studentBtn_Click);
            // 
            // announcementBtn
            // 
            this.announcementBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.BorderRadius = 25;
            this.announcementBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.announcementBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.announcementBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.announcementBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.announcementBtn.FillColor = System.Drawing.Color.Transparent;
            this.announcementBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.announcementBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.announcementBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.announcementBtn.HoverState.ForeColor = System.Drawing.Color.White;
            this.announcementBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            this.announcementBtn.Image = ((System.Drawing.Image)(resources.GetObject("announcementBtn.Image")));
            this.announcementBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.announcementBtn.ImageOffset = new System.Drawing.Point(20, 0);
            this.announcementBtn.Location = new System.Drawing.Point(0, 262);
            this.announcementBtn.Name = "announcementBtn";
            this.announcementBtn.Size = new System.Drawing.Size(289, 62);
            this.announcementBtn.TabIndex = 8;
            this.announcementBtn.Text = "Announcement";
            this.announcementBtn.Click += new System.EventHandler(this.announcementBtn_Click);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(295, 25);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(196, 32);
            this.guna2HtmlLabel5.TabIndex = 17;
            this.guna2HtmlLabel5.Text = "Feedbacks";
            this.guna2HtmlLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.BorderRadius = 15;
            this.logoutBtn.BorderThickness = 2;
            this.logoutBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logoutBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logoutBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logoutBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logoutBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.logoutBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.logoutBtn.Location = new System.Drawing.Point(1170, 13);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(109, 44);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Log-out";
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 42;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fbidDataGridViewTextBoxColumn,
            this.srcodeDataGridViewTextBoxColumn,
            this.feedbacksDataGridViewTextBoxColumn,
            this.datefbDataGridViewTextBoxColumn});
            this.guna2DataGridView1.DataSource = this.feedbacksBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(349, 159);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(903, 719);
            this.guna2DataGridView1.TabIndex = 21;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 42;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // fbidDataGridViewTextBoxColumn
            // 
            this.fbidDataGridViewTextBoxColumn.DataPropertyName = "fbid";
            this.fbidDataGridViewTextBoxColumn.HeaderText = "fbid";
            this.fbidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fbidDataGridViewTextBoxColumn.Name = "fbidDataGridViewTextBoxColumn";
            // 
            // srcodeDataGridViewTextBoxColumn
            // 
            this.srcodeDataGridViewTextBoxColumn.DataPropertyName = "srcode";
            this.srcodeDataGridViewTextBoxColumn.HeaderText = "srcode";
            this.srcodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.srcodeDataGridViewTextBoxColumn.Name = "srcodeDataGridViewTextBoxColumn";
            // 
            // feedbacksDataGridViewTextBoxColumn
            // 
            this.feedbacksDataGridViewTextBoxColumn.DataPropertyName = "feedbacks";
            this.feedbacksDataGridViewTextBoxColumn.HeaderText = "feedbacks";
            this.feedbacksDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.feedbacksDataGridViewTextBoxColumn.Name = "feedbacksDataGridViewTextBoxColumn";
            // 
            // datefbDataGridViewTextBoxColumn
            // 
            this.datefbDataGridViewTextBoxColumn.DataPropertyName = "datefb";
            this.datefbDataGridViewTextBoxColumn.HeaderText = "datefb";
            this.datefbDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.datefbDataGridViewTextBoxColumn.Name = "datefbDataGridViewTextBoxColumn";
            // 
            // feedbacksBindingSource
            // 
            this.feedbacksBindingSource.DataMember = "feedbacks";
            this.feedbacksBindingSource.DataSource = this.rGO_LIPADataSet;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Silver;
            this.guna2Panel2.Controls.Add(this.viewMyAccountBtn);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel5);
            this.guna2Panel2.Controls.Add(this.logoutBtn);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1310, 75);
            this.guna2Panel2.TabIndex = 20;
            // 
            // viewMyAccountBtn
            // 
            this.viewMyAccountBtn.BackColor = System.Drawing.Color.Transparent;
            this.viewMyAccountBtn.BorderColor = System.Drawing.Color.Transparent;
            this.viewMyAccountBtn.BorderRadius = 15;
            this.viewMyAccountBtn.BorderThickness = 2;
            this.viewMyAccountBtn.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.viewMyAccountBtn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.viewMyAccountBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewMyAccountBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewMyAccountBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewMyAccountBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewMyAccountBtn.FillColor = System.Drawing.Color.Gray;
            this.viewMyAccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewMyAccountBtn.ForeColor = System.Drawing.Color.White;
            this.viewMyAccountBtn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.viewMyAccountBtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.viewMyAccountBtn.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.viewMyAccountBtn.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewMyAccountBtn.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.viewMyAccountBtn.Location = new System.Drawing.Point(946, 13);
            this.viewMyAccountBtn.Name = "viewMyAccountBtn";
            this.viewMyAccountBtn.Size = new System.Drawing.Size(199, 44);
            this.viewMyAccountBtn.TabIndex = 25;
            this.viewMyAccountBtn.Text = "Account Information";
            this.viewMyAccountBtn.Click += new System.EventHandler(this.viewMyAccountBtn_Click);
            // 
            // feedbacksTableAdapter
            // 
            this.feedbacksTableAdapter.ClearBeforeFill = true;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(640, 95);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(309, 46);
            this.guna2HtmlLabel3.TabIndex = 68;
            this.guna2HtmlLabel3.Text = "FEEDBACKS";
            this.guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adminFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1310, 900);
            this.ControlBox = false;
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adminFeedback";
            this.Load += new System.EventHandler(this.adminFeedback_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rGO_LIPADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.announcementBindingSource)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedbacksBindingSource)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RGO_LIPADataSet rGO_LIPADataSet;
        private RGO_LIPADataSetTableAdapters.announcementTableAdapter announcementTableAdapter;
        private System.Windows.Forms.BindingSource announcementBindingSource;
        private Guna.UI2.WinForms.Guna2Button feedbackBtn;
        private Guna.UI2.WinForms.Guna2Button faqBtn;
        private Guna.UI2.WinForms.Guna2Button orderBtn;
        private Guna.UI2.WinForms.Guna2Button productBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button accBtn;
        private Guna.UI2.WinForms.Guna2Button staffBtn;
        private Guna.UI2.WinForms.Guna2Button studentBtn;
        private Guna.UI2.WinForms.Guna2Button paymentBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Button announcementBtn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2Button logoutBtn;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.BindingSource feedbacksBindingSource;
        private RGO_LIPADataSetTableAdapters.feedbacksTableAdapter feedbacksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fbidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedbacksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefbDataGridViewTextBoxColumn;
        private Guna.UI2.WinForms.Guna2Button viewMyAccountBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
    }
}