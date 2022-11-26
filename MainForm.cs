using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace HelloPixelizer {
	public partial class MainForm : Form {
		public static List<customColorButton> Pallete = new List<customColorButton>();
		Bitmap Converted_Bitmap;
		string[] Formats = { "png", "PNG", "JPG", "JPEG", "jpg", "jpeg" };
		Rectangle PictureBox_Rect = new Rectangle(0, 0, 350, 350);

		public MainForm() {
			InitializeComponent();
		}

		//시작시
		private void MainForm_Load(object sender, EventArgs e) {
			Original_Picture.AllowDrop = true;
		}

		//변환버튼
		private void ConversionButton_Click(object sender, EventArgs e) {
			if (Label_OpenLink.Text == "Load Link") {
				MessageBox.Show("선택된 이미지가 없습니다.");
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			try {
				Converted_Bitmap = Pixelate(new Bitmap(Label_OpenLink.Text), Convert.ToInt32(PixelSizeController.Value));
				Converted_Picture.Image = (Pallete.Count > 0) ? PixelPallete(Converted_Bitmap) : Converted_Bitmap;
			}
			catch (ArgumentException) {
				MessageBox.Show("파일을 확인해 주세요.");
			}
			Cursor.Current = Cursors.Default;
		}

		//로드된 이미지 클릭
		private void Original_Picture_Click(object sender, EventArgs e) {
			OpenButton_Click(sender, e);
		}
		//로드버튼
		private void OpenButton_Click(object sender, EventArgs e) {
			openFileDialog.ShowDialog();
		}
		//변환된 이미지 클릭
		private void Converted_Picture_Click(object sender, EventArgs e) {
			SaveButton_Click(sender, e);
		}
		//저장 버튼
		private void SaveButton_Click(object sender, EventArgs e) {
			if (Converted_Picture.Image == null) {
				MessageBox.Show("변환된 파일이 없습니다.");
				return;
			}
			saveFileDialog.FileName = "Converted.png";
			saveFileDialog.ShowDialog();
		}

		//로드
		private void openFileDialog_FileOk(object sender, CancelEventArgs e) {
			Label_OpenLink.Text = openFileDialog.FileName;
			Image target;
			try {
				target = Image.FromFile(@Label_OpenLink.Text);
				if (target.Width >= 5000 || target.Height >= 5000) { 
					MessageBox.Show("파일이 너무 큽니다. Width 5000, Height 5000 이하의 사진만 가능합니다.");
					return;
				}
				Original_Picture.Image = target;
			}
			catch (ArgumentException) {
				MessageBox.Show("파일을 확인해 주세요.");
			}
		}
		//저장
		private void saveFileDialog_FileOk(object sender, CancelEventArgs e) {
			Label_SaveLink.Text = saveFileDialog.FileName;
			try {
				Converted_Picture.Image.Save(Label_SaveLink.Text, ImageFormat.Png);
			}
			catch (ArgumentException) {
				MessageBox.Show("파일을 확인해 주세요.");
			}
			Label_SaveLink.Text = "저장 완료";
		}

		//픽셀아트 그리기(원본)
		private void Original_Picture_Paint(object sender, PaintEventArgs e) {
			if (Original_Picture.Image == null) return;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(Original_Picture.Image, GetAspectRect(Original_Picture.Image));
		}
		//픽셀아트 그리기(편집본)
		private void Converted_Picture_Paint(object sender, PaintEventArgs e) {
			if (Converted_Picture.Image == null) return;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(Converted_Picture.Image, GetAspectRect(Original_Picture.Image));
		}
		//Rect구하기
		public Rectangle GetAspectRect(Image target){
			Rectangle result = PictureBox_Rect;
			if (target.Width == target.Height) return result;

			if (target.Width > target.Height) {
				result.Height = (target.Height * result.Width) / target.Width;
				result.Y = PictureBox_Rect.Height / 2 - (result.Height / 2);
			}
			else {
				result.Width = (target.Width * result.Height) / target.Height;
				result.X = PictureBox_Rect.Width / 2 - (result.Width / 2);
			}
			return result;
		}

		//픽셀화 변환 작동
		public Bitmap Pixelate(Bitmap OriginalBitmap, int PixelSize) {
			if (PixelSize == 1) return OriginalBitmap;
			if (OriginalBitmap.Width < PixelSize || OriginalBitmap.Height < PixelSize) {
				MessageBox.Show("픽셀 크기가 원본 크기를 초과합니다.");
				return OriginalBitmap;
			}

			Bitmap result = new Bitmap(OriginalBitmap.Width / PixelSize, OriginalBitmap.Height / PixelSize);
			int r, g, b;
			Color Target;
			int sqr = PixelSize * PixelSize;
			Rectangle Area = new Rectangle();

			for (int y = 0; y < result.Height; y++) {
				for (int x = 0; x < result.Width; x++) {
                    r = g = b = 0;
					Area.Width = Math.Clamp((x + 1) * PixelSize, 0, OriginalBitmap.Width);
					Area.Height = Math.Clamp((y + 1) * PixelSize, 0, OriginalBitmap.Height);
					Area.X = x * PixelSize;
					Area.Y = y * PixelSize;
					for (int i = Area.Y; i < Area.Height; i++) {
						for (int j = Area.X; j < Area.Width; j++) {
								Target = OriginalBitmap.GetPixel(j, i);
								r += Target.R;
								g += Target.G;
								b += Target.B;
						}
					}
					r /= sqr;
					g /= sqr;
					b /= sqr;
					result.SetPixel(x, y, Color.FromArgb(r, g, b));
				}
			}
			return result;
		}
		//팔레트 적용
		public Bitmap PixelPallete(Bitmap OriginalBitmap) {
			Bitmap result = new Bitmap(OriginalBitmap.Width, OriginalBitmap.Height);
			float close_dist = 0;
			float dist = 0;
			int SPN;
			for (int x = 0; x < OriginalBitmap.Width; x++) {
				for (int y = 0; y < OriginalBitmap.Height; y++) {
					SPN = 0;
					close_dist = Calc_ColorDist(OriginalBitmap.GetPixel(x, y), Pallete[SPN].BackColor);
					for (int i = 1; i < Pallete.Count; i++) {
						dist = Calc_ColorDist(OriginalBitmap.GetPixel(x, y), Pallete[i].BackColor);
						if (close_dist > dist) {
							SPN = i;
							close_dist = dist;
						}
					}
					result.SetPixel(x, y, Pallete[SPN].BackColor);
				}
			}
            return result;
		}
		// 색 거리 계산(팔레트 적용을 위한 작업)
		public float Calc_ColorDist(Color A, Color B) {
			if (B.A == 0) return 256;
			float r = B.R - A.R;
			float g = B.G - A.G;
			float b = B.B - A.B;
			float a = B.A - A.A;
			return (float)Math.Sqrt(r * r + g * g + b * b + a * a);
		}
		
		//팔레트 버튼 클릭
        private void ColorButton_Click(object sender, EventArgs e) {
			if(colorPicker.ShowDialog() == DialogResult.OK) {
					Button btn = new customColorButton(colorPicker.Color);
					btn.MouseUp += new MouseEventHandler(customColorButton_Click);
					PalleteLayout.Controls.Add(btn);
			}
		}
		// 생성된 커스텀 팔레트 버튼 클릭
		public void customColorButton_Click(Object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (colorPicker.ShowDialog() == DialogResult.OK)
					((customColorButton)sender).BackColor = colorPicker.Color;
			} else if (e.Button == MouseButtons.Right) {
				Pallete.Remove((customColorButton)sender);
				PalleteLayout.Controls.Remove((customColorButton)sender);
			}
		}
		//커스텀 팔레트
		public class customColorButton : Button {
			public customColorButton(Color Data) {
				this.Size = new Size(25, 25);
				this.BackColor = Data;
				Pallete.Add(this);
			}
		}
		
		//팔레트 로드
        private void openPalleteDialog_FileOk(object sender, CancelEventArgs e) {
            try { 
				Bitmap data = new Bitmap(Image.FromFile(@openPalleteDialog.FileName.ToString()));
				Color target;
				bool jmp;
				for (int y = 0; y < data.Height; y++) {
					for (int x = 0; x < data.Width; x++) {
						target = data.GetPixel(x, y);
						jmp = false;
						for (int i = 0; i < Pallete.Count; i++) {
							if (jmp = (Pallete[i].BackColor == target)) break;
						}
						if (jmp) continue;
						if (Pallete.Count >= 103) {
							MessageBox.Show("팔레트가 너무 많습니다.");
							return;
						}
						Button btn = new customColorButton(target);
						btn.MouseUp += new MouseEventHandler(customColorButton_Click);
						PalleteLayout.Controls.Add(btn);
					}
				}
			} catch (ArgumentException) {
				MessageBox.Show("파일을 확인해 주세요.");
			}
		}
        private void LoadPalleteButton_Click(object sender, EventArgs e) {
			openPalleteDialog.ShowDialog();
		}

		//팔레트 제거
        private void PalleteClearButton_Click(object sender, EventArgs e) {
			Pallete.Clear();
			Button tmp = ColorButton;
			PalleteLayout.Controls.Clear();
			PalleteLayout.Controls.Add(tmp);
		}

        private void Original_Picture_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}
		private void Original_Picture_DragDrop(object sender, DragEventArgs e) {
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length < 1) return;
			else if (files.Length > 1) {
				MessageBox.Show("하나의 파일만 올려 주세요.");
				return;
			}
			if(!CheckFileFormat(files[0], Formats)) return;
			try {
				Image data = Image.FromFile(files[0]);
				if (data.Width >= 5000 || data.Height >= 5000) {
					MessageBox.Show("파일이 너무 큽니다. Width 5000, Height 5000 이하의 사진만 가능합니다.");
					return;
				}
				Original_Picture.Image = data;
				Label_OpenLink.Text = files[0];
			}
			catch (ArgumentException) {
				MessageBox.Show("파일을 확인해 주세요.");
			}
        }
		private bool CheckFileFormat(string target, string [] formats) {
			string target_format = "";
			for (int i = target.Length - 1; i >= 0; i--) {
				if (target[i] == '.') {
					target_format = target.Substring(i + 1, target.Length - (i + 1));
					break;
				}
			}
			for (int i = 0; i < formats.Length; i++) {
				if (target_format.Equals(formats[i])) 
					return true;
			}
			return false;
		}
	}
}