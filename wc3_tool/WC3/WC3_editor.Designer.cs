/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 28/04/2016
 * Time: 21:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WC3_TOOL
{
	partial class WC3_editor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button load_wc3_but;
		private System.Windows.Forms.Button save_wc3_but;
		private System.Windows.Forms.TextBox wc3_path;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox header1;
		private System.Windows.Forms.TextBox header2;
		private System.Windows.Forms.TextBox body1;
		private System.Windows.Forms.TextBox body2;
		private System.Windows.Forms.TextBox body3;
		private System.Windows.Forms.TextBox body4;
		private System.Windows.Forms.TextBox footer1;
		private System.Windows.Forms.TextBox footer2;
		private System.Windows.Forms.Button export_script_but;
		private System.Windows.Forms.Button import_script_but;
		private System.Windows.Forms.CheckBox custom_script;
		private System.Windows.Forms.ComboBox iconbox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox colorbox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown icon_num;
		private System.Windows.Forms.RadioButton distro_but_always;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton distro_but_one;
		private System.Windows.Forms.RadioButton distro_but_no;
		private System.Windows.Forms.Label regionlab;
		private System.Windows.Forms.Button giveEgg_but;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown map_npc;
		private System.Windows.Forms.NumericUpDown map_map;
		private System.Windows.Forms.NumericUpDown map_bank;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button map_help;
		private System.Windows.Forms.Button xse_import;
		private System.Windows.Forms.Button xse_export;
		private System.Windows.Forms.Button xse_help;
		private System.Windows.Forms.Button giveEggExt_but;
		private System.Windows.Forms.CheckBox faketoogle;
		
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
			this.load_wc3_but = new System.Windows.Forms.Button();
			this.save_wc3_but = new System.Windows.Forms.Button();
			this.wc3_path = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.header1 = new System.Windows.Forms.TextBox();
			this.header2 = new System.Windows.Forms.TextBox();
			this.body1 = new System.Windows.Forms.TextBox();
			this.body2 = new System.Windows.Forms.TextBox();
			this.body3 = new System.Windows.Forms.TextBox();
			this.body4 = new System.Windows.Forms.TextBox();
			this.footer1 = new System.Windows.Forms.TextBox();
			this.footer2 = new System.Windows.Forms.TextBox();
			this.export_script_but = new System.Windows.Forms.Button();
			this.import_script_but = new System.Windows.Forms.Button();
			this.custom_script = new System.Windows.Forms.CheckBox();
			this.iconbox = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.colorbox = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.icon_num = new System.Windows.Forms.NumericUpDown();
			this.distro_but_always = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.distro_but_no = new System.Windows.Forms.RadioButton();
			this.distro_but_one = new System.Windows.Forms.RadioButton();
			this.regionlab = new System.Windows.Forms.Label();
			this.giveEgg_but = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.map_help = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.map_npc = new System.Windows.Forms.NumericUpDown();
			this.map_map = new System.Windows.Forms.NumericUpDown();
			this.map_bank = new System.Windows.Forms.NumericUpDown();
			this.xse_import = new System.Windows.Forms.Button();
			this.xse_export = new System.Windows.Forms.Button();
			this.xse_help = new System.Windows.Forms.Button();
			this.giveEggExt_but = new System.Windows.Forms.Button();
			this.faketoogle = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.icon_num)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.map_npc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.map_map)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.map_bank)).BeginInit();
			this.SuspendLayout();
			// 
			// load_wc3_but
			// 
			this.load_wc3_but.Location = new System.Drawing.Point(49, 11);
			this.load_wc3_but.Name = "load_wc3_but";
			this.load_wc3_but.Size = new System.Drawing.Size(75, 23);
			this.load_wc3_but.TabIndex = 0;
			this.load_wc3_but.Text = "Load WC3";
			this.load_wc3_but.UseVisualStyleBackColor = true;
			this.load_wc3_but.Click += new System.EventHandler(this.Load_wc3_butClick);
			// 
			// save_wc3_but
			// 
			this.save_wc3_but.Enabled = false;
			this.save_wc3_but.Location = new System.Drawing.Point(130, 11);
			this.save_wc3_but.Name = "save_wc3_but";
			this.save_wc3_but.Size = new System.Drawing.Size(75, 23);
			this.save_wc3_but.TabIndex = 1;
			this.save_wc3_but.Text = "Save WC3";
			this.save_wc3_but.UseVisualStyleBackColor = true;
			this.save_wc3_but.Click += new System.EventHandler(this.Save_wc3_butClick);
			// 
			// wc3_path
			// 
			this.wc3_path.Location = new System.Drawing.Point(221, 13);
			this.wc3_path.Name = "wc3_path";
			this.wc3_path.ReadOnly = true;
			this.wc3_path.Size = new System.Drawing.Size(522, 20);
			this.wc3_path.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(46, 117);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Header 1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(46, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Header 2";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(46, 163);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Body 1";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(46, 186);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Body 2";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(46, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Body 3";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(46, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Body 4";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(46, 255);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "Footer 1";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(46, 278);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 10;
			this.label8.Text = "Footer 2";
			// 
			// header1
			// 
			this.header1.Location = new System.Drawing.Point(114, 114);
			this.header1.MaxLength = 40;
			this.header1.Name = "header1";
			this.header1.Size = new System.Drawing.Size(379, 20);
			this.header1.TabIndex = 11;
			this.header1.TextChanged += new System.EventHandler(this.Header1TextChanged);
			// 
			// header2
			// 
			this.header2.Location = new System.Drawing.Point(114, 137);
			this.header2.MaxLength = 40;
			this.header2.Name = "header2";
			this.header2.Size = new System.Drawing.Size(379, 20);
			this.header2.TabIndex = 12;
			this.header2.TextChanged += new System.EventHandler(this.Header2TextChanged);
			// 
			// body1
			// 
			this.body1.Location = new System.Drawing.Point(114, 160);
			this.body1.MaxLength = 40;
			this.body1.Name = "body1";
			this.body1.Size = new System.Drawing.Size(379, 20);
			this.body1.TabIndex = 13;
			this.body1.TextChanged += new System.EventHandler(this.Body1TextChanged);
			// 
			// body2
			// 
			this.body2.Location = new System.Drawing.Point(114, 183);
			this.body2.MaxLength = 40;
			this.body2.Name = "body2";
			this.body2.Size = new System.Drawing.Size(379, 20);
			this.body2.TabIndex = 14;
			this.body2.TextChanged += new System.EventHandler(this.Body2TextChanged);
			// 
			// body3
			// 
			this.body3.Location = new System.Drawing.Point(114, 206);
			this.body3.MaxLength = 40;
			this.body3.Name = "body3";
			this.body3.Size = new System.Drawing.Size(379, 20);
			this.body3.TabIndex = 15;
			this.body3.TextChanged += new System.EventHandler(this.Body3TextChanged);
			// 
			// body4
			// 
			this.body4.Location = new System.Drawing.Point(114, 229);
			this.body4.MaxLength = 40;
			this.body4.Name = "body4";
			this.body4.Size = new System.Drawing.Size(379, 20);
			this.body4.TabIndex = 16;
			this.body4.TextChanged += new System.EventHandler(this.Body4TextChanged);
			// 
			// footer1
			// 
			this.footer1.Location = new System.Drawing.Point(114, 252);
			this.footer1.MaxLength = 40;
			this.footer1.Name = "footer1";
			this.footer1.Size = new System.Drawing.Size(379, 20);
			this.footer1.TabIndex = 17;
			this.footer1.TextChanged += new System.EventHandler(this.Footer1TextChanged);
			// 
			// footer2
			// 
			this.footer2.Location = new System.Drawing.Point(114, 275);
			this.footer2.MaxLength = 40;
			this.footer2.Name = "footer2";
			this.footer2.Size = new System.Drawing.Size(379, 20);
			this.footer2.TabIndex = 18;
			this.footer2.TextChanged += new System.EventHandler(this.Footer2TextChanged);
			// 
			// export_script_but
			// 
			this.export_script_but.Enabled = false;
			this.export_script_but.Location = new System.Drawing.Point(49, 304);
			this.export_script_but.Name = "export_script_but";
			this.export_script_but.Size = new System.Drawing.Size(75, 23);
			this.export_script_but.TabIndex = 19;
			this.export_script_but.Text = "Export Script";
			this.export_script_but.UseVisualStyleBackColor = true;
			this.export_script_but.Click += new System.EventHandler(this.Export_script_butClick);
			// 
			// import_script_but
			// 
			this.import_script_but.Enabled = false;
			this.import_script_but.Location = new System.Drawing.Point(130, 304);
			this.import_script_but.Name = "import_script_but";
			this.import_script_but.Size = new System.Drawing.Size(75, 23);
			this.import_script_but.TabIndex = 20;
			this.import_script_but.Text = "Import Script";
			this.import_script_but.UseVisualStyleBackColor = true;
			this.import_script_but.Click += new System.EventHandler(this.Import_script_butClick);
			// 
			// custom_script
			// 
			this.custom_script.AutoCheck = false;
			this.custom_script.Location = new System.Drawing.Point(215, 304);
			this.custom_script.Name = "custom_script";
			this.custom_script.Size = new System.Drawing.Size(137, 24);
			this.custom_script.TabIndex = 21;
			this.custom_script.Text = "Custom script loaded";
			this.custom_script.UseVisualStyleBackColor = true;
			// 
			// iconbox
			// 
			this.iconbox.FormattingEnabled = true;
			this.iconbox.Items.AddRange(new object[] {
			"????????",
			"Bulbasaur",
			"Ivysaur",
			"Venusaur",
			"Charmander",
			"Charmeleon",
			"Charizard",
			"Squirtle",
			"Wartortle",
			"Blastoise",
			"Caterpie",
			"Metapod",
			"Butterfree",
			"Weedle",
			"Kakuna",
			"Beedrill",
			"Pidgey",
			"Pidgeotto",
			"Pidgeot",
			"Rattata",
			"Raticate",
			"Spearow",
			"Fearow",
			"Ekans",
			"Arbok",
			"Pikachu",
			"Raichu",
			"Sandshrew",
			"Sandslash",
			"Nidoran♀",
			"Nidorina",
			"Nidoqueen",
			"Nidoran♂",
			"Nidorino",
			"Nidoking",
			"Clefairy",
			"Clefable",
			"Vulpix",
			"Ninetales",
			"Jigglypuff",
			"Wigglytuff",
			"Zubat",
			"Golbat",
			"Oddish",
			"Gloom",
			"Vileplume",
			"Paras",
			"Parasect",
			"Venonat",
			"Venomoth",
			"Diglett",
			"Dugtrio",
			"Meowth",
			"Persian",
			"Psyduck",
			"Golduck",
			"Mankey",
			"Primeape",
			"Growlithe",
			"Arcanine",
			"Poliwag",
			"Poliwhirl",
			"Poliwrath",
			"Abra",
			"Kadabra",
			"Alakazam",
			"Machop",
			"Machoke",
			"Machamp",
			"Bellsprout",
			"Weepinbell",
			"Victreebel",
			"Tentacool",
			"Tentacruel",
			"Geodude",
			"Graveler",
			"Golem",
			"Ponyta",
			"Rapidash",
			"Slowpoke",
			"Slowbro",
			"Magnemite",
			"Magneton",
			"Farfetch\'d",
			"Doduo",
			"Dodrio",
			"Seel",
			"Dewgong",
			"Grimer",
			"Muk",
			"Shellder",
			"Cloyster",
			"Gastly",
			"Haunter",
			"Gengar",
			"Onix",
			"Drowzee",
			"Hypno",
			"Krabby",
			"Kingler",
			"Voltorb",
			"Electrode",
			"Exeggcute",
			"Exeggutor",
			"Cubone",
			"Marowak",
			"Hitmonlee",
			"Hitmonchan",
			"Lickitung",
			"Koffing",
			"Weezing",
			"Rhyhorn",
			"Rhydon",
			"Chansey",
			"Tangela",
			"Kangaskhan",
			"Horsea",
			"Seadra",
			"Goldeen",
			"Seaking",
			"Staryu",
			"Starmie",
			"Mr. Mime",
			"Scyther",
			"Jynx",
			"Electabuzz",
			"Magmar",
			"Pinsir",
			"Tauros",
			"Magikarp",
			"Gyarados",
			"Lapras",
			"Ditto",
			"Eevee",
			"Vaporeon",
			"Jolteon",
			"Flareon",
			"Porygon",
			"Omanyte",
			"Omastar",
			"Kabuto",
			"Kabutops",
			"Aerodactyl",
			"Snorlax",
			"Articuno",
			"Zapdos",
			"Moltres",
			"Dratini",
			"Dragonair",
			"Dragonite",
			"Mewtwo",
			"Mew",
			"Chikorita",
			"Bayleef",
			"Meganium",
			"Cyndaquil",
			"Quilava",
			"Typhlosion",
			"Totodile",
			"Croconaw",
			"Feraligatr",
			"Sentret",
			"Furret",
			"Hoothoot",
			"Noctowl",
			"Ledyba",
			"Ledian",
			"Spinarak",
			"Ariados",
			"Crobat",
			"Chinchou",
			"Lanturn",
			"Pichu",
			"Cleffa",
			"Igglybuff",
			"Togepi",
			"Togetic",
			"Natu",
			"Xatu",
			"Mareep",
			"Flaaffy",
			"Ampharos",
			"Bellossom",
			"Marill",
			"Azumarill",
			"Sudowoodo",
			"Politoed",
			"Hoppip",
			"Skiploom",
			"Jumpluff",
			"Aipom",
			"Sunkern",
			"Sunflora",
			"Yanma",
			"Wooper",
			"Quagsire",
			"Espeon",
			"Umbreon",
			"Murkrow",
			"Slowking",
			"Misdreavus",
			"Unown A",
			"Wobbuffet",
			"Girafarig",
			"Pineco",
			"Forretress",
			"Dunsparce",
			"Gligar",
			"Steelix",
			"Snubbull",
			"Granbull",
			"Qwilfish",
			"Scizor",
			"Shuckle",
			"Heracross",
			"Sneasel",
			"Teddiursa",
			"Ursaring",
			"Slugma",
			"Magcargo",
			"Swinub",
			"Piloswine",
			"Corsola",
			"Remoraid",
			"Octillery",
			"Delibird",
			"Mantine",
			"Skarmory",
			"Houndour",
			"Houndoom",
			"Kingdra",
			"Phanpy",
			"Donphan",
			"Porygon2",
			"Stantler",
			"Smeargle",
			"Tyrogue",
			"Hitmontop",
			"Smoochum",
			"Elekid",
			"Magby",
			"Miltank",
			"Blissey",
			"Raikou",
			"Entei",
			"Suicune",
			"Larvitar",
			"Pupitar",
			"Tyranitar",
			"Lugia",
			"Ho-oh",
			"Celebi",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"? (glitch Pokémon)",
			"Treecko",
			"Grovyle",
			"Sceptile",
			"Torchic",
			"Combusken",
			"Blaziken",
			"Mudkip",
			"Marshtomp",
			"Swampert",
			"Poochyena",
			"Mightyena",
			"Zigzagoon",
			"Linoone",
			"Wurmple",
			"Silcoon",
			"Beautifly",
			"Cascoon",
			"Dustox",
			"Lotad",
			"Lombre",
			"Ludicolo",
			"Seedot",
			"Nuzleaf",
			"Shiftry",
			"Nincada",
			"Ninjask",
			"Shedinja",
			"Taillow",
			"Swellow",
			"Shroomish",
			"Breloom",
			"Spinda",
			"Wingull",
			"Pelipper",
			"Surskit",
			"Masquerain",
			"Wailmer",
			"Wailord",
			"Skitty",
			"Delcatty",
			"Kecleon",
			"Baltoy",
			"Claydol",
			"Nosepass",
			"Torkoal",
			"Sableye",
			"Barboach",
			"Whiscash",
			"Luvdisc",
			"Corphish",
			"Crawdaunt",
			"Feebas",
			"Milotic",
			"Carvanha",
			"Sharpedo",
			"Trapinch",
			"Vibrava",
			"Flygon",
			"Makuhita",
			"Hariyama",
			"Electrike",
			"Manectric",
			"Numel",
			"Camerupt",
			"Spheal",
			"Sealeo",
			"Walrein",
			"Cacnea",
			"Cacturne",
			"Snorunt",
			"Glalie",
			"Lunatone",
			"Solrock",
			"Azurill",
			"Spoink",
			"Grumpig",
			"Plusle",
			"Minun",
			"Mawile",
			"Meditite",
			"Medicham",
			"Swablu",
			"Altaria",
			"Wynaut",
			"Duskull",
			"Dusclops",
			"Roselia",
			"Slakoth",
			"Vigoroth",
			"Slaking",
			"Gulpin",
			"Swalot",
			"Tropius",
			"Whismur",
			"Loudred",
			"Exploud",
			"Clamperl",
			"Huntail",
			"Gorebyss",
			"Absol",
			"Shuppet",
			"Banette",
			"Seviper",
			"Zangoose",
			"Relicanth",
			"Aron",
			"Lairon",
			"Aggron",
			"Castform",
			"Volbeat",
			"Illumise",
			"Lileep",
			"Cradily",
			"Anorith",
			"Armaldo",
			"Ralts",
			"Kirlia",
			"Gardevoir",
			"Bagon",
			"Shelgon",
			"Salamence",
			"Beldum",
			"Metang",
			"Metagross",
			"Regirock",
			"Regice",
			"Registeel",
			"Kyogre",
			"Groudon",
			"Rayquaza",
			"Latias",
			"Latios",
			"Jirachi",
			"Deoxys",
			"Chimecho",
			"Pokémon Egg",
			"Unown B",
			"Unown C",
			"Unown D",
			"Unown E",
			"Unown F",
			"Unown G",
			"Unown H",
			"Unown I",
			"Unown J",
			"Unown K",
			"Unown L",
			"Unown M",
			"Unown N",
			"Unown O",
			"Unown P",
			"Unown Q",
			"Unown R",
			"Unown S",
			"Unown T",
			"Unown U",
			"Unown V",
			"Unown W",
			"Unown X",
			"Unown Y",
			"Unown Z",
			"Unown !",
			"Unown ?",
			"SET WITH INDEX  --->"});
			this.iconbox.Location = new System.Drawing.Point(115, 85);
			this.iconbox.Name = "iconbox";
			this.iconbox.Size = new System.Drawing.Size(243, 21);
			this.iconbox.TabIndex = 23;
			this.iconbox.SelectedIndexChanged += new System.EventHandler(this.IconboxSelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(46, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(33, 14);
			this.label9.TabIndex = 24;
			this.label9.Text = "Icon";
			// 
			// colorbox
			// 
			this.colorbox.FormattingEnabled = true;
			this.colorbox.Items.AddRange(new object[] {
			"Dark Yellow with square patterns (0x00)",
			"Dark Blue/Green with square patterns (0x04)",
			"Red with line patterns (0x08)",
			"Green with line patterns (0x0c)",
			"Blue with line patterns (0x10)",
			"Yellow with line patterns (0x14)",
			"Yellow with pokeball patterns (0x18)",
			"Grey with pokeball patterns (0x1c)"});
			this.colorbox.Location = new System.Drawing.Point(115, 58);
			this.colorbox.Name = "colorbox";
			this.colorbox.Size = new System.Drawing.Size(243, 21);
			this.colorbox.TabIndex = 25;
			this.colorbox.SelectedIndexChanged += new System.EventHandler(this.ColorboxSelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(46, 60);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 19);
			this.label10.TabIndex = 26;
			this.label10.Text = "Color";
			// 
			// icon_num
			// 
			this.icon_num.Location = new System.Drawing.Point(373, 86);
			this.icon_num.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.icon_num.Name = "icon_num";
			this.icon_num.Size = new System.Drawing.Size(120, 20);
			this.icon_num.TabIndex = 27;
			this.icon_num.ValueChanged += new System.EventHandler(this.Icon_numValueChanged);
			// 
			// distro_but_always
			// 
			this.distro_but_always.Location = new System.Drawing.Point(6, 19);
			this.distro_but_always.Name = "distro_but_always";
			this.distro_but_always.Size = new System.Drawing.Size(141, 24);
			this.distro_but_always.TabIndex = 28;
			this.distro_but_always.TabStop = true;
			this.distro_but_always.Text = "Always";
			this.distro_but_always.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.distro_but_no);
			this.groupBox1.Controls.Add(this.distro_but_one);
			this.groupBox1.Controls.Add(this.distro_but_always);
			this.groupBox1.Location = new System.Drawing.Point(499, 39);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(154, 95);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Distributable";
			// 
			// distro_but_no
			// 
			this.distro_but_no.Location = new System.Drawing.Point(6, 65);
			this.distro_but_no.Name = "distro_but_no";
			this.distro_but_no.Size = new System.Drawing.Size(141, 24);
			this.distro_but_no.TabIndex = 30;
			this.distro_but_no.TabStop = true;
			this.distro_but_no.Text = "No";
			this.distro_but_no.UseVisualStyleBackColor = true;
			// 
			// distro_but_one
			// 
			this.distro_but_one.Location = new System.Drawing.Point(6, 42);
			this.distro_but_one.Name = "distro_but_one";
			this.distro_but_one.Size = new System.Drawing.Size(141, 24);
			this.distro_but_one.TabIndex = 29;
			this.distro_but_one.TabStop = true;
			this.distro_but_one.Text = "Receiver can\'t distribute";
			this.distro_but_one.UseVisualStyleBackColor = true;
			// 
			// regionlab
			// 
			this.regionlab.Location = new System.Drawing.Point(373, 60);
			this.regionlab.Name = "regionlab";
			this.regionlab.Size = new System.Drawing.Size(100, 23);
			this.regionlab.TabIndex = 30;
			this.regionlab.Text = "USA/EUR";
			// 
			// giveEgg_but
			// 
			this.giveEgg_but.Location = new System.Drawing.Point(49, 371);
			this.giveEgg_but.Name = "giveEgg_but";
			this.giveEgg_but.Size = new System.Drawing.Size(135, 23);
			this.giveEgg_but.TabIndex = 31;
			this.giveEgg_but.Text = "Inject Give Egg Script";
			this.giveEgg_but.UseVisualStyleBackColor = true;
			this.giveEgg_but.Click += new System.EventHandler(this.GiveEgg_butClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.map_help);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.map_npc);
			this.groupBox2.Controls.Add(this.map_map);
			this.groupBox2.Controls.Add(this.map_bank);
			this.groupBox2.Location = new System.Drawing.Point(342, 304);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(203, 113);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Script Association";
			// 
			// map_help
			// 
			this.map_help.Location = new System.Drawing.Point(174, 11);
			this.map_help.Name = "map_help";
			this.map_help.Size = new System.Drawing.Size(21, 22);
			this.map_help.TabIndex = 7;
			this.map_help.Text = "?";
			this.map_help.UseVisualStyleBackColor = true;
			this.map_help.Click += new System.EventHandler(this.Map_helpClick);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(125, 31);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 72);
			this.label14.TabIndex = 6;
			this.label14.Text = "All 255 for Pokémon Center deliveryman";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(17, 83);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(36, 23);
			this.label13.TabIndex = 5;
			this.label13.Text = "NPC:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 57);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(36, 23);
			this.label12.TabIndex = 4;
			this.label12.Text = "Map:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(17, 31);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(36, 18);
			this.label11.TabIndex = 3;
			this.label11.Text = "Bank:";
			// 
			// map_npc
			// 
			this.map_npc.Location = new System.Drawing.Point(59, 81);
			this.map_npc.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_npc.Name = "map_npc";
			this.map_npc.Size = new System.Drawing.Size(60, 20);
			this.map_npc.TabIndex = 2;
			// 
			// map_map
			// 
			this.map_map.Location = new System.Drawing.Point(59, 55);
			this.map_map.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_map.Name = "map_map";
			this.map_map.Size = new System.Drawing.Size(60, 20);
			this.map_map.TabIndex = 1;
			// 
			// map_bank
			// 
			this.map_bank.Location = new System.Drawing.Point(59, 29);
			this.map_bank.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.map_bank.Name = "map_bank";
			this.map_bank.Size = new System.Drawing.Size(60, 20);
			this.map_bank.TabIndex = 0;
			// 
			// xse_import
			// 
			this.xse_import.Enabled = false;
			this.xse_import.Location = new System.Drawing.Point(130, 333);
			this.xse_import.Name = "xse_import";
			this.xse_import.Size = new System.Drawing.Size(75, 23);
			this.xse_import.TabIndex = 34;
			this.xse_import.Text = "XSE Import";
			this.xse_import.UseVisualStyleBackColor = true;
			this.xse_import.Click += new System.EventHandler(this.Xse_importClick);
			// 
			// xse_export
			// 
			this.xse_export.Enabled = false;
			this.xse_export.Location = new System.Drawing.Point(49, 333);
			this.xse_export.Name = "xse_export";
			this.xse_export.Size = new System.Drawing.Size(75, 23);
			this.xse_export.TabIndex = 33;
			this.xse_export.Text = "XSE Export";
			this.xse_export.UseVisualStyleBackColor = true;
			this.xse_export.Click += new System.EventHandler(this.Xse_exportClick);
			// 
			// xse_help
			// 
			this.xse_help.Location = new System.Drawing.Point(211, 335);
			this.xse_help.Name = "xse_help";
			this.xse_help.Size = new System.Drawing.Size(21, 22);
			this.xse_help.TabIndex = 8;
			this.xse_help.Text = "?";
			this.xse_help.UseVisualStyleBackColor = true;
			this.xse_help.Click += new System.EventHandler(this.Xse_helpClick);
			// 
			// giveEggExt_but
			// 
			this.giveEggExt_but.Location = new System.Drawing.Point(49, 400);
			this.giveEggExt_but.Name = "giveEggExt_but";
			this.giveEggExt_but.Size = new System.Drawing.Size(135, 35);
			this.giveEggExt_but.TabIndex = 35;
			this.giveEggExt_but.Text = "Inject Give Egg Script (Extended version)";
			this.giveEggExt_but.UseVisualStyleBackColor = true;
			this.giveEggExt_but.Click += new System.EventHandler(this.GiveEggExt_butClick);
			// 
			// faketoogle
			// 
			this.faketoogle.Location = new System.Drawing.Point(130, 38);
			this.faketoogle.Name = "faketoogle";
			this.faketoogle.Size = new System.Drawing.Size(126, 17);
			this.faketoogle.TabIndex = 36;
			this.faketoogle.Text = "Fake saved WC ID";
			this.faketoogle.UseVisualStyleBackColor = true;
			this.faketoogle.Visible = false;
			// 
			// WC3_editor
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 448);
			this.Controls.Add(this.faketoogle);
			this.Controls.Add(this.giveEggExt_but);
			this.Controls.Add(this.xse_help);
			this.Controls.Add(this.xse_import);
			this.Controls.Add(this.xse_export);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.giveEgg_but);
			this.Controls.Add(this.regionlab);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.icon_num);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.colorbox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.iconbox);
			this.Controls.Add(this.custom_script);
			this.Controls.Add(this.import_script_but);
			this.Controls.Add(this.export_script_but);
			this.Controls.Add(this.footer2);
			this.Controls.Add(this.footer1);
			this.Controls.Add(this.body4);
			this.Controls.Add(this.body3);
			this.Controls.Add(this.body2);
			this.Controls.Add(this.body1);
			this.Controls.Add(this.header2);
			this.Controls.Add(this.header1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.wc3_path);
			this.Controls.Add(this.save_wc3_but);
			this.Controls.Add(this.load_wc3_but);
			this.Name = "WC3_editor";
			this.Text = "WC3 Editor";
			this.Load += new System.EventHandler(this.WC3_editorLoad);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WC3_editorDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WC3_editorDragEnter);
			((System.ComponentModel.ISupportInitialize)(this.icon_num)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.map_npc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.map_map)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.map_bank)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
