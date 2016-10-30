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
	public partial class WC3_editor_givegg : Form
	{
		public WC3_editor_givegg()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			game_box.SelectedIndex = 0;
			lang_box.SelectedIndex = 1;
			species_box.SelectedIndex = 172;
			move_box.SelectedIndex = 0x39;			
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
			byte[] egg_script = (byte[]) EggScripts.GetObject("ROM_"+game+"_GiveEgg_"+lang);
			//byte[] egg_script = (byte[]) EggScripts.GetObject("ROM_FR_GiveEgg_Esp");
			
			UInt16 move;
			move = (UInt16)move_box.SelectedIndex;
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x86);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x8C);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x92);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x98);
			BitConverter.GetBytes(move).ToArray().CopyTo(egg_script, 0x9E);

			UInt16 species;
			species = (UInt16)species_box.SelectedIndex;
			BitConverter.GetBytes(species).ToArray().CopyTo(egg_script, 0x42);
			
			WC3_editor.wc3file.set_script(egg_script);
			WC3_editor.script_injected = true;
			
			this.Close();
		}
		void Cancel_butClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
