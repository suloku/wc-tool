/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 02/05/2016
 * Time: 23:40
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
	/// Description of ME3_editor.
	/// </summary>
	public partial class ME3_editor : Form
	{
		public ME3_editor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string me3filter = "Mistery Event file|*.me3|All Files (*.*)|*.*";
		public string scriptfilter = "Script file|*.script|All Files (*.*)|*.*";
		public string xsescriptfilter = "XSE padded script file|*.gba";
		public byte[] me3buffer;
		public byte[] me3script_new;
		public static ME3 me3file;
		
		//private int me3size;
		
		void get_me3data()
		{
			amountbox.Value = me3file.get_item_amount();
			counterbox.Value = me3file.get_item_counter();
			itembox.SelectedIndex = me3file.get_item();
			
			if(me3file.isemerald == 0)//These items aren't in emerald
			{
				if (itembox.SelectedIndex > 348)
					itembox.SelectedIndex = 348;
			}else{
				if (itembox.SelectedIndex > 376)
					itembox.SelectedIndex = 376;
			}
			
			map_bank.Value =  me3file.MAP_BANK;
			map_num.Value = me3file.MAP_MAP;
			map_npc.Value = me3file.MAP_PERSON;
			
		}
		
		void set_me3data()
		{
			me3file.set_item( (UInt16)itembox.SelectedIndex);
			me3file.set_item_amount( (byte) amountbox.Value);
			me3file.set_item_counter( (byte) counterbox.Value);
			
			me3file.MAP_BANK = (byte)map_bank.Value;
			me3file.MAP_MAP = (byte)map_num.Value;
			me3file.MAP_PERSON = (byte)map_npc.Value;
			
			if (radio_E.Checked == true)
				me3file.isemerald = 1;
			else if (radio_RS.Checked == true)
				me3file.isemerald = 0;
		}
		
		void Load_me3(string path)
		{
			int filesize = FileIO.load_file(ref me3buffer, ref path, me3filter);
			if( filesize == SAV3.ME3_SIZE_E || filesize == SAV3.ME3_SIZE_RS )
			{	
				
				radio_RS.Checked = false;
				radio_E.Checked = false;
				
				me3_path.Text = path;
				me3file = new ME3(me3buffer, filesize);
				
				switch (me3file.isemerald)
				{
					case 0:
						radio_RS.Checked = true;
						break;
					case 1:
						radio_E.Checked = true;
						break;
				}
						
				get_me3data();
				
				save_me3_but.Enabled = true;
				removescript_but.Enabled = true;
				export_script_but.Enabled = true;
				import_script_but.Enabled = true;
				custom_script.Checked = false;
				script_check.Checked = true;
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		
		void Load_me3_butClick(object sender, EventArgs e)
		{
			Load_me3(null);

		}
		void ItemboxSelectedIndexChanged(object sender, EventArgs e)
		{
			if(me3file.isemerald == 0)//These items aren't in RS
			{
				if (itembox.SelectedIndex > 348){
					itembox.SelectedIndex = 348;
					MessageBox.Show("Selected item is not available in Ruby/Sapphire.");
				}
			}else{
				if (itembox.SelectedIndex > 376)
					itembox.SelectedIndex = 376;
			}
		}
		void Save_me3_butClick(object sender, EventArgs e)
		{
			set_me3data();
			me3file.fix_me_script_checksum();
			me3file.fix_me_item_checksum();

			if (me3file.Edited)
				FileIO.save_data(me3file.Data, me3filter);
			else MessageBox.Show("Save has not been edited");
		}
		void Export_script_butClick(object sender, EventArgs e)
		{
			FileIO.save_data(me3file.get_script(), scriptfilter);
		}
		void Import_script_butClick(object sender, EventArgs e)
		{
			string path = null;
			int filesize = FileIO.load_file(ref me3script_new, ref path, scriptfilter);
			if( filesize <= 996 )
			{				
				me3file.set_script(me3script_new);
				custom_script.Checked = true;
				script_check.Checked = me3file.has_script();
				MessageBox.Show("Custom script imported.");
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		void CounterboxValueChanged(object sender, EventArgs e)
		{
			//Not sure about this anymore
			/*if (counterbox.Value > amountbox.Value)
			{
				MessageBox.Show("Counter can't be bigger than total amount");
				counterbox.Value = amountbox.Value;
			}*/
		}
		void Removescript_butClick(object sender, EventArgs e)
		{
			me3file.removeScript();
			script_check.Checked = me3file.has_script();
		}
		void Help_npcClick(object sender, EventArgs e)
		{
			MessageBox.Show("These values are used to associate the script to a NPC character in the game.\n\nYou can use Advance Map to locate the values for all NPC in the game.\n\nFather at petalburg Gym is Bank 08, Map 01, NPC 01.");
		}
		void Counter_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Every time you mix records, this number decreases by 1, even if the item isn't transfered due to the other person already having it.");
		}
		void Amount_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Should always be 1? Changing it has no apparent effect.");
		}
		void Item_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("The item will only be transfered via record mixing if receiver doesn't own the item.");
		}
		void Xse_exportClick(object sender, EventArgs e)
		{
			FileIO.save_data(me3file.get_script_XSE(), xsescriptfilter);
		}
		void Xse_importClick(object sender, EventArgs e)
		{
			string path = null;
			int filesize = FileIO.load_file(ref me3script_new, ref path, xsescriptfilter);
			if( filesize <= 1000 )
			{				
				me3file.set_script_XSE(me3script_new);
				custom_script.Checked = true;
				MessageBox.Show("Custom script imported.");
				
			}else{
				MessageBox.Show("Invalid file size.");
			}
		}
		void Xse_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("XSE Export: exports the script with padding corresponding to base address of the script and *.gba extension. You can directly load (and edit) the script in XSE, script offset will be shown when using the export button.\nXSE Import: imports a *.gba script generated by this tool after editing (or not) with XSE (importing anything else will not correctly work).\n\nThese options are just for convenience, the scripts are in no way gba roms, but it's the more convenient way to edit them in XSE.");
		}
		
		void ME3_editorDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		void ME3_editorDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			Load_me3(files[0]);
		}
	}
}
