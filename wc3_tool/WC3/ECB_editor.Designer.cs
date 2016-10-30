/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 09/05/2016
 * Time: 0:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WC3_TOOL
{
	partial class ECB_editor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button load_ecb_but;
		private System.Windows.Forms.Button save_ecb_but;
		private System.Windows.Forms.TextBox ecb_path;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.ComboBox firm_box;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown size;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown yield_max;
		private System.Windows.Forms.NumericUpDown yield_min;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown growth;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown spicy;
		private System.Windows.Forms.NumericUpDown dry;
		private System.Windows.Forms.NumericUpDown sweet;
		private System.Windows.Forms.NumericUpDown bitter;
		private System.Windows.Forms.NumericUpDown sour;
		private System.Windows.Forms.NumericUpDown smooth;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox desc1;
		private System.Windows.Forms.TextBox desc2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown held;
		private System.Windows.Forms.Button held_help;
		private System.Windows.Forms.Button sprite_export_but;
		private System.Windows.Forms.Button sprite_import_but;
		private System.Windows.Forms.Button palette_export_but;
		private System.Windows.Forms.Button palette_import_but;
		private System.Windows.Forms.Button sprite_help;
		private System.Windows.Forms.CheckBox jap_encoding;
		private System.Windows.Forms.CheckBox heal_inf;
		private System.Windows.Forms.CheckBox heal_sleep;
		private System.Windows.Forms.CheckBox heal_poison;
		private System.Windows.Forms.CheckBox heal_burn;
		private System.Windows.Forms.CheckBox heal_ice;
		private System.Windows.Forms.CheckBox heal_para;
		private System.Windows.Forms.CheckBox heal_confu;
		private System.Windows.Forms.CheckBox guard;
		private System.Windows.Forms.CheckBox lvlup;
		private System.Windows.Forms.CheckBox firstpoke;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.NumericUpDown direhit;
		private System.Windows.Forms.NumericUpDown atkup;
		private System.Windows.Forms.NumericUpDown defup;
		private System.Windows.Forms.NumericUpDown speedup;
		private System.Windows.Forms.NumericUpDown spatkup;
		private System.Windows.Forms.NumericUpDown accurup;
		private System.Windows.Forms.CheckBox ev_hp;
		private System.Windows.Forms.CheckBox ev_atk;
		private System.Windows.Forms.CheckBox ev_def;
		private System.Windows.Forms.CheckBox ev_speed;
		private System.Windows.Forms.CheckBox ev_speatk;
		private System.Windows.Forms.CheckBox ev_spedef;
		private System.Windows.Forms.NumericUpDown tr6_val;
		private System.Windows.Forms.CheckBox heal_hp;
		private System.Windows.Forms.CheckBox heal_pp;
		private System.Windows.Forms.CheckBox selectedatk;
		private System.Windows.Forms.CheckBox maxppUP;
		private System.Windows.Forms.CheckBox revive;
		private System.Windows.Forms.CheckBox stone;
		private System.Windows.Forms.CheckBox happy200;
		private System.Windows.Forms.CheckBox happy100;
		private System.Windows.Forms.CheckBox happy0;
		private System.Windows.Forms.NumericUpDown hap200;
		private System.Windows.Forms.NumericUpDown hap100;
		private System.Windows.Forms.NumericUpDown happ0;
		private System.Windows.Forms.CheckBox ppup;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button pphelp;
		private System.Windows.Forms.Button modifier_help;
		private System.Windows.Forms.Button note;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		
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
			this.load_ecb_but = new System.Windows.Forms.Button();
			this.save_ecb_but = new System.Windows.Forms.Button();
			this.ecb_path = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.TextBox();
			this.firm_box = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.size = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.yield_max = new System.Windows.Forms.NumericUpDown();
			this.yield_min = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.growth = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.spicy = new System.Windows.Forms.NumericUpDown();
			this.dry = new System.Windows.Forms.NumericUpDown();
			this.sweet = new System.Windows.Forms.NumericUpDown();
			this.bitter = new System.Windows.Forms.NumericUpDown();
			this.sour = new System.Windows.Forms.NumericUpDown();
			this.smooth = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.desc1 = new System.Windows.Forms.TextBox();
			this.desc2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.held = new System.Windows.Forms.NumericUpDown();
			this.held_help = new System.Windows.Forms.Button();
			this.sprite_export_but = new System.Windows.Forms.Button();
			this.sprite_import_but = new System.Windows.Forms.Button();
			this.palette_export_but = new System.Windows.Forms.Button();
			this.palette_import_but = new System.Windows.Forms.Button();
			this.sprite_help = new System.Windows.Forms.Button();
			this.jap_encoding = new System.Windows.Forms.CheckBox();
			this.heal_inf = new System.Windows.Forms.CheckBox();
			this.heal_sleep = new System.Windows.Forms.CheckBox();
			this.heal_poison = new System.Windows.Forms.CheckBox();
			this.heal_burn = new System.Windows.Forms.CheckBox();
			this.heal_ice = new System.Windows.Forms.CheckBox();
			this.heal_para = new System.Windows.Forms.CheckBox();
			this.heal_confu = new System.Windows.Forms.CheckBox();
			this.guard = new System.Windows.Forms.CheckBox();
			this.lvlup = new System.Windows.Forms.CheckBox();
			this.firstpoke = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.direhit = new System.Windows.Forms.NumericUpDown();
			this.atkup = new System.Windows.Forms.NumericUpDown();
			this.defup = new System.Windows.Forms.NumericUpDown();
			this.speedup = new System.Windows.Forms.NumericUpDown();
			this.spatkup = new System.Windows.Forms.NumericUpDown();
			this.accurup = new System.Windows.Forms.NumericUpDown();
			this.ev_hp = new System.Windows.Forms.CheckBox();
			this.ev_atk = new System.Windows.Forms.CheckBox();
			this.ev_def = new System.Windows.Forms.CheckBox();
			this.ev_speed = new System.Windows.Forms.CheckBox();
			this.ev_speatk = new System.Windows.Forms.CheckBox();
			this.ev_spedef = new System.Windows.Forms.CheckBox();
			this.tr6_val = new System.Windows.Forms.NumericUpDown();
			this.heal_hp = new System.Windows.Forms.CheckBox();
			this.heal_pp = new System.Windows.Forms.CheckBox();
			this.selectedatk = new System.Windows.Forms.CheckBox();
			this.maxppUP = new System.Windows.Forms.CheckBox();
			this.revive = new System.Windows.Forms.CheckBox();
			this.stone = new System.Windows.Forms.CheckBox();
			this.happy200 = new System.Windows.Forms.CheckBox();
			this.happy100 = new System.Windows.Forms.CheckBox();
			this.happy0 = new System.Windows.Forms.CheckBox();
			this.hap200 = new System.Windows.Forms.NumericUpDown();
			this.hap100 = new System.Windows.Forms.NumericUpDown();
			this.happ0 = new System.Windows.Forms.NumericUpDown();
			this.ppup = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.pphelp = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.note = new System.Windows.Forms.Button();
			this.modifier_help = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yield_max)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yield_min)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.growth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spicy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sweet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bitter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smooth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.held)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.direhit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.atkup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.defup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.speedup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spatkup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accurup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tr6_val)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hap200)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hap100)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.happ0)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// load_ecb_but
			// 
			this.load_ecb_but.Location = new System.Drawing.Point(12, 21);
			this.load_ecb_but.Name = "load_ecb_but";
			this.load_ecb_but.Size = new System.Drawing.Size(75, 23);
			this.load_ecb_but.TabIndex = 0;
			this.load_ecb_but.Text = "Load ECB";
			this.load_ecb_but.UseVisualStyleBackColor = true;
			this.load_ecb_but.Click += new System.EventHandler(this.Load_ecb_butClick);
			// 
			// save_ecb_but
			// 
			this.save_ecb_but.Enabled = false;
			this.save_ecb_but.Location = new System.Drawing.Point(93, 21);
			this.save_ecb_but.Name = "save_ecb_but";
			this.save_ecb_but.Size = new System.Drawing.Size(75, 23);
			this.save_ecb_but.TabIndex = 1;
			this.save_ecb_but.Text = "Save ECB";
			this.save_ecb_but.UseVisualStyleBackColor = true;
			this.save_ecb_but.Click += new System.EventHandler(this.Save_ecb_butClick);
			// 
			// ecb_path
			// 
			this.ecb_path.Location = new System.Drawing.Point(174, 24);
			this.ecb_path.Name = "ecb_path";
			this.ecb_path.Size = new System.Drawing.Size(482, 20);
			this.ecb_path.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Name:";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(93, 69);
			this.name.MaxLength = 6;
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(252, 20);
			this.name.TabIndex = 4;
			// 
			// firm_box
			// 
			this.firm_box.FormattingEnabled = true;
			this.firm_box.Items.AddRange(new object[] {
			"Very soft",
			"Soft",
			"Hard",
			"Very hard",
			"Super hard"});
			this.firm_box.Location = new System.Drawing.Point(93, 151);
			this.firm_box.Name = "firm_box";
			this.firm_box.Size = new System.Drawing.Size(120, 21);
			this.firm_box.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Firmness:";
			// 
			// size
			// 
			this.size.Location = new System.Drawing.Point(93, 177);
			this.size.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.size.Name = "size";
			this.size.Size = new System.Drawing.Size(120, 20);
			this.size.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 179);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "Size:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 205);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Maximum yield:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 231);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Minumum yield:";
			// 
			// yield_max
			// 
			this.yield_max.Location = new System.Drawing.Point(93, 203);
			this.yield_max.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.yield_max.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.yield_max.Name = "yield_max";
			this.yield_max.Size = new System.Drawing.Size(120, 20);
			this.yield_max.TabIndex = 11;
			this.yield_max.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// yield_min
			// 
			this.yield_min.Location = new System.Drawing.Point(93, 229);
			this.yield_min.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.yield_min.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.yield_min.Name = "yield_min";
			this.yield_min.Size = new System.Drawing.Size(120, 20);
			this.yield_min.TabIndex = 12;
			this.yield_min.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 254);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 34);
			this.label6.TabIndex = 13;
			this.label6.Text = "Growth hours per stage:";
			// 
			// growth
			// 
			this.growth.Location = new System.Drawing.Point(93, 255);
			this.growth.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.growth.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.growth.Name = "growth";
			this.growth.Size = new System.Drawing.Size(120, 20);
			this.growth.TabIndex = 14;
			this.growth.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(219, 154);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Spicyness:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(219, 179);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 16;
			this.label8.Text = "Dryness:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(219, 205);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "Sweetness:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(219, 231);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 18;
			this.label10.Text = "Bitterness:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(219, 257);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 19;
			this.label11.Text = "Sourness:";
			// 
			// spicy
			// 
			this.spicy.Location = new System.Drawing.Point(288, 152);
			this.spicy.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.spicy.Name = "spicy";
			this.spicy.Size = new System.Drawing.Size(78, 20);
			this.spicy.TabIndex = 20;
			// 
			// dry
			// 
			this.dry.Location = new System.Drawing.Point(288, 177);
			this.dry.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.dry.Name = "dry";
			this.dry.Size = new System.Drawing.Size(78, 20);
			this.dry.TabIndex = 21;
			// 
			// sweet
			// 
			this.sweet.Location = new System.Drawing.Point(288, 203);
			this.sweet.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.sweet.Name = "sweet";
			this.sweet.Size = new System.Drawing.Size(78, 20);
			this.sweet.TabIndex = 22;
			// 
			// bitter
			// 
			this.bitter.Location = new System.Drawing.Point(288, 229);
			this.bitter.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.bitter.Name = "bitter";
			this.bitter.Size = new System.Drawing.Size(78, 20);
			this.bitter.TabIndex = 23;
			// 
			// sour
			// 
			this.sour.Location = new System.Drawing.Point(288, 255);
			this.sour.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.sour.Name = "sour";
			this.sour.Size = new System.Drawing.Size(78, 20);
			this.sour.TabIndex = 24;
			// 
			// smooth
			// 
			this.smooth.Location = new System.Drawing.Point(288, 281);
			this.smooth.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.smooth.Name = "smooth";
			this.smooth.Size = new System.Drawing.Size(78, 20);
			this.smooth.TabIndex = 25;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(219, 283);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(69, 23);
			this.label12.TabIndex = 26;
			this.label12.Text = "Smoothness:";
			// 
			// desc1
			// 
			this.desc1.Location = new System.Drawing.Point(42, 94);
			this.desc1.MaxLength = 44;
			this.desc1.Name = "desc1";
			this.desc1.Size = new System.Drawing.Size(303, 20);
			this.desc1.TabIndex = 27;
			// 
			// desc2
			// 
			this.desc2.Location = new System.Drawing.Point(42, 120);
			this.desc2.MaxLength = 44;
			this.desc2.Name = "desc2";
			this.desc2.Size = new System.Drawing.Size(303, 20);
			this.desc2.TabIndex = 28;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(12, 311);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(102, 18);
			this.label13.TabIndex = 29;
			this.label13.Text = "Usage as held item:";
			// 
			// held
			// 
			this.held.Location = new System.Drawing.Point(120, 309);
			this.held.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.held.Name = "held";
			this.held.Size = new System.Drawing.Size(59, 20);
			this.held.TabIndex = 30;
			// 
			// held_help
			// 
			this.held_help.Location = new System.Drawing.Point(185, 309);
			this.held_help.Name = "held_help";
			this.held_help.Size = new System.Drawing.Size(15, 20);
			this.held_help.TabIndex = 31;
			this.held_help.Text = "?";
			this.held_help.UseVisualStyleBackColor = true;
			this.held_help.Click += new System.EventHandler(this.Held_helpClick);
			// 
			// sprite_export_but
			// 
			this.sprite_export_but.Enabled = false;
			this.sprite_export_but.Location = new System.Drawing.Point(662, 21);
			this.sprite_export_but.Name = "sprite_export_but";
			this.sprite_export_but.Size = new System.Drawing.Size(86, 23);
			this.sprite_export_but.TabIndex = 33;
			this.sprite_export_but.Text = "Export Sprite";
			this.sprite_export_but.UseVisualStyleBackColor = true;
			this.sprite_export_but.Click += new System.EventHandler(this.Sprite_export_butClick);
			// 
			// sprite_import_but
			// 
			this.sprite_import_but.Enabled = false;
			this.sprite_import_but.Location = new System.Drawing.Point(754, 21);
			this.sprite_import_but.Name = "sprite_import_but";
			this.sprite_import_but.Size = new System.Drawing.Size(86, 23);
			this.sprite_import_but.TabIndex = 34;
			this.sprite_import_but.Text = "Import Sprite";
			this.sprite_import_but.UseVisualStyleBackColor = true;
			this.sprite_import_but.Click += new System.EventHandler(this.Sprite_import_butClick);
			// 
			// palette_export_but
			// 
			this.palette_export_but.Enabled = false;
			this.palette_export_but.Location = new System.Drawing.Point(472, 0);
			this.palette_export_but.Name = "palette_export_but";
			this.palette_export_but.Size = new System.Drawing.Size(86, 23);
			this.palette_export_but.TabIndex = 35;
			this.palette_export_but.Text = "Export Palette";
			this.palette_export_but.UseVisualStyleBackColor = true;
			this.palette_export_but.Visible = false;
			this.palette_export_but.Click += new System.EventHandler(this.Palette_export_butClick);
			// 
			// palette_import_but
			// 
			this.palette_import_but.Enabled = false;
			this.palette_import_but.Location = new System.Drawing.Point(564, 0);
			this.palette_import_but.Name = "palette_import_but";
			this.palette_import_but.Size = new System.Drawing.Size(86, 23);
			this.palette_import_but.TabIndex = 36;
			this.palette_import_but.Text = "Import Palette";
			this.palette_import_but.UseVisualStyleBackColor = true;
			this.palette_import_but.Visible = false;
			this.palette_import_but.Click += new System.EventHandler(this.Palette_import_butClick);
			// 
			// sprite_help
			// 
			this.sprite_help.Location = new System.Drawing.Point(846, 22);
			this.sprite_help.Name = "sprite_help";
			this.sprite_help.Size = new System.Drawing.Size(15, 20);
			this.sprite_help.TabIndex = 37;
			this.sprite_help.Text = "?";
			this.sprite_help.UseVisualStyleBackColor = true;
			this.sprite_help.Click += new System.EventHandler(this.Sprite_helpClick);
			// 
			// jap_encoding
			// 
			this.jap_encoding.Location = new System.Drawing.Point(93, 47);
			this.jap_encoding.Name = "jap_encoding";
			this.jap_encoding.Size = new System.Drawing.Size(134, 22);
			this.jap_encoding.TabIndex = 38;
			this.jap_encoding.Text = "Japanese encoding";
			this.jap_encoding.UseVisualStyleBackColor = true;
			this.jap_encoding.CheckedChanged += new System.EventHandler(this.Jap_encodingCheckedChanged);
			// 
			// heal_inf
			// 
			this.heal_inf.Location = new System.Drawing.Point(6, 19);
			this.heal_inf.Name = "heal_inf";
			this.heal_inf.Size = new System.Drawing.Size(104, 18);
			this.heal_inf.TabIndex = 39;
			this.heal_inf.Text = "Heal Infatuation";
			this.heal_inf.UseVisualStyleBackColor = true;
			// 
			// heal_sleep
			// 
			this.heal_sleep.Location = new System.Drawing.Point(6, 40);
			this.heal_sleep.Name = "heal_sleep";
			this.heal_sleep.Size = new System.Drawing.Size(104, 18);
			this.heal_sleep.TabIndex = 40;
			this.heal_sleep.Text = "Heal Sleep";
			this.heal_sleep.UseVisualStyleBackColor = true;
			// 
			// heal_poison
			// 
			this.heal_poison.Location = new System.Drawing.Point(6, 58);
			this.heal_poison.Name = "heal_poison";
			this.heal_poison.Size = new System.Drawing.Size(104, 18);
			this.heal_poison.TabIndex = 41;
			this.heal_poison.Text = "Heal Poison";
			this.heal_poison.UseVisualStyleBackColor = true;
			// 
			// heal_burn
			// 
			this.heal_burn.Location = new System.Drawing.Point(6, 76);
			this.heal_burn.Name = "heal_burn";
			this.heal_burn.Size = new System.Drawing.Size(104, 18);
			this.heal_burn.TabIndex = 42;
			this.heal_burn.Text = "Heal Burn";
			this.heal_burn.UseVisualStyleBackColor = true;
			// 
			// heal_ice
			// 
			this.heal_ice.Location = new System.Drawing.Point(6, 93);
			this.heal_ice.Name = "heal_ice";
			this.heal_ice.Size = new System.Drawing.Size(104, 18);
			this.heal_ice.TabIndex = 43;
			this.heal_ice.Text = "Heal Ice";
			this.heal_ice.UseVisualStyleBackColor = true;
			// 
			// heal_para
			// 
			this.heal_para.Location = new System.Drawing.Point(6, 111);
			this.heal_para.Name = "heal_para";
			this.heal_para.Size = new System.Drawing.Size(104, 18);
			this.heal_para.TabIndex = 44;
			this.heal_para.Text = "Heal Paralyze";
			this.heal_para.UseVisualStyleBackColor = true;
			// 
			// heal_confu
			// 
			this.heal_confu.Location = new System.Drawing.Point(6, 129);
			this.heal_confu.Name = "heal_confu";
			this.heal_confu.Size = new System.Drawing.Size(104, 18);
			this.heal_confu.TabIndex = 45;
			this.heal_confu.Text = "Heal Confusion";
			this.heal_confu.UseVisualStyleBackColor = true;
			// 
			// guard
			// 
			this.guard.Location = new System.Drawing.Point(17, 141);
			this.guard.Name = "guard";
			this.guard.Size = new System.Drawing.Size(91, 16);
			this.guard.TabIndex = 46;
			this.guard.Text = "Guard-spec";
			this.guard.UseVisualStyleBackColor = true;
			// 
			// lvlup
			// 
			this.lvlup.Location = new System.Drawing.Point(228, 226);
			this.lvlup.Name = "lvlup";
			this.lvlup.Size = new System.Drawing.Size(104, 16);
			this.lvlup.TabIndex = 47;
			this.lvlup.Text = "Level up";
			this.lvlup.UseVisualStyleBackColor = true;
			// 
			// firstpoke
			// 
			this.firstpoke.Location = new System.Drawing.Point(228, 191);
			this.firstpoke.Name = "firstpoke";
			this.firstpoke.Size = new System.Drawing.Size(95, 40);
			this.firstpoke.TabIndex = 48;
			this.firstpoke.Text = "Apply to first pokemon";
			this.firstpoke.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(17, 18);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(55, 13);
			this.label15.TabIndex = 49;
			this.label15.Text = "Dire Hit";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(17, 39);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 13);
			this.label16.TabIndex = 50;
			this.label16.Text = "Atk Up";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(17, 60);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 13);
			this.label17.TabIndex = 51;
			this.label17.Text = "Def Up";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(17, 81);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 13);
			this.label18.TabIndex = 52;
			this.label18.Text = "Speed Up";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(17, 102);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 13);
			this.label19.TabIndex = 53;
			this.label19.Text = "SP Atk Up";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(17, 123);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 13);
			this.label20.TabIndex = 54;
			this.label20.Text = "Accur. Up";
			// 
			// direhit
			// 
			this.direhit.Location = new System.Drawing.Point(78, 16);
			this.direhit.Maximum = new decimal(new int[] {
			3,
			0,
			0,
			0});
			this.direhit.Name = "direhit";
			this.direhit.Size = new System.Drawing.Size(39, 20);
			this.direhit.TabIndex = 56;
			// 
			// atkup
			// 
			this.atkup.Location = new System.Drawing.Point(78, 37);
			this.atkup.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.atkup.Name = "atkup";
			this.atkup.Size = new System.Drawing.Size(39, 20);
			this.atkup.TabIndex = 57;
			// 
			// defup
			// 
			this.defup.Location = new System.Drawing.Point(78, 58);
			this.defup.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.defup.Name = "defup";
			this.defup.Size = new System.Drawing.Size(39, 20);
			this.defup.TabIndex = 58;
			// 
			// speedup
			// 
			this.speedup.Location = new System.Drawing.Point(78, 79);
			this.speedup.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.speedup.Name = "speedup";
			this.speedup.Size = new System.Drawing.Size(39, 20);
			this.speedup.TabIndex = 59;
			// 
			// spatkup
			// 
			this.spatkup.Location = new System.Drawing.Point(78, 100);
			this.spatkup.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.spatkup.Name = "spatkup";
			this.spatkup.Size = new System.Drawing.Size(39, 20);
			this.spatkup.TabIndex = 60;
			// 
			// accurup
			// 
			this.accurup.Location = new System.Drawing.Point(78, 121);
			this.accurup.Maximum = new decimal(new int[] {
			15,
			0,
			0,
			0});
			this.accurup.Name = "accurup";
			this.accurup.Size = new System.Drawing.Size(39, 20);
			this.accurup.TabIndex = 61;
			// 
			// ev_hp
			// 
			this.ev_hp.Location = new System.Drawing.Point(13, 17);
			this.ev_hp.Name = "ev_hp";
			this.ev_hp.Size = new System.Drawing.Size(65, 18);
			this.ev_hp.TabIndex = 62;
			this.ev_hp.Text = "HP";
			this.ev_hp.UseVisualStyleBackColor = true;
			// 
			// ev_atk
			// 
			this.ev_atk.Location = new System.Drawing.Point(13, 38);
			this.ev_atk.Name = "ev_atk";
			this.ev_atk.Size = new System.Drawing.Size(65, 18);
			this.ev_atk.TabIndex = 63;
			this.ev_atk.Text = "Attack";
			this.ev_atk.UseVisualStyleBackColor = true;
			// 
			// ev_def
			// 
			this.ev_def.Location = new System.Drawing.Point(13, 56);
			this.ev_def.Name = "ev_def";
			this.ev_def.Size = new System.Drawing.Size(75, 18);
			this.ev_def.TabIndex = 65;
			this.ev_def.Text = "Defense";
			this.ev_def.UseVisualStyleBackColor = true;
			// 
			// ev_speed
			// 
			this.ev_speed.Location = new System.Drawing.Point(13, 74);
			this.ev_speed.Name = "ev_speed";
			this.ev_speed.Size = new System.Drawing.Size(75, 18);
			this.ev_speed.TabIndex = 66;
			this.ev_speed.Text = "Speed";
			this.ev_speed.UseVisualStyleBackColor = true;
			// 
			// ev_speatk
			// 
			this.ev_speatk.Location = new System.Drawing.Point(13, 91);
			this.ev_speatk.Name = "ev_speatk";
			this.ev_speatk.Size = new System.Drawing.Size(75, 18);
			this.ev_speatk.TabIndex = 67;
			this.ev_speatk.Text = "SPE Atk";
			this.ev_speatk.UseVisualStyleBackColor = true;
			// 
			// ev_spedef
			// 
			this.ev_spedef.Location = new System.Drawing.Point(13, 109);
			this.ev_spedef.Name = "ev_spedef";
			this.ev_spedef.Size = new System.Drawing.Size(75, 18);
			this.ev_spedef.TabIndex = 68;
			this.ev_spedef.Text = "SPE Def";
			this.ev_spedef.UseVisualStyleBackColor = true;
			// 
			// tr6_val
			// 
			this.tr6_val.Location = new System.Drawing.Point(401, 207);
			this.tr6_val.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.tr6_val.Name = "tr6_val";
			this.tr6_val.Size = new System.Drawing.Size(54, 20);
			this.tr6_val.TabIndex = 69;
			// 
			// heal_hp
			// 
			this.heal_hp.Location = new System.Drawing.Point(6, 21);
			this.heal_hp.Name = "heal_hp";
			this.heal_hp.Size = new System.Drawing.Size(104, 18);
			this.heal_hp.TabIndex = 70;
			this.heal_hp.Text = "Heal HP";
			this.heal_hp.UseVisualStyleBackColor = true;
			// 
			// heal_pp
			// 
			this.heal_pp.Location = new System.Drawing.Point(6, 39);
			this.heal_pp.Name = "heal_pp";
			this.heal_pp.Size = new System.Drawing.Size(104, 18);
			this.heal_pp.TabIndex = 71;
			this.heal_pp.Text = "Heal PP";
			this.heal_pp.UseVisualStyleBackColor = true;
			// 
			// selectedatk
			// 
			this.selectedatk.Location = new System.Drawing.Point(6, 57);
			this.selectedatk.Name = "selectedatk";
			this.selectedatk.Size = new System.Drawing.Size(139, 18);
			this.selectedatk.TabIndex = 73;
			this.selectedatk.Text = "Only to selected attack";
			this.selectedatk.UseVisualStyleBackColor = true;
			// 
			// maxppUP
			// 
			this.maxppUP.Location = new System.Drawing.Point(6, 78);
			this.maxppUP.Name = "maxppUP";
			this.maxppUP.Size = new System.Drawing.Size(109, 18);
			this.maxppUP.TabIndex = 74;
			this.maxppUP.Text = "Increase Max PP";
			this.maxppUP.UseVisualStyleBackColor = true;
			// 
			// revive
			// 
			this.revive.Location = new System.Drawing.Point(6, 95);
			this.revive.Name = "revive";
			this.revive.Size = new System.Drawing.Size(104, 18);
			this.revive.TabIndex = 75;
			this.revive.Text = "Revive and heal";
			this.revive.UseVisualStyleBackColor = true;
			// 
			// stone
			// 
			this.stone.Location = new System.Drawing.Point(6, 142);
			this.stone.Name = "stone";
			this.stone.Size = new System.Drawing.Size(104, 18);
			this.stone.TabIndex = 76;
			this.stone.Text = "Evolution stone";
			this.stone.UseVisualStyleBackColor = true;
			// 
			// happy200
			// 
			this.happy200.Location = new System.Drawing.Point(12, 16);
			this.happy200.Name = "happy200";
			this.happy200.Size = new System.Drawing.Size(104, 18);
			this.happy200.TabIndex = 77;
			this.happy200.Text = "Friendship >200";
			this.happy200.UseVisualStyleBackColor = true;
			// 
			// happy100
			// 
			this.happy100.Location = new System.Drawing.Point(12, 42);
			this.happy100.Name = "happy100";
			this.happy100.Size = new System.Drawing.Size(104, 18);
			this.happy100.TabIndex = 78;
			this.happy100.Text = "Friendship >100";
			this.happy100.UseVisualStyleBackColor = true;
			// 
			// happy0
			// 
			this.happy0.Location = new System.Drawing.Point(12, 68);
			this.happy0.Name = "happy0";
			this.happy0.Size = new System.Drawing.Size(109, 18);
			this.happy0.TabIndex = 79;
			this.happy0.Text = "Friendship < 100";
			this.happy0.UseVisualStyleBackColor = true;
			// 
			// hap200
			// 
			this.hap200.Location = new System.Drawing.Point(117, 16);
			this.hap200.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.hap200.Name = "hap200";
			this.hap200.Size = new System.Drawing.Size(57, 20);
			this.hap200.TabIndex = 80;
			// 
			// hap100
			// 
			this.hap100.Location = new System.Drawing.Point(117, 42);
			this.hap100.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.hap100.Name = "hap100";
			this.hap100.Size = new System.Drawing.Size(57, 20);
			this.hap100.TabIndex = 81;
			// 
			// happ0
			// 
			this.happ0.Location = new System.Drawing.Point(117, 68);
			this.happ0.Maximum = new decimal(new int[] {
			127,
			0,
			0,
			0});
			this.happ0.Name = "happ0";
			this.happ0.Size = new System.Drawing.Size(57, 20);
			this.happ0.TabIndex = 82;
			// 
			// ppup
			// 
			this.ppup.Location = new System.Drawing.Point(6, 111);
			this.ppup.Name = "ppup";
			this.ppup.Size = new System.Drawing.Size(124, 30);
			this.ppup.TabIndex = 83;
			this.ppup.Text = "Increase PP to max on selected attack";
			this.ppup.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvlup);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.note);
			this.groupBox1.Controls.Add(this.modifier_help);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.tr6_val);
			this.groupBox1.Controls.Add(this.firstpoke);
			this.groupBox1.Location = new System.Drawing.Point(372, 53);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(525, 283);
			this.groupBox1.TabIndex = 84;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Usage by trainer:";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.pphelp);
			this.groupBox6.Controls.Add(this.ppup);
			this.groupBox6.Controls.Add(this.stone);
			this.groupBox6.Controls.Add(this.revive);
			this.groupBox6.Controls.Add(this.maxppUP);
			this.groupBox6.Controls.Add(this.heal_pp);
			this.groupBox6.Controls.Add(this.heal_hp);
			this.groupBox6.Controls.Add(this.selectedatk);
			this.groupBox6.Location = new System.Drawing.Point(370, 16);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(144, 168);
			this.groupBox6.TabIndex = 92;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "HP/PP";
			// 
			// pphelp
			// 
			this.pphelp.Location = new System.Drawing.Point(113, 13);
			this.pphelp.Name = "pphelp";
			this.pphelp.Size = new System.Drawing.Size(25, 21);
			this.pphelp.TabIndex = 85;
			this.pphelp.Text = "?";
			this.pphelp.UseVisualStyleBackColor = true;
			this.pphelp.Click += new System.EventHandler(this.PphelpClick);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.happ0);
			this.groupBox5.Controls.Add(this.hap100);
			this.groupBox5.Controls.Add(this.hap200);
			this.groupBox5.Controls.Add(this.happy0);
			this.groupBox5.Controls.Add(this.happy100);
			this.groupBox5.Controls.Add(this.happy200);
			this.groupBox5.Location = new System.Drawing.Point(6, 180);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(199, 96);
			this.groupBox5.TabIndex = 91;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Friendship";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.heal_confu);
			this.groupBox4.Controls.Add(this.heal_para);
			this.groupBox4.Controls.Add(this.heal_ice);
			this.groupBox4.Controls.Add(this.heal_burn);
			this.groupBox4.Controls.Add(this.heal_poison);
			this.groupBox4.Controls.Add(this.heal_sleep);
			this.groupBox4.Controls.Add(this.heal_inf);
			this.groupBox4.Location = new System.Drawing.Point(6, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(121, 162);
			this.groupBox4.TabIndex = 90;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Status";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.accurup);
			this.groupBox3.Controls.Add(this.spatkup);
			this.groupBox3.Controls.Add(this.speedup);
			this.groupBox3.Controls.Add(this.defup);
			this.groupBox3.Controls.Add(this.atkup);
			this.groupBox3.Controls.Add(this.direhit);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.guard);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Location = new System.Drawing.Point(133, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(132, 162);
			this.groupBox3.TabIndex = 89;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Battle";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ev_spedef);
			this.groupBox2.Controls.Add(this.ev_speatk);
			this.groupBox2.Controls.Add(this.ev_speed);
			this.groupBox2.Controls.Add(this.ev_def);
			this.groupBox2.Controls.Add(this.ev_atk);
			this.groupBox2.Controls.Add(this.ev_hp);
			this.groupBox2.Location = new System.Drawing.Point(271, 20);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(93, 133);
			this.groupBox2.TabIndex = 88;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "EV";
			// 
			// note
			// 
			this.note.Location = new System.Drawing.Point(301, 248);
			this.note.Name = "note";
			this.note.Size = new System.Drawing.Size(75, 23);
			this.note.TabIndex = 87;
			this.note.Text = "Note";
			this.note.UseVisualStyleBackColor = true;
			this.note.Click += new System.EventHandler(this.NoteClick);
			// 
			// modifier_help
			// 
			this.modifier_help.Location = new System.Drawing.Point(461, 206);
			this.modifier_help.Name = "modifier_help";
			this.modifier_help.Size = new System.Drawing.Size(25, 21);
			this.modifier_help.TabIndex = 86;
			this.modifier_help.Text = "?";
			this.modifier_help.UseVisualStyleBackColor = true;
			this.modifier_help.Click += new System.EventHandler(this.Modifier_helpClick);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(395, 187);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 20);
			this.label14.TabIndex = 84;
			this.label14.Text = "HP/PP/EV modifier:";
			// 
			// ECB_editor
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(901, 342);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.jap_encoding);
			this.Controls.Add(this.sprite_help);
			this.Controls.Add(this.palette_import_but);
			this.Controls.Add(this.palette_export_but);
			this.Controls.Add(this.sprite_import_but);
			this.Controls.Add(this.sprite_export_but);
			this.Controls.Add(this.held_help);
			this.Controls.Add(this.held);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.desc2);
			this.Controls.Add(this.desc1);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.smooth);
			this.Controls.Add(this.sour);
			this.Controls.Add(this.bitter);
			this.Controls.Add(this.sweet);
			this.Controls.Add(this.dry);
			this.Controls.Add(this.spicy);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.growth);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.yield_min);
			this.Controls.Add(this.yield_max);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.size);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firm_box);
			this.Controls.Add(this.name);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ecb_path);
			this.Controls.Add(this.save_ecb_but);
			this.Controls.Add(this.load_ecb_but);
			this.Name = "ECB_editor";
			this.Text = "ECB Editor";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ECB_editorDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ECB_editorDragEnter);
			((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yield_max)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yield_min)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.growth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spicy)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sweet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bitter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smooth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.held)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.direhit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.atkup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.defup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.speedup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spatkup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accurup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tr6_val)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hap200)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hap100)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.happ0)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
