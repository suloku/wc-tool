/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 09/05/2016
 * Time: 0:59
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

namespace WC3_TOOL
{
	/// <summary>
	/// Description of ECB_editor.
	/// </summary>
	public partial class ECB_editor : Form
	{
		public ECB_editor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			hap200.Minimum = -127;
			hap100.Minimum = -127;
			happ0.Minimum = -127;
			tr6_val.Minimum = 0;
			tr6_val.Maximum = 255;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public string berryfilter = "e-card Berry file|*.ecb|All Files (*.*)|*.*";
		public string berry_sp_filter = "All Files (*.*)|*.*";
		public byte[] ecbbuffer;
		public byte[] spritebuf;
		public byte[] paletebuf;
		public static ECB ecbfile;
		
		void Load_ECB(string path)
		{
			int filesize = FileIO.load_file(ref ecbbuffer, ref path, berryfilter);
			if( filesize == ECB.SIZE_ECB )
			{				
				ecb_path.Text = path;
				ecbfile = new ECB(ecbbuffer);
				
				update_ecbData();
				
				save_ecb_but.Enabled = true;
				palette_export_but.Enabled = true;
				palette_import_but.Enabled = true;
				sprite_export_but.Enabled = true;
				sprite_import_but.Enabled = true;
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		
		void Load_ecb_butClick(object sender, EventArgs e)
		{
			Load_ECB(null);
		}
		void Save_ecb_butClick(object sender, EventArgs e)
		{
			set_ecbData();
			ecbfile.fix_berry_checksum();
			//if (ecbfile.Edited)
				FileIO.save_data(ecbfile.Data, berryfilter);
			//else MessageBox.Show("Save has not been edited");
		}
		void update_ecbData()
		{
			name.Text = ecbfile.NAME;
			firm_box.SelectedIndex = ecbfile.FIRMNESS-1;
			size.Value = ecbfile.SIZE;
			yield_max.Value = ecbfile.YIELD_MAX;
			yield_min.Value = ecbfile.YIELD_MIN;
			growth.Value = ecbfile.GROWTH;
			spicy.Value = ecbfile.SPICY;
			dry.Value = ecbfile.DRY;
			sweet.Value = ecbfile.SWEET;
			bitter.Value = ecbfile.BITTER;
			sour.Value = ecbfile.SOUR;
			smooth.Value = ecbfile.SMOOTH;
			
			desc1.Text = ecbfile.DESC_1;
			desc2.Text = ecbfile.DESC_2;
			
			held.Value = ecbfile.HITEM;
			
			heal_burn.Checked = ecbfile.TR_3_clearBurn;
			heal_confu.Checked = ecbfile.TR_3_clearConf;
			heal_ice.Checked = ecbfile.TR_3_clearIce;
			heal_inf.Checked = ecbfile.TR_0_healinfatuation;
			heal_para.Checked = ecbfile.TR_3_clearPar;
			heal_poison.Checked = ecbfile.TR_3_clearPoison;
			heal_sleep.Checked = ecbfile.TR_3_clearSleep;
			
			guard.Checked = ecbfile.TR_3_guardspec;
			lvlup.Checked = ecbfile.TR_3_lvlUP;
			
			firstpoke.Checked = ecbfile.TR_0_firstpkm;
			
			direhit.Value = ecbfile.TR_0_direhit;
			atkup.Value = ecbfile.TR_0_attackUP;
			defup.Value = ecbfile.TR_1_defUP;
			speedup.Value = ecbfile.TR_1_speedUP;
			spatkup.Value = ecbfile.TR_2_espUP;
			accurup.Value = ecbfile.TR_2_accUP;
			
			ev_hp.Checked = ecbfile.TR_4_hpEVUP;
			ev_atk.Checked = ecbfile.TR_4_atkEVUP;
			ev_def.Checked = ecbfile.TR_5_defEVUP;
			ev_speed.Checked = ecbfile.TR_5_spEVUP;
			ev_speatk.Checked = ecbfile.TR_5_spatkEVUP;
			ev_spedef.Checked = ecbfile.TR_5_spdefEVUP;
			
			if (ecbfile.HPRecovery != 0)
				tr6_val.Value = ecbfile.HPRecovery;
			else if (ecbfile.PPRecovery != 0)
				tr6_val.Value = ecbfile.PPRecovery;
			else if (ecbfile.EVchange != 0)
				tr6_val.Value = ecbfile.EVchange;
			//else if (ecbfile.HPRecovery == 0 && ecbfile.EVchange == 0 && ecbfile.PPRecovery == 0)
			//	tr6_val.Enabled = false;
			
			heal_hp.Checked = ecbfile.TR_4_healHP;
			heal_pp.Checked = ecbfile.TR_4_healPP;
			selectedatk.Checked = ecbfile.TR_4_onlyatack;
			maxppUP.Checked = ecbfile.TR_4_maxPPUP;
			revive.Checked = ecbfile.TR_4_revive;
			stone.Checked = ecbfile.TR_4_stone;
			ppup.Checked = ecbfile.TR_5_ppMax;
			
			happy200.Checked = ecbfile.TR_5_happy200;
			happy100.Checked = ecbfile.TR_5_happy100;
			happy0.Checked = ecbfile.TR_5_happy0;
			
			if (happy200.Checked == true)
				hap200.Value = ecbfile.Happy200;
			else
				hap200.Value = 0;
			if (happy100.Checked == true)
				hap100.Value = ecbfile.Happy100;
			else
				hap100.Value = 0;
			if (happy0.Checked == true)
				happ0.Value = ecbfile.Happy0;
			else
				happ0.Value = 0;			
			
		}
		
		void set_ecbData()
		{
			ecbfile.NAME = name.Text;
			ecbfile.FIRMNESS = (byte)(firm_box.SelectedIndex+1);
			ecbfile.SIZE = (UInt16) size.Value;
			ecbfile.YIELD_MAX = (byte)yield_max.Value;
			ecbfile.YIELD_MIN = (byte)yield_min.Value;
			ecbfile.GROWTH = (byte)growth.Value;
			ecbfile.SPICY = (byte)spicy.Value;
			ecbfile.DRY = (byte)dry.Value;
			ecbfile.SWEET = (byte)sweet.Value;
			ecbfile.BITTER = (byte)bitter.Value;
			ecbfile.SOUR = (byte)sour.Value;
			ecbfile.SMOOTH = (byte)smooth.Value;
			
			ecbfile.DESC_1 = desc1.Text;
			ecbfile.DESC_2 = desc2.Text;
			
			ecbfile.HITEM = (byte) held.Value;
			
			ecbfile.TR_3_clearBurn = heal_burn.Checked;
			ecbfile.TR_3_clearConf = heal_confu.Checked ;
			ecbfile.TR_3_clearIce = heal_ice.Checked;
			ecbfile.TR_0_healinfatuation = heal_inf.Checked;
			ecbfile.TR_3_clearPar = heal_para.Checked;
			ecbfile.TR_3_clearPoison = heal_poison.Checked;
			ecbfile.TR_3_clearSleep = heal_sleep.Checked;
			
			ecbfile.TR_3_guardspec = guard.Checked;
			ecbfile.TR_3_lvlUP = lvlup.Checked;
			
			ecbfile.TR_0_firstpkm = firstpoke.Checked;
			
			ecbfile.TR_0_direhit = (int)direhit.Value;
			ecbfile.TR_0_attackUP = (int)atkup.Value;
			ecbfile.TR_1_defUP = (int)defup.Value;
			ecbfile.TR_1_speedUP = (int)speedup.Value;
			ecbfile.TR_2_espUP = (int)spatkup.Value;
			ecbfile.TR_2_accUP = (int)accurup.Value;
			
			ecbfile.TR_4_hpEVUP = ev_hp.Checked;
			ecbfile.TR_4_atkEVUP = ev_atk.Checked;
			ecbfile.TR_5_defEVUP = ev_def.Checked;
			ecbfile.TR_5_spEVUP = ev_speed.Checked;
			ecbfile.TR_5_spatkEVUP = ev_speatk.Checked;
			ecbfile.TR_5_spdefEVUP = ev_spedef.Checked;
			
			ecbfile.TR_4_healHP = heal_hp.Checked;
			ecbfile.TR_4_healPP = heal_pp.Checked;
			ecbfile.TR_4_onlyatack = selectedatk.Checked;
			ecbfile.TR_4_maxPPUP = maxppUP.Checked;
			ecbfile.TR_4_revive = revive.Checked;
			ecbfile.TR_4_stone = stone.Checked;
			ecbfile.TR_5_ppMax = ppup.Checked;
			
			//Only put the first value found
			if (heal_hp.Checked == true)
				ecbfile.HPRecovery = (byte)tr6_val.Value;
			else if (heal_pp.Checked == true)
				ecbfile.PPRecovery = (byte)tr6_val.Value;
			else if (ev_hp.Checked == true || ev_atk.Checked == true || ev_def.Checked == true || ev_speed.Checked == true || ev_speatk.Checked == true || ev_spedef.Checked == true)
				ecbfile.EVchange = (sbyte)tr6_val.Value;			
			
			ecbfile.TR_5_happy200 = happy200.Checked;
			ecbfile.TR_5_happy100 = happy100.Checked;
			ecbfile.TR_5_happy0 = happy0.Checked;
			
			ecbfile.Happy200 = (sbyte)hap200.Value;
			ecbfile.Happy100 = (sbyte)hap100.Value;
			ecbfile.Happy0 = (sbyte)happ0.Value;	
		}
		void Held_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Known values:\n00: No effect\n04: Cures poison (Drash Berry)\n05: Cures burn (Japanese Yago Berry)\n06: Cures freeze (Pumkin Berry)\n08: Cures confusion (Japanese Touga Berry)\n23: Restores a lowered stat (Japanese Ginema Berry)\n28: Cures infatuation (Eggant Berry)");
		}
		void Sprite_export_butClick(object sender, EventArgs e)
		{
			FileIO.save_data(ecbfile.get_full_sprite(), berry_sp_filter);
		}
		void Sprite_import_butClick(object sender, EventArgs e)
		{
				string path = null;
				int filesize = FileIO.load_file(ref spritebuf, ref path, berry_sp_filter);
				if( filesize == ECB.SIZE_SPRITE+ECB.SIZE_PALETTE)
				{				
					ecbfile.set_full_sprite(spritebuf);
					MessageBox.Show("Berry sprite injected.");
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
		}
		void Palette_import_butClick(object sender, EventArgs e)
		{
				string path = null;
				int filesize = FileIO.load_file(ref paletebuf, ref path, berry_sp_filter);
				if( filesize == ECB.SIZE_PALETTE)
				{				
					ecbfile.set_palette(paletebuf);
					MessageBox.Show("Berry palette injected.");
					
				}else if (filesize == -1){
					;
				}else{
					MessageBox.Show("Invalid file size.");
				}
		}
		void Palette_export_butClick(object sender, EventArgs e)
		{
			FileIO.save_data(ecbfile.get_palette(), berry_sp_filter);
		}
		void Sprite_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("To edit the berry sprite you may use \"Nameless Sprite Editor (NSE) 2.1 beta\".\nSave the berry sprite as \".gba\" file and open in NSE with \"Load ROM\" option, then click navigate and input this values:\n\tImage offset: 20\n\tPalette ofsset: 0\n\tWidth: 6\n\tHeight: 6\n\nThen click open and edit the sprite. To save it simply use file->save or control+S (palette can be edited too, use the palette editor's save button to save it).\n\nTo inject the berry sprite you can simply import the modified berry \".gba\" file");
		}
		void Jap_encodingCheckedChanged(object sender, EventArgs e)
		{
			ecbfile.isjap = jap_encoding.Checked;
			name.Text = ecbfile.NAME;
			desc1.Text = ecbfile.DESC_1;
			desc2.Text = ecbfile.DESC_2;
		}
		void PphelpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Healing HP and PP are mutually exclusive, you cannot heal PP and HP at the same time. HP takes precedence over PP if both are set. ");
		}
		void Modifier_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("PP restoring items have a maximum of 127.\nFor health restoration, 255 means max health, 254 means half max health, 253 is used by rare candy (only increase with level up).\nFor EV items, 0-127 increases EV, 128-255 decreases EV (128 is -1, 255 is -127).");
		}
		void NoteClick(object sender, EventArgs e)
		{
			MessageBox.Show("Keep in mind that there are incompatibilities between flags. For example you can't make an HP restoring berry that also levels up a pokémon and expect it to be usable in battle, since a level up item can only be used from the bag.");
		}
		
		void ECB_editorDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void ECB_editorDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_ECB(files[0]);
		}	
	}
}
