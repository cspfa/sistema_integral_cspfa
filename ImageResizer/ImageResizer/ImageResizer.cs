using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageResizer
{
    public delegate void WorkCompleteDelegate(object sender, bool complete);

    public partial class ImageResizer : Form
    {
        #region Members

        // Subscribe to this event when control is not in StandAloneMode; called by close button click
        public event WorkCompleteDelegate WorkComplete;

        // Used for saving the edited image
        private Dictionary<string, ImageCodecInfo> _codecs = new Dictionary<string, ImageCodecInfo>();
        private EncoderParameters _encoderParams = new EncoderParameters();

        public Image _editedImage = null;

        // Determines whether the image is saved to disk (true) or memory (false). Also controls
        // what happens when the Close button is pushed; App.Exit (true) or WorkComplete event (false)
        public bool StandAloneMode
        {
            get
            {
                return btnSave.Text.Equals("Save");
            }
            set
            {
                if (value)
                {
                    btnSave.Text = "Save";
                    btnSave.Image = Properties.Resources.disk_blue;
                    btnClose.Text = "Close";
                }
                else
                {
                    btnSave.Text = "Ok";
                    btnSave.Image = Properties.Resources.disk_blue;
                    btnClose.Text = "Cancel";
                }
            }
        }

        // Set this if the final image must have a minimum width
        public int RequiredWidth
        {
            get
            {
                return _requiredWidth;
            }
            set
            {
                _requiredWidth = value;
            }
        }
        private int _requiredWidth = 0;

        // Set this if the final image must have a minimum height
        public int RequiredHeight
        {
            get
            {
                return _requiredHeight;
            }
            set
            {
                _requiredHeight = value;
            }
        }
        private int _requiredHeight = 0;

        // The starting image
        protected Image BaseImage
        {
            get
            {
                return _image;
            }
            set
            {
                try
                {
                    SuspendRefresh = true;
                    _image = value;
                    tbResize.Value = 100;
                    SetSizes(true);
                    if (DrawnImage != null)
                    {
                        while (DrawnImage.Width > grpImage.Width || DrawnImage.Height > grpImage.Height)
                        {
                            tbResize.Value -= 5;
                        }
                    }
                }
                finally
                {
                    btnSave.Enabled = true;
                    chkCrop.Enabled = true;
                    tbResize.Enabled = true;
                    SuspendRefresh = false;
                    RefreshForm();
                }
            }
        }
        private Image _image = null;

        // The in-process image
        protected Bitmap DrawnImage
        {
            get
            {
                return _drawnImage;
            }
            set
            {
                _drawnImage = value;
            }
        }
        private Bitmap _drawnImage = null;

        // X coordinate of the top left point of the yellow crop box
        protected int CropBoxX
        {
            get
            {
                return _cropBoxX;
            }
            set
            {
                _cropBoxX = value;
            }
        }
        private int _cropBoxX = -1;

        // Y coordinate of the top left point of the yellow crop box
        protected int CropBoxY
        {
            get
            {
                return _cropBoxY;
            }
            set
            {
                _cropBoxY = value;
            }
        }
        private int _cropBoxY = -1;

        protected int MaxCanvasWidth
        {
            get
            {
                int retVal = DrawnImage.Width;
                if (retVal > grpImage.Width)
                {
                    retVal = grpImage.Width;
                }
                return retVal;
            }
        }

        protected int MaxCanvasHeight
        {
            get
            {
                int retVal = DrawnImage.Height;
                if (retVal > grpImage.Height)
                {
                    retVal = grpImage.Height;
                }
                return retVal;
            }
        }

        protected bool SuspendRefresh
        {
            get
            {
                return _suspendRefresh;
            }
            set
            {
                _suspendRefresh = value;
            }
        }
        private bool _suspendRefresh = false;

        #endregion

        #region Constructors

        public ImageResizer(Image im)
        {
            InitializeComponent();

            // Save in full quality
            _encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            // Find the codecs for the supported formats, set the open and save dialog filters
            string displayFilters = string.Empty;
            int codecCount = 0;
            int jpegIndex = 0;
            List<Guid> imageFormats = new List<Guid>(new Guid[] { ImageFormat.Bmp.Guid, ImageFormat.Gif.Guid, ImageFormat.Jpeg.Guid, ImageFormat.Png.Guid, ImageFormat.Tiff.Guid });
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
            {
                if (imageFormats.Contains(codec.FormatID))
                {
                    codecCount++;
                    if (codec.FormatDescription.Equals("JPEG"))
                    {
                        jpegIndex = codecCount;
                    }

                    string fileFilterLeft = codec.FormatDescription + " files (";
                    string fileFilterRight = "|";
                    foreach (string extension in codec.FilenameExtension.Split(new char[] { ';' }))
                    {
                        string ext = extension.ToLower();
                        fileFilterLeft += ext + ",";
                        fileFilterRight += ext + ";";
                        _codecs.Add(ext.Replace("*",string.Empty), codec);
                    }
                    displayFilters += fileFilterLeft.Substring(0, fileFilterLeft.Length - 1) + ")" + fileFilterRight.Substring(0, fileFilterRight.Length - 1) + "|";
                }
            }
            ofdImage.Filter = displayFilters.Substring(0, displayFilters.Length - 1 );
            sfdImage.Filter = ofdImage.Filter;
            ofdImage.FilterIndex = jpegIndex;
            this.Cargar_Imagen(im);
        }

        // Allows developer to set starting image and required size of resulting image
        public ImageResizer(Image baseImage, int requiredWidth, int requiredHeight)
        {
            BaseImage = baseImage;
            if (requiredWidth > 0)
            {
                RequiredWidth = requiredWidth;
            }
            if (requiredHeight > 0)
            {
                RequiredHeight = requiredHeight;
            }
        }

        #endregion

        #region Methods

        // Removes all images for control reuse
        public void Reset()
        {
            _editedImage = null;
            DrawnImage = null;
            BaseImage = null;
            RefreshForm();
        }

        public Image GetEditedImage()
        {
            return _editedImage;
        }

        // Draw the canvas, the image and crop box
        private void ImageResizer_Paint(object sender, PaintEventArgs e)
        {
            // Draws alternating shaded rectangles so user can differentiate canvas from image.
            bool xGrayBox = true;
            int backgroundX = 0;
            while (backgroundX < grpImage.Width)
            {
                int backgroundY = 0;
                bool yGrayBox = xGrayBox;
                while (backgroundY < grpImage.Height)
                {
                    int recWidth = (int)((backgroundX + 50 > grpImage.Width) ? grpImage.Width - backgroundX : 50);
                    int recHeight = (int)((backgroundY + 50 > grpImage.Height) ? grpImage.Height - backgroundY : 50);
                    e.Graphics.FillRectangle(((Brush)(yGrayBox ? Brushes.LightGray : Brushes.Gainsboro)), backgroundX, backgroundY, recWidth + 2, recHeight + 2);
                    backgroundY += 50;
                    yGrayBox = !yGrayBox;
                }
                backgroundX += 50;
                xGrayBox = !xGrayBox;
            }

            if (!SuspendRefresh && DrawnImage != null)
            {
                // if( the image is too large, draw only visible portion as dictated by the scrollbars, otherwise draw the whole image.
                if (DrawnImage.Width > grpImage.Width || DrawnImage.Height > grpImage.Height)
                {
                    int rectX = 0;
                    if (hsbImage.Value > 0)
                    {
                        rectX = hsbImage.Value;
                    }
                    int rectY = 0;
                    if (vsbImage.Value > 0)
                    {
                        rectY = vsbImage.Value;
                    }
                    e.Graphics.DrawImage(DrawnImage, 0, 0, new Rectangle(rectX, rectY, grpImage.Width, grpImage.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImage(DrawnImage, 0, 0);
                }

                // Draw the crop rectangle with both yellow and black so it is easily visible no matter the image.
                if (chkCrop.Checked)
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, CropBoxX, CropBoxY, (float)nudCropWidth.Value, (float)nudCropHeight.Value);
                    e.Graphics.DrawRectangle(Pens.Black, CropBoxX - 1, CropBoxY - 1, (float)nudCropWidth.Value + 2, (float)nudCropHeight.Value + 2);
                }
            }
        }

        // Keep all stored values up to date
        protected void SetSizes(bool adjustCropSize)
        {
            if (BaseImage != null)
            {
                DrawnImage = new Bitmap(BaseImage, (int)Math.Ceiling(BaseImage.Width * 0.01 * tbResize.Value), (int)Math.Ceiling(BaseImage.Height * 0.01 * tbResize.Value));

                SetCropValues(adjustCropSize);

                hsbImage.Enabled = DrawnImage.Width > grpImage.Width && !SuspendRefresh;
                vsbImage.Enabled = DrawnImage.Height > grpImage.Height && !SuspendRefresh;
                if (hsbImage.Enabled)
                {
                    hsbImage.Maximum = Math.Max(0, DrawnImage.Width - grpImage.Width);
                    hsbImage.LargeChange = (int)(hsbImage.Maximum / 10);
                }
                if (vsbImage.Enabled)
                {
                    vsbImage.Maximum = Math.Max(0, DrawnImage.Height - grpImage.Height);
                    vsbImage.LargeChange = (int)(vsbImage.Maximum / 10);
                }

                if (_requiredWidth > 0 || _requiredHeight > 0)
                {
                    chkCrop.Checked = true;
                }
            }
            RefreshForm();
        }

        // Ensure the crop box size meets the required sizes, if any.
        protected void SetCropValues(bool adjustCropSize)
        {
            if (chkCrop.Checked)
            {
                if (_requiredWidth < 1)
                {
                    nudCropWidth.Maximum = MaxCanvasWidth;
                    if (adjustCropSize)
                    {
                        nudCropWidth.Value = (int)(MaxCanvasWidth / 2);
                    }
                }
                else
                {
                    nudCropWidth.Maximum = _requiredWidth;
                    if (adjustCropSize)
                    {
                        nudCropWidth.Value = _requiredWidth;
                    }
                }
                if (_requiredHeight < 1)
                {
                    nudCropHeight.Maximum = MaxCanvasHeight;
                    if (adjustCropSize)
                    {
                        nudCropHeight.Value = (int)(MaxCanvasHeight / 2);
                    }
                }
                else
                {
                    nudCropHeight.Maximum = _requiredHeight;
                    if (adjustCropSize)
                    {
                        nudCropHeight.Value = _requiredHeight;
                    }
                }

                if (CropBoxX == -1)
                {
                    CropBoxX = (int)(MaxCanvasWidth / 2) - (int)(nudCropWidth.Value / 2);
                }
                if (CropBoxY == -1)
                {
                    CropBoxY = (int)(MaxCanvasHeight / 2) - (int)(nudCropHeight.Value / 2);
                }
            }
            else
            {
                // No cropping, reset all values
                CropBoxX = -1;
                CropBoxY = -1;
                nudCropWidth.Value = 0;
                nudCropHeight.Value = 0;
                nudCropWidth.Maximum = 0;
                nudCropHeight.Maximum = 0;
            }
            VerifyCropValues();
        }

        // Ensure the crop box stays with in the bounds of the drawn image
        protected void VerifyCropValues()
        {
            bool toggle = false;
            try
            {
                // Suspend repainting so the crop box only redraws once
                if (!SuspendRefresh)
                {
                    SuspendRefresh = true;
                    toggle = true;
                }

                // First try to fit the existing size crop box in the alloted space.
                // if it still won't fit, begin to shrink it.
                while (CropBoxX + nudCropWidth.Value > MaxCanvasWidth)
                {
                    if (CropBoxX > 0)
                    {
                        CropBoxX -= 1;
                    }
                    else
                    {
                        nudCropWidth.Value -= 1;
                    }
                }

                while (CropBoxY + nudCropHeight.Value > MaxCanvasHeight)
                {
                    if (CropBoxY > 0)
                    {
                        CropBoxY -= 1;
                    }
                    else
                    {
                        nudCropHeight.Value -= 1;
                    }
                }
            }
            finally
            {
                if (toggle)
                {
                    SuspendRefresh = false;
                }
            }
            RefreshForm();
        }

        // Update image size label and repaint
        protected void RefreshForm()
        {
            if (!SuspendRefresh)
            {
                if (DrawnImage != null)
                {
                    lblSize.Text = DrawnImage.Width.ToString() + " x " + DrawnImage.Height.ToString();
                }
                Refresh();
                Invalidate();
            }
        }

        // Save the resized or cropped image
        protected void SaveImage()
        {
            try
            {
                if (!chkCrop.Checked)
                {
                    _editedImage = new Bitmap(BaseImage, DrawnImage.Width, DrawnImage.Height);
                }
                else
                {
                    _editedImage = new Bitmap((int)nudCropWidth.Value, (int)nudCropHeight.Value);
                    Graphics g = Graphics.FromImage(_editedImage);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    int drawnImageCropBoxX = CropBoxX - grpImage.Location.X + grpImage.Location.X;

                    if (hsbImage.Enabled)
                    {
                        drawnImageCropBoxX += hsbImage.Value;
                    }

                    int drawnImageCropBoxY = CropBoxY - grpImage.Location.Y + grpImage.Location.Y;
                    
                    if (hsbImage.Enabled)
                    {
                        drawnImageCropBoxY += vsbImage.Value;
                    }

                    g.DrawImage(DrawnImage, 0, 0, new Rectangle(drawnImageCropBoxX, drawnImageCropBoxY, (int)nudCropWidth.Value, (int)nudCropHeight.Value), GraphicsUnit.Pixel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Save to disk or memory
        protected void SaveImage(Image saveImage)
        {
            if (StandAloneMode)
            {
                if (sfdImage.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileName = new FileInfo(sfdImage.FileName);
                    if (_codecs.ContainsKey(fileName.Extension.ToLower()))
                    {
                        saveImage.Save(sfdImage.FileName, _codecs[fileName.Extension.ToLower()], _encoderParams);
                    }
                    else
                    {
                        MessageBox.Show("Please choose a valid file extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SaveImage(saveImage);
                    }
                }
            }
            else
            {
                MemoryStream saveStream = null;
                try
                {
                    saveStream = new MemoryStream();
                    saveImage.Save(saveStream, ImageFormat.Jpeg);
                    saveImage = Image.FromStream(saveStream);
                    WorkComplete(this, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
                finally
                {
                    if (saveStream != null)
                    {
                        saveStream.Close();
                    }
                }
            }
        }

        private void Cargar_Imagen(Image pimg)
        {
            ofdImage.FileName = null;

            // Image.FromFile keeps the file locked, need to copy it
            Image img = null;
            MemoryStream saveStream = null;
            try
            {
                //img = pimg;
                // saveStream = new MemoryStream();
                //img.Save(saveStream, img.RawFormat);
                BaseImage = pimg;// Image.FromStream(saveStream);

                sfdImage.FileName = null;
                sfdImage.FilterIndex = ofdImage.FilterIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (img != null)
                {
                    img.Dispose();
                    img = null;
                }
                if (saveStream != null)
                {
                    saveStream.Close();
                    saveStream = null;
                }
                chkCrop.Checked = false;
            }


        }

        #endregion

        #region Control Events

        // Load the image into memory.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            ofdImage.FileName = null;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                // Image.FromFile keeps the file locked, need to copy it
                Image img = null;
                MemoryStream saveStream = null;
                try
                {
                    img = Image.FromFile(ofdImage.FileName);
                    saveStream = new MemoryStream();
                    img.Save(saveStream, img.RawFormat);
                    BaseImage = Image.FromStream(saveStream);

                    sfdImage.FileName = null;
                    sfdImage.FilterIndex = ofdImage.FilterIndex;
                }
                catch( Exception ex)
                {
                    MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (img != null)
                    {
                        img.Dispose();
                        img = null;
                    }
                    if (saveStream != null)
                    {
                        saveStream.Close();
                        saveStream = null;
                    }
                    chkCrop.Checked = false;
                }
            }
        }

        // Save the image to disk
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        // Raises the Close event so the parent form knows the user is done.
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (StandAloneMode)
            {
                Application.Exit();
            }
            else if (WorkComplete != null)
            {
                WorkComplete(this, false);
            }
        }

        // Controls the zoom factor.
        private void tbResize_ValueChanged(object sender, EventArgs e)
        {
            SetSizes(false);
            lblZoomFactor.Text = tbResize.Value.ToString() + "%";
        }

        private void picZoomOut_Click(object sender, EventArgs e)
        {
            if (tbResize.Value > tbResize.Minimum)
            {
                tbResize.Value -= 1;
            }
        }

        private void picZoomIn_Click(object sender, EventArgs e)
        {
            if (tbResize.Value < tbResize.Maximum)
            {
                tbResize.Value += 1;
            }
        }

        // Toggles the crop box.
        private void chkCrop_CheckedChanged(object sender, EventArgs e)
        {
            nudCropHeight.Enabled = chkCrop.Checked;
            nudCropWidth.Enabled = chkCrop.Checked;
            SetSizes(true);
        }

        // Update stored values when user resizes control
        private void EasyImageResizerControl_SizeChanged(object sender, EventArgs e)
        {
            SetSizes(true);
        }

        // Allows user to reposition the crop box.
        private void EasyImageResizerControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Ignore clicks outside the canvas.
            if (e.X < grpImage.Width + 1 && e.Y < grpImage.Height + 1 && chkCrop.Checked)
            {
                // Use the mouse click position as the center for crop box
                int newCropX = e.X - (int)(nudCropWidth.Value / 2);
                int newCropY = e.Y - (int)(nudCropHeight.Value / 2);
                if (newCropX < 0)
                {
                    newCropX = 0;
                }
                if (newCropY < 0)
                {
                    newCropY = 0;
                }

                if (newCropX >= 0 && newCropX < DrawnImage.Width && newCropY >= 0 && newCropY < DrawnImage.Height)
                {
                    if (newCropX + (int)nudCropWidth.Value > MaxCanvasWidth)
                    {
                        CropBoxX = MaxCanvasWidth - (int)nudCropWidth.Value;
                    }
                    else
                    {
                        CropBoxX = newCropX;
                    }
                    if (newCropY + (int)nudCropHeight.Value > MaxCanvasHeight)
                    {
                        CropBoxY = MaxCanvasHeight - (int)nudCropHeight.Value;
                    }
                    else
                    {
                        CropBoxY = newCropY;
                    }
                }
                RefreshForm();
            }
        }

        // Simple scrolling.
        private void ImagedScrolled(object sender, ScrollEventArgs e)
        {
            RefreshForm();
        }

        // Ensure the crop box draws correctly
        private void nudCrop_ValueChanged(object sender, EventArgs e)
        {
            VerifyCropValues();
        }

        #endregion

        private void ImageResizer_Load(object sender, EventArgs e)
        {

        }
    }
}