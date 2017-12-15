using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalTestAppWF
{
	public partial class Form1 : Form
	{
		private SerializeAPI serializeAPI;

		public Form1()
		{
			InitializeComponent();
			this.serializeAPI = new SerializeAPI();
		}

		/// <summary>
		///  Handles the Click event of the button1 control to serialize the selected folder.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void serialize_Click(object sender, EventArgs e)
		{
			//file open dialog
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					//save file dialog
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						if (!string.IsNullOrWhiteSpace(sfd.FileName))
						{
							try
							{
								this.serializeAPI.Serialize(fbd.SelectedPath + "\\", sfd.FileName);
							}
							catch (UnauthorizedAccessException ex)
							{
								MessageBox.Show(ex.Message);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
					}
				}
			}
		}


		/// <summary>
		/// Handles the Click event of the button2 control to deserialize the selected file.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void deserialize_Click(object sender, EventArgs e)
		{
			//open folder dielog
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				ofd.Title = "Select File";
				if (!string.IsNullOrWhiteSpace(ofd.FileName))
				{
					//folder browser dialog
					if (fbd.ShowDialog() == DialogResult.OK)
					{
						if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
						{
							try
							{
								this.serializeAPI.Deserialize(ofd.FileName, fbd.SelectedPath + "\\");
							}
							catch (UnauthorizedAccessException ex)
							{
								MessageBox.Show(ex.Message);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
					}
				}
			}
		}
	}
}
