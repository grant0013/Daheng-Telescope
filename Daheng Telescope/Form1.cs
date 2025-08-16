using GxIAPINET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Daheng_Telescope
{
    public partial class Form1 : Form
    {
        // --- SDK Objects ---
        private IGXFactory m_objIGXFactory = null;
        private IGXDevice m_objIGXDevice = null;
        private IGXStream m_objIGXStream = null;
        private IGXFeatureControl m_objIGXFeatureControl = null;

        // --- Application State ---
        private bool m_bDeviceIsOpen = false;
        private bool m_bIsStreaming = false;
        private bool m_bIsAutoExposureOn = false;
        private bool m_bExposureAutoSupported = false;
        private bool m_bIsAutoWhiteBalanceOn = false;
        private bool m_bWhiteBalanceSupported = false;
        private bool m_bPixelFormatSupported = false;
        private bool m_bBinningSupported = false;
        private bool m_bSaveNextFrameAsRaw = false; // Flag for one-shot raw capture
        private bool m_bIsRecording = false; // Flag for video recording
        private string m_sVideoFolderName = ""; // Folder for the current recording

        // --- Helper for Displaying Images ---
        private GxBitmap m_objGxBitmap = null;

        // --- Timer for live UI updates ---
        private System.Windows.Forms.Timer m_updateTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeSdk();

            m_updateTimer = new System.Windows.Forms.Timer();
            m_updateTimer.Interval = 500;
            m_updateTimer.Tick += M_updateTimer_Tick;

            UpdateUI();
        }

        private void InitializeSdk()
        {
            try
            {
                m_objIGXFactory = IGXFactory.GetInstance();
                m_objIGXFactory.Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize the camera SDK: " + ex.Message, "SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region Core Camera Operations

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
                m_objIGXFactory.UpdateAllDeviceList(200, listGXDeviceInfo);

                if (listGXDeviceInfo.Count == 0)
                {
                    MessageBox.Show("No camera found. Please ensure it is connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_objIGXDevice = m_objIGXFactory.OpenDeviceBySN(listGXDeviceInfo[0].GetSN(), GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                m_objIGXFeatureControl = m_objIGXDevice.GetRemoteFeatureControl();
                m_objIGXStream = m_objIGXDevice.OpenStream(0);
                m_objGxBitmap = new GxBitmap(m_objIGXDevice, pic_CameraView);

                m_bExposureAutoSupported = m_objIGXFeatureControl.IsImplemented("ExposureAuto");
                m_bWhiteBalanceSupported = m_objIGXFeatureControl.IsImplemented("BalanceWhiteAuto");
                m_bPixelFormatSupported = m_objIGXFeatureControl.IsImplemented("PixelFormat");
                m_bBinningSupported = m_objIGXFeatureControl.IsImplemented("BinningHorizontal") && m_objIGXFeatureControl.IsImplemented("BinningVertical");

                InitializeParameterControls();

                m_bDeviceIsOpen = true;
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the device: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!m_bDeviceIsOpen) return;
            try
            {
                m_objIGXStream.RegisterCaptureCallback(this, OnFrameCallback);
                m_objIGXStream.StartGrab();
                m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                m_bIsStreaming = true;
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start streaming: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFrameCallback(object userParam, IFrameData frameData)
        {
            if (frameData.GetStatus() == GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS)
            {
                if (m_bIsRecording)
                {
                    m_objGxBitmap.SaveBmpSequence(frameData, m_sVideoFolderName);
                }

                if (m_bSaveNextFrameAsRaw)
                {
                    m_bSaveNextFrameAsRaw = false;
                    m_objGxBitmap.SaveRaw(frameData);

                    this.BeginInvoke(new Action(() => {
                        MessageBox.Show("Raw image saved.", "Capture Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }

                m_objGxBitmap.Show(frameData);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (!m_bIsStreaming) return;
            try
            {
                if (m_bIsRecording)
                {
                    btnRecord_Click(btnRecord, EventArgs.Empty); // Programmatically stop recording
                }
                m_updateTimer.Stop();
                m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                m_objIGXStream.StopGrab();
                m_objIGXStream.UnregisterCaptureCallback();
                m_bIsStreaming = false;
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to stop streaming: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (!m_bDeviceIsOpen) return;
            if (m_bIsStreaming)
            {
                btn_Stop_Click(null, null);
            }
            try
            {
                m_objIGXStream?.Close();
                m_objIGXDevice?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while closing the device: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                m_objIGXStream = null;
                m_objIGXDevice = null;
                m_objIGXFeatureControl = null;
                m_bDeviceIsOpen = false;

                m_bExposureAutoSupported = false;
                m_bIsAutoExposureOn = false;
                if (AutoExposure != null) AutoExposure.BackColor = SystemColors.Control;

                m_bWhiteBalanceSupported = false;
                m_bIsAutoWhiteBalanceOn = false;
                if (WhiteBalance != null) WhiteBalance.BackColor = SystemColors.Control;

                m_bPixelFormatSupported = false;
                m_bBinningSupported = false;
                m_bIsRecording = false;

                UpdateUI();
            }
        }

        #endregion

        #region Parameter Controls

        private void AutoExposure_Click(object sender, EventArgs e)
        {
            if (!m_bDeviceIsOpen || !m_bExposureAutoSupported) return;

            try
            {
                m_bIsAutoExposureOn = !m_bIsAutoExposureOn;
                Button btn = sender as Button;

                if (m_bIsAutoExposureOn)
                {
                    m_objIGXFeatureControl.GetEnumFeature("ExposureAuto").SetValue("Continuous");
                    btn.BackColor = Color.LightGreen;
                    m_updateTimer.Start();
                }
                else
                {
                    m_updateTimer.Stop();
                    m_objIGXFeatureControl.GetEnumFeature("ExposureAuto").SetValue("Off");
                    btn.BackColor = SystemColors.Control;
                    UpdateExposureTimeUI();
                }
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set auto exposure: " + ex.Message, "Error");
            }
        }

        private void ExposureValue_Leave(object sender, EventArgs e)
        {
            if (!m_bDeviceIsOpen) return;

            try
            {
                double exposureInSeconds = Convert.ToDouble(ExposureValue.Text);
                double exposureInMicroseconds = exposureInSeconds * 1000000.0;

                IFloatFeature exposureTimeFeature = m_objIGXFeatureControl.GetFloatFeature("ExposureTime");
                double min = exposureTimeFeature.GetMin();
                double max = exposureTimeFeature.GetMax();

                exposureInMicroseconds = Math.Max(min, Math.Min(max, exposureInMicroseconds));

                exposureTimeFeature.SetValue(exposureInMicroseconds);
                ExposureValue.Text = (exposureInMicroseconds / 1000000.0).ToString("0.####");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format.", "Input Error");
                UpdateExposureTimeUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set exposure time: " + ex.Message, "Error");
                UpdateExposureTimeUI();
            }
        }

        private void WhiteBalance_Click(object sender, EventArgs e)
        {
            if (!m_bDeviceIsOpen || !m_bWhiteBalanceSupported) return;

            try
            {
                m_bIsAutoWhiteBalanceOn = !m_bIsAutoWhiteBalanceOn;
                Button btn = sender as Button;

                if (m_bIsAutoWhiteBalanceOn)
                {
                    m_objIGXFeatureControl.GetEnumFeature("BalanceWhiteAuto").SetValue("Continuous");
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    m_objIGXFeatureControl.GetEnumFeature("BalanceWhiteAuto").SetValue("Off");
                    btn.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set white balance: " + ex.Message, "Error");
            }
        }

        private void cbPixelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_objIGXFeatureControl != null && cbPixelFormat.SelectedItem != null)
            {
                try
                {
                    m_objIGXFeatureControl.GetEnumFeature("PixelFormat").SetValue(cbPixelFormat.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to set pixel format: " + ex.Message, "Error");
                }
            }
        }

        private void cbBinning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_objIGXFeatureControl != null && cbBinning.SelectedItem != null)
            {
                try
                {
                    long binningValue = Convert.ToInt64(cbBinning.SelectedItem);
                    m_objIGXFeatureControl.GetIntFeature("BinningHorizontal").SetValue(binningValue);
                    m_objIGXFeatureControl.GetIntFeature("BinningVertical").SetValue(binningValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to set binning: " + ex.Message, "Error");
                }
            }
        }

        private void btnSaveRaw_Click(object sender, EventArgs e)
        {
            if (m_bIsStreaming)
            {
                m_bSaveNextFrameAsRaw = true;
            }
            else
            {
                MessageBox.Show("Please start streaming before capturing an image.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            m_bIsRecording = !m_bIsRecording;
            Button btn = sender as Button;

            if (m_bIsRecording)
            {
                m_sVideoFolderName = Path.Combine(Directory.GetCurrentDirectory(), "Recordings", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                Directory.CreateDirectory(m_sVideoFolderName);

                m_objGxBitmap.ResetFrameCount(); // Reset frame counter for new recording

                btn.Text = "Stop Rec";
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.Text = "Record";
                btn.BackColor = SystemColors.Control;
                MessageBox.Show("Recording stopped. Images saved to:\n" + m_sVideoFolderName, "Recording Complete");
                m_sVideoFolderName = "";
            }
            UpdateUI();
        }


        #endregion

        #region UI and Form Management

        private void M_updateTimer_Tick(object sender, EventArgs e)
        {
            if (m_bIsAutoExposureOn)
            {
                UpdateExposureTimeUI();
            }
        }

        private void InitializeParameterControls()
        {
            UpdateExposureTimeUI();

            if (m_bPixelFormatSupported && cbPixelFormat != null)
            {
                List<string> formats = m_objIGXFeatureControl.GetEnumFeature("PixelFormat").GetEnumEntryList();
                string currentFormat = m_objIGXFeatureControl.GetEnumFeature("PixelFormat").GetValue();
                cbPixelFormat.Items.Clear();
                cbPixelFormat.Items.AddRange(formats.ToArray());
                cbPixelFormat.SelectedItem = currentFormat;
            }

            if (m_bBinningSupported && cbBinning != null)
            {
                IIntFeature binningFeature = m_objIGXFeatureControl.GetIntFeature("BinningHorizontal");
                long min = binningFeature.GetMin();
                long max = binningFeature.GetMax();
                long inc = binningFeature.GetInc();
                long currentBinning = binningFeature.GetValue();

                cbBinning.Items.Clear();
                for (long i = min; i <= max; i += inc)
                {
                    cbBinning.Items.Add(i);
                }
                cbBinning.SelectedItem = currentBinning;
            }
        }

        private void UpdateExposureTimeUI()
        {
            if (m_bDeviceIsOpen && m_objIGXFeatureControl != null)
            {
                try
                {
                    double exposureInMicroseconds = m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetValue();
                    double exposureInSeconds = exposureInMicroseconds / 1000000.0;

                    this.BeginInvoke(new Action(() => {
                        if (ExposureValue != null)
                        {
                            ExposureValue.Text = exposureInSeconds.ToString("0.####");
                        }
                    }));
                }
                catch (Exception)
                {
                    this.BeginInvoke(new Action(() => {
                        if (ExposureValue != null)
                        {
                            ExposureValue.Text = "N/A";
                        }
                    }));
                }
            }
        }

        private void UpdateUI()
        {
            btn_Open.Enabled = !m_bDeviceIsOpen;
            btn_Close.Enabled = m_bDeviceIsOpen;
            btn_Start.Enabled = m_bDeviceIsOpen && !m_bIsStreaming;
            btn_Stop.Enabled = m_bDeviceIsOpen && m_bIsStreaming;

            if (AutoExposure != null) AutoExposure.Enabled = m_bDeviceIsOpen && m_bExposureAutoSupported;
            if (ExposureValue != null)
            {
                ExposureValue.Enabled = m_bDeviceIsOpen;
                ExposureValue.ReadOnly = m_bIsAutoExposureOn;
            }
            if (WhiteBalance != null) WhiteBalance.Enabled = m_bDeviceIsOpen && m_bWhiteBalanceSupported;
            if (btnSaveRaw != null) btnSaveRaw.Enabled = m_bDeviceIsOpen;
            if (cbPixelFormat != null) cbPixelFormat.Enabled = m_bDeviceIsOpen && m_bPixelFormatSupported && !m_bIsStreaming;
            if (cbBinning != null) cbBinning.Enabled = m_bDeviceIsOpen && m_bBinningSupported && !m_bIsStreaming;
            if (btnRecord != null) btnRecord.Enabled = m_bIsStreaming; // Can only record when streaming
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bDeviceIsOpen)
            {
                btn_Close_Click(null, null);
            }
            m_objIGXFactory?.Uninit();
        }

        #endregion
    }

    public class GxBitmap
    {
        private PictureBox m_pictureBox;
        private string m_savePath;
        private long m_lFrameCount = 0; // Frame counter for video sequence

        public GxBitmap(IGXDevice device, PictureBox pictureBox)
        {
            m_pictureBox = pictureBox;
            m_savePath = Path.Combine(Directory.GetCurrentDirectory(), "GxSingleCamImages");
            if (!Directory.Exists(m_savePath))
            {
                Directory.CreateDirectory(m_savePath);
            }
        }

        public void ResetFrameCount()
        {
            m_lFrameCount = 0;
        }

        public void Show(IFrameData frameData)
        {
            if (m_pictureBox == null || frameData == null) return;

            IntPtr pBuffer = frameData.ConvertToRGB24(GX_VALID_BIT_LIST.GX_BIT_0_7, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);
            Bitmap bitmap = new Bitmap(
                (int)frameData.GetWidth(),
                (int)frameData.GetHeight(),
                (int)frameData.GetWidth() * 3,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                pBuffer
            );

            if (m_pictureBox.InvokeRequired)
            {
                m_pictureBox.BeginInvoke(new Action(() =>
                {
                    m_pictureBox.Image = (Image)bitmap.Clone();
                }));
            }
            else
            {
                m_pictureBox.Image = (Image)bitmap.Clone();
            }
        }

        public void SaveRaw(IFrameData frameData)
        {
            try
            {
                IntPtr pBuffer = frameData.GetBuffer();
                int payloadSize = (int)frameData.GetPayloadSize();
                byte[] rawData = new byte[payloadSize];
                Marshal.Copy(pBuffer, rawData, 0, payloadSize);

                string fileName = Path.Combine(m_savePath, $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.raw");
                File.WriteAllBytes(fileName, rawData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save raw image: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveBmpSequence(IFrameData frameData, string folderPath)
        {
            try
            {
                IntPtr pBuffer = frameData.ConvertToRGB24(GX_VALID_BIT_LIST.GX_BIT_0_7, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);
                Bitmap bitmap = new Bitmap(
                    (int)frameData.GetWidth(),
                    (int)frameData.GetHeight(),
                    (int)frameData.GetWidth() * 3,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                    pBuffer
                );

                string fileName = Path.Combine(folderPath, $"frame_{m_lFrameCount:D6}.bmp");
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                m_lFrameCount++;
            }
            catch
            {
                // Suppress errors during sequence save to avoid spamming the user
            }
        }
    }
}
