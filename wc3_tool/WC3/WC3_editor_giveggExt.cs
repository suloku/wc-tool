/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 07/05/2016
 * Time: 21:27
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
	/// Description of WC3_editor_givegg.
	/// </summary>
	public partial class WC3_editor_giveggExt : Form
	{
		public WC3_editor_giveggExt()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			game_box.SelectedIndex = 0;
			lang_box.SelectedIndex = 1;
			species_box.SelectedIndex = 172;
			move_box.SelectedIndex = 0x39;
			move2.SelectedIndex = 0x39;
			move3.SelectedIndex = 0x39;
			move4.SelectedIndex = 0x39;
/*
ResourceManager resources = new ResourceManager("Namespace.ResourceFile", Assembly.GetExecutingAssembly());
byte[] fileData = (byte[])ResourceManager.GetObject("Test.dat");
Bitmap bitmap = (Bitmap)ResourceManager.GetObject("Image");
*/
			//byte[] fileData = (byte[]) EggScripts.GetObject("ROM"+game+"GiveEgg"+lang);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Save_butClick(object sender, EventArgs e)
		{
			string game;
			if (game_box.SelectedIndex == 1)
				game = "FR";
			else
				game = "E";
			
			string lang = "Eng";
			switch (lang_box.SelectedIndex)
			{
				case 0:
					lang = "Jap";
					break;
				case 1:
					lang = "Eng";
					break;
				case 2:
					lang = "Fre";
					break;
				case 3:
					lang = "Ita";
					break;
				case 4:
					lang = "Deu";
					break;
				case 5:
					lang = "Esp";
					break;
			}
			//MessageBox.Show("ROM_"+game+"_GiveEgg_"+lang);
			ResourceManager EggScripts = new ResourceManager("WC3_tool.WC3.GiveEggOrg", Assembly.GetExecutingAssembly());
			byte[] egg_script;
			
			if (killscript.Checked == true)
				egg_script =(byte[]) EggScripts.GetObject("ROM_"+game+"_GiveEgg_"+lang+"_4moves_kill");
			else
				egg_script = (byte[]) EggScripts.GetObject("ROM_"+game+"_GiveEgg_"+lang+"_4moves");
			
			UInt16 move;
			UInt16 move_2;
			UInt16 move_3;
			UInt16 move_4;
			
			int offset = 4;//Embedded scripts have a 4 byte padding
			if (killscript.Checked == true)
			{
				egg_script[0x5+offset] = 0x00; //Remove jumpram command, I should technically update the embedded script files instead of doing this...
				offset -= 0xF;//Killscript version is 0xF bytes shorter
			}
			move = (UInt16)move_box.SelectedIndex;
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0xB1+offset);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0xC7+offset);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0xDD+offset);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0xF3+offset);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x109+offset);
			
			offset+=5;
			move_2 = (UInt16)move2.SelectedIndex;
			BitConverter.GetBytes(move_2).ToArray().CopyTo(egg_script, 0xB1+offset);
			BitConverter.GetBytes(move_2).ToArray().CopyTo(egg_script, 0xC7+offset);
			BitConverter.GetBytes(move_2).ToArray().CopyTo(egg_script, 0xDD+offset);
			BitConverter.GetBytes(move_2).ToArray().CopyTo(egg_script, 0xF3+offset);
			BitConverter.GetBytes(move_2).ToArray().CopyTo(egg_script, 0x109+offset);
			
			offset+=5;
			move_3 = (UInt16)move3.SelectedIndex;
			BitConverter.GetBytes(move_3).ToArray().CopyTo(egg_script, 0xB1+offset);
			BitConverter.GetBytes(move_3).ToArray().CopyTo(egg_script, 0xC7+offset);
			BitConverter.GetBytes(move_3).ToArray().CopyTo(egg_script, 0xDD+offset);
			BitConverter.GetBytes(move_3).ToArray().CopyTo(egg_script, 0xF3+offset);
			BitConverter.GetBytes(move_3).ToArray().CopyTo(egg_script, 0x109+offset);
			
			offset+=5;
			move_4 = (UInt16)move4.SelectedIndex;
			BitConverter.GetBytes(move_4).ToArray().CopyTo(egg_script, 0xB1+offset);
			BitConverter.GetBytes(move_4).ToArray().CopyTo(egg_script, 0xC7+offset);
			BitConverter.GetBytes(move_4).ToArray().CopyTo(egg_script, 0xDD+offset);
			BitConverter.GetBytes(move_4).ToArray().CopyTo(egg_script, 0xF3+offset);
			BitConverter.GetBytes(move_4).ToArray().CopyTo(egg_script, 0x109+offset);

			UInt16 species;
			species = (UInt16)species_box.SelectedIndex;
			if (killscript.Checked == true)
				BitConverter.GetBytes(species).ToArray().CopyTo(egg_script, 0x5D+4);
			else
				BitConverter.GetBytes(species).ToArray().CopyTo(egg_script, 0x6C+4);
			
			//Because script files embedded have a 4 byte padding for XSE editing...and I'm lazy to strip those 4 bytes
			WC3_editor.wc3file.set_script(egg_script.Skip(4).Take(996).ToArray());
			WC3_editor.script_injected = true;
			
			this.Close();
		}
		void Cancel_butClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void Script_helpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Use rom event flag: the script will use the flag that the Egg event found in the ROM uses to mark the EGG as received. The wondercard will be able to be sent and the receiver will be able to receive an egg (if the savegame still has the flag unset).\n\nKillscript: no flags are set in the savegame, so the only outcome is that the egg is received. The script gets erased from the savegame, so sharing the wondercard won't allow receiver to get an egg.");
		}
	}
}
