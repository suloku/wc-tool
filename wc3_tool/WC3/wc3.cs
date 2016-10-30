/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 28/04/2016
 * Time: 21:32
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

using PKHeX;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of wc3.
	/// </summary>
	public class wc3
	{

		private static UInt16[] lookup_table = new UInt16[256];
		
		private static void init_table()
		{
		        //Sorry, this is not public for now.
		}
		
		private static UInt16 swap(UInt16 value)
		{
		    int b1 = value & 0xFF;
		    int b2 = value >> 8 & 0xFF;
		    return (UInt16)(b1 << 8 | b2 << 0);
		}
		
		public static UInt16 wc_checksum(byte[] buffer, int fSize, int offset)
		{
			init_table();
		    UInt16 iSeed = 0;//Also not public...sorry again
		    UInt16 tabNum;
		    UInt16 tabVal;
		    int curByte = 0;
		    for (curByte=0; curByte<fSize; curByte++)
		    {
		    	tabNum  = (UInt16)((iSeed ^ buffer[curByte+offset]) & 0xFF);
		    	//MessageBox.Show(tabNum.ToString());
		        tabVal = lookup_table[tabNum];
		        //MessageBox.Show(tabVal.ToString());
		        tabVal = (UInt16)(swap(tabVal) & 0xFFFF);
		        iSeed = (UInt16)((tabVal ^ (iSeed >> 8)) & 0xFFFF);
		    }
		    iSeed = (UInt16)((iSeed ^ 0xFFFF) & 0xFFFF);
		
		    return iSeed;
		}
		
		char[] SYMBOL = {
		' ', 'À', 'Á', 'Â', 'Ç', 'È', 'É', 'Ê', 'Ë', 'Ì', 'こ', 'Î', 'Ï', 'Ò', 'Ó', 'Ô',
		'Œ', 'Ù', 'Ú', 'Û', 'Ñ', 'ß', 'à', 'á', 'ね', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'ま',
		'î', 'ï', 'ò', 'ó', 'ô', 'œ', 'ù', 'ú', 'û', 'ñ', 'º', 'ª', ' ', '&', '+', 'あ',
		'ぃ', 'ぅ', 'ぇ', 'ぉ', ' ', '=', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
		' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
		' ', '¿', '¡', ' ', ' ', ' ', ' ', ' ', ' ', '<', 'Í', '%', '(', ')', ' ', ' ',
		' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'â', ' ', ' ', ' ', ' ', ' ', ' ', 'í',
		' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
		' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
		'ゾ', 'ダ', 'ヂ','ヅ', 'デ', 'ド', 'バ', 'ビ', 'ブ', 'ベ', 'ボ', 'パ', 'ピ', 'プ', 'ペ', 'ポ',
		'ッ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '?', '.', '-', '·',
		'…', '“', '”', '‘', '\'', '♂', '♀', '§', ',', '×', '/', 'A', 'B', 'C', 'D', 'E',
		'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
		'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
		'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '>',
		':', 'Ä', 'Ö', 'Ü', 'ä', 'ö', 'ü', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'
		};

        public const int SIZE_WC3 = 0x4 + 0x14C + 0x28 + 0x28 + 0x3E8 + 4;
        public const int SIZE_WC3_jap = 0x4 + 0xA4 + 0x28 + 0x28 + 0x3E8 + 4;
        public const int ICON_WC3 = 0x4 + 0x14C + 10;
        public const int ICON_WC3_jap = 0x4 + 0xA4 + 10;
        
        public const int SIZE_WN3 = 4+4+440; //Checksum + header + Data (40bytes*11 lines)
        public const int SIZE_WN3_jap = 4+4+220; //Checksum + header + Data (20bytes*11 lines)
        
        public const int WC_TEXT_START = 14;
        public const int WCN_TEXT_START = 8;
        
        public byte cardcolor;
        public int distributable;

        private int text_start = 0;
        private int wc3_size = 0;
        private int wn_size = 0;
        public bool japanese = false;

        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        public wc3(byte[] data)
        {
        	
        	if(data.Length == SIZE_WN3 || data.Length == SIZE_WN3_jap) //WN3
        	{
	            Data = (byte[])(data ?? new byte[data.Length]).Clone();
	            BAK = (byte[])Data.Clone();
	            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
	            
		        if ( Data[0x06] == 0x1)
		        	distributable = 1;
		        else
		        	distributable = 0;
		        
		        cardcolor = Data[0x07];
		        
		        text_start = WCN_TEXT_START;
		        
		        if(data.Length == SIZE_WN3_jap)
		        	japanese = true;
		        
		        if (japanese == true)
		        	wn_size = SIZE_WN3_jap;
	        	else
	        		wn_size = SIZE_WN3;
        	}
	        else //WC3
        	{
	        	
	            Data = (byte[])(data ?? new byte[data.Length]).Clone();
	            BAK = (byte[])Data.Clone();
	            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
	
	            if(data.Length == SIZE_WC3_jap)
		        	japanese = true;
		       
	            if (japanese == true)
		        	wc3_size = SIZE_WC3_jap;
				else
	        		wc3_size = SIZE_WC3;
	            
		        if ( (Data[0xC] & 0x80) == 0x80)
		        	distributable = 1;
		        else if ( (Data[0xC] & 0x40) == 0x40)
		        	distributable = 2;
		        else
		        	distributable = 0;
 
		        cardcolor = (byte)(Data[0xC] & ~0x80);   
		        text_start = WC_TEXT_START;
        	}
            
            return;
        }
/*        public wc3(byte[] data, int wcn)
        {
            Data = (byte[])(data ?? new byte[SAV3.WCN_SIZE]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);

	        if ( Data[0x06] == 0x1)
	        	distributable = 1;
	        else
	        	distributable = 0;
	        
	        cardcolor = Data[0x07];
	        
	        text_start = WCN_TEXT_START;
	        if (japanese == true)
	        	wn_size = WCN
            
            return;
        }
 */
        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
            Edited = true;
        }
        public string gba2text(byte[] input)
        {
        	string texto;
        	texto = "";
        	foreach (byte value in input)
        	{
        		string newtext = texto + SYMBOL[value].ToString();
        		texto = newtext;
        	}
        	return texto;
		}
        public byte[] text2gba(string input)
        {
        	byte[] gbatext = new byte[40];
        	byte i = 0;
        	int count = 0;
        	foreach (char value in input)
        	{
        		for(i=0;i<0xFF;i++)
        		{
	        		if (value == SYMBOL[i])
	        		{
	        			if (i==0)
	        			{
	        				gbatext[count] = 0;
	        				break;
	        			}
	        			else
	        			{
	        				gbatext[count] = i;
	        				break;
	        			}
	        		}
	        			
        		}

        		//MessageBox.Show(gbatext[count].ToString("X"));
        		count++;
        	}
        	return gbatext;
		}

        public UInt16 get_wc_icon()
        {
        	if(japanese == true)
        		return BitConverter.ToUInt16(getData(ICON_WC3_jap, 2), 0);
        	else
        		return BitConverter.ToUInt16(getData(ICON_WC3, 2), 0);
        }
        public int get_wc_color()
        {
        	int colorgui;
        	byte test = (byte)(cardcolor&0x1F);
        	switch (test)
        	{
        		case 0x0:
        		case 0x1:
        		case 0x2:
        		case 0x3:
        			colorgui = 0;
        			break;
        		case 0x4:
        		case 0x5:
        		case 0x6:
        		case 0x7:
        			colorgui = 1;
        			break;
        		case 0x8:
        		case 0x9:
        		case 0xA:
        		case 0xB:
        			colorgui = 2;
        			break;
        		case 0xC:
        		case 0xD:
        		case 0xE:
        		case 0xF:
        			colorgui = 3;
        			break;
        		case 0x10:
        		case 0x11:
        		case 0x12:
        		case 0x13:
        			colorgui = 4;
        			break;
        		case 0x14:
        		case 0x15:
        		case 0x16:
        		case 0x17:
        			colorgui = 5;
        			break;
        		case 0x18:
        		case 0x19:
        		case 0x1A:
        		case 0x1B:
        			colorgui = 6;
        			break;
        		case 0x1C:
        		case 0x1D:
        		case 0x1E:
        		case 0x1F:
        			colorgui = 7;
        			break;
        		default:
        			colorgui = 0;
        			break;
        	}
        		
        	return colorgui;
        }
        public void set_wc_icon(int newicon)
        {
        	if (japanese == true)
        	{
        		setData(BitConverter.GetBytes((UInt16)newicon), ICON_WC3_jap);
        	}
        	else
        	{
        		setData(BitConverter.GetBytes((UInt16)newicon), ICON_WC3);
        	}
        	
        }
        public void set_wcn_color_distro(int color, int distro)
        {
		    if (distro == 1)
		    	Data[0x06] = 0x01;
			if (distro == 2)
		    	Data[0x06] = 0x02;//Does not allow distribution either. More testing needed.
		    else
		    	Data[0x06] = 0x00;
		    
		    Data[0x07] = (byte)(color&0xFF);
        }
        public void set_wc_color_distro(int color, int distro)
        {
        	byte output = 0;
        	switch (color)
        	{
        		case 0x0:
        			output = 0x00;
        			break;
        		case 0x1:
        			output = 0x04;
        			break;
        		case 0x2:
        			output = 0x08;
        			break;
        		case 0x3:
        			output = 0x0C;
        			break;
        		case 0x4:
        			output = 0x10;
        			break;
        		case 0x5:
        			output = 0x14;
        			break;
        		case 0x6:
        			output = 0x18;
        			break;
        		case 0x7:
        			output = 0x1C;
        			break;
        		default:
        			output = 0x00;
        			break;
        	}
        	
		    if (distro == 1)
		    	output = (byte)(output + 0x80);
		    else if (distro == 2)
		    	output = (byte)(output + 0x40);
		    
		    Data[0xC] = output;
        }
        public string get_wc_text(int index)
        {
        	return gba2text(Data.Skip(text_start+(index * 0x28)).Take(0x28).ToArray());
        }
        public string get_wc_text_2(int index)
        {
        	int size = 0x28;
        	int[] offset = {0,40,80,120,160,200,240,280};
        	if (japanese == true)
        	{
        		offset[0]=0;offset[1]=18;offset[2]=18+13;offset[3]=18+13+20;
        		offset[4]=18+13+40;offset[5]=18+13+60;offset[6]=18+13+80;offset[7]=18+13+100;
        		switch(index)
        		{
        			case 0:
        				size = 18;
        				break;
        			case 1:
        				size = 13;
        				break;
        			default:
        				size = 20;
        				break;
        		}
        	}
        	return PKHeX.PKM.getG3Str(Data.Skip(text_start+(offset[index])).Take(size).ToArray(), japanese);
        }
        public void insert_wc_text(string text, int index)
        {
        	setData(text2gba(text), text_start+(index * 0x28));
        }
        public void insert_wc_text_2(string text, int index)
        {
        	int[] offset = {0,40,80,120,160,200,240,280};
        	if (japanese == true)
        	{
        		offset[0]=0;offset[1]=18;offset[2]=18+13;offset[3]=18+13+20;
        		offset[4]=18+13+40;offset[5]=18+13+60;offset[6]=18+13+80;offset[7]=18+13+100;
        	}
        	setData(PKHeX.PKM.setG3Str_WONDER(text, japanese), text_start+offset[index]);
        }
        public void clear_wc_text()
        {
        	int i;
        	if (japanese == true)
        	{
        		for(i=0;i<(18+13+(20*6));i++)
        		    Data[text_start+i]=0x00;
        	}else
        	{
        		for(i=0;i<(40*8);i++)
        		    Data[text_start+i]=0x00;
        	}
        }
        public void clear_wn_text()
        {
        	int i;
        	if (japanese == true)
        	{
        		for(i=0;i<(20*11);i++)
        		    Data[text_start+i]=0x00;
        	}else
        	{
        		for(i=0;i<(40*11);i++)
        		    Data[text_start+i]=0x00;
        	}
        }
        public string get_wn_text_2(int index)
        {
        	int size = 0x28;
        	int[] offset = {0,40,80,120,160,200,240,280,320,360,400};
        	if (japanese == true)
        	{
        		size = 0x14;
        		int i;
        		for (i=0;i<11;i++){
        			offset[i]=(0x14*i);
        		}
        	}
        	return PKHeX.PKM.getG3Str(Data.Skip(text_start+(offset[index])).Take(size).ToArray(), japanese);
        }
        public void insert_wn_text_2(string text, int index)
        {
        	int[] offset = {0,40,80,120,160,200,240,280,320,360,400};
        	if (japanese == true)
        	{
        		int i;
        		for (i=0;i<11;i++){
        			offset[i]=(0x14*i);
        		}
			}
        	setData(PKHeX.PKM.setG3Str_WONDER(text, japanese), text_start+offset[index]);
        }
        public void fakeWC()
        {
        	UInt32 fakemagic = 0xB9BEB4BA;
        	setData(BitConverter.GetBytes(fakemagic), 4);
        }
        public void fakeSCript()
        {
        	//This value is actually to whom the script is associated, changing it removes it from green deliveryman
        	//UInt32 fakemagic = 0x01000333;
        	UInt32 fakemagic = 0xFFFFFF33;//Value in the wondercard routine, triggers green man.
        	setData(BitConverter.GetBytes(fakemagic), wc3_size-1000);
        }
        public void clean_trash()
        {
        	int i = 0;
        	for (i=0; i<996; i++)
        	{
        		if(Data[wc3_size-i-1] == 0xFF)
        			break;
        		else
        			Data[wc3_size-i-1] = 0;
        	}
        }
        public void fix_wcn_checksum()
        {
        	UInt16 chk = wc_checksum(getData(4, wn_size-4), wn_size-4, 0);
        	setData(BitConverter.GetBytes(chk), 0);
        }
        public void fix_wc_checksum()
        {
        	UInt16 chk;
        	if(japanese == true)
        	{
        		chk = wc_checksum(getData(4, 0xA4), 0xA4, 0);
        	}
        	else
        	{
        		chk = wc_checksum(getData(4, 0x14C), 0x14C, 0);
        	}
        	
        	setData(BitConverter.GetBytes(chk), 0);
        }
        public void fix_script_checksum()
        {
        	UInt16 chk = wc_checksum(getData(wc3_size-1000, 1000), 1000, 0);
        	setData(BitConverter.GetBytes(chk), wc3_size-1004);
        }
        public byte[] get_script()
        {
        	int scriptsize=0;
        	//int i = 0;
        	//Not how to detect the end of the script...
        	/*for (i=0; i<996; i++)
        	{
        		if(Data[wc3_size-i-1] == 0xFF)
        			break;
        		else
        			scriptsize++;
        	}*/
        	return getData(wc3_size-996, 996-scriptsize);
        }
        public byte[] get_script_XSE()
        {
        	//Get base address
        	UInt32 address = BitConverter.ToUInt32(getData(wc3_size-996+1, 4), 0);
        	address = address - (address&0xFF000000);
        	//Build file
        	byte[] xse_export = new byte[address+996];
        	//Set address to the first 4 bytes
        	if (address > 3)
        		BitConverter.GetBytes(address).CopyTo(xse_export, 0);
        	MessageBox.Show("Open script in XSE at address 0x"+address.ToString("X"));
        	//Set script to buffer
        	getData(wc3_size-996, 996).CopyTo(xse_export, address);
        	return xse_export;
        }
        public void set_script(byte[] newscript)
        {
        	//UInt32 header = 0xFFFFFF33;
        	//setData(BitConverter.GetBytes(header).ToArray(), wc3_size-1000);
        	//Clear existing script
        	int i = 0;
        	for (i=0; i<996; i++)
        	{
        		Data[wc3_size-i-1] = 0x00;
        	}
        	setData(newscript, wc3_size-996);
        }
        public void set_script_XSE(byte[] newscript)
        {
        	//Clear existing script
        	int i = 0;
        	for (i=0; i<996; i++)
        	{
        		Data[wc3_size-i-1] = 0x00;
        	}
        	//Get address to script
        	UInt32 address = BitConverter.ToUInt32(newscript, 0);       	
        	setData(newscript.Skip((int)address).Take(996).ToArray(), wc3_size-996);
        }
        public byte ID { get { return Data[wc3_size-1000]; } set { Data[wc3_size-1000] = value; } }
        public byte MAP_BANK { get { return Data[wc3_size-999]; } set { Data[wc3_size-999] = value; } }
        public byte MAP_MAP { get { return Data[wc3_size-998]; } set { Data[wc3_size-998] = value; } }
        public byte MAP_NPC { get { return Data[wc3_size-997]; } set { Data[wc3_size-997] = value; } }
	}
}
