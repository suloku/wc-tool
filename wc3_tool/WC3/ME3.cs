/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 02/05/2016
 * Time: 23:22
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
	/// Description of ME3.
	/// </summary>
	public class ME3
	{
		
		public int isemerald = -1;
		
        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        private int me3_size;
        
        public ME3(byte[] data, int size)
        {
        	me3_size = size;
            Data = (byte[])(data ?? new byte[me3_size]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
            
            isEmerald();

            return;
        }
        
        public int isEmerald()
        {
        	//Get checksum in script
        	UInt32 chk_scr = BitConverter.ToUInt32(getData(0, 4), 0);
        	
        	//RS checksum
        	UInt32 chk_RS = me3_checksum(getData(4, me3_size-4-8), me3_size-4-8);
        	
        	//E checksum
        	UInt32 chk_E = (UInt32) wc3.wc_checksum(getData(4, me3_size-4-8), me3_size-4-8, 0);
        	
        	if (chk_scr == chk_RS)
        	{
        		isemerald = 0;
        		return isemerald;
        	}else if (chk_scr == chk_E)
        	{
        		isemerald = 1;
        		return isemerald;
        	}else{
				DialogResult dialogResult = MessageBox.Show("ME3 file script has wrong checksum. Is this a Ruby/Sapphire mystery event?", "Wrong checksum", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.Yes)
				{
					isemerald = 0;
				}
				else if (dialogResult == DialogResult.No)
				{
					isemerald = 1;
				}
				return isemerald;
        	}
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
        
        public byte MAP_BANK { get { return Data[0x05]; } set {  Data[0x05] = (byte) value; } }
        public byte MAP_MAP { get { return Data[0x06]; } set {  Data[0x06] = (byte) value; } }
        public byte MAP_PERSON { get { return Data[0x07]; } set {  Data[0x07] = (byte) value; } }
        
        public byte[] get_script()
        {
        	
        	int scriptsize=0;
        	int i = 0;
        	for (i=0; i<me3_size-4-4-8; i++) //Leave out checksum (4), header(4) and item structure (8)
        	{
        		if(Data[me3_size-8-i-1] == 0xFF)
        			break;
        		else
        			scriptsize++;
        	}
        	return getData(8, 996-scriptsize);
        	
        }
        public byte[] get_script_XSE()
        {
        	//Get base address
        	UInt32 address = BitConverter.ToUInt32(getData(0X9, 4), 0);
        	address = address - (address&0xFF000000);
        	//Build file
        	byte[] xse_export = new byte[address+996];
        	//Set address to the first 4 bytes
        	if (address > 3)
        		BitConverter.GetBytes(address).CopyTo(xse_export, 0);
        	MessageBox.Show("Open script in XSE at address 0x"+address.ToString("X"));
        	//Set script to buffer
        	getData(0x8, 996).CopyTo(xse_export, address);
        	return xse_export;
        }
        public void set_script(byte[] newscript)
        {
			//Clear existing script
        	int i = 0;
        	for (i=8; i<996+8; i++)
        	{
        		Data[i] = 0x00;
        	}
        	UInt32 header = 0x01010833;
        	setData(BitConverter.GetBytes(header).ToArray(), 4);
        	setData(newscript, 8);
        }
        
		public void set_script_XSE(byte[] newscript)
        {
        	//Clear existing script
        	int i = 0;
        	for (i=8; i<996+8; i++)
        	{
        		Data[i] = 0x00;
        	}
        	//Get address to script
        	UInt32 address = BitConverter.ToUInt32(newscript, 4);
        	
			UInt32 header = 0x01010833;
        	setData(BitConverter.GetBytes(header).ToArray(), 4);
        	setData(newscript.Skip((int)address).ToArray(), 8);
        }        
        
        public byte get_item_amount()
        {
        	return getData(me3_size-4, 1)[0];
        }
        public byte get_item_counter()
        {
        	return getData(me3_size-3, 1)[0];
        }
        public UInt16 get_item()
        {
        	return BitConverter.ToUInt16(getData(me3_size-2, 2), 0);
        }
        public void set_item_amount(byte amount)
        {
        	Data[me3_size-4] = amount;
        }
        public void set_item_counter(byte counter)
        {
        	Data[me3_size-3] = counter;
        }
        public void set_item(UInt16 item)
        {
        	setData( BitConverter.GetBytes(item).ToArray(), me3_size-2);
        }

		public static UInt32 me3_checksum(byte[] buffer, int length)
		{
			int i=0;
			UInt32 Chk = 0;
			for(i=0; i<length; i++){
				Chk = unchecked( Chk + buffer[i]);
			}
			//MessageBox.Show(Chk.ToString("X"));
		    return Chk;
		}
        public void fix_me_item_checksum()
        {
        	UInt32 chk = me3_checksum(getData(me3_size-4, 0x4), 0x4);
        	setData(BitConverter.GetBytes(chk), me3_size-8);
        }
        public void fix_me_script_checksum()
        {
        	UInt32 chk = 0;
        	//if (has_script() == true)
        		//fake_script();
        	if (isemerald == 1)
        	{
				chk = (UInt32) wc3.wc_checksum(getData(4, me3_size-4-8), me3_size-4-8, 0);
        	}
        	else{
        		chk = me3_checksum(getData(4, me3_size-4-8), me3_size-4-8);
        	}
        	setData(BitConverter.GetBytes(chk), 0);
        }
        private void fake_script()
        {
        	if(Data[me3_size-8] == 0x00)
        		Data[me3_size-8] = 0xFF;
        }
        public bool has_script()
        {
        	UInt32 header;
        	header = BitConverter.ToUInt32(Data, 4);
        	
        	if (header != 0x00){
        		return true;
        	}else{
        		return false;}
        }
        public void removeScript()
        {
        	int i;
        	for(i=0;i<me3_size-8;i++)
        	{
        		Data[i] = 0x00;
        	}
        }
	}
}
