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

using PKHeX;

using System.Reflection;
using System.Resources;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class WC3_editor : Form
	{
		public WC3_editor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			faketoogle.Checked = true;
			regionlab.Text = "";
			GFX = this.CreateGraphics();
			colorbox.SelectedIndex = 0;
			icon_num.Value = 0;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public string wc3filter = "Wonder Card file|*.wc3|All Files (*.*)|*.*";
		public string scriptfilter = "Script file|*.script|All Files (*.*)|*.*";
		public string xsescriptfilter = "XSE padded script file|*.gba";
		public byte[] wc3buffer;
		public byte[] wc3script_new;
		public static wc3 wc3file;
		
		public bool japanese = false;
		public static bool script_injected = false;
		
		private Graphics GFX;
		
		void update_iconbox()
		{
			iconbox.Enabled = true;
			if (icon_num.Value >= 1 && icon_num.Value <= 251){
				iconbox.SelectedIndex = (UInt16)icon_num.Value;
			}/*else if (icon_num.Value >= 252 && icon_num.Value <= 276){
				iconbox.Enabled = false;
				iconbox.SelectedIndex = 440;
			}*/else if (icon_num.Value >= 251 && icon_num.Value <= 440){
				iconbox.SelectedIndex = (UInt16)icon_num.Value;
			}else if (icon_num.Value == 0xFFFF){
				iconbox.SelectedIndex = 0;
			}else{
				iconbox.Enabled = false;
				iconbox.SelectedIndex = 440;
			}
		}
		string fill_line(string line, int index) //Fills string with spaces to "erase" old content.
		{
			if (japanese == true)
			{
				switch (index)
				{
					case 0:
						while(line.Length < 18)
						{
							line = line + " ";
						}
						break;
					case 1:
						while(line.Length < 13)
						{
							line = line + " ";
						}
						break;
					default:
						while(line.Length < 20)
						{
							line = line + " ";
						}
						break;
				}

			}else
			{
				while(line.Length < 40)
				{
					line = line + " ";
				}
			}
			
			return line;
			
		}
		void update_wcdata()
		{
			switch (wc3file.distributable)
			{
				case 0:
					distro_but_no.Checked = true;
					break;
				case 1:
					distro_but_always.Checked = true;
					break;
				case 2:
					distro_but_one.Checked = true;
					break;
				default:
					distro_but_no.Checked = true;
					break;
			}
			icon_num.Value = wc3file.get_wc_icon();
			update_iconbox();
			colorbox.SelectedIndex = wc3file.get_wc_color();
			

				header1.Text = wc3file.get_wc_text_2(0);
				header2.Text = wc3file.get_wc_text_2(1);
				body1.Text = wc3file.get_wc_text_2(2);
				body2.Text = wc3file.get_wc_text_2(3);
				body3.Text = wc3file.get_wc_text_2(4);
				body4.Text = wc3file.get_wc_text_2(5);
				footer1.Text = wc3file.get_wc_text_2(6);
				footer2.Text = wc3file.get_wc_text_2(7);
			/*
				header1.Text = wc3file.get_wc_text(0);
				header2.Text = wc3file.get_wc_text(1);
				body1.Text = wc3file.get_wc_text(2);
				body2.Text = wc3file.get_wc_text(3);
				body3.Text = wc3file.get_wc_text(4);
				body4.Text = wc3file.get_wc_text(5);
				footer1.Text = wc3file.get_wc_text(6);
				footer2.Text = wc3file.get_wc_text(7);
			*/
			
				map_bank.Value = wc3file.MAP_BANK;
				map_map.Value = wc3file.MAP_MAP;
				map_npc.Value = wc3file.MAP_NPC;
		}
		void set_wcdata()
		{
				wc3file.clear_wc_text(); //instead of clearing line, clear all text
				wc3file.insert_wc_text_2(header1.Text, 0);
				wc3file.insert_wc_text_2(header2.Text, 1);
				wc3file.insert_wc_text_2(body1.Text, 2);
				wc3file.insert_wc_text_2(body2.Text, 3);
				wc3file.insert_wc_text_2(body3.Text, 4);
				wc3file.insert_wc_text_2(body4.Text, 5);
				wc3file.insert_wc_text_2(footer1.Text, 6);
				wc3file.insert_wc_text_2(footer2.Text, 7);
			/*
				wc3file.insert_wc_text(header1.Text, 0);
				wc3file.insert_wc_text(header2.Text, 1);
				wc3file.insert_wc_text(body1.Text, 2);
				wc3file.insert_wc_text(body2.Text, 3);
				wc3file.insert_wc_text(body3.Text, 4);
				wc3file.insert_wc_text(body4.Text, 5);
				wc3file.insert_wc_text(footer1.Text, 6);
				wc3file.insert_wc_text(footer2.Text, 7);
			*/
				wc3file.ID = 0x33;
				wc3file.MAP_BANK = (byte)map_bank.Value;
				wc3file.MAP_MAP = (byte)map_map.Value;
				wc3file.MAP_NPC = (byte)map_npc.Value;
		}
		
		void Load_WC3(string path)
		{
			int filesize = FileIO.load_file(ref wc3buffer, ref path, wc3filter);
			if( filesize == wc3.SIZE_WC3 || filesize == wc3.SIZE_WC3_jap)
			{	
				if (filesize == wc3.SIZE_WC3_jap)
				{
					japanese = true;
					regionlab.Text = "JAP";
					header1.MaxLength = 18;
					header2.MaxLength = 13;
					body1.MaxLength = 20;
					body2.MaxLength = 20;
					body3.MaxLength = 20;
					body4.MaxLength = 20;
					footer1.MaxLength = 20;
					footer2.MaxLength = 20;
				}else{
					japanese = false;
					regionlab.Text = "USA/EUR";
					header1.MaxLength = 40;
					header2.MaxLength = 40;
					body1.MaxLength = 40;
					body2.MaxLength = 40;
					body3.MaxLength = 40;
					body4.MaxLength = 40;
					footer1.MaxLength = 40;
					footer2.MaxLength = 40;
				}
				
				wc3_path.Text = path;
				wc3file = new wc3(wc3buffer);
				
				update_wcdata();
				
				save_wc3_but.Enabled = true;
				export_script_but.Enabled = true;
				import_script_but.Enabled = true;
				xse_export.Enabled = true;
				xse_import.Enabled = true;
				custom_script.Checked = false;
				
				drawCard();
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		
		void Load_wc3_butClick(object sender, EventArgs e)
		{
			Load_WC3(null);
		}
		void Save_wc3_butClick(object sender, EventArgs e)
		{
			if (faketoogle.Checked == true)
				wc3file.fakeWC();
			//wc3file.fakeSCript();
			//wc3file.clean_trash();
			wc3file.set_wc_icon((UInt16)icon_num.Value);
			int distro = 0;
			if (distro_but_always.Checked == true)
				distro = 1;
			else if (distro_but_one.Checked == true)
				distro = 2;
			else
				distro = 0;
			wc3file.set_wc_color_distro(colorbox.SelectedIndex , distro);
			set_wcdata();
			wc3file.fix_script_checksum();
			wc3file.fix_wc_checksum();
			if (wc3file.Edited)
				FileIO.save_data(wc3file.Data, wc3filter);
			else MessageBox.Show("Save has not been edited");
		}
		void Export_script_butClick(object sender, EventArgs e)
		{
			FileIO.save_data(wc3file.get_script(), scriptfilter);
		}
		void Import_script_butClick(object sender, EventArgs e)
		{
			string path = null;
			int filesize = FileIO.load_file(ref wc3script_new, ref path, scriptfilter);
			if( filesize <= 996 )
			{				
				wc3file.set_script(wc3script_new);
				custom_script.Checked = true;
				MessageBox.Show("Custom script imported.");
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		void IconboxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (iconbox.SelectedIndex == 0)
				icon_num.Value = 0xFFFF;
			else if(iconbox.SelectedIndex > 251)
				icon_num.Value = iconbox.SelectedIndex;
			else
				icon_num.Value = iconbox.SelectedIndex;
		}
		void Icon_numValueChanged(object sender, EventArgs e)
		{
			update_iconbox();
			drawCard();
		}
		void WC3_editorLoad(object sender, EventArgs e)
		{
	
		}
		void GiveEgg_butClick(object sender, EventArgs e)
		{
			Form giveEeg = new WC3_editor_givegg();
			giveEeg.ShowDialog();
			if (script_injected == true)
			{
				script_injected = false;
				custom_script.Checked = true;
				MessageBox.Show("Give Egg script injected.");
			}
		}
		void ColorboxSelectedIndexChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		ResourceManager resources = new ResourceManager("WC3_TOOL.WC3.Image.Cards", Assembly.GetExecutingAssembly());
		ResourceManager resources2 = new ResourceManager("WC3_TOOL.WC3.Image.Icons", Assembly.GetExecutingAssembly());
		Image bitmap2;
		Image bitmap;
		void drawCard()
		{
 			bitmap = (Image)resources.GetObject("Card_"+colorbox.SelectedIndex.ToString());
			GFX.DrawImage(bitmap, 501, 141, 238, 158);

			if (icon_num.Value <= 251 || (icon_num.Value >= 277 && icon_num.Value <= 411))
			{
				bitmap2 = (Image)resources2.GetObject(PKHeX.PKM.getG4Species((int)icon_num.Value).ToString());
				GFX.DrawImage(bitmap2, 700, 140, 40, 40);
			}else if ((icon_num.Value >= 412 && icon_num.Value <= 439)) // Egg and unown forms
			{
				bitmap2 = (Bitmap)resources2.GetObject(icon_num.Value.ToString());
				GFX.DrawImage(bitmap2, 700, 140, 40, 40);
			}else
			{
				bitmap2 = (Bitmap)resources2.GetObject("0");
				GFX.DrawImage(bitmap2, 700, 140, 40, 40);
			}
			

			GFX.DrawString(header1.Text, new Font("Calibri", 8), Brushes.Black, 500+10+1, 140+12);
			GFX.DrawString(header2.Text, new Font("Calibri", 8), Brushes.Black, 500+10+1, 140+28);
			GFX.DrawString(body1.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+50);
			GFX.DrawString(body2.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+66);
			GFX.DrawString(body3.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+82);
			GFX.DrawString(body4.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+98);
			GFX.DrawString(footer1.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+122);
			GFX.DrawString(footer2.Text, new Font("Calibri", 8), Brushes.Black, 500+5+1, 140+138);
			
		}
		void Header1TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Header2TextChanged(object sender, EventArgs e)
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
		void Footer1TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Footer2TextChanged(object sender, EventArgs e)
		{
			drawCard();
		}
		void Map_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("These values are used to associate the script to a NPC character in the game.\n\nYou can use Advance Map to locate the values for all NPC in the game.\n\nIn Emerald, father at petalburg Gym is Bank 08, Map 01, NPC 01.\n\n For Wondercard Deliveryman set all to 255");
		}
		void Xse_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("XSE Export: exports the script with padding corresponding to base address of the script and *.gba extension. You can directly load (and edit) the script in XSE, script offset will be shown when using the export button.\nXSE Import: imports a *.gba script generated by this tool after editing (or not) with XSE (importing anything else will not correctly work).\n\nThese options are just for convenience, the scripts are in no way gba roms, but it's the more convenient way to edit them in XSE.");
		}
		void Xse_exportClick(object sender, EventArgs e)
		{
			FileIO.save_data(wc3file.get_script_XSE(), xsescriptfilter);
		}
		void Xse_importClick(object sender, EventArgs e)
		{
			string path = null;
			int filesize = FileIO.load_file(ref wc3script_new, ref path, xsescriptfilter);
			if( filesize <= 1000 )
			{				
				wc3file.set_script_XSE(wc3script_new);
				custom_script.Checked = true;
				MessageBox.Show("Custom script imported.");
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		void GiveEggExt_butClick(object sender, EventArgs e)
		{
			Form giveEegExt = new WC3_editor_giveggExt();
			giveEegExt.ShowDialog();
			if (script_injected == true)
			{
				script_injected = false;
				custom_script.Checked = true;
				MessageBox.Show("Give Egg script injected.");
			}
		}
		
		void WC3_editorDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void WC3_editorDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_WC3(files[0]);
		}

	}
}
