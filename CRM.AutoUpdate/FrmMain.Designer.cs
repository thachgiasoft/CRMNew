namespace Lotus.AutoUpdate
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblNewVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblDateRelease = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblSizeRelease = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblTenUngDung = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtInfo = new DevExpress.XtraEditors.MemoEdit();
            this.progressBarTotal = new DevExpress.XtraEditors.ProgressBarControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(24, 70);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(89, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Phiên bản hiện tại:";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.Location = new System.Drawing.Point(158, 70);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(26, 13);
            this.lblCurrentVersion.TabIndex = 2;
            this.lblCurrentVersion.Text = "1.0.1";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Phiên bản mới nhất:";
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.Location = new System.Drawing.Point(158, 101);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(26, 13);
            this.lblNewVersion.TabIndex = 2;
            this.lblNewVersion.Text = "1.0.2";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(24, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Ngày phát hành:";
            // 
            // lblDateRelease
            // 
            this.lblDateRelease.Location = new System.Drawing.Point(158, 122);
            this.lblDateRelease.Name = "lblDateRelease";
            this.lblDateRelease.Size = new System.Drawing.Size(50, 13);
            this.lblDateRelease.TabIndex = 5;
            this.lblDateRelease.Text = "11/1/2015";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(24, 145);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(59, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Dung lượng:";
            // 
            // lblSizeRelease
            // 
            this.lblSizeRelease.Location = new System.Drawing.Point(158, 143);
            this.lblSizeRelease.Name = "lblSizeRelease";
            this.lblSizeRelease.Size = new System.Drawing.Size(29, 13);
            this.lblSizeRelease.TabIndex = 7;
            this.lblSizeRelease.Text = "36 MB";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.lblTenUngDung);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lblCurrentVersion);
            this.groupControl1.Controls.Add(this.lblSizeRelease);
            this.groupControl1.Controls.Add(this.lblNewVersion);
            this.groupControl1.Controls.Add(this.lbl);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.lblDateRelease);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(231, 174);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Thông tin phiên bản";
            // 
            // lblTenUngDung
            // 
            this.lblTenUngDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTenUngDung.Appearance.Options.UseFont = true;
            this.lblTenUngDung.Appearance.Options.UseTextOptions = true;
            this.lblTenUngDung.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTenUngDung.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTenUngDung.Location = new System.Drawing.Point(3, 48);
            this.lblTenUngDung.Name = "lblTenUngDung";
            this.lblTenUngDung.Size = new System.Drawing.Size(224, 13);
            this.lblTenUngDung.TabIndex = 9;
            this.lblTenUngDung.Text = "PHẦN MỀM IN HÓA ĐƠN";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.LineVisible = true;
            this.labelControl8.Location = new System.Drawing.Point(0, 87);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(227, 10);
            this.labelControl8.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(387, 216);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 27);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(74, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(249, 11);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Properties.AcceptsTab = true;
            this.txtInfo.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.txtInfo.Properties.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(221, 174);
            this.txtInfo.TabIndex = 12;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Location = new System.Drawing.Point(12, 194);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Properties.ShowTitle = true;
            this.progressBarTotal.ShowProgressInTaskBar = true;
            this.progressBarTotal.Size = new System.Drawing.Size(458, 16);
            this.progressBarTotal.TabIndex = 18;
            this.progressBarTotal.ToolTip = "Tiến trình cập cập";
            this.progressBarTotal.ToolTipTitle = "Thông tin";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(15, 221);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(16, 16);
            this.pictureEdit1.TabIndex = 16;
            this.pictureEdit1.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 252);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật phiên bản mới";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.LabelControl lblCurrentVersion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblNewVersion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblDateRelease;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblSizeRelease;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.MemoEdit txtInfo;
        private DevExpress.XtraEditors.LabelControl lblTenUngDung;
        private DevExpress.XtraEditors.ProgressBarControl progressBarTotal;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}