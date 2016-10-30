/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 03/05/2016
 * Time: 17:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WC3_TOOL
{
	partial class Decor_editor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox decortypebox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox decorationbox;
		private System.Windows.Forms.Label Decoration;
		private System.Windows.Forms.Button save_but;
		private System.Windows.Forms.Button add_but;
		private System.Windows.Forms.Button del_but;
		
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
			this.decortypebox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.decorationbox = new System.Windows.Forms.ComboBox();
			this.Decoration = new System.Windows.Forms.Label();
			this.save_but = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.add_but = new System.Windows.Forms.Button();
			this.del_but = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// decortypebox
			// 
			this.decortypebox.FormattingEnabled = true;
			this.decortypebox.Items.AddRange(new object[] {
			"Desk",
			"Chair",
			"Plant",
			"Ornament",
			"Mat",
			"Poster",
			"Doll",
			"Cushion"});
			this.decortypebox.Location = new System.Drawing.Point(9, 38);
			this.decortypebox.Name = "decortypebox";
			this.decortypebox.Size = new System.Drawing.Size(297, 21);
			this.decortypebox.TabIndex = 0;
			this.decortypebox.SelectedIndexChanged += new System.EventHandler(this.DecortypeboxSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Decoration type";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Slot";
			// 
			// decorationbox
			// 
			this.decorationbox.FormattingEnabled = true;
			this.decorationbox.Items.AddRange(new object[] {
			"Empty",
			"Small Desk",
			"Pokémon Desk",
			"Heavy Desk",
			"Ragged Desk",
			"Comfort Desk",
			"Pretty Desk",
			"Brick Desk",
			"Camp Desk",
			"Hard Desk"});
			this.decorationbox.Location = new System.Drawing.Point(135, 88);
			this.decorationbox.Name = "decorationbox";
			this.decorationbox.Size = new System.Drawing.Size(171, 21);
			this.decorationbox.TabIndex = 4;
			this.decorationbox.SelectedIndexChanged += new System.EventHandler(this.DecorationboxSelectedIndexChanged);
			// 
			// Decoration
			// 
			this.Decoration.Location = new System.Drawing.Point(135, 73);
			this.Decoration.Name = "Decoration";
			this.Decoration.Size = new System.Drawing.Size(100, 13);
			this.Decoration.TabIndex = 5;
			this.Decoration.Text = "Decoration";
			// 
			// save_but
			// 
			this.save_but.Location = new System.Drawing.Point(109, 130);
			this.save_but.Name = "save_but";
			this.save_but.Size = new System.Drawing.Size(75, 23);
			this.save_but.TabIndex = 6;
			this.save_but.Text = "Save";
			this.save_but.UseVisualStyleBackColor = true;
			this.save_but.Click += new System.EventHandler(this.Save_butClick);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(9, 89);
			this.numericUpDown1.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 2;
			this.numericUpDown1.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
			// 
			// add_but
			// 
			this.add_but.Location = new System.Drawing.Point(312, 73);
			this.add_but.Name = "add_but";
			this.add_but.Size = new System.Drawing.Size(37, 23);
			this.add_but.TabIndex = 7;
			this.add_but.Text = "Add";
			this.add_but.UseVisualStyleBackColor = true;
			this.add_but.Click += new System.EventHandler(this.Add_butClick);
			// 
			// del_but
			// 
			this.del_but.Location = new System.Drawing.Point(312, 102);
			this.del_but.Name = "del_but";
			this.del_but.Size = new System.Drawing.Size(37, 23);
			this.del_but.TabIndex = 8;
			this.del_but.Text = "Del";
			this.del_but.UseVisualStyleBackColor = true;
			this.del_but.Click += new System.EventHandler(this.Del_butClick);
			// 
			// Decor_editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 165);
			this.Controls.Add(this.del_but);
			this.Controls.Add(this.add_but);
			this.Controls.Add(this.save_but);
			this.Controls.Add(this.Decoration);
			this.Controls.Add(this.decorationbox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.decortypebox);
			this.Name = "Decor_editor";
			this.Text = "Decoration Inventory Editor";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
