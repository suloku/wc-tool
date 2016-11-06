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
using System.Resources;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of EventTool.
	/// </summary>
	public partial class EventTool : Form
	{
		public EventTool()
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
		ResourceManager Tickets = new ResourceManager("WC3_tool.WC3.Tickets", Assembly.GetExecutingAssembly());
		public string savfilter = "RAW Save file|*.sav;*sa1;*sa2|All Files (*.*)|*.*";
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
		void Load_save(string path)
		{
			int filesize = FileIO.load_file(ref savbuffer, ref path, savfilter);
			if( filesize == SAV3.SAVE_SIZE)
			{				
				sav3_path.Text = path;
				sav3file = new SAV3(savbuffer);
				
				
				region_but.Enabled = false;
				
				switch(sav3file.game)
				{
					case 0:
						//Gamelabel.Text = "Ruby/Sapphire";

						break;
					case 1:
						//Gamelabel.Text = "Emerald";

						break;
					case 2:
						//Gamelabel.Text = "Fire Red/Leaf Green";

						break;
					default:
						//Gamelabel.Text = "Can't autodetect save game";
						break;
				}

				
				if(sav3file.isjap == true)
					region_lab.Text = "JAP";
				else
					region_lab.Text = "USA/EUR";

				region_but.Enabled = true;
				
				language_box.SelectedIndex = sav3file.language-1;
				game_box.SelectedIndex = sav3file.game;

				if (sav3file.isjap == true && sav3file.language != 1)
				{
					DialogResult dialogResult = MessageBox.Show("Region/language autodetection inconsistency.\n\nIs this a japanesse savegame?", "Region Input", MessageBoxButtons.YesNo);
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
					MessageBox.Show("Mystery Event was removed from non Japanesse Emerald.\n\tYou can still inject the data at your own risk.");
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
		void EnableMysteryGiftEventToolStripMenuItemClick(object sender, EventArgs e)
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
					MessageBox.Show("Mystery Event was removed from non Japanesse Emerald.\n\tYou can still inject the data at your own risk.");
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
		void EventToolDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void EventToolDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_save(files[0]);
		}
		void Game_boxSelectedIndexChanged(object sender, EventArgs e)
		{
			sav3file.game = game_box.SelectedIndex;
			sav3file.updateOffsets();
			
			switch (game_box.SelectedIndex)
			{
				case 0: //RS
					jap_eon.Enabled = true;
					jap_aurora.Enabled = false;
					jap_mystic.Enabled = false;
					jap_old.Enabled = false;
					usa_eon_ecard.Enabled = true;
					usa_eon_italy.Enabled = true;
					usa_aurora.Enabled = false;
					usa_mystic.Enabled = false;
					eur_eon.Enabled = true;
					eur_aurora.Enabled = false;
					break;
				case 1: //E
					jap_eon.Enabled = true;
					jap_aurora.Enabled = false; //No aurora for japanesse?
					jap_mystic.Enabled = true;
					jap_old.Enabled = true;
					usa_eon_ecard.Enabled = false;
					usa_eon_italy.Enabled = false;
					usa_aurora.Enabled = true;
					usa_mystic.Enabled = true;
					eur_eon.Enabled = false;
					eur_aurora.Enabled = true;
					break;
				case 2: //FRLG
					jap_eon.Enabled = false;
					jap_aurora.Enabled = true;
					jap_mystic.Enabled = true;
					jap_old.Enabled = false;
					usa_eon_ecard.Enabled = false;
					usa_eon_italy.Enabled = false;
					usa_aurora.Enabled = true;
					usa_mystic.Enabled = false;
					eur_eon.Enabled = false;
					eur_aurora.Enabled = true;
					break;
			}
			//Uncheck all
			jap_eon.Checked = false;
			jap_aurora.Checked = false;
			jap_mystic.Checked = false;
			jap_old.Checked = false;
			usa_eon_ecard.Checked = false;
			usa_eon_italy.Checked = false;
			usa_aurora.Checked = false;
			usa_mystic.Checked = false;
			eur_eon.Checked = false;
			eur_aurora.Checked = false;
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
			
			sav3file.updateOffsets();
			
			switch (language_box.SelectedIndex)
			{
				case 0://JAP
					JAP_group.Enabled = true;
					USA_group.Enabled = false;
					EUR_group.Enabled = false;
					break;
				case 1://English
					JAP_group.Enabled = false;
					USA_group.Enabled = true;
					EUR_group.Enabled = false;
					break;
				case 2://French
					JAP_group.Enabled = false;
					USA_group.Enabled = false;
					EUR_group.Enabled = true;
					break;
				case 3://Italian
					JAP_group.Enabled = false;
					USA_group.Enabled = false;
					EUR_group.Enabled = true;
					break;
				case 4://German
					JAP_group.Enabled = false;
					USA_group.Enabled = false;
					EUR_group.Enabled = true;
					break;
				case 5://Korean
					JAP_group.Enabled = false;
					USA_group.Enabled = false;
					EUR_group.Enabled = false;
					break;
				case 6://Spanish
					JAP_group.Enabled = false;
					USA_group.Enabled = false;
					EUR_group.Enabled = true;
					break;
			}
			//Uncheck all
			jap_eon.Checked = false;
			jap_aurora.Checked = false;
			jap_mystic.Checked = false;
			jap_old.Checked = false;
			usa_eon_ecard.Checked = false;
			usa_eon_italy.Checked = false;
			usa_aurora.Checked = false;
			usa_mystic.Checked = false;
			eur_eon.Checked = false;
			eur_aurora.Checked = false;			
		}


		void Inject_savClick(object sender, EventArgs e)
		{
			switch (language_box.SelectedIndex)
			{
				case 0://JAP
					if (jap_eon.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("JAP_EON_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else if (game_box.SelectedIndex == 1) //E
							{
								sav3file.enable_eon_emerald();
								MessageBox.Show("Eon Ticket Mystery Event injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (jap_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("JAP_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					else if (jap_mystic.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("JAP_MYSTIC_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Mystic Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable Mystery Gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("JAP_MYSTIC_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Mystic Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable Mystery Gift in the savefile.");
							}

						}
					}
					else if (jap_old.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("JAP_OLDMAP_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Old Map Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable Mystery Gift in the savefile.");
							}

						}
					}
					break;
				case 1://English
					if (usa_eon_ecard.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("USA_EON_ECARD_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (usa_eon_italy.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("USA_EON_ITALY_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (usa_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("USA_AURORA_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("USA_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					else if (usa_mystic.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("USA_MYSTIC_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Mystic Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable Mystery Gift in the savefile.");
							}

						}/*
						else if (game_box.SelectedIndex == 2) //FRLG
						{

							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("USA_MYSTIC_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Mystic Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable Mystery Gift in the savefile.");
							}
						}*/

					}
					break;
				case 2://French
					if (eur_eon.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("FR_EON_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (eur_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("FR_AURORA_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("FR_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					break;
				case 3://Italian
					if (eur_eon.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("IT_EON_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (eur_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("IT_AURORA_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("IT_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					break;
				case 4://German
					if (eur_eon.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("DE_EON_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (eur_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("DE_AURORA_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("DE_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					break;
				case 5://Korean
					break;
				case 6://Spanish
					if (eur_eon.Checked == true)
					{
						if (sav3file.has_mystery_event == true)
						{
							if (game_box.SelectedIndex == 0) //RS
							{
								sav3file.set_ME3((byte[]) Tickets.GetObject("SP_EON_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Eon Ticket Mystery Event injected.\n\nGo see your father at Petalburg Gym.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
						}
						else
						{
							MessageBox.Show("Please enable Mystery Event in the savefile.");
						}
					}
					else if (eur_aurora.Checked == true)
					{
						if (game_box.SelectedIndex == 1) //E
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("SP_AURORA_E_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in blue at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
						else if (game_box.SelectedIndex == 2) //FRLG
						{
							if (sav3file.has_mystery_gift == true)
							{
								sav3file.set_WC3((byte[]) Tickets.GetObject("SP_AURORA_FRLG_FILE"));
								sav3file.update_section_chk(4);
								MessageBox.Show("Aurora Ticket Wondercard injected.\nGo see the man in green at pokemon's center 2nd floor.\nNote: if you saved in the 2nd floor of Pokémon Center, you'll have to exit and enter for the Blue man to appear.");
								FileIO.save_data(sav3file.Data, savfilter);
							}
							else
							{
								MessageBox.Show("Please enable mystery gift in the savefile.");
							}

						}
					}
					break;
			}
		}

	}
}
