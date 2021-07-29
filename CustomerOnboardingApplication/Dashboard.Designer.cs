
namespace CustomerOnboardingApplication
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MembersGridControl = new DevExpress.XtraGrid.GridControl();
            this.entityServerModeSource1 = new DevExpress.Data.Linq.EntityServerModeSource();
            this.MembersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMembershipNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateOfBirth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalIdNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateJoined = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMembershipStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_SMS = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.btn_SMS});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1117, 143);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Add Customer";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Edit";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Delete";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "View Customer";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Refresh";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "New";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Edit";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Delete";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "View";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Refresh";
            // 
            // MembersGridControl
            // 
            this.MembersGridControl.DataSource = this.entityServerModeSource1;
            this.MembersGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MembersGridControl.Location = new System.Drawing.Point(0, 143);
            this.MembersGridControl.MainView = this.MembersGridView;
            this.MembersGridControl.MenuManager = this.ribbonControl1;
            this.MembersGridControl.Name = "MembersGridControl";
            this.MembersGridControl.Size = new System.Drawing.Size(1117, 217);
            this.MembersGridControl.TabIndex = 1;
            this.MembersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MembersGridView});
            // 
            // entityServerModeSource1
            // 
            this.entityServerModeSource1.ElementType = typeof(CustomerOnboardingApplication.EF.member);
            this.entityServerModeSource1.KeyExpression = "MembershipNumber";
            // 
            // MembersGridView
            // 
            this.MembersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMembershipNumber,
            this.colName,
            this.colPhoneNumber,
            this.colEmail,
            this.colDateOfBirth,
            this.colGender,
            this.colNationality,
            this.colNationalIdNumber,
            this.colTaxPIN,
            this.colAddress,
            this.colPhoto,
            this.colDateJoined,
            this.colMembershipStatus});
            this.MembersGridView.GridControl = this.MembersGridControl;
            this.MembersGridView.Name = "MembersGridView";
            this.MembersGridView.OptionsBehavior.Editable = false;
            this.MembersGridView.OptionsFind.AlwaysVisible = true;
            this.MembersGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.MembersGridView_RowClick);
            this.MembersGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colMembershipNumber
            // 
            this.colMembershipNumber.FieldName = "MembershipNumber";
            this.colMembershipNumber.Name = "colMembershipNumber";
            this.colMembershipNumber.Visible = true;
            this.colMembershipNumber.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.FieldName = "PhoneNumber";
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.Visible = true;
            this.colPhoneNumber.VisibleIndex = 2;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 3;
            // 
            // colDateOfBirth
            // 
            this.colDateOfBirth.FieldName = "DateOfBirth";
            this.colDateOfBirth.Name = "colDateOfBirth";
            this.colDateOfBirth.Visible = true;
            this.colDateOfBirth.VisibleIndex = 4;
            // 
            // colGender
            // 
            this.colGender.FieldName = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 5;
            // 
            // colNationality
            // 
            this.colNationality.FieldName = "Nationality";
            this.colNationality.Name = "colNationality";
            this.colNationality.Visible = true;
            this.colNationality.VisibleIndex = 6;
            // 
            // colNationalIdNumber
            // 
            this.colNationalIdNumber.FieldName = "NationalIdNumber";
            this.colNationalIdNumber.Name = "colNationalIdNumber";
            this.colNationalIdNumber.Visible = true;
            this.colNationalIdNumber.VisibleIndex = 7;
            // 
            // colTaxPIN
            // 
            this.colTaxPIN.FieldName = "TaxPIN";
            this.colTaxPIN.Name = "colTaxPIN";
            this.colTaxPIN.Visible = true;
            this.colTaxPIN.VisibleIndex = 8;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 9;
            // 
            // colPhoto
            // 
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.Visible = true;
            this.colPhoto.VisibleIndex = 10;
            // 
            // colDateJoined
            // 
            this.colDateJoined.FieldName = "DateJoined";
            this.colDateJoined.Name = "colDateJoined";
            this.colDateJoined.Visible = true;
            this.colDateJoined.VisibleIndex = 11;
            // 
            // colMembershipStatus
            // 
            this.colMembershipStatus.FieldName = "MembershipStatus";
            this.colMembershipStatus.Name = "colMembershipStatus";
            this.colMembershipStatus.Visible = true;
            this.colMembershipStatus.VisibleIndex = 12;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Alerts";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btn_SMS);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "SMS Alerts";
            // 
            // btn_SMS
            // 
            this.btn_SMS.Caption = "Send SMS";
            this.btn_SMS.Id = 6;
            this.btn_SMS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.btn_SMS.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.btn_SMS.Name = "btn_SMS";
            this.btn_SMS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SMS_ItemClick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 360);
            this.Controls.Add(this.MembersGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Dashboard";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Customer Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraGrid.GridControl MembersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MembersGridView;
        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colMembershipNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colDateOfBirth;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colNationality;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalIdNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPIN;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoto;
        private DevExpress.XtraGrid.Columns.GridColumn colDateJoined;
        private DevExpress.XtraGrid.Columns.GridColumn colMembershipStatus;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btn_SMS;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
    }
}

