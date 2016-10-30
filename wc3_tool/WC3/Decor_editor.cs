/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 03/05/2016
 * Time: 17:34
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
	/// Description of Decor_editor.
	/// </summary>
	public partial class Decor_editor : Form
	{
		byte[] decorbuff;
		SAV3 sav3file;
		public string savfilter = MainScreen.savfilter;
		
		public Decor_editor(SAV3 save)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			sav3file = save;
			decorbuff = sav3file.get_decorations();
			
			decortypebox.SelectedIndex = 0;
			numericUpDown1.Maximum = slots_max[decortypebox.SelectedIndex];
			decorationbox.SelectedIndex = 0;
			
			load_decor();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void del_item()
		{
			int i;
			int offset = 0;
			for (i=0; i<decortypebox.SelectedIndex; i++)
			{
				offset = offset + slots_max[i];
			}
			decorbuff[offset + (int)numericUpDown1.Value - 1] = 0x00;
		}
		
		void set_item(int newitem)
		{
			int i;
			int offset = 0;
			for (i=0; i<decortypebox.SelectedIndex; i++)
			{
				offset = offset + slots_max[i];
			}
			int[] reference = desk_ref;
			switch(decortypebox.SelectedIndex)
			{
				case 0:
					reference = desk_ref;
					break;
				case 1:
					reference = chair_ref;
					break;
				case 2:
					reference = plant_ref;
					break;
				case 3:
					reference = ornament_ref;
					break;
				case 4:
					reference = mat_ref;
					break;
				case 5:
					reference = poster_ref;
					break;
				case 6:
					reference = doll_ref;
					break;
				case 7:
					reference = cushion_ref;
					break;
			}
			decorbuff[offset + (int)numericUpDown1.Value - 1] = (byte)reference[newitem];
		}
		
		byte get_item(int modifier)
		{
			int item_index = (int)numericUpDown1.Value-1;
			if (item_index + modifier < 0)
				modifier = 0;

			int i;
			int offset = 0;
			for (i=0; i<decortypebox.SelectedIndex; i++)
			{
				offset = offset + slots_max[i];
			}
			byte item = decorbuff[offset + item_index + modifier];
			return item;
		}
		void load_decor()
		{
			int i;
			byte item = get_item(0);
			//MessageBox.Show(item.ToString());
			
			int[] reference = desk_ref;
			switch(decortypebox.SelectedIndex)
			{
				case 0:
					reference = desk_ref;
					break;
				case 1:
					reference = chair_ref;
					break;
				case 2:
					reference = plant_ref;
					break;
				case 3:
					reference = ornament_ref;
					break;
				case 4:
					reference = mat_ref;
					break;
				case 5:
					reference = poster_ref;
					break;
				case 6:
					reference = doll_ref;
					break;
				case 7:
					reference = cushion_ref;
					break;
			}
			for (i = 0; i<reference.Length; i++)
			{
				//MessageBox.Show(reference[i].ToString());
				if(item==reference[i]){
					decorationbox.SelectedIndex = i + 1;
					break;
				}else
					decorationbox.SelectedIndex = 0;
			}
		}
		int[] desk_ref = {1,2,3,4,5,6,7,8,9};
		int[] chair_ref = {10,11,12,13,14,15,16,17,18};
		int[] plant_ref = {19,20,21,22,23,24};
		int[] ornament_ref = {25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47};
		int[] mat_ref = {48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65};
		int[] poster_ref = {66,67,68,69,70,71,72,73,74,75};
		int[] doll_ref = {76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,111,112,113,114,115,116,117,118,119,120};
		int[] cushion_ref = {101,102,103,104,105,106,107,108,109,110};
		
		int[] slots_max = {10,10,10,30,30,10,40,10};
		object[] Desks = new object[] {
			"Empty",
			"Small Desk",
			"Pokémon Desk",
			"Heavy Desk",
			"Ragged Desk",
			"Comfort Desk",
			"Pretty Desk",
			"Brick Desk",
			"Camp Desk",
			"Hard Desk"};
		object[] Chairs = new object[] {
			"Empty",
			"Small Chair",
			"Pokémon Chair",
			"Heavy Chair",
			"Pretty Chair",
			"Comfort Chair",
			"Ragged Chair",
			"Brick Chair",
			"Camp Chair",
			"Hard Chair"};
		object[] Plants = new object[] {
			"Empty",
			"Red Plant",
			"Tropical Plant",
			"Pretty Flowers",
			"Colorful Plant",
			"Big Plant",
			"Gorgeous Plant"};
		object[] Ornament = new object[] {
			"Empty",
			"Red Brick",
			"Yellow Brick",
			"Blue Brick",
			"Red Balloon",
			"Blue Balloon",
			"Yellow Balloon",
			"Red Tent",
			"Blue Tent",
			"Solid Board",
			"Slide",
			"Fence Length",
			"Fence Width",
			"Tire",
			"Stand",
			"Mud Ball",
			"Breakable Door",
			"Sand Ornament",
			"Silver Shield",
			"Gold Shield",
			"Glass Ornament",
			"TV",
			"Round TV",
			"Cute TV"};
		object[] Mats = new object[] {
			"Empty",
			"Glitter Mat",
			"Jump Mat",
			"Spin Mat",
			"C Low Note Mat",
			"D Note Mat",
			"E Note Mat",
			"F Note Mat",
			"G Note Mat",
			"A Note Mat",
			"B Note Mat",
			"C High Note Mat",
			"Surf Mat",
			"Thunder Mat",
			"Fire Blast Mat",
			"Powder Snow Mat",
			"Attract Mat",
			"Fissure Mat",
			"Spikes Mat"};
		object[] Posters = new object[] {
			"Empty",
			"Ball Poster",
			"Green Poster",
			"Red Poster",
			"Blue Poster",
			"Cute Poster",
			"Pika Poster",
			"Long Poster",
			"Sea Poster",
			"Sky Poster",
			"Kiss Poster"};
		object[] Dolls = new object[] {
			"Empty",
			"Pichu Doll",
			"Pikachu Doll",
			"Marill Doll",
			"Togepi Doll",
			"Cyndaquil Doll",
			"Chikorita Doll",
			"Totodile Doll",
			"Jigglypuff Doll",
			"Meowth Doll",
			"Clefairy Doll",
			"Ditto Doll",
			"Smoochum Doll",
			"Treecko Doll",
			"Torchic Doll",
			"Mudkip Doll",
			"Duskull Doll",
			"Wynaut Doll",
			"Baltoy Doll",
			"Kecleon Doll",
			"Azurill Doll",
			"Skitty Doll",
			"Swablu Doll",
			"Gulpin Doll",
			"Lotad Doll",
			"Seedot Doll",
			"Snorlax Doll",
			"Rhydon Doll",
			"Lapras Doll",
			"Venusaur Doll",
			"Charizard Doll",
			"Blastoise Doll",
			"Wailmer Doll",
			"Regirock Doll",
			"Regice Doll",
			"Registeel Doll"};
		object[] Cushions = new object[] {
			"Empty",
			"Pika Cushion",
			"Round Cushion",
			"Kiss Cushion",
			"Zigzag Cushion",
			"Spin Cushion",
			"Diamond Cushion",
			"Ball Cushion",
			"Grass Cushion",
			"Fire Cushion",
			"Water Cushion"};
		
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			if (get_item(-1) == 0x00) // There was already an empty slot, don't advance
			{
				if (numericUpDown1.Value - 1 < numericUpDown1.Minimum)
					numericUpDown1.Value = numericUpDown1.Minimum;
				else
					numericUpDown1.Value = numericUpDown1.Value-1;
			}else{

				load_decor();
			}
				
		}
		void DecortypeboxSelectedIndexChanged(object sender, EventArgs e)
		{
			numericUpDown1.Value = 1;
			numericUpDown1.Maximum = slots_max[decortypebox.SelectedIndex];
			decorationbox.Items.Clear();
			switch(decortypebox.SelectedIndex)
			{
				case 0:
					decorationbox.Items.AddRange(Desks);
					break;
				case 1:
					decorationbox.Items.AddRange(Chairs);
					break;
				case 2:
					decorationbox.Items.AddRange(Plants);
					break;
				case 3:
					decorationbox.Items.AddRange(Ornament);
					break;
				case 4:
					decorationbox.Items.AddRange(Mats);
					break;
				case 5:
					decorationbox.Items.AddRange(Posters);
					break;
				case 6:
					decorationbox.Items.AddRange(Dolls);
					break;
				case 7:
					decorationbox.Items.AddRange(Cushions);
					break;
			}
			numericUpDown1.Value = 1;
			numericUpDown1.Maximum = slots_max[decortypebox.SelectedIndex];
			decorationbox.SelectedIndex = 0;
			load_decor();

		}
		void Save_butClick(object sender, EventArgs e)
		{
			sav3file.set_decoration(decorbuff);
			sav3file.update_section_chk(3);
			FileIO.save_data(sav3file.Data, savfilter);
		}
		void DecorationboxSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		void Add_butClick(object sender, EventArgs e)
		{
			if (decorationbox.SelectedIndex != 0)
				set_item(decorationbox.SelectedIndex-1);
		}
		void Del_butClick(object sender, EventArgs e)
		{
			if (numericUpDown1.Value != numericUpDown1.Maximum && get_item(+1) != 0x00)
				MessageBox.Show("Please delete only last occupied slot.");
			else{
				del_item();
				load_decor();
			}
		}
	}
}
