/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 29/04/2016
 * Time: 13:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of MainScreen.
	/// </summary>
	public partial class MainScreen : Form
	{
		public string version()
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;
			DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision*2);
			return "BUILD "+buildDate.Year.ToString()+buildDate.Month.ToString()+buildDate.Day.ToString()+"_"+buildDate.Hour.ToString()+buildDate.Minute.ToString()+buildDate.Second.ToString();
		}
		
		public MainScreen()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			region_lab.Text = "";
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public static string savfilter = "RAW Save file|*.sav;*sa1;*sa2|All Files (*.*)|*.*";
		public string wc3filter = "Wonder Card file|*.wc3|All Files (*.*)|*.*";
		public string wcnfilter = "Wonder News file|*.wn3|All Files (*.*)|*.*";
		public string me3filter = "Mystery Event file|*.me3|All Files (*.*)|*.*";
		public string ectfilter = "e-card Trainer file|*.ect|All Files (*.*)|*.*";
		public string berryfilter = "e-card Berry file|*.ecb|All Files (*.*)|*.*";
		public byte[] savbuffer;
		public byte[] wc3new;
		public byte[] wcnnew;
		public byte[] me3file;
		public byte[] ectfile;
		public byte[] berryfile;
		public static SAV3 sav3file;
		void Button1Click(object sender, EventArgs e)
		{
			Form wc3edit = new WC3_editor();
			wc3edit.ShowDialog();
		}
		
		void update_button_state()
		{
				export_wc3but.Enabled = false;
				inject_wc3_but.Enabled = false;
				export_wcn.Enabled = false;
				inject_wcn.Enabled = false;
				export_me3_but.Enabled = false;
				inject_me3_but.Enabled = false;
				eon_em_but.Enabled = false;
				decor_but.Enabled = false;
				export_ect_but.Enabled = false;
				inject_ect_but.Enabled = false;
				export_eberry.Enabled = false;
				inject_eberry.Enabled = false;
				tvswarm_but.Enabled = false;
				
				region_but.Enabled = false;
				
				toolStripMenuItem1.Enabled = false;
				exportOldSaveToolStripMenuItem.Enabled = false;
				enableMysteryGiftMainScreenStripMenuItem.Enabled = false;
				fixSectionChecksumsToolStripMenuItem.Enabled = false;
				
				switch(sav3file.game)
				{
					case 0:
						//Gamelabel.Text = "Ruby/Sapphire";
						export_me3_but.Enabled = true;
						inject_me3_but.Enabled = true;
						decor_but.Enabled = true;
						export_eberry.Enabled = true;
						inject_eberry.Enabled = true;
						tvswarm_but.Enabled = true;
						break;
					case 1:
						//Gamelabel.Text = "Emerald";
						export_wc3but.Enabled = true;
						inject_wc3_but.Enabled = true;
						export_wcn.Enabled = true;
						inject_wcn.Enabled = true;
						export_me3_but.Enabled = true;
						inject_me3_but.Enabled = true;
						eon_em_but.Enabled = true;
						decor_but.Enabled = true;
						tvswarm_but.Enabled = true;
						break;
					case 2:
						//Gamelabel.Text = "Fire Red/Leaf Green";
						export_wc3but.Enabled = true;
						inject_wc3_but.Enabled = true;
						export_wcn.Enabled = true;
						inject_wcn.Enabled = true;
						tvswarm_but.Enabled = false;
						break;
					default:
						//Gamelabel.Text = "Can't autodetect save game";
						break;
				}
				toolStripMenuItem1.Enabled = true;
				exportOldSaveToolStripMenuItem.Enabled = true;
				enableMysteryGiftMainScreenStripMenuItem.Enabled = true;
				fixSectionChecksumsToolStripMenuItem.Enabled = true;
				clearEggEventFlagToolStripMenuItem.Enabled = sav3file.has_EggEvent_Flag();
				
				export_ect_but.Enabled = true;
				inject_ect_but.Enabled = true;
				
				if(sav3file.isjap == true)
					region_lab.Text = "JAP";
				else
					region_lab.Text = "USA/EUR";

				region_but.Enabled = true;
		}
		
		void Load_save(string path)
		{
			int filesize = FileIO.load_file(ref savbuffer, ref path, savfilter);
			if( filesize == SAV3.SAVE_SIZE)
			{				
				sav3_path.Text = path;
				sav3file = new SAV3(savbuffer);
				
				update_button_state();
				
				language_box.SelectedIndex = sav3file.language-1;
				game_box.SelectedIndex = sav3file.game;

				if (sav3file.isjap == true && sav3file.language != 1)
				{
					DialogResult dialogResult = MessageBox.Show("Region/language autodetection inconsistency.\n\nIs this a japanese savegame?", "Region Input", MessageBoxButtons.YesNo);
					if(dialogResult == DialogResult.Yes)
					{
						sav3file.isjap = true;
						region_lab.Text = "JAP";
						language_box.SelectedIndex = 0;
					}
					else if (dialogResult == DialogResult.No)
					{
						sav3file.isjap = false;
						region_lab.Text = "USA/EUR";
					}
				}
				sav3file.updateOffsets();
	
			}else if (filesize == -1){
					;
			}else{
				MessageBox.Show("Invalid file.");
			}
		}
		void Load_save_butClick(object sender, EventArgs e)
		{
			Load_save(null);
		}
		void Export_wc3butClick(object sender, EventArgs e)
		{
			if(sav3file.has_WC == false)
				MessageBox.Show("Save file does not contain WonderCard data.");
			else
				FileIO.save_data(sav3file.get_WC3(), wc3filter);
		}
		void Inject_wc3_butClick(object sender, EventArgs e)
		{
			if(sav3file.has_WC == true)
			{
				DialogResult dialogResult = MessageBox.Show("Savefile already has a WonderCard. Overwrite?", "WonderCard Injection", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.No)
				{
					return;
				}
			}
					if (sav3file.has_mystery_gift == true)
					{
						string path = null;
						int filesize = FileIO.load_file(ref wc3new, ref path, wc3filter);
						if( (filesize == wc3.SIZE_WC3 && sav3file.isjap == false) || (filesize == wc3.SIZE_WC3_jap  && sav3file.isjap == true) )
						{				
							sav3file.set_WC3(wc3new);
							//custom_script.Checked = true;
							//Add fix sav3 checksum func3
							sav3file.update_section_chk(4);
							MessageBox.Show("WC3 injected.");
							FileIO.save_data(sav3file.Data, savfilter);
							
						}else if (filesize == -1){
							;
						}else{
							MessageBox.Show("Invalid file size.");
						}
					}else
					{
						MessageBox.Show("Save file does not have Mystery Gift enabled.");
					}
		}
		void Export_wcnClick(object sender, EventArgs e)
		{
			if(sav3file.has_WCN == false)
				MessageBox.Show("Save file does not contain Wonder News data.");
			else
			FileIO.save_data(sav3file.get_WCN(), wcnfilter);
		}
		void Inject_wcnClick(object sender, EventArgs e)
		{
			if (sav3file.has_mystery_gift == true)
			{
				string path = null;
				int filesize = FileIO.load_file(ref wcnnew, ref path, wcnfilter);
				if( (filesize == SAV3.WCN_SIZE && sav3file.isjap == false) || (filesize == SAV3.WCN_SIZE_jap  && sav3file.isjap == true) )
				{				
					sav3file.set_WCN(wcnnew);
					//custom_script.Checked = true;
					//Add fix sav3 checksum func3
					sav3file.update_section_chk(4);
					MessageBox.Show("WC News injected.");
					FileIO.save_data(sav3file.Data, savfilter);
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
			}else
			{
				MessageBox.Show("Save file does not have Mystery Gift enabled.");
			}
		}
		void Wcn_edit_butClick(object sender, EventArgs e)
		{
			Form wcnedit = new WCN_editor();
			wcnedit.ShowDialog();
		}
		void Export_me3_butClick(object sender, EventArgs e)
		{
			int check = sav3file.has_ME3();
			if(check == 0)
				MessageBox.Show("Save file does not contain Mystery Event Data.");
			else if(check == 2)
				MessageBox.Show("Save file does contain Mystery Event Data, but the script has already been erased from savedata.");
			
			if (check != 0)
				FileIO.save_data(sav3file.get_ME3(), me3filter);
		}
		void Inject_me3_butClick(object sender, EventArgs e)
		{
			if (sav3file.has_mystery_event == true || sav3file.game == 1)
			{
				if (sav3file.game == 1)
					MessageBox.Show("Mystery Event was removed from non Japanese Emerald.\n\tYou can still inject the data at your own risk.");
				string path = null;
				int filesize = FileIO.load_file(ref me3file, ref path, me3filter);
				if( filesize == sav3file.me3_size )
				{	
					ME3 me3_struct = new ME3(me3file, filesize);
					if (sav3file.game != me3_struct.isemerald)
					{
						MessageBox.Show("This ME3 file is not for this game!");
					}else
					{
						sav3file.set_ME3(me3file);
						//custom_script.Checked = true;
						//Add fix sav3 checksum func3
						sav3file.update_section_chk(4);
						MessageBox.Show("Mystery event injected.");
						FileIO.save_data(sav3file.Data, savfilter);
					}
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
			}else
			{
				MessageBox.Show("Save file does not have Mystery Event enabled.");
			}
		}
		void Me3_editor_butClick(object sender, EventArgs e)
		{
			Form me3edit = new ME3_editor();
			me3edit.ShowDialog();
		}
		void Eon_em_butClick(object sender, EventArgs e)
		{
			MessageBox.Show("This will enable the Eon ticket event as distributed in Japan.\nKeep in mind this event was never available outside Japan.\nIf you want a legit EON ticket in Emerald, you have to Mix Records with a Ruby/Saphire game with distributable EON ticket.");
			sav3file.enable_eon_emerald();
			MessageBox.Show("Mystery event EON Ticket injected.\n\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
			FileIO.save_data(sav3file.Data, savfilter);
		}
		void EnableMysteryGiftMainScreenStripMenuItemClick(object sender, EventArgs e)
		{
			sav3file.enable_Mystery();
			FileIO.save_data(sav3file.Data, savfilter);
		}
		void Region_butClick(object sender, EventArgs e)
		{
			/*
			sav3file.prompt_region("Is this a Japanese savegame?");
				if (sav3file.isjap)
					region_text.Text = "JAP";
				else
					region_text.Text = "USA/EUR";
			*/
			game_box.Enabled = true;
			language_box.Enabled = true;
		}
		void FixSectionChecksumsToolStripMenuItemClick(object sender, EventArgs e)
		{
			sav3file.fix_section_checksums();
			FileIO.save_data(sav3file.Data, savfilter);
		}
		void Decor_butClick(object sender, EventArgs e)
		{
			Form decoredit = new Decor_editor(sav3file);
			decoredit.ShowDialog();
		}
		void Ect_edit_butClick(object sender, EventArgs e)
		{
			Form ectedit = new ECT_editor();
			ectedit.ShowDialog();
		}
		void Export_ect_butClick(object sender, EventArgs e)
		{
			/*int check = sav3file.has_ME3();
			if(check == 0)
				MessageBox.Show("Save file does not contain Mystery Event Data.");
			else if(check == 2)
				MessageBox.Show("Save file does contain Mystery Event Data, but the script has already been erased from savedata.");
			
			if (check != 0)*/
				FileIO.save_data(sav3file.get_ECT(), ectfilter);
		}
		void Inject_ect_butClick(object sender, EventArgs e)
		{
			//if (sav3file.has_mystery_event == true || sav3file.game == 1)
			//{
				if (sav3file.game == 1)
					MessageBox.Show("Mystery Event was removed from non Japanese Emerald.\n\tYou can still inject the data at your own risk.");
				string path = null;
				int filesize = FileIO.load_file(ref ectfile, ref path, ectfilter);
				if( filesize == ECT.SIZE_ECT )
				{				
					sav3file.set_ECT(ectfile);
					sav3file.update_section_chk(0);
					MessageBox.Show("e-card Trainer injected.");
					FileIO.save_data(sav3file.Data, savfilter);
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
			//}else
			//{
			//	MessageBox.Show("Save file does not have Mystery Event enabled.");
			//}
		}
		void MainScreenDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void MainScreenDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_save(files[0]);
		}
		void Game_boxSelectedIndexChanged(object sender, EventArgs e)
		{
			sav3file.game = game_box.SelectedIndex;
			update_button_state();
			sav3file.updateOffsets();
		}
		void Language_boxSelectedIndexChanged(object sender, EventArgs e)
		{
			sav3file.language = language_box.SelectedIndex+1;
			
			if(sav3file.language == 1)
				sav3file.isjap = true;
			else
				sav3file.isjap = false;
			
			if(sav3file.isjap == true)
				region_lab.Text = "JAP";
			else
				region_lab.Text = "USA/EUR";
			
			update_button_state();			
			sav3file.updateOffsets();
		}
		void ExportOldSaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			FileIO.save_data(sav3file.getSortedSave(1), savfilter);
		}
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			FileIO.save_data(sav3file.getSortedSave(0), savfilter);
		}
		void ClearEggEventFlagToolStripMenuItemClick(object sender, EventArgs e)
		{
			sav3file.clear_EggEvent_Flag();
			MessageBox.Show("Egg Event flag cleared.");
			FileIO.save_data(sav3file.Data, savfilter);
			clearEggEventFlagToolStripMenuItem.Enabled = sav3file.has_EggEvent_Flag();
		}
		void EnableEnigmaBerryFlagToolStripMenuItemClick(object sender, EventArgs e)
		{

		}
		void Export_eberryClick(object sender, EventArgs e)
		{
			if(sav3file.has_berry() == true)
			{
				FileIO.save_data(sav3file.get_ECB(), berryfilter);
			}else
			{
				MessageBox.Show("There's no berry in savefile.");
			}

		}
		void Inject_eberryClick(object sender, EventArgs e)
		{
			if (sav3file.game == 0)
			{
				string path = null;
				int filesize = FileIO.load_file(ref berryfile, ref path, berryfilter);
				if( filesize == SAV3.BERRY_SIZE)
				{				
					sav3file.set_ECB(berryfile);
					sav3file.set_Enigma_Flag();
					sav3file.update_section_chk(4);
					MessageBox.Show("Enigma Berry injected.");
					FileIO.save_data(sav3file.Data, savfilter);
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
			}

		}
		void Ecb_edit_butClick(object sender, EventArgs e)
		{
			Form ecbedit = new ECB_editor();
			ecbedit.ShowDialog();
		}
		void AboutToolStripMenuItem1Click(object sender, EventArgs e)
		{
			MessageBox.Show("Mystery Gift Tool 0.1c by suloku ("+version()+")\n\nMany thanks to ajxpkm, Real.96, BlackShark, lostaddict, Háčky, every contributor and many more involved in Mystery Event research!\n\nThe research thread at projectpokemon.org might be of your interest.\n\nIf you want to contribute any missing event, contact suloku or ajxpkm at projectpokemon's forums or gen3mysterygift@gmail.com");
		}
		void Tvswarm_butClick(object sender, EventArgs e)
		{
			Form tvswarm = new TV_editor(sav3file);
			tvswarm.ShowDialog();
		}
		void Events_distro_butClick(object sender, EventArgs e)
		{
			Form distro = new EventTool();
			distro.ShowDialog();
		}
	}
}
