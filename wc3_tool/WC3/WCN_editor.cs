/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 28/04/2016
 * Time: 21:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Reflection;
using System.Resources;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class WCN_editor : Form
	{
		public WCN_editor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			regionlab.Text = "";
			GFX = this.CreateGraphics();
			colorbox.SelectedIndex = 0;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public string wcnfilter = "Wonder News file|*.wn3|All Files (*.*)|*.*";
		public byte[] wcnbuffer = new byte[SAV3.WCN_SIZE];
		public static wc3 wcnfile;
		
		public bool japanese = false;
		
		private Graphics GFX;
		
		void update_wcdata()
		{
			switch (wcnfile.distributable)
			{
				case 0:
					distrocheck.Checked = false;
					break;
				case 1:
					distrocheck.Checked = true;
					break;
				default:
					distrocheck.Checked = false;
					break;
			}
			
			colorbox.SelectedIndex = wcnfile.cardcolor;
			
			header1.Text = wcnfile.get_wn_text_2(0);
			body1.Text = wcnfile.get_wn_text_2(1);
			body2.Text = wcnfile.get_wn_text_2(2);
			body3.Text = wcnfile.get_wn_text_2(3);
			body4.Text = wcnfile.get_wn_text_2(4);
			body5.Text = wcnfile.get_wn_text_2(5);
			body6.Text = wcnfile.get_wn_text_2(6);
			body7.Text = wcnfile.get_wn_text_2(7);
			body8.Text = wcnfile.get_wn_text_2(8);
			body9.Text = wcnfile.get_wn_text_2(9);
			body10.Text = wcnfile.get_wn_text_2(10);
		}
		void set_wcndata()
		{
			wcnfile.clear_wn_text();
			wcnfile.insert_wn_text_2(header1.Text, 0);
			wcnfile.insert_wn_text_2(body1.Text, 1);
			wcnfile.insert_wn_text_2(body2.Text, 2);
			wcnfile.insert_wn_text_2(body3.Text, 3);
			wcnfile.insert_wn_text_2(body4.Text, 4);
			wcnfile.insert_wn_text_2(body5.Text, 5);
			wcnfile.insert_wn_text_2(body6.Text, 6);
			wcnfile.insert_wn_text_2(body7.Text, 7);
			wcnfile.insert_wn_text_2(body8.Text, 8);
			wcnfile.insert_wn_text_2(body9.Text, 9);
			wcnfile.insert_wn_text_2(body10.Text,10);
		}
		
		void Load_WCN(string path)
		{
			int filesize = FileIO.load_file(ref wcnbuffer, ref path, wcnfilter);
			if( filesize == SAV3.WCN_SIZE || filesize == SAV3.WCN_SIZE_jap)
			{	
				if (filesize == SAV3.WCN_SIZE_jap)
				{
					japanese = true;
					regionlab.Text = "JAP";
					header1.MaxLength = 20;
					body1.MaxLength = 20;
					body2.MaxLength = 20;
					body3.MaxLength = 20;
					body4.MaxLength = 20;
					body5.MaxLength = 20;
					body6.MaxLength = 20;
					body7.MaxLength = 20;
					body8.MaxLength = 20;
					body9.MaxLength = 20;
					body10.MaxLength = 20;
				}else
				{
					japanese = false;
					regionlab.Text = "USA/EUR";
					header1.MaxLength = 40;
					body1.MaxLength = 40;
					body2.MaxLength = 40;
					body3.MaxLength = 40;
					body4.MaxLength = 40;
					body5.MaxLength = 40;
					body6.MaxLength = 40;
					body7.MaxLength = 40;
					body8.MaxLength = 40;
					body9.MaxLength = 40;
					body10.MaxLength = 40;
				}
			
				wc3_path.Text = path;
				wcnfile = new wc3(wcnbuffer);
				
				update_wcdata();
				
				save_wc3_but.Enabled = true;
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		void Load_wc3_butClick(object sender, EventArgs e)
		{
			Load_WCN(null);
		}
		void Save_wc3_butClick(object sender, EventArgs e)
		{
			int distro = 0;
			if(distrocheck.Checked)
				distro = 1;
			wcnfile.set_wcn_color_distro(colorbox.SelectedIndex , distro);
			set_wcndata();
			wcnfile.fix_wcn_checksum();
			//if (wcnfile.Edited)
				FileIO.save_data(wcnfile.Data, wcnfilter);
			//else MessageBox.Show("Save has not been edited");
		}

		void WCN_editorLoad(object sender, EventArgs e)
		{
	
		}
		ResourceManager resources = new ResourceManager("WC3_TOOL.WC3.Image.Cards", Assembly.GetExecutingAssembly());
		Image bitmap;
		void drawCard()
		{
			//ResourceManager resources = new ResourceManager("WC3_TOOL.WC3.Image.Cards", Assembly.GetExecutingAssembly());
			bitmap = (Image)resources.GetObject("News_"+colorbox.SelectedIndex.ToString());
			GFX.DrawImage(bitmap, 500, 140+26, 260, 140);
			GFX.DrawImage(bitmap, 500, 140, 260, 140);
			

			GFX.DrawString(header1.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+4);
			GFX.DrawString(body1.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21);
			GFX.DrawString(body2.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*1));
			GFX.DrawString(body3.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*2));
			GFX.DrawString(body4.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*3));
			GFX.DrawString(body5.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*4));
			GFX.DrawString(body6.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*5));
			GFX.DrawString(body7.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*6));
			GFX.DrawString(body8.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*7));
			GFX.DrawString(body9.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*8));
			GFX.DrawString(body10.Text, new Font("Calibri", 8), Brushes.Black, 500+7, 140+21+(14*9));
			
		}
		void ColorboxSelectedIndexChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Header1TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body1TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body2TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body3TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body4TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body5TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body6TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body7TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body8TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body9TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Body10TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		
		void WCN_editorDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void WCN_editorDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_WCN(files[0]);
		}		
	}
}
