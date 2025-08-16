namespace Daheng_Telescope
{
    partial class Form1 : System.Windows.Forms.Form
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
            this.pic_CameraView = new System.Windows.Forms.PictureBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.grp_DeviceControl = new System.Windows.Forms.GroupBox();
            this.grp_AcquisitionControl = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.grp_ParameterControl = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBinning = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPixelFormat = new System.Windows.Forms.ComboBox();
            this.btnSaveRaw = new System.Windows.Forms.Button();
            this.WhiteBalance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExposureValue = new System.Windows.Forms.TextBox();
            this.AutoExposure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CameraView)).BeginInit();
            this.grp_DeviceControl.SuspendLayout();
            this.grp_AcquisitionControl.SuspendLayout();
            this.grp_ParameterControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_CameraView
            // 
            this.pic_CameraView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_CameraView.BackColor = System.Drawing.Color.Black;
            this.pic_CameraView.Location = new System.Drawing.Point(12, 12);
            this.pic_CameraView.Name = "pic_CameraView";
            this.pic_CameraView.Size = new System.Drawing.Size(640, 537);
            this.pic_CameraView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_CameraView.TabIndex = 0;
            this.pic_CameraView.TabStop = false;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(15, 25);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(100, 30);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "Open Device";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(121, 25);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 30);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close Device";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(15, 25);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(60, 30);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(81, 25);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(60, 30);
            this.btn_Stop.TabIndex = 4;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // grp_DeviceControl
            // 
            this.grp_DeviceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_DeviceControl.Controls.Add(this.btn_Open);
            this.grp_DeviceControl.Controls.Add(this.btn_Close);
            this.grp_DeviceControl.Location = new System.Drawing.Point(665, 12);
            this.grp_DeviceControl.Name = "grp_DeviceControl";
            this.grp_DeviceControl.Size = new System.Drawing.Size(237, 70);
            this.grp_DeviceControl.TabIndex = 5;
            this.grp_DeviceControl.TabStop = false;
            this.grp_DeviceControl.Text = "Device Control";
            // 
            // grp_AcquisitionControl
            // 
            this.grp_AcquisitionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_AcquisitionControl.Controls.Add(this.btnRecord);
            this.grp_AcquisitionControl.Controls.Add(this.btn_Start);
            this.grp_AcquisitionControl.Controls.Add(this.btn_Stop);
            this.grp_AcquisitionControl.Location = new System.Drawing.Point(665, 88);
            this.grp_AcquisitionControl.Name = "grp_AcquisitionControl";
            this.grp_AcquisitionControl.Size = new System.Drawing.Size(237, 70);
            this.grp_AcquisitionControl.TabIndex = 6;
            this.grp_AcquisitionControl.TabStop = false;
            this.grp_AcquisitionControl.Text = "Acquisition Control";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.SystemColors.Control;
            this.btnRecord.Location = new System.Drawing.Point(147, 25);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 30);
            this.btnRecord.TabIndex = 5;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // grp_ParameterControl
            // 
            this.grp_ParameterControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_ParameterControl.Controls.Add(this.label3);
            this.grp_ParameterControl.Controls.Add(this.cbBinning);
            this.grp_ParameterControl.Controls.Add(this.label2);
            this.grp_ParameterControl.Controls.Add(this.cbPixelFormat);
            this.grp_ParameterControl.Controls.Add(this.btnSaveRaw);
            this.grp_ParameterControl.Controls.Add(this.WhiteBalance);
            this.grp_ParameterControl.Controls.Add(this.label1);
            this.grp_ParameterControl.Controls.Add(this.ExposureValue);
            this.grp_ParameterControl.Controls.Add(this.AutoExposure);
            this.grp_ParameterControl.Location = new System.Drawing.Point(665, 164);
            this.grp_ParameterControl.Name = "grp_ParameterControl";
            this.grp_ParameterControl.Size = new System.Drawing.Size(237, 385);
            this.grp_ParameterControl.TabIndex = 7;
            this.grp_ParameterControl.TabStop = false;
            this.grp_ParameterControl.Text = "Camera Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Binning Mode";
            // 
            // cbBinning
            // 
            this.cbBinning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinning.FormattingEnabled = true;
            this.cbBinning.Location = new System.Drawing.Point(15, 195);
            this.cbBinning.Name = "cbBinning";
            this.cbBinning.Size = new System.Drawing.Size(206, 21);
            this.cbBinning.TabIndex = 13;
            this.cbBinning.SelectedIndexChanged += new System.EventHandler(this.cbBinning_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pixel Format";
            // 
            // cbPixelFormat
            // 
            this.cbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPixelFormat.FormattingEnabled = true;
            this.cbPixelFormat.Location = new System.Drawing.Point(15, 148);
            this.cbPixelFormat.Name = "cbPixelFormat";
            this.cbPixelFormat.Size = new System.Drawing.Size(206, 21);
            this.cbPixelFormat.TabIndex = 11;
            this.cbPixelFormat.SelectedIndexChanged += new System.EventHandler(this.cbPixelFormat_SelectedIndexChanged);
            // 
            // btnSaveRaw
            // 
            this.btnSaveRaw.Location = new System.Drawing.Point(15, 232);
            this.btnSaveRaw.Name = "btnSaveRaw";
            this.btnSaveRaw.Size = new System.Drawing.Size(206, 30);
            this.btnSaveRaw.TabIndex = 10;
            this.btnSaveRaw.Text = "Capture Raw Image";
            this.btnSaveRaw.UseVisualStyleBackColor = true;
            this.btnSaveRaw.Click += new System.EventHandler(this.btnSaveRaw_Click);
            // 
            // WhiteBalance
            // 
            this.WhiteBalance.Location = new System.Drawing.Point(15, 96);
            this.WhiteBalance.Name = "WhiteBalance";
            this.WhiteBalance.Size = new System.Drawing.Size(206, 30);
            this.WhiteBalance.TabIndex = 6;
            this.WhiteBalance.Text = "Auto White Balance";
            this.WhiteBalance.UseVisualStyleBackColor = true;
            this.WhiteBalance.Click += new System.EventHandler(this.WhiteBalance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Exposure Time (sec)";
            // 
            // ExposureValue
            // 
            this.ExposureValue.Location = new System.Drawing.Point(121, 25);
            this.ExposureValue.Name = "ExposureValue";
            this.ExposureValue.Size = new System.Drawing.Size(100, 20);
            this.ExposureValue.TabIndex = 8;
            this.ExposureValue.Leave += new System.EventHandler(this.ExposureValue_Leave);
            // 
            // AutoExposure
            // 
            this.AutoExposure.Location = new System.Drawing.Point(15, 60);
            this.AutoExposure.Name = "AutoExposure";
            this.AutoExposure.Size = new System.Drawing.Size(206, 30);
            this.AutoExposure.TabIndex = 7;
            this.AutoExposure.Text = "Auto Exposure";
            this.AutoExposure.UseVisualStyleBackColor = true;
            this.AutoExposure.Click += new System.EventHandler(this.AutoExposure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 561);
            this.Controls.Add(this.grp_ParameterControl);
            this.Controls.Add(this.grp_AcquisitionControl);
            this.Controls.Add(this.grp_DeviceControl);
            this.Controls.Add(this.pic_CameraView);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Daheng Telescope Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pic_CameraView)).EndInit();
            this.grp_DeviceControl.ResumeLayout(false);
            this.grp_AcquisitionControl.ResumeLayout(false);
            this.grp_ParameterControl.ResumeLayout(false);
            this.grp_ParameterControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_CameraView;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.GroupBox grp_DeviceControl;
        private System.Windows.Forms.GroupBox grp_AcquisitionControl;
        private System.Windows.Forms.GroupBox grp_ParameterControl;
        private System.Windows.Forms.Button AutoExposure;
        private System.Windows.Forms.TextBox ExposureValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button WhiteBalance;
        private System.Windows.Forms.Button btnSaveRaw;
        private System.Windows.Forms.ComboBox cbPixelFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBinning;
        private System.Windows.Forms.Button btnRecord;
    }
}
