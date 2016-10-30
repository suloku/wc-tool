/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 04/05/2016
 * Time: 13:42
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
	/// Description of ECT_pkedit.
	/// </summary>
	public partial class ECT_pkedit : Form
	{
		public ECT_pkedit(int index)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			pid.Maximum = 0xFFFFFFFF;
			pk = 0x34+(index*44);
			populate();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		int pk;
		//byte nickname;

		public UInt32 IV32 { get { return BitConverter.ToUInt32(ECT_editor.ectfile.Data, pk+0x18); } set { BitConverter.GetBytes((UInt32)value).CopyTo(ECT_editor.ectfile.Data, 0x18); } }
        public int IV_HP { get { return (int)(IV32 >> 00) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 00)) | (uint)((value > 31 ? 31 : value) << 00)); } }
        public int IV_ATK { get { return (int)(IV32 >> 05) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 05)) | (uint)((value > 31 ? 31 : value) << 05)); } }
        public int IV_DEF { get { return (int)(IV32 >> 10) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 10)) | (uint)((value > 31 ? 31 : value) << 10)); } }
        public int IV_SPE { get { return (int)(IV32 >> 15) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 15)) | (uint)((value > 31 ? 31 : value) << 15)); } }
        public int IV_SPA { get { return (int)(IV32 >> 20) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 20)) | (uint)((value > 31 ? 31 : value) << 20)); } }
        public int IV_SPD { get { return (int)(IV32 >> 25) & 0x1F; } set { IV32 = (uint)((IV32 & ~(0x1F << 25)) | (uint)((value > 31 ? 31 : value) << 25)); } }
        public int IV_Ability { get { return (int)((IV32 >> 31) & 1); } set { IV32 = (IV32 & 0x7FFFFFFF) | (value == 1 ? 0x80000000 : 0); } }
        
      	public byte PPUP { get { return ECT_editor.ectfile.Data[pk+0xD]; } set { ECT_editor.ectfile.Data[pk+0xD] = value; } }
        public int PPUP_1 { get { return (int)(PPUP >> 00) & 0x03; } set { PPUP = (byte)((PPUP & ~(0x03 << 00)) | (byte)((value > 3 ? 3 : value) << 00)); } }
        public int PPUP_2 { get { return (int)(PPUP >> 02) & 0x03; } set { PPUP = (byte)((PPUP & ~(0x03 << 02)) | (byte)((value > 3 ? 3 : value) << 02)); } }
        public int PPUP_3 { get { return (int)(PPUP >> 04) & 0x03; } set { PPUP = (byte)((PPUP & ~(0x03 << 04)) | (byte)((value > 3 ? 3 : value) << 04)); } }
        public int PPUP_4 { get { return (int)(PPUP >> 06) & 0x03; } set { PPUP = (byte)((PPUP & ~(0x03 << 06)) | (byte)((value > 3 ? 3 : value) << 06)); } }
        
		void populate()
		{
			item_box.SelectedIndex = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x2, 2), 0);
			namebox.Text = PKHeX.PKM.getG3Str(ECT_editor.ectfile.getData(pk+0x20, 11), jap_check.Checked);
			
			move1.SelectedIndex = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x4, 2), 0);
			move2.SelectedIndex = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x6, 2), 0);
			move3.SelectedIndex = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x8, 2), 0);
			move4.SelectedIndex = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0xA, 2), 0);
			
			pp1.Value = PPUP_1;
			pp2.Value = PPUP_2;
			pp3.Value = PPUP_3;
			pp4.Value = PPUP_4;
					
			level.Value = ECT_editor.ectfile.Data[pk+0x0C];
			friendship.Value = ECT_editor.ectfile.Data[pk+0x2B];
				
			otid.Value = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x14, 2), 0);
			otsid.Value = BitConverter.ToUInt16( ECT_editor.ectfile.getData(pk+0x16, 2), 0);
			
			pid.Value = BitConverter.ToUInt32( ECT_editor.ectfile.getData(pk+0x1c, 4), 0);
			
			ev1.Value = ECT_editor.ectfile.Data[pk+0x0E];
			ev2.Value = ECT_editor.ectfile.Data[pk+0x0F];
			ev3.Value = ECT_editor.ectfile.Data[pk+0x10];
			ev4.Value = ECT_editor.ectfile.Data[pk+0x11];
			ev5.Value = ECT_editor.ectfile.Data[pk+0x12];
			ev6.Value = ECT_editor.ectfile.Data[pk+0x13];
			
			iv1.Value = IV_HP;
			iv2.Value = IV_ATK;
			iv3.Value = IV_DEF;
			iv4.Value = IV_SPE;
			iv5.Value = IV_SPA;
			iv6.Value = IV_SPD;
			
			ability.Value = IV_Ability;
			
		}

		void save_edits()
		{
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)item_box.SelectedIndex).ToArray(),pk+0x2);

			ECT_editor.ectfile.setData(PKHeX.PKM.setG3Str(namebox.Text, jap_check.Checked), pk+0x20);
			
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)move1.SelectedIndex).ToArray(),pk+0x4);
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)move2.SelectedIndex).ToArray(),pk+0x6);
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)move3.SelectedIndex).ToArray(),pk+0x8);
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)move4.SelectedIndex).ToArray(),pk+0xA);
		
			PPUP_1 = (int)pp1.Value;
			PPUP_2 = (int)pp1.Value;
			PPUP_3 = (int)pp1.Value;
			PPUP_4 = (int)pp1.Value;
					
			ECT_editor.ectfile.Data[pk+0x0C] = (byte) level.Value;
			ECT_editor.ectfile.Data[pk+0x2B] = (byte) friendship.Value;
			
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)otid.Value).ToArray(), pk+0x14);
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt16)otsid.Value).ToArray(), pk+0x16);
			
			ECT_editor.ectfile.setData(BitConverter.GetBytes((UInt32)pid.Value).ToArray(), pk+0x1c);
			
			
			ECT_editor.ectfile.Data[pk+0x0E] = (byte) ev1.Value;
			ECT_editor.ectfile.Data[pk+0x0F] = (byte) ev2.Value;
			ECT_editor.ectfile.Data[pk+0x10] = (byte) ev3.Value;
			ECT_editor.ectfile.Data[pk+0x11] = (byte) ev4.Value;
			ECT_editor.ectfile.Data[pk+0x12] = (byte) ev5.Value;
			ECT_editor.ectfile.Data[pk+0x13] = (byte) ev6.Value;
			
		
			IV_HP = (int)iv1.Value;
			IV_ATK = (int)iv1.Value;
			IV_DEF = (int)iv3.Value;
			IV_SPE = (int)iv4.Value;
			IV_SPA = (int)iv5.Value;
			IV_SPD = (int)iv6.Value;
			
			IV_Ability = (int)ability.Value;
			
		}
		
		void CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void SaveClick(object sender, EventArgs e)
		{
			save_edits();
			this.Close();
		}
		void Jap_checkCheckedChanged(object sender, EventArgs e)
		{
			namebox.Text = PKHeX.PKM.getG3Str(ECT_editor.ectfile.getData(pk+0x20, 11), jap_check.Checked);
		}
		
	}

}
