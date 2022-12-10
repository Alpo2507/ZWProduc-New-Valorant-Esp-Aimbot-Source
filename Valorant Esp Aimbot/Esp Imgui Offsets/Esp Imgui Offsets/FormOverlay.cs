using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace iBaseult
{
	public class FormOverlay : Form
	{
		private Graphics g;

		private IContainer components;

		protected override System.Windows.Forms.CreateParams CreateParams
		{
			get
			{
				System.Windows.Forms.CreateParams createParams = base.CreateParams;
				createParams.ClassStyle = createParams.ClassStyle | 512;
				return createParams;
			}
		}

		public FormOverlay()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void FormOverlay_Load(object sender, EventArgs e)
		{
			try
			{
				this.BackColor = Color.Wheat;
				base.TransparencyKey = Color.Wheat;
				base.TopMost = true;
				base.MaximizeBox = true;
				base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				int test = (int)FormOverlay.GetWindowLongPtr(base.Handle, -20) | 524288 | 32;
				FormOverlay.SetWindowLongPtr(new HandleRef(this, base.Handle), -20, new IntPtr(test));
				Form1 form1 = new Form1();
			}
			catch
			{
				MessageBox.Show("Failure Code - 10 - There might be an issue with the FovCircle!");
			}
		}

		public void FormOverlayPaint(object sender, PaintEventArgs e)
		{
			while (true)
			{
				try
				{
				Label0:
					Form1 form1 = new Form1();
					base.Top = (form1.ySize - form1.fovY) / 2;
					base.Left = (form1.xSize - form1.fovX) / 2;
					base.Size = new System.Drawing.Size(form1.fovX + 50, form1.fovY + 50);
					if (form1.isCircle)
					{
						while (true)
						{
							try
							{
								Form1 form2 = new Form1();
								this.g = e.Graphics;
								Pen New = new Pen(Color.FromArgb(form2.FovCircleRed, form2.FovCircleGreen, form2.FovCircleBlue))
								{
									Width = (float)form1.FovCircleWidth
								};
								e.Graphics.Clear(Color.Wheat);
								this.g.DrawEllipse(New, 0, 0, form2.fovX, form2.fovY);
								this.WaitNSeconds(5);
								goto Label0;
							}
							catch
							{
								MessageBox.Show("Failure Code - 12 - There might be an issue with the FovCircle!");
								base.Close();
							}
						}
					}
					else
					{
						base.Invalidate();
						base.Close();
						break;
					}
				}
				catch
				{
					MessageBox.Show("Failure Code - 13 - There might be an issue with the FovCircle!");
					break;
				}
			}
		}

		[DllImport("user32.dll", CharSet=CharSet.None, EntryPoint="GetWindowLong", ExactSpelling=false)]
		private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(800, 450);
			base.Name = "FormOverlay";
			this.Text = "Fov Circle";
			base.Load += new EventHandler(this.FormOverlay_Load);
			base.Paint += new PaintEventHandler(this.FormOverlayPaint);
			base.ResumeLayout(false);
		}

		[DllImport("user32.dll", CharSet=CharSet.None, EntryPoint="SetWindowLong", ExactSpelling=false)]
		private static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

		public static IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
		{
			if (IntPtr.Size == 8)
			{
				return FormOverlay.SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			}
			return new IntPtr(FormOverlay.SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
		}

		[DllImport("user32.dll", CharSet=CharSet.None, EntryPoint="SetWindowLongPtr", ExactSpelling=false)]
		private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

		private void WaitNSeconds(int segundos)
		{
			if (segundos < 1)
			{
				return;
			}
			DateTime _desired = DateTime.Now.AddSeconds((double)segundos);
			while (DateTime.Now < _desired)
			{
				Application.DoEvents();
			}
		}
	}
}