using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftKeyUtils
{
	public enum ProgressBarDisplayText
	{
		Percentage,
		CustomText,
		Both
	}

	public class CustomProgressBar : ProgressBar
	{
		//Property to set to decide whether to print a % or Text
		public ProgressBarDisplayText DisplayStyle { get; set; }

		//Property to hold the custom text
		public String CustomText { get; set; }

		public bool UseCustomText { get; set; }

		public CustomProgressBar()
		{
			try
			{
				if (UseCustomText == true)
				{
					// Modify the ControlStyles flags
					//http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
					SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "78286506-1527-4a59-8fbe-3123a4fabc95");
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (UseCustomText == false)
				{
					return;
				}

				Rectangle rect = ClientRectangle;
				Graphics g = e.Graphics;

				ProgressBarRenderer.DrawHorizontalBar(g, rect);
				rect.Inflate(-3, -3);
				if (Value > 0)
				{
					// As we doing this ourselves we need to draw the chunks on the progress bar
					Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
					ProgressBarRenderer.DrawHorizontalChunks(g, clip);
				}

				// Set the Display text (Either a % amount or our custom text
				string text = string.Empty;

				int iPercent = Value * 100 / Maximum;

				switch (DisplayStyle)
				{
					case ProgressBarDisplayText.Percentage:
						text = iPercent.ToString() + '%';
						break;

					case ProgressBarDisplayText.CustomText:
						text = CustomText;
						break;

					case ProgressBarDisplayText.Both:
						text = string.Format("{0} - {1}%", CustomText, iPercent.ToString());
						break;
				}


				using (Font f = new Font(FontFamily.GenericSerif, 10))
				{

					SizeF len = g.MeasureString(text, f);
					// Calculate the location of the text (the middle of progress bar)
					Point location = new Point(Convert.ToInt32((rect.Width / 2) - (len.Width / 2)), Convert.ToInt32((rect.Height / 2) - (len.Height / 2)));
					// Draw the custom text
					g.DrawString(text, f, Brushes.Black, location);
				}
				//UpdateText();
			}
			catch (Exception exp)
			{
                Logger.WriteErrorLogOnly(exp, "e4af60b8-39dc-49d5-a2f3-931114a6d31f");
			}

		}


        #region @cmnt skislyuk: [18 October 13, 13:37:55]   [131018_133755]
        //private void UpdateText()
        //{

        //try
        //{
        //if (UseCustomText == true)
        //{
        //return;
        //}

        //string text = string.Empty;
        //int iPercent = Value * 100 / Maximum;

        //switch (DisplayStyle)
        //{
        //case ProgressBarDisplayText.Percentage:
        //text = iPercent.ToString() + '%';
        //break;

        //case ProgressBarDisplayText.CustomText:
        //text = CustomText;
        //break;

        //case ProgressBarDisplayText.Both:
        //text = string.Format("{0} - {1}%", CustomText, iPercent.ToString());
        //break;
        //}

        //using (Graphics gr = CreateGraphics())
        //{
        //gr.DrawString(text, Font, new SolidBrush(ForeColor),
        //new PointF(Width / 2 - (gr.MeasureString(text, Font).Width / 2.0F),
        //Height / 2 - (gr.MeasureString(text, Font).Height / 2.0F)));
        //}
        //}
        //catch (Exception exp)
        //{
        ////Logger.WriteErrorLogOnly(exp, "16f8097f-ba9f-478d-bdbd-25505237cbd4");
        //}

        //}
        #endregion @cmnt skislyuk: [18 October 13, 13:37:55]   [131018_133755]

    }
}
