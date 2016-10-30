/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 03/05/2016
 * Time: 20:54
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
	/// Description of ECT.
	/// </summary>
	public class ECT
	{
		public const int SIZE_ECT = 188;
		
        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        public ECT(byte[] data)
        {
            Data = (byte[])(data ?? new byte[SIZE_ECT]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
          
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
		public static UInt32 ect_checksum(int length, byte[] Data)
		{
			UInt32 Chk = 0;
			int i;
			length = length>>2;
			Chk=0;
			for(i=0; i<length; i++){
				Chk = unchecked( Chk + (UInt32) BitConverter.ToUInt32(Data, i*4));
			}
			return Chk;
		}
		public void fix_ect_checksum()
		{
			UInt32 Chk = ect_checksum(SIZE_ECT-4, Data);
			//MessageBox.Show("Checksum: " + Chk.ToString("X"));
			setData(BitConverter.GetBytes(Chk).ToArray(), SIZE_ECT-4);
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
        public string gba2text(byte[] input)
        {
        	string texto;
        	texto = "";
        	foreach (byte value in input)
        	{
        		if (value == 0xFF)
        			break;
        		else{
        			string newtext = texto + SYMBOL[value].ToString();
        			texto = newtext;
        		}
        	}
        	return texto;
		}
        public byte[] text2gba(string input, int len)
        {
        	byte[] gbatext = new byte[len];
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
        	if (count < len)
        		gbatext[count] = 0xFF;
        	return gbatext;
		}
	}
}
