
namespace HelloPixelizer {
    partial class MainForm {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Original_Picture = new System.Windows.Forms.PictureBox();
            this.Converted_Picture = new System.Windows.Forms.PictureBox();
            this.ConversionButton = new System.Windows.Forms.Button();
            this.PixelSizeController = new System.Windows.Forms.NumericUpDown();
            this.Pixel_Size_Label = new System.Windows.Forms.Label();
            this.Original_label = new System.Windows.Forms.Label();
            this.Converted_Label = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.Label_OpenLink = new System.Windows.Forms.Label();
            this.Label_SaveLink = new System.Windows.Forms.Label();
            this.PalleteLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.ColorButton = new System.Windows.Forms.Button();
            this.LoadPalleteButton = new System.Windows.Forms.Button();
            this.openPalleteDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PalleteClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Converted_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelSizeController)).BeginInit();
            this.PalleteLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Original_Picture
            // 
            this.Original_Picture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Original_Picture.BackgroundImage")));
            this.Original_Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Original_Picture.Location = new System.Drawing.Point(12, 38);
            this.Original_Picture.Name = "Original_Picture";
            this.Original_Picture.Size = new System.Drawing.Size(350, 350);
            this.Original_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Original_Picture.TabIndex = 0;
            this.Original_Picture.TabStop = false;
            this.Original_Picture.Click += new System.EventHandler(this.Original_Picture_Click);
            this.Original_Picture.DragDrop += new System.Windows.Forms.DragEventHandler(this.Original_Picture_DragDrop);
            this.Original_Picture.DragEnter += new System.Windows.Forms.DragEventHandler(this.Original_Picture_DragEnter);
            this.Original_Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Original_Picture_Paint);
            // 
            // Converted_Picture
            // 
            this.Converted_Picture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Converted_Picture.BackgroundImage")));
            this.Converted_Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Converted_Picture.Location = new System.Drawing.Point(472, 38);
            this.Converted_Picture.Name = "Converted_Picture";
            this.Converted_Picture.Size = new System.Drawing.Size(350, 350);
            this.Converted_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Converted_Picture.TabIndex = 1;
            this.Converted_Picture.TabStop = false;
            this.Converted_Picture.Click += new System.EventHandler(this.Converted_Picture_Click);
            this.Converted_Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Converted_Picture_Paint);
            // 
            // ConversionButton
            // 
            this.ConversionButton.Location = new System.Drawing.Point(385, 213);
            this.ConversionButton.Name = "ConversionButton";
            this.ConversionButton.Size = new System.Drawing.Size(66, 32);
            this.ConversionButton.TabIndex = 2;
            this.ConversionButton.Text = "변환";
            this.ConversionButton.UseVisualStyleBackColor = true;
            this.ConversionButton.Click += new System.EventHandler(this.ConversionButton_Click);
            // 
            // PixelSizeController
            // 
            this.PixelSizeController.Location = new System.Drawing.Point(427, 252);
            this.PixelSizeController.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.PixelSizeController.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PixelSizeController.Name = "PixelSizeController";
            this.PixelSizeController.Size = new System.Drawing.Size(39, 21);
            this.PixelSizeController.TabIndex = 3;
            this.PixelSizeController.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Pixel_Size_Label
            // 
            this.Pixel_Size_Label.AutoSize = true;
            this.Pixel_Size_Label.Location = new System.Drawing.Point(368, 254);
            this.Pixel_Size_Label.Name = "Pixel_Size_Label";
            this.Pixel_Size_Label.Size = new System.Drawing.Size(59, 15);
            this.Pixel_Size_Label.TabIndex = 4;
            this.Pixel_Size_Label.Text = "Pixel Size";
            // 
            // Original_label
            // 
            this.Original_label.AutoSize = true;
            this.Original_label.Location = new System.Drawing.Point(160, 20);
            this.Original_label.Name = "Original_label";
            this.Original_label.Size = new System.Drawing.Size(31, 15);
            this.Original_label.TabIndex = 5;
            this.Original_label.Text = "원본";
            // 
            // Converted_Label
            // 
            this.Converted_Label.AutoSize = true;
            this.Converted_Label.Location = new System.Drawing.Point(628, 20);
            this.Converted_Label.Name = "Converted_Label";
            this.Converted_Label.Size = new System.Drawing.Size(31, 15);
            this.Converted_Label.TabIndex = 6;
            this.Converted_Label.Text = "변환";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"Image files (*.jpg, *.jpeg, *.jpe, *.png, *.jfif) | *.jpg; *.jpeg; *.jpe; *.png;" +
    " *.jfif\"";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(472, 394);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(68, 27);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "저장";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(12, 394);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(68, 27);
            this.OpenButton.TabIndex = 8;
            this.OpenButton.Text = "불러오기";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Label_OpenLink
            // 
            this.Label_OpenLink.AutoSize = true;
            this.Label_OpenLink.Location = new System.Drawing.Point(86, 400);
            this.Label_OpenLink.Name = "Label_OpenLink";
            this.Label_OpenLink.Size = new System.Drawing.Size(61, 15);
            this.Label_OpenLink.TabIndex = 9;
            this.Label_OpenLink.Text = "Load Link";
            // 
            // Label_SaveLink
            // 
            this.Label_SaveLink.AutoSize = true;
            this.Label_SaveLink.Location = new System.Drawing.Point(546, 400);
            this.Label_SaveLink.Name = "Label_SaveLink";
            this.Label_SaveLink.Size = new System.Drawing.Size(60, 15);
            this.Label_SaveLink.TabIndex = 10;
            this.Label_SaveLink.Text = "Save Link";
            // 
            // PalleteLayout
            // 
            this.PalleteLayout.Controls.Add(this.ColorButton);
            this.PalleteLayout.Location = new System.Drawing.Point(13, 428);
            this.PalleteLayout.Name = "PalleteLayout";
            this.PalleteLayout.Size = new System.Drawing.Size(809, 121);
            this.PalleteLayout.TabIndex = 11;
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.White;
            this.ColorButton.Location = new System.Drawing.Point(3, 3);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(25, 25);
            this.ColorButton.TabIndex = 0;
            this.ColorButton.Text = "+";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // LoadPalleteButton
            // 
            this.LoadPalleteButton.Location = new System.Drawing.Point(736, 400);
            this.LoadPalleteButton.Name = "LoadPalleteButton";
            this.LoadPalleteButton.Size = new System.Drawing.Size(86, 23);
            this.LoadPalleteButton.TabIndex = 13;
            this.LoadPalleteButton.Text = "Load Pallete";
            this.LoadPalleteButton.UseVisualStyleBackColor = true;
            this.LoadPalleteButton.Click += new System.EventHandler(this.LoadPalleteButton_Click);
            // 
            // openPalleteDialog
            // 
            this.openPalleteDialog.Filter = "\"Image files (*.jpg, *.jpeg, *.jpe, *.png, *.jfif) | *.jpg; *.jpeg; *.jpe; *.png;" +
    " *.jfif\"";
            this.openPalleteDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openPalleteDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "\"png\"";
            this.saveFileDialog.Filter = "\"Image files (*.jpg, *.jpeg, *.jpe, *.png, *.jfif) | *.jpg; *.jpeg; *.jpe; *.png;" +
    " *.jfif\"";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // PalleteClearButton
            // 
            this.PalleteClearButton.Location = new System.Drawing.Point(655, 399);
            this.PalleteClearButton.Name = "PalleteClearButton";
            this.PalleteClearButton.Size = new System.Drawing.Size(75, 23);
            this.PalleteClearButton.TabIndex = 14;
            this.PalleteClearButton.Text = "Clear";
            this.PalleteClearButton.UseVisualStyleBackColor = true;
            this.PalleteClearButton.Click += new System.EventHandler(this.PalleteClearButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.PalleteClearButton);
            this.Controls.Add(this.LoadPalleteButton);
            this.Controls.Add(this.PalleteLayout);
            this.Controls.Add(this.Label_SaveLink);
            this.Controls.Add(this.Label_OpenLink);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Converted_Label);
            this.Controls.Add(this.Original_label);
            this.Controls.Add(this.Pixel_Size_Label);
            this.Controls.Add(this.PixelSizeController);
            this.Controls.Add(this.ConversionButton);
            this.Controls.Add(this.Converted_Picture);
            this.Controls.Add(this.Original_Picture);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 535);
            this.Name = "MainForm";
            this.Text = "HelloPixelizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Original_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Converted_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelSizeController)).EndInit();
            this.PalleteLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConversionButton;
        private System.Windows.Forms.NumericUpDown PixelSizeController;
        private System.Windows.Forms.Label Pixel_Size_Label;
        private System.Windows.Forms.Label Original_label;
        private System.Windows.Forms.Label Converted_Label;
        public System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Label Label_OpenLink;
        private System.Windows.Forms.Label Label_SaveLink;
        private System.Windows.Forms.FlowLayoutPanel PalleteLayout;
        public System.Windows.Forms.PictureBox Original_Picture;
        private System.Windows.Forms.PictureBox Converted_Picture;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button LoadPalleteButton;
        private System.Windows.Forms.OpenFileDialog openPalleteDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button PalleteClearButton;
    }
}

