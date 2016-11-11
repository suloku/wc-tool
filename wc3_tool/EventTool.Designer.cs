/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 29/04/2016
 * Time: 13:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WC3_TOOL
{
	partial class EventTool
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button load_save_but;
		private System.Windows.Forms.TextBox sav3_path;
		private System.Windows.Forms.Button region_but;
		private System.Windows.Forms.ComboBox game_box;
		private System.Windows.Forms.ComboBox language_box;
		private System.Windows.Forms.Label region_lab;
		private System.Windows.Forms.Button inject_sav;
		private System.Windows.Forms.RadioButton jap_eon;
		private System.Windows.Forms.RadioButton jap_aurora;
		private System.Windows.Forms.GroupBox JAP_group;
		private System.Windows.Forms.RadioButton jap_old;
		private System.Windows.Forms.RadioButton jap_mystic;
		private System.Windows.Forms.GroupBox USA_group;
		private System.Windows.Forms.RadioButton usa_eon_italy;
		private System.Windows.Forms.RadioButton usa_mystic;
		private System.Windows.Forms.RadioButton usa_aurora;
		private System.Windows.Forms.RadioButton usa_eon_ecard;
		private System.Windows.Forms.GroupBox EUR_group;
		private System.Windows.Forms.RadioButton eur_eon;
		private System.Windows.Forms.RadioButton eur_aurora;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		
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
			this.load_save_but = new System.Windows.Forms.Button();
			this.sav3_path = new System.Windows.Forms.TextBox();
			this.region_but = new System.Windows.Forms.Button();
			this.game_box = new System.Windows.Forms.ComboBox();
			this.language_box = new System.Windows.Forms.ComboBox();
			this.region_lab = new System.Windows.Forms.Label();
			this.inject_sav = new System.Windows.Forms.Button();
			this.jap_eon = new System.Windows.Forms.RadioButton();
			this.jap_aurora = new System.Windows.Forms.RadioButton();
			this.JAP_group = new System.Windows.Forms.GroupBox();
			this.jap_old = new System.Windows.Forms.RadioButton();
			this.jap_mystic = new System.Windows.Forms.RadioButton();
			this.USA_group = new System.Windows.Forms.GroupBox();
			this.usa_eon_italy = new System.Windows.Forms.RadioButton();
			this.usa_mystic = new System.Windows.Forms.RadioButton();
			this.usa_aurora = new System.Windows.Forms.RadioButton();
			this.usa_eon_ecard = new System.Windows.Forms.RadioButton();
			this.EUR_group = new System.Windows.Forms.GroupBox();
			this.eur_eon = new System.Windows.Forms.RadioButton();
			this.eur_aurora = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.JAP_group.SuspendLayout();
			this.USA_group.SuspendLayout();
			this.EUR_group.SuspendLayout();
			this.SuspendLayout();
			// 
			// load_save_but
			// 
			this.load_save_but.Location = new System.Drawing.Point(13, 10);
			this.load_save_but.Name = "load_save_but";
			this.load_save_but.Size = new System.Drawing.Size(91, 23);
			this.load_save_but.TabIndex = 1;
			this.load_save_but.Text = "Load Save File";
			this.load_save_but.UseVisualStyleBackColor = true;
			this.load_save_but.Click += new System.EventHandler(this.Load_save_butClick);
			// 
			// sav3_path
			// 
			this.sav3_path.Location = new System.Drawing.Point(13, 39);
			this.sav3_path.Name = "sav3_path";
			this.sav3_path.ReadOnly = true;
			this.sav3_path.Size = new System.Drawing.Size(588, 20);
			this.sav3_path.TabIndex = 5;
			// 
			// region_but
			// 
			this.region_but.Enabled = false;
			this.region_but.Location = new System.Drawing.Point(460, 10);
			this.region_but.Name = "region_but";
			this.region_but.Size = new System.Drawing.Size(92, 23);
			this.region_but.TabIndex = 15;
			this.region_but.Text = "Override Region";
			this.region_but.UseVisualStyleBackColor = true;
			this.region_but.Click += new System.EventHandler(this.Region_butClick);
			// 
			// game_box
			// 
			this.game_box.Enabled = false;
			this.game_box.FormattingEnabled = true;
			this.game_box.Items.AddRange(new object[] {
			"Ruby/Saphire",
			"Emerald",
			"Fire Red/Leaf Green"});
			this.game_box.Location = new System.Drawing.Point(110, 12);
			this.game_box.Name = "game_box";
			this.game_box.Size = new System.Drawing.Size(149, 21);
			this.game_box.TabIndex = 21;
			this.game_box.SelectedIndexChanged += new System.EventHandler(this.Game_boxSelectedIndexChanged);
			// 
			// language_box
			// 
			this.language_box.Enabled = false;
			this.language_box.FormattingEnabled = true;
			this.language_box.Items.AddRange(new object[] {
			"Japanesse",
			"English",
			"French",
			"Italian",
			"German",
			"Korean (not used)",
			"Spanish"});
			this.language_box.Location = new System.Drawing.Point(264, 12);
			this.language_box.Name = "language_box";
			this.language_box.Size = new System.Drawing.Size(121, 21);
			this.language_box.TabIndex = 22;
			this.language_box.SelectedIndexChanged += new System.EventHandler(this.Language_boxSelectedIndexChanged);
			// 
			// region_lab
			// 
			this.region_lab.Location = new System.Drawing.Point(391, 15);
			this.region_lab.Name = "region_lab";
			this.region_lab.Size = new System.Drawing.Size(63, 18);
			this.region_lab.TabIndex = 23;
			this.region_lab.Text = "Region";
			// 
			// inject_sav
			// 
			this.inject_sav.Location = new System.Drawing.Point(441, 185);
			this.inject_sav.Name = "inject_sav";
			this.inject_sav.Size = new System.Drawing.Size(144, 23);
			this.inject_sav.TabIndex = 28;
			this.inject_sav.Text = "Inject and Save";
			this.inject_sav.UseVisualStyleBackColor = true;
			this.inject_sav.Click += new System.EventHandler(this.Inject_savClick);
			// 
			// jap_eon
			// 
			this.jap_eon.Location = new System.Drawing.Point(6, 19);
			this.jap_eon.Name = "jap_eon";
			this.jap_eon.Size = new System.Drawing.Size(144, 24);
			this.jap_eon.TabIndex = 29;
			this.jap_eon.TabStop = true;
			this.jap_eon.Text = "Eon Ticket (R/S/E)";
			this.jap_eon.UseVisualStyleBackColor = true;
			// 
			// jap_aurora
			// 
			this.jap_aurora.Location = new System.Drawing.Point(6, 49);
			this.jap_aurora.Name = "jap_aurora";
			this.jap_aurora.Size = new System.Drawing.Size(170, 24);
			this.jap_aurora.TabIndex = 30;
			this.jap_aurora.TabStop = true;
			this.jap_aurora.Text = "Aurora Ticket 2004 (FR/LG)";
			this.jap_aurora.UseVisualStyleBackColor = true;
			// 
			// JAP_group
			// 
			this.JAP_group.Controls.Add(this.jap_old);
			this.JAP_group.Controls.Add(this.jap_mystic);
			this.JAP_group.Controls.Add(this.jap_aurora);
			this.JAP_group.Controls.Add(this.jap_eon);
			this.JAP_group.Enabled = false;
			this.JAP_group.Location = new System.Drawing.Point(13, 65);
			this.JAP_group.Name = "JAP_group";
			this.JAP_group.Size = new System.Drawing.Size(192, 143);
			this.JAP_group.TabIndex = 31;
			this.JAP_group.TabStop = false;
			this.JAP_group.Text = "Japanesse";
			// 
			// jap_old
			// 
			this.jap_old.Location = new System.Drawing.Point(6, 109);
			this.jap_old.Name = "jap_old";
			this.jap_old.Size = new System.Drawing.Size(170, 24);
			this.jap_old.TabIndex = 32;
			this.jap_old.TabStop = true;
			this.jap_old.Text = "Old Sea Map (E)";
			this.jap_old.UseVisualStyleBackColor = true;
			// 
			// jap_mystic
			// 
			this.jap_mystic.Location = new System.Drawing.Point(6, 79);
			this.jap_mystic.Name = "jap_mystic";
			this.jap_mystic.Size = new System.Drawing.Size(170, 24);
			this.jap_mystic.TabIndex = 31;
			this.jap_mystic.TabStop = true;
			this.jap_mystic.Text = "Mystic Ticket 2005 (FR/LG/E)";
			this.jap_mystic.UseVisualStyleBackColor = true;
			// 
			// USA_group
			// 
			this.USA_group.Controls.Add(this.usa_eon_italy);
			this.USA_group.Controls.Add(this.usa_mystic);
			this.USA_group.Controls.Add(this.usa_aurora);
			this.USA_group.Controls.Add(this.usa_eon_ecard);
			this.USA_group.Enabled = false;
			this.USA_group.Location = new System.Drawing.Point(211, 65);
			this.USA_group.Name = "USA_group";
			this.USA_group.Size = new System.Drawing.Size(192, 143);
			this.USA_group.TabIndex = 33;
			this.USA_group.TabStop = false;
			this.USA_group.Text = "USA/EUR (english only)";
			// 
			// usa_eon_italy
			// 
			this.usa_eon_italy.Location = new System.Drawing.Point(6, 49);
			this.usa_eon_italy.Name = "usa_eon_italy";
			this.usa_eon_italy.Size = new System.Drawing.Size(180, 24);
			this.usa_eon_italy.TabIndex = 32;
			this.usa_eon_italy.TabStop = true;
			this.usa_eon_italy.Text = "Eon Ticket (R/S) (Nintendo Italy)";
			this.usa_eon_italy.UseVisualStyleBackColor = true;
			// 
			// usa_mystic
			// 
			this.usa_mystic.Location = new System.Drawing.Point(6, 109);
			this.usa_mystic.Name = "usa_mystic";
			this.usa_mystic.Size = new System.Drawing.Size(170, 24);
			this.usa_mystic.TabIndex = 31;
			this.usa_mystic.TabStop = true;
			this.usa_mystic.Text = "Mystic Ticket (FR/LG/E)";
			this.usa_mystic.UseVisualStyleBackColor = true;
			// 
			// usa_aurora
			// 
			this.usa_aurora.Location = new System.Drawing.Point(6, 79);
			this.usa_aurora.Name = "usa_aurora";
			this.usa_aurora.Size = new System.Drawing.Size(170, 24);
			this.usa_aurora.TabIndex = 30;
			this.usa_aurora.TabStop = true;
			this.usa_aurora.Text = "Aurora Ticket (FR/LG/E)";
			this.usa_aurora.UseVisualStyleBackColor = true;
			// 
			// usa_eon_ecard
			// 
			this.usa_eon_ecard.Location = new System.Drawing.Point(6, 19);
			this.usa_eon_ecard.Name = "usa_eon_ecard";
			this.usa_eon_ecard.Size = new System.Drawing.Size(168, 24);
			this.usa_eon_ecard.TabIndex = 29;
			this.usa_eon_ecard.TabStop = true;
			this.usa_eon_ecard.Text = "Eon Ticket (R/S) (e-card)";
			this.usa_eon_ecard.UseVisualStyleBackColor = true;
			// 
			// EUR_group
			// 
			this.EUR_group.Controls.Add(this.eur_eon);
			this.EUR_group.Controls.Add(this.eur_aurora);
			this.EUR_group.Enabled = false;
			this.EUR_group.Location = new System.Drawing.Point(409, 65);
			this.EUR_group.Name = "EUR_group";
			this.EUR_group.Size = new System.Drawing.Size(192, 103);
			this.EUR_group.TabIndex = 34;
			this.EUR_group.TabStop = false;
			this.EUR_group.Text = "EUR (non english)";
			// 
			// eur_eon
			// 
			this.eur_eon.Location = new System.Drawing.Point(6, 19);
			this.eur_eon.Name = "eur_eon";
			this.eur_eon.Size = new System.Drawing.Size(180, 24);
			this.eur_eon.TabIndex = 32;
			this.eur_eon.TabStop = true;
			this.eur_eon.Text = "Eon Ticket (R/S) (Nintendo Italy)";
			this.eur_eon.UseVisualStyleBackColor = true;
			// 
			// eur_aurora
			// 
			this.eur_aurora.Location = new System.Drawing.Point(6, 49);
			this.eur_aurora.Name = "eur_aurora";
			this.eur_aurora.Size = new System.Drawing.Size(170, 24);
			this.eur_aurora.TabIndex = 30;
			this.eur_aurora.TabStop = true;
			this.eur_aurora.Text = "Aurora Ticket (FR/LG/E)";
			this.eur_aurora.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 217);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(588, 19);
			this.label1.TabIndex = 35;
			this.label1.Text = "Note: The following events are still missing:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(33, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(494, 18);
			this.label3.TabIndex = 37;
			this.label3.Text = "- \"MYSTIC TICKET\" TCG WORLD CHAMPIONSHIPS 2005 (US/English) (FR/LG)";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(33, 252);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(444, 23);
			this.label4.TabIndex = 38;
			this.label4.Text = "- \"MYSTIC TICKET\" POKÉMON ROCKS AMERICA 2005 (US/English) (FR/LG and E)";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(33, 267);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(421, 23);
			this.label5.TabIndex = 39;
			this.label5.Text = "-  All Pokémon Egg WonderCards for FR/LG and E.";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 289);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(552, 31);
			this.label6.TabIndex = 40;
			this.label6.Text = "If you own any of these events and want to contribute want to contribute to this " +
	"project, please contact suloku or ajxpkm at projectpokemon.org forums or send an" +
	" e-mail to gen3mysterygift@gmail.com";
			// 
			// EventTool
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 322);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EUR_group);
			this.Controls.Add(this.USA_group);
			this.Controls.Add(this.JAP_group);
			this.Controls.Add(this.inject_sav);
			this.Controls.Add(this.region_lab);
			this.Controls.Add(this.language_box);
			this.Controls.Add(this.game_box);
			this.Controls.Add(this.region_but);
			this.Controls.Add(this.sav3_path);
			this.Controls.Add(this.load_save_but);
			this.Name = "EventTool";
			this.Text = "Gen3 Event Tool 0.1d by suloku";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EventToolDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EventToolDragEnter);
			this.JAP_group.ResumeLayout(false);
			this.USA_group.ResumeLayout(false);
			this.EUR_group.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
