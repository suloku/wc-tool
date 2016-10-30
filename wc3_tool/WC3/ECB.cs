/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 09/05/2016
 * Time: 0:54
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
	/// Description of ECB.
	/// </summary>
	public class ECB
	{
		public const int SIZE_ECB = SAV3.BERRY_SIZE;
		public const int SIZE_SPRITE = 1152;
		public const int SIZE_PALETTE = 32;
		
        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        public ECB(byte[] data)
        {
            Data = (byte[])(data ?? new byte[SIZE_ECB]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
            
            isjap = false;
          
            return;
        }
        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
            Edited = true;
        }
        public void fix_berry_checksum()
        {
        	byte[] chk = getData(0, SIZE_ECB-4);
        	int i;
        	for(i=0;i<8;i++) //These 8 bytes are taken as 0x00 for chk calculation
        	{
        		chk[0xC+i]=0x00;
        	}
        	UInt32 checksum = ME3.me3_checksum(chk, chk.Length);
        	setData(BitConverter.GetBytes(checksum).ToArray(), SIZE_ECB-4);
        }
        public UInt32 get_berry_checksum()
        {
        	byte[] chk = getData(0, SIZE_ECB-4);
        	int i;
        	for(i=0;i<8;i++) //These 8 bytes are taken as 0x00 for chk calculation
        	{
        		chk[0xC+i]=0x00;
        	}
        	return ME3.me3_checksum(chk, chk.Length);
        }
        
        public byte[] get_sprite()
        {
        	return getData(0x1C, SIZE_SPRITE);
        }
        public void set_sprite(byte[] sprite)
        {
        	if (sprite.Length == SIZE_SPRITE)
        		setData(sprite, 0x1C);
        }
        
        public byte[] get_palette()
        {
        	return getData(0x49C, SIZE_PALETTE);
        }
        public void set_palette(byte[] palette)
        {
        	if (palette.Length == SIZE_PALETTE)
        		setData(palette, 0x49C);
        }
        public byte[] get_full_sprite()
        {
        	byte[] sprite = new byte[SIZE_SPRITE+SIZE_PALETTE];
        	get_palette().CopyTo(sprite, 0);
        	get_sprite().CopyTo(sprite, SIZE_PALETTE);
        	return sprite;
        }
        public void set_full_sprite(byte[] sprite)
        {
        	set_sprite(sprite.Skip(SIZE_PALETTE).Take(SIZE_SPRITE).ToArray());
        	set_palette(sprite.Skip(0).Take(SIZE_PALETTE).ToArray());
        }
        public bool isjap;
        
        public string NAME { get { return PKHeX.PKM.getG3Str(Data.Take(7).ToArray(), isjap); } set { setData(PKHeX.PKM.setG3Str(value, isjap), 0); } }
        public byte FIRMNESS { get { return Data[0x7]; } set {  Data[0x7] = (byte) value; } }
        public UInt16 SIZE { get { return BitConverter.ToUInt16(Data, 0x8); } set {  BitConverter.GetBytes((UInt16)value).CopyTo(Data, 0x8);; } }
        public byte YIELD_MAX { get { return Data[0xA]; } set {  Data[0xA] = (byte) value; } }
        public byte YIELD_MIN { get { return Data[0xB]; } set {  Data[0xB] = (byte) value; } }
        public byte GROWTH { get { return Data[0x14]; } set {  Data[0x14] = (byte) value; } }
        public byte SPICY { get { return Data[0x15]; } set {  Data[0x15] = (byte) value; } }
        public byte DRY { get { return Data[0x16]; } set {  Data[0x16] = (byte) value; } }
        public byte SWEET { get { return Data[0x17]; } set {  Data[0x17] = (byte) value; } }
        public byte BITTER { get { return Data[0x18]; } set {  Data[0x18] = (byte) value; } }
        public byte SOUR { get { return Data[0x19]; } set {  Data[0x19] = (byte) value; } }
        public byte SMOOTH { get { return Data[0x1A]; } set {  Data[0x1A] = (byte) value; } }
        
        public string DESC_1 { get { return PKHeX.PKM.getG3Str(Data.Skip(0x4BC).Take(45).ToArray(), isjap); } set { setData(PKHeX.PKM.setG3Str(value, isjap), 0x4BC); } }
        public string DESC_2 { get { return PKHeX.PKM.getG3Str(Data.Skip(0x4E9).Take(45).ToArray(), isjap); } set { setData(PKHeX.PKM.setG3Str(value, isjap), 0x4E9); } }
        
        public byte HITEM { get { return Data[0x528]; } set {  Data[0x528] = (byte) value; } }
        
        public byte TR_0 { get { return Data[0x516]; } set {  Data[0x516] = (byte) value; } }
        public bool TR_0_healinfatuation { get { return Convert.ToBoolean((TR_0 >> 07) & 0x01); } set { TR_0 = (byte)((TR_0 & ~(0x01 << 07)) | (byte)((value == true ? 0x01 : 0x00) << 07)); } }
        public bool TR_0_firstpkm { get { return Convert.ToBoolean((TR_0 >> 06) & 0x01); } set { TR_0 = (byte)((TR_0 & ~(0x01 << 06)) | (byte)((value == true ? 0x01 : 0x00) << 06)); } }
        public int TR_0_direhit { get { return (int)(TR_0 >> 05) & 0x03; } set { TR_0 = (byte)((TR_0 & ~(0x03 << 05)) | (byte)((value > 3 ? 3 : value) << 05)); } }
        public int TR_0_attackUP { get { return (int)(TR_0 >> 00) & 0x0f; } set { TR_0 = (byte)((TR_0 & ~(0x0f << 00)) | (byte)((value > 0xf ? 0xf : value) << 00)); } }
        
        public byte TR_1 { get { return Data[0x517]; } set {  Data[0x517] = (byte) value; } }
        public int TR_1_speedUP { get { return (int)(TR_1 >> 00) & 0x0f; } set { TR_1 = (byte)((TR_1 & ~(0x0f << 00)) | (byte)((value > 0xf ? 0xf : value) << 00)); } }
        public int TR_1_defUP { get { return (int)(TR_1 >> 04) & 0x0f; } set { TR_1 = (byte)((TR_1 & ~(0x0f << 04)) | (byte)((value > 0xf ? 0xf : value) << 04)); } }
        
        public byte TR_2 { get { return Data[0x518]; } set {  Data[0x518] = (byte) value; } }
        public int TR_2_espUP { get { return (int)(TR_2 >> 00) & 0x0f; } set { TR_2 = (byte)((TR_2 & ~(0x0f << 00)) | (byte)((value > 0xf ? 0xf : value) << 00)); } }
        public int TR_2_accUP { get { return (int)(TR_2 >> 04) & 0x0f; } set { TR_2 = (byte)((TR_2 & ~(0x0f << 04)) | (byte)((value > 0xf ? 0xf : value) << 04)); } }
        
        public byte TR_3 { get { return Data[0x519]; } set {  Data[0x519] = (byte) value; } }
        public bool TR_3_guardspec { get { return Convert.ToBoolean((TR_3 >> 07) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 07)) | (byte)((value == true ? 0x01 : 0x00) << 07)); } }
        public bool TR_3_lvlUP { get { return Convert.ToBoolean((TR_3 >> 06) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 06)) | (byte)((value == true ? 0x01 : 0x00) << 06)); } }
        public bool TR_3_clearSleep { get { return Convert.ToBoolean((TR_3 >> 05) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 05)) | (byte)((value == true ? 0x01 : 0x00) << 05)); } }
        public bool TR_3_clearPoison { get { return Convert.ToBoolean((TR_3 >> 04) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 04)) | (byte)((value == true ? 0x01 : 0x00) << 04)); } }
        public bool TR_3_clearBurn { get { return Convert.ToBoolean((TR_3 >> 03) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 03)) | (byte)((value == true ? 0x01 : 0x00) << 03)); } }
        public bool TR_3_clearIce { get { return Convert.ToBoolean((TR_3 >> 02) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 02)) | (byte)((value == true ? 0x01 : 0x00) << 02)); } }
        public bool TR_3_clearPar { get { return Convert.ToBoolean((TR_3 >> 01) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 01)) | (byte)((value == true ? 0x01 : 0x00) << 01)); } }
        public bool TR_3_clearConf { get { return Convert.ToBoolean((TR_3 >> 00) & 0x01); } set { TR_3 = (byte)((TR_3 & ~(0x01 << 00)) | (byte)((value == true ? 0x01 : 0x00) << 00)); } }
        
        public byte TR_4 { get { return Data[0x51A]; } set {  Data[0x51A] = (byte) value; } }
        public bool TR_4_stone { get { return Convert.ToBoolean((TR_4 >> 07) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 07)) | (byte)((value == true ? 0x01 : 0x00) << 07)); } }
        public bool TR_4_revive { get { return Convert.ToBoolean((TR_4 >> 06) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 06)) | (byte)((value == true ? 0x01 : 0x00) << 06)); } }
        public bool TR_4_maxPPUP { get { return Convert.ToBoolean((TR_4 >> 05) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 05)) | (byte)((value == true ? 0x01 : 0x00) << 05)); } }
        public bool TR_4_onlyatack { get { return Convert.ToBoolean((TR_4 >> 04) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 04)) | (byte)((value == true ? 0x01 : 0x00) << 04)); } }
        public bool TR_4_healPP { get { return Convert.ToBoolean((TR_4 >> 03) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 03)) | (byte)((value == true ? 0x01 : 0x00) << 03)); } }
        public bool TR_4_healHP { get { return Convert.ToBoolean((TR_4 >> 02) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 02)) | (byte)((value == true ? 0x01 : 0x00) << 02)); } }
        public bool TR_4_atkEVUP { get { return Convert.ToBoolean((TR_4 >> 01) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 01)) | (byte)((value == true ? 0x01 : 0x00) << 01)); } }
        public bool TR_4_hpEVUP { get { return Convert.ToBoolean((TR_4 >> 00) & 0x01); } set { TR_4 = (byte)((TR_4 & ~(0x01 << 00)) | (byte)((value == true ? 0x01 : 0x00) << 00)); } }

        
        public byte TR_5 { get { return Data[0x51B]; } set {  Data[0x51B] = (byte) value; } }
        public bool TR_5_happy200 { get { return Convert.ToBoolean((TR_5 >> 07) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 07)) | (byte)((value == true ? 0x01 : 0x00) << 07)); } }
        public bool TR_5_happy100 { get { return Convert.ToBoolean((TR_5 >> 06) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 06)) | (byte)((value == true ? 0x01 : 0x00) << 06)); } }
        public bool TR_5_happy0 { get { return Convert.ToBoolean((TR_5 >> 05) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 05)) | (byte)((value == true ? 0x01 : 0x00) << 05)); } }
        public bool TR_5_ppMax { get { return Convert.ToBoolean((TR_5 >> 04) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 04)) | (byte)((value == true ? 0x01 : 0x00) << 04)); } }
        public bool TR_5_spdefEVUP { get { return Convert.ToBoolean((TR_5 >> 03) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 03)) | (byte)((value == true ? 0x01 : 0x00) << 03)); } }
        public bool TR_5_spatkEVUP { get { return Convert.ToBoolean((TR_5 >> 02) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 02)) | (byte)((value == true ? 0x01 : 0x00) << 02)); } }
        public bool TR_5_spEVUP { get { return Convert.ToBoolean((TR_5 >> 01) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 01)) | (byte)((value == true ? 0x01 : 0x00) << 01)); } }
        public bool TR_5_defEVUP { get { return Convert.ToBoolean((TR_5 >> 00) & 0x01); } set { TR_5 = (byte)((TR_5 & ~(0x01 << 00)) | (byte)((value == true ? 0x01 : 0x00) << 00)); } }
        
        public byte TR_6 { get { return Data[0x51C]; } set {  Data[0x51C] = (byte) value; } }
        public sbyte TR_7 { get { return (sbyte)Data[0x51D]; } set {  Data[0x51D] = (byte) value; } }
        public sbyte TR_8 { get { return (sbyte)Data[0x51E]; } set {  Data[0x51E] = (byte) value; } }
        public sbyte TR_9 { get { return (sbyte)Data[0x51F]; } set {  Data[0x51F] = (byte) value; } }
        
        public byte HPRecovery { 
        	get { 
        		if(TR_4_revive == true || TR_4_healHP == true)
        			return TR_6;
        		else
        			return 0;
        	} 
        	set {
        		if(TR_4_revive == true || TR_4_healHP == true)
        			TR_6 = (byte) value; 
        	} }
        public byte PPRecovery { 
        	get { 
        		if(TR_4_healPP == true)
        			return TR_6;
        		else
        			return 0;
        	} 
        	set {
        		if(TR_4_healPP == true)
        			TR_6 = (byte) value; 
        	} }
        public sbyte EVchange {
        	get {
        		if(TR_5_spEVUP == true || TR_5_defEVUP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true )
        			return (sbyte)TR_6;
        		else
        			return 0;
        	} 
        	set {
        		if(TR_5_spEVUP == true || TR_5_defEVUP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true )
        				TR_6 = (byte) value; 
        	} }
        
        public sbyte Happy200 { 
        	get {
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        			return (sbyte)TR_7;
        		else
        			return (sbyte)TR_6;
        	} set {  
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        			TR_7 = (sbyte) value;
        		else
	        		TR_6 = (byte) value; 
        	} }
        public sbyte Happy100 { 
        	get {
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        		{
        			if(TR_5_happy200 == true)
        				return (sbyte)TR_8;
        			else
        				return (sbyte)TR_7;
        		}
        		else{
        			if(TR_5_happy200 == true)
        				return (sbyte)TR_7;
        			else
        				return (sbyte)TR_6;
        		}
        	} set {  
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        		{
        			if(TR_5_happy200 == true)
        				TR_8 = (sbyte) value;
        			else
        				TR_7 = (sbyte) value;
        		}
        			
        		else{
        			if(TR_5_happy200 == true)
        				TR_7 = (sbyte) value; 
        			else
        				TR_6 = (byte) value; 
        		}

        	} }
        public sbyte Happy0 { 
        	get {
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        		{
        			if(TR_5_happy200 == true){
        				if(TR_5_happy100 == true){
        					return (sbyte)TR_9;
        				}else{
        					return (sbyte)TR_8;}
        			}else{
        				if(TR_5_happy100 == true){
        					return (sbyte)TR_8;}
        				else{
        					return (sbyte)TR_7;
        				}
        			}
        		}
        		else{
        			if(TR_5_happy200 == true){
        				if(TR_5_happy100 == true){
        					return (sbyte)TR_8;}
        				else{
        					return (sbyte)TR_7;}
        			}else{
    					if(TR_5_happy100 == true){
        					return (sbyte)TR_7;}
        				else{
        					return (sbyte)TR_6;}
        			}
        		}
        	} set {  
        		if(TR_4_revive == true || TR_4_healHP == true || TR_4_healPP == true || TR_4_atkEVUP == true || 
        		   TR_4_hpEVUP == true || TR_5_spdefEVUP == true || TR_5_spatkEVUP == true ||
        		   TR_5_spEVUP == true || TR_5_defEVUP == true)
        		{
        			if(TR_5_happy200 == true){
        				if(TR_5_happy100 == true)
        					TR_9 = (sbyte) value;
        				else
        					TR_8 = (sbyte) value;
        			}else{
        				if(TR_5_happy100 == true)
        					TR_8 = (sbyte) value;
        				else
        					TR_7 = (sbyte) value;
        			}
        		}
        			
        		else{
        			if(TR_5_happy200 == true){
        				if(TR_5_happy100 == true)
        					TR_8 = (sbyte) value;
        				else
        					TR_7 = (sbyte) value;
        			}else{
        				if(TR_5_happy100 == true)
        					TR_7 = (sbyte) value;
        				else
        					TR_6 = (byte) value;
        			}
        		}

        	} }
        
        
        
        
	}
}
