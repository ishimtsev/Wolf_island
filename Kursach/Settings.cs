using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
	public partial class Settings : Form
	{
		public Settings()
		{
			InitializeComponent();
		}

		private void OKbutton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && OKbutton.Visible)
				DialogResult = DialogResult.OK;
		}
		private void textBox_TextChanged(object sender, EventArgs e)
		{
			WarningLabel1.Visible = false;
			WarningLabel2.Visible = false;
			if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" 
				|| textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
			{
				WarningLabel1.Visible = true;
			}

			TextBox textbox = sender as TextBox;
			int k;
			if (int.TryParse(textbox.Text, out k))
			{
				if (k < 0)
					WarningLabel2.Visible = true;
			}
			else
				WarningLabel2.Visible = true;
			if (WarningLabel1.Visible || WarningLabel2.Visible)
				OKbutton.Enabled = false;
			else
				OKbutton.Enabled = true;
		}

		private void DefaultButton_Click(object sender, EventArgs e)
		{
			textBox1.Text = "20";
			textBox2.Text = "7";
			textBox3.Text = "7";
			textBox4.Text = "1";
			textBox5.Text = "2";
			textBox6.Text = "7";
			textBox7.Text = "20";
		}
	}
}
