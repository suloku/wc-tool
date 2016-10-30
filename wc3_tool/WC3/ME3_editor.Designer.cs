/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 02/05/2016
 * Time: 23:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WC3_TOOL
{
	partial class ME3_editor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button load_me3_but;
		private System.Windows.Forms.Button save_me3_but;
		private System.Windows.Forms.TextBox me3_path;
		private System.Windows.Forms.Button export_script_but;
		private System.Windows.Forms.Button import_script_but;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox itembox;
		private System.Windows.Forms.NumericUpDown amountbox;
		private System.Windows.Forms.NumericUpDown counterbox;
		private System.Windows.Forms.CheckBox custom_script;
		private System.Windows.Forms.Button removescript_but;
		private System.Windows.Forms.CheckBox script_check;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radio_E;
		private System.Windows.Forms.RadioButton radio_RS;
		private System.Windows.Forms.NumericUpDown map_bank;
		private System.Windows.Forms.NumericUpDown map_num;
		private System.Windows.Forms.NumericUpDown map_npc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button help_npc;
		private System.Windows.Forms.Button counter_help;
		private System.Windows.Forms.Button amount_help;
		private System.Windows.Forms.Button item_help;
		private System.Windows.Forms.Button xse_help;
		private System.Windows.Forms.Button xse_import;
		private System.Windows.Forms.Button xse_export;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.load_me3_but = new System.Windows.Forms.Button();
			this.save_me3_but = new System.Windows.Forms.Button();
			this.me3_path = new System.Windows.Forms.TextBox();
			this.export_script_but = new System.Windows.Forms.Button();
			this.import_script_but = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.itembox = new System.Windows.Forms.ComboBox();
			this.amountbox = new System.Windows.Forms.NumericUpDown();
			this.counterbox = new System.Windows.Forms.NumericUpDown();
			this.custom_script = new System.Windows.Forms.CheckBox();
			this.script_check = new System.Windows.Forms.CheckBox();
			this.removescript_but = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radio_E = new System.Windows.Forms.RadioButton();
			this.radio_RS = new System.Windows.Forms.RadioButton();
			this.map_bank = new System.Windows.Forms.NumericUpDown();
			this.map_num = new System.Windows.Forms.NumericUpDown();
			this.map_npc = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.help_npc = new System.Windows.Forms.Button();
			this.counter_help = new System.Windows.Forms.Button();
			this.amount_help = new System.Windows.Forms.Button();
			this.item_help = new System.Windows.Forms.Button();
			this.xse_help = new System.Windows.Forms.Button();
			this.xse_import = new System.Windows.Forms.Button();
			this.xse_export = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.amountbox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.counterbox)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.map_bank)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.map_num)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.map_npc)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// load_me3_but
			// 
			this.load_me3_but.Location = new System.Drawing.Point(12, 12);
			this.load_me3_but.Name = "load_me3_but";
			this.load_me3_but.Size = new System.Drawing.Size(75, 23);
			this.load_me3_but.TabIndex = 0;
			this.load_me3_but.Text = "Load ME3";
			this.load_me3_but.UseVisualStyleBackColor = true;
			this.load_me3_but.Click += new System.EventHandler(this.Load_me3_butClick);
			// 
			// save_me3_but
			// 
			this.save_me3_but.Enabled = false;
			this.save_me3_but.Location = new System.Drawing.Point(93, 12);
			this.save_me3_but.Name = "save_me3_but";
			this.save_me3_but.Size = new System.Drawing.Size(75, 23);
			this.save_me3_but.TabIndex = 1;
			this.save_me3_but.Text = "Save ME3";
			this.save_me3_but.UseVisualStyleBackColor = true;
			this.save_me3_but.Click += new System.EventHandler(this.Save_me3_butClick);
			// 
			// me3_path
			// 
			this.me3_path.Location = new System.Drawing.Point(12, 41);
			this.me3_path.Name = "me3_path";
			this.me3_path.ReadOnly = true;
			this.me3_path.Size = new System.Drawing.Size(309, 20);
			this.me3_path.TabIndex = 2;
			// 
			// export_script_but
			// 
			this.export_script_but.Enabled = false;
			this.export_script_but.Location = new System.Drawing.Point(12, 213);
			this.export_script_but.Name = "export_script_but";
			this.export_script_but.Size = new System.Drawing.Size(75, 23);
			this.export_script_but.TabIndex = 3;
			this.export_script_but.Text = "Export Script";
			this.export_script_but.UseVisualStyleBackColor = true;
			this.export_script_but.Click += new System.EventHandler(this.Export_script_butClick);
			// 
			// import_script_but
			// 
			this.import_script_but.Enabled = false;
			this.import_script_but.Location = new System.Drawing.Point(93, 213);
			this.import_script_but.Name = "import_script_but";
			this.import_script_but.Size = new System.Drawing.Size(75, 23);
			this.import_script_but.TabIndex = 4;
			this.import_script_but.Text = "Import Script";
			this.import_script_but.UseVisualStyleBackColor = true;
			this.import_script_but.Click += new System.EventHandler(this.Import_script_butClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(26, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Item";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(26, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Total amount ?";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(26, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Distribution counter";
			// 
			// itembox
			// 
			this.itembox.FormattingEnabled = true;
			this.itembox.Items.AddRange(new object[] {
			"Nothing",
			"Master Ball",
			"Ultra Ball",
			"Great Ball",
			"Poké Ball",
			"Safari Ball",
			"Net Ball",
			"Dive Ball",
			"Nest Ball",
			"Repeat Ball",
			"Timer Ball",
			"Luxury Ball",
			"Premier Ball",
			"Potion",
			"Antidote",
			"Burn Heal",
			"Ice Heal",
			"Awakening",
			"Parlyz Heal",
			"Full Restore",
			"Max Potion",
			"Hyper Potion",
			"Super Potion",
			"Full Heal",
			"Revive",
			"Max Revive",
			"Fresh Water",
			"Soda Pop",
			"Lemonade",
			"Moomoo Milk",
			"EnergyPowder",
			"Energy Root",
			"Heal Powder",
			"Revival Herb",
			"Ether",
			"Max Ether",
			"Elixir",
			"Max Elixir",
			"Lava Cookie",
			"Blue Flute",
			"Yellow Flute",
			"Red Flute",
			"Black Flute",
			"White Flute",
			"Berry Juice",
			"Sacred Ash",
			"Shoal Salt",
			"Shoal Shell",
			"Red Shard",
			"Blue Shard",
			"Yellow Shard",
			"Green Shard",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"HP Up",
			"Protein",
			"Iron",
			"Carbos",
			"Calcium",
			"Rare Candy",
			"PP Up",
			"Zinc",
			"PP Max",
			"unknown",
			"Guard Spec.",
			"Dire Hit",
			"X Attack",
			"X Defend",
			"X Speed",
			"X Accuracy",
			"X Special",
			"Poké Doll",
			"Fluffy Tail",
			"unknown",
			"Super Repel",
			"Max Repel",
			"Escape Rope",
			"Repel",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"Sun Stone",
			"Moon Stone",
			"Fire Stone",
			"Thunder Stone",
			"Water Stone",
			"Leaf Stone",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"TinyMushroom",
			"Big Mushroom",
			"unknown",
			"Pearl",
			"Big Pearl",
			"Stardust",
			"Star Piece",
			"Nugget",
			"Heart Scale",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"Orange Mail",
			"Harbor Mail",
			"Glitter Mail",
			"Mech Mail",
			"Wood Mail",
			"Wave Mail",
			"Bead Mail",
			"Shadow Mail",
			"Tropic Mail",
			"Dream Mail",
			"Fab Mail",
			"Retro Mail",
			"Cheri Berry",
			"Chesto Berry",
			"Pecha Berry",
			"Rawst Berry",
			"Aspear Berry",
			"Leppa Berry",
			"Oran Berry",
			"Persim Berry",
			"Lum Berry",
			"Sitrus Berry",
			"Figy Berry",
			"Wiki Berry",
			"Mago Berry",
			"Aguav Berry",
			"Iapapa Berry",
			"Razz Berry",
			"Bluk Berry",
			"Nanab Berry",
			"Wepear Berry",
			"Pinap Berry",
			"Pomeg Berry",
			"Kelpsy Berry",
			"Qualot Berry",
			"Hondew Berry",
			"Grepa Berry",
			"Tamato Berry",
			"Cornn Berry",
			"Magost Berry",
			"Rabuta Berry",
			"Nomel Berry",
			"Spelon Berry",
			"Pamtre Berry",
			"Watmel Berry",
			"Durin Berry",
			"Belue Berry",
			"Liechi Berry",
			"Ganlon Berry",
			"Salac Berry",
			"Petaya Berry",
			"Apicot Berry",
			"Lansat Berry",
			"Starf Berry",
			"Enigma Berry",
			"unknown",
			"unknown",
			"unknown",
			"BrightPowder",
			"White Herb",
			"Macho Brace",
			"Exp. Share",
			"Quick Claw",
			"Soothe Bell",
			"Mental Herb",
			"Choice Band",
			"King\'s Rock",
			"SilverPowder",
			"Amulet Coin",
			"Cleanse Tag",
			"Soul Dew",
			"DeepSeaTooth",
			"DeepSeaScale",
			"Smoke Ball",
			"Everstone",
			"Focus Band",
			"Lucky Egg",
			"Scope Lens",
			"Metal Coat",
			"Leftovers",
			"Dragon Scale",
			"Light Ball",
			"Soft Sand",
			"Hard Stone",
			"Miracle Seed",
			"BlackGlasses",
			"Black Belt",
			"Magnet",
			"Mystic Water",
			"Sharp Beak",
			"Poison Barb",
			"NeverMeltIce",
			"Spell Tag",
			"TwistedSpoon",
			"Charcoal",
			"Dragon Fang",
			"Silk Scarf",
			"Up-Grade",
			"Shell Bell",
			"Sea Incense",
			"Lax Incense",
			"Lucky Punch",
			"Metal Powder",
			"Thick Club",
			"Stick",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"unknown",
			"Red Scarf",
			"Blue Scarf",
			"Pink Scarf",
			"Green Scarf",
			"Yellow Scarf",
			"Mach Bike",
			"Coin Case",
			"Itemfinder",
			"Old Rod",
			"Good Rod",
			"Super Rod",
			"S.S. Ticket",
			"Contest Pass",
			"unknown",
			"Wailmer Pail",
			"Devon Goods",
			"Soot Sack",
			"Basement Key",
			"Acro Bike",
			"Pokéblock Case",
			"Letter",
			"Eon Ticket",
			"Red Orb",
			"Blue Orb",
			"Scanner",
			"Go-Goggles",
			"Meteorite",
			"Rm. 1 Key",
			"Rm. 2 Key",
			"Rm. 4 Key",
			"Rm. 6 Key",
			"Storage Key",
			"Root Fossil",
			"Claw Fossil",
			"Devon Scope",
			"TM01",
			"TM02",
			"TM03",
			"TM04",
			"TM05",
			"TM06",
			"TM07",
			"TM08",
			"TM09",
			"TM10",
			"TM11",
			"TM12",
			"TM13",
			"TM14",
			"TM15",
			"TM16",
			"TM17",
			"TM18",
			"TM19",
			"TM20",
			"TM21",
			"TM22",
			"TM23",
			"TM24",
			"TM25",
			"TM26",
			"TM27",
			"TM28",
			"TM29",
			"TM30",
			"TM31",
			"TM32",
			"TM33",
			"TM34",
			"TM35",
			"TM36",
			"TM37",
			"TM38",
			"TM39",
			"TM40",
			"TM41",
			"TM42",
			"TM43",
			"TM44",
			"TM45",
			"TM46",
			"TM47",
			"TM48",
			"TM49",
			"TM50",
			"HM01",
			"HM02",
			"HM03",
			"HM04",
			"HM05",
			"HM06",
			"HM07",
			"HM08",
			"unknown",
			"unknown",
			"Oak\'s Parcel* (Emerald only)",
			"Poké Flute* (Emerald only)",
			"Secret Key* (Emerald only)",
			"Bike Voucher* (Emerald only)",
			"Gold Teeth* (Emerald only)",
			"Old Amber* (Emerald only)",
			"Card Key* (Emerald only)",
			"Lift Key* (Emerald only)",
			"Helix Fossil* (Emerald only)",
			"Dome Fossil* (Emerald only)",
			"Silph Scope* (Emerald only)",
			"Bicycle* (Emerald only)",
			"Town Map* (Emerald only)",
			"Vs. Seeker* (Emerald only)",
			"Fame Checker* (Emerald only)",
			"TM Case* (Emerald only)",
			"Berry Pouch* (Emerald only)",
			"Teachy TV* (Emerald only)",
			"Tri-Pass* (Emerald only)",
			"Rainbow Pass* (Emerald only)",
			"Tea* (Emerald only)",
			"MysticTicket* (Emerald only)",
			"AuroraTicket* (Emerald only)",
			"Powder Jar* (Emerald only)",
			"Ruby* (Emerald only)",
			"Sapphire* (Emerald only)",
			"Magma Emblem* (Emerald only)",
			"Old Sea Map* (Emerald only)"});
			this.itembox.Location = new System.Drawing.Point(132, 85);
			this.itembox.Name = "itembox";
			this.itembox.Size = new System.Drawing.Size(189, 21);
			this.itembox.TabIndex = 8;
			this.itembox.SelectedIndexChanged += new System.EventHandler(this.ItemboxSelectedIndexChanged);
			// 
			// amountbox
			// 
			this.amountbox.Location = new System.Drawing.Point(132, 112);
			this.amountbox.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.amountbox.Name = "amountbox";
			this.amountbox.Size = new System.Drawing.Size(189, 20);
			this.amountbox.TabIndex = 9;
			// 
			// counterbox
			// 
			this.counterbox.Location = new System.Drawing.Point(132, 138);
			this.counterbox.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.counterbox.Name = "counterbox";
			this.counterbox.Size = new System.Drawing.Size(189, 20);
			this.counterbox.TabIndex = 10;
			this.counterbox.ValueChanged += new System.EventHandler(this.CounterboxValueChanged);
			// 
			// custom_script
			// 
			this.custom_script.AutoCheck = false;
			this.custom_script.Location = new System.Drawing.Point(204, 213);
			this.custom_script.Name = "custom_script";
			this.custom_script.Size = new System.Drawing.Size(104, 24);
			this.custom_script.TabIndex = 11;
			this.custom_script.Text = "Custom Script";
			this.custom_script.UseVisualStyleBackColor = true;
			// 
			// script_check
			// 
			this.script_check.AutoCheck = false;
			this.script_check.Location = new System.Drawing.Point(204, 183);
			this.script_check.Name = "script_check";
			this.script_check.Size = new System.Drawing.Size(104, 24);
			this.script_check.TabIndex = 12;
			this.script_check.Text = "Script present";
			this.script_check.UseVisualStyleBackColor = true;
			// 
			// removescript_but
			// 
			this.removescript_but.Enabled = false;
			this.removescript_but.Location = new System.Drawing.Point(33, 184);
			this.removescript_but.Name = "removescript_but";
			this.removescript_but.Size = new System.Drawing.Size(114, 23);
			this.removescript_but.TabIndex = 13;
			this.removescript_but.Text = "Remove script";
			this.removescript_but.UseVisualStyleBackColor = true;
			this.removescript_but.Click += new System.EventHandler(this.Removescript_butClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radio_E);
			this.groupBox1.Controls.Add(this.radio_RS);
			this.groupBox1.Location = new System.Drawing.Point(20, 271);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(127, 93);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Game";
			// 
			// radio_E
			// 
			this.radio_E.Location = new System.Drawing.Point(6, 54);
			this.radio_E.Name = "radio_E";
			this.radio_E.Size = new System.Drawing.Size(104, 24);
			this.radio_E.TabIndex = 1;
			this.radio_E.TabStop = true;
			this.radio_E.Text = "Emerald";
			this.radio_E.UseVisualStyleBackColor = true;
			// 
			// radio_RS
			// 
			this.radio_RS.Location = new System.Drawing.Point(6, 24);
			this.radio_RS.Name = "radio_RS";
			this.radio_RS.Size = new System.Drawing.Size(104, 24);
			this.radio_RS.TabIndex = 0;
			this.radio_RS.TabStop = true;
			this.radio_RS.Text = "Ruby / Sapphire";
			this.radio_RS.UseVisualStyleBackColor = true;
			// 
			// map_bank
			// 
			this.map_bank.Location = new System.Drawing.Point(82, 14);
			this.map_bank.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_bank.Name = "map_bank";
			this.map_bank.Size = new System.Drawing.Size(71, 20);
			this.map_bank.TabIndex = 15;
			// 
			// map_num
			// 
			this.map_num.Location = new System.Drawing.Point(82, 40);
			this.map_num.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_num.Name = "map_num";
			this.map_num.Size = new System.Drawing.Size(71, 20);
			this.map_num.TabIndex = 16;
			// 
			// map_npc
			// 
			this.map_npc.Location = new System.Drawing.Point(82, 66);
			this.map_npc.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_npc.Name = "map_npc";
			this.map_npc.Size = new System.Drawing.Size(71, 20);
			this.map_npc.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 18);
			this.label4.TabIndex = 18;
			this.label4.Text = "Map Bank";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 42);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 23);
			this.label5.TabIndex = 19;
			this.label5.Text = "Map #";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 23);
			this.label6.TabIndex = 20;
			this.label6.Text = "Map NPC";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.map_bank);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.map_num);
			this.groupBox2.Controls.Add(this.map_npc);
			this.groupBox2.Location = new System.Drawing.Point(155, 271);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(166, 93);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Script NPC";
			// 
			// help_npc
			// 
			this.help_npc.Location = new System.Drawing.Point(327, 283);
			this.help_npc.Name = "help_npc";
			this.help_npc.Size = new System.Drawing.Size(17, 21);
			this.help_npc.TabIndex = 22;
			this.help_npc.Text = "?";
			this.help_npc.UseVisualStyleBackColor = true;
			this.help_npc.Click += new System.EventHandler(this.Help_npcClick);
			// 
			// counter_help
			// 
			this.counter_help.Location = new System.Drawing.Point(327, 136);
			this.counter_help.Name = "counter_help";
			this.counter_help.Size = new System.Drawing.Size(17, 21);
			this.counter_help.TabIndex = 23;
			this.counter_help.Text = "?";
			this.counter_help.UseVisualStyleBackColor = true;
			this.counter_help.Click += new System.EventHandler(this.Counter_helpClick);
			// 
			// amount_help
			// 
			this.amount_help.Location = new System.Drawing.Point(327, 110);
			this.amount_help.Name = "amount_help";
			this.amount_help.Size = new System.Drawing.Size(17, 21);
			this.amount_help.TabIndex = 24;
			this.amount_help.Text = "?";
			this.amount_help.UseVisualStyleBackColor = true;
			this.amount_help.Click += new System.EventHandler(this.Amount_helpClick);
			// 
			// item_help
			// 
			this.item_help.Location = new System.Drawing.Point(327, 84);
			this.item_help.Name = "item_help";
			this.item_help.Size = new System.Drawing.Size(17, 21);
			this.item_help.TabIndex = 25;
			this.item_help.Text = "?";
			this.item_help.UseVisualStyleBackColor = true;
			this.item_help.Click += new System.EventHandler(this.Item_helpClick);
			// 
			// xse_help
			// 
			this.xse_help.Location = new System.Drawing.Point(174, 244);
			this.xse_help.Name = "xse_help";
			this.xse_help.Size = new System.Drawing.Size(21, 22);
			this.xse_help.TabIndex = 35;
			this.xse_help.Text = "?";
			this.xse_help.UseVisualStyleBackColor = true;
			this.xse_help.Click += new System.EventHandler(this.Xse_helpClick);
			// 
			// xse_import
			// 
			this.xse_import.Location = new System.Drawing.Point(93, 242);
			this.xse_import.Name = "xse_import";
			this.xse_import.Size = new System.Drawing.Size(75, 23);
			this.xse_import.TabIndex = 37;
			this.xse_import.Text = "XSE Import";
			this.xse_import.UseVisualStyleBackColor = true;
			this.xse_import.Click += new System.EventHandler(this.Xse_importClick);
			// 
			// xse_export
			// 
			this.xse_export.Location = new System.Drawing.Point(12, 242);
			this.xse_export.Name = "xse_export";
			this.xse_export.Size = new System.Drawing.Size(75, 23);
			this.xse_export.TabIndex = 36;
			this.xse_export.Text = "XSE Export";
			this.xse_export.UseVisualStyleBackColor = true;
			this.xse_export.Click += new System.EventHandler(this.Xse_exportClick);
			// 
			// ME3_editor
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 371);
			this.Controls.Add(this.xse_help);
			this.Controls.Add(this.xse_import);
			this.Controls.Add(this.xse_export);
			this.Controls.Add(this.item_help);
			this.Controls.Add(this.amount_help);
			this.Controls.Add(this.counter_help);
			this.Controls.Add(this.help_npc);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.removescript_but);
			this.Controls.Add(this.script_check);
			this.Controls.Add(this.custom_script);
			this.Controls.Add(this.counterbox);
			this.Controls.Add(this.amountbox);
			this.Controls.Add(this.itembox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.import_script_but);
			this.Controls.Add(this.export_script_but);
			this.Controls.Add(this.me3_path);
			this.Controls.Add(this.save_me3_but);
			this.Controls.Add(this.load_me3_but);
			this.Name = "ME3_editor";
			this.Text = "ME3 Editor";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ME3_editorDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ME3_editorDragEnter);
			((System.ComponentModel.ISupportInitialize)(this.amountbox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.counterbox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.map_bank)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.map_num)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.map_npc)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
