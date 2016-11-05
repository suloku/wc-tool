/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 29/04/2016
 * Time: 14:00
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
	/// Description of SAV3.
	/// </summary>
	public class SAV3
	{
		
		public const int SAVE_SIZE = 0x20000;
		
		UInt16[] DATALEN;
		//UInt16[] FRLGMAP = { 0xF24,0xF80,0xF80,0xF80,0xEC0,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0x7D0,0x01C,0x100};
		UInt16[] FRLGMAP = { 0xF24,0xF80,0xF80,0xF80,0xEE8,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0x7D0,0x01C,0x100};
		UInt16[] RSMAP = { 0x890,0xF80,0xF80,0xF80,0xC40,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0x7D0,0xF80,0xF80};
		UInt16[] EMAP = { 0xF2C,0xF80,0xF80,0xF80,0xF08,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0xF80,0x7D0,0xF80,0xF80 };
		
		private const int TEAM_RSE = 0x234;
		private const int TEAM_FRLG = 0x034;
		private int team_offset = 0x234;
		
		private const int BERRY_OFFSET_RS = 0x2E0;
		public const int BERRY_SIZE = 0x530;
		
		private const int WC_OFFSET_E = 0x56C;
		private const int WC_SCRIPT_OFFSET_E = 0x8A8;
		private const int WC_OFFSET_FRLG = 0x460;
		private const int WC_SCRIPT_OFFSET_FRLG = 0x79C;
		
		private const int WC_OFFSET_E_jap = 0x490;
		private const int WC_SCRIPT_OFFSET_E_jap = 0x8A8;
		private const int WC_OFFSET_FRLG_jap = 0x384;
		private const int WC_SCRIPT_OFFSET_FRLG_jap = 0x79C;
		
		private const int WCN_OFFSET_E = 0x3AC;
		private const int WCN_OFFSET_FRLG = 0x2A0;
		public const int WCN_SIZE = wc3.SIZE_WN3; //Checksum + header + Data (40bytes*11 lines)
		
		private const int WCN_OFFSET_E_jap = 0x3AC;
		private const int WCN_OFFSET_FRLG_jap = 0x2A0;
		public const int WCN_SIZE_jap = wc3.SIZE_WN3_jap; //Checksum + header + Data (20bytes*11 lines)
		
		private const int ME3_OFFSET_E = 0x8A8;
		public const int ME3_SIZE_E = 1012;
		private const int ME3_SCRIPT_SIZE_E = ME3_SIZE_E-8;
		private const int ME3_OFFSET_RS = 0x810;
		public const int ME3_SIZE_RS = 1012;
		private const int ME3_SCRIPT_SIZE_RS = 1004;
		private const int ME3_ITEM_SIZE = 8;
		
		private const int ECT_OFFSET_RS = 0x498;
		private const int ECT_OFFSET_E = 0xBEC;
		private const int ECT_OFFSET_FRLG = 0x4A0;
		
		//TV show offsets
		private const int TV_EVENT_RS = 0xBBC;
		private const int TV_OUTBREAK_RS = 0x85C;
		private const int TV_SHOWS_RS = 0x8EC;
		private const int TV_OUTBREAK_DATA_RS = 0xBFC;
		
		private const int TV_EVENT_E = 0xC50;
		private const int TV_OUTBREAK_E = 0x8CC;
		private const int TV_SHOWS_E = 0x980;
		private const int TV_OUTBREAK_DATA_E = 0xC90;
		
		
        // Global Settings
        // Save Data Attributes
        public byte[] Data;
        public bool Edited;
        public readonly bool Exportable;
        public readonly byte[] BAK;
        public string FileName, FilePath;
        
        public bool isvalid = true;
        public int game = -1;
        public bool has_WC = false;
        public bool has_WCN = false;
        public bool has_mistery_gift = false;
        public bool has_mistery_event = false;
        
        public bool isjap = false;
        public int language = 0;
        
        byte[] boxbuffer = new byte[(3968*8)+2000];
/*
0x0201	Japanese
0x0202	English
0x0203	French
0x0204	Italian
0x0205	German
0x0206	Korean*
0x0207	Spanish
*/
        
        private int wc_offset;
        private int wc_script_offset;
        private int wcn_offset;
        private int me3_offset;
        public int me3_size;
        private int ect_offset;
        private int tv_event_offset;
        private int tv_outbreak_offset;
        private int tv_shows_offset;
        private int tv_outbreak_data_offset;
        
        private UInt16 noCash;
        private UInt32 oldSav = 0;
        private UInt32 currentSav = 0;
        private UInt32 sec0, s0, sx, x;
        private UInt32[] sec = new UInt32[14];
        
        public SAV3(byte[] data)
        {
            Data = (byte[])(data ?? new byte[SAVE_SIZE]).Clone();
            BAK = (byte[])Data.Clone();
            Exportable = !Data.SequenceEqual(new byte[Data.Length]);
            
            checkNocash();
            checkCurrentSav();
            
		    // get section locations in current save
		    for(s0 = 0; s0 <= 13; s0++){
		        sec0 = Data[0x0FF4 + 0x1000 * s0 + currentSav];
		        if (sec0 == 0x0){
		            for(sx = 0; sx <=13; sx++){
		                if((s0 + sx) <= 13){
		                    sec[sx] = s0 + sx;
		                }
		                else {
		                    sec[sx] = s0 + sx - 14;
		                }
		            }
		            break;
		        }
		    }
		    // check if all sections were found
		    for(x = 0; x <= 13; x++){
		        if(Data[0x0FF4 + 0x1000 * sec[x] + currentSav] != x){
		    		isvalid = false;
		        }
		    }
		    
		  	whichgame();//Here we set offsets and flags
		    buildBoxBuffer();//Needed for language detection
		    isJap();
		    getLanguage();
		    if (language == 1)
		    	isjap = true;

		}
        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public int getBlockOffset(int Offset, int block)
        {
        	return (int)(Offset + 0x1000 * sec[block] + currentSav);
        }
        public byte[] getDataFromBlock(int Offset, int Length, int block)
        {
        	return Data.Skip((int)(Offset + 0x1000 * sec[block] + currentSav)).Take(Length).ToArray();
        }
        public byte[] getDataFromBlock_old(int Offset, int Length, int block)
        {
        	if (block == 0)
        		return Data.Skip((int)(Offset + 0x1000 * sec[13] + oldSav)).Take(Length).ToArray();
        	else
        		return Data.Skip((int)(Offset + 0x1000 * sec[block-1] + oldSav)).Take(Length).ToArray();
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
            Edited = true;
        }
        public void setDataToBlock(byte[] input, int Offset, int block)
        {
            input.CopyTo(Data, Offset + 0x1000 * sec[block] + currentSav);
            Edited = true;
        }
        public void setDataToBlock_old(byte[] input, int Offset, int block)
        {
        	if (block == 0)
        		input.CopyTo(Data, Offset + 0x1000 * sec[13] + oldSav);
        	else
        		input.CopyTo(Data, Offset + 0x1000 * sec[block-1] + oldSav);
        	
            //input.CopyTo(Data, Offset + 0x1000 * sec[block] + oldSav);
            Edited = true;
        }
        public void prompt_region(string text)
        {
			DialogResult dialogResult = MessageBox.Show(text, "Region Input", MessageBoxButtons.YesNo);
			if(dialogResult == DialogResult.Yes)
			{
				isjap = true;
			}
			else if (dialogResult == DialogResult.No)
			{
				isjap = false;
			}
        }
        public void isJap()
        {
        	if (game == 2) //FR/LG
        	{
        		if (Data[getBlockOffset(0xbd2, 4)] != 0x00) // This will only not be 0x00 on USA/EUR save, but requires rival name to have at least 6 characters
        			isjap = false;
        		else if (language == 1)
        			isjap = true;
        		else
        			isjap = false;
        			//prompt_region("Can't autodetect region for FRLG.\n\nIs this a Japanese savegame?");
        	}
        	else
        	{
	        	if (Data[getBlockOffset(0x07, 0)] == 0x00)
	        		isjap = true;
	        	else
	        		isjap = false;
        	}
        }
        public void updateOffsets()
        {
        	switch(game)
        	{
        		case 0://Rubby/Sapphire
					DATALEN = RSMAP;
					team_offset = TEAM_RSE;
	
					if(isjap) //Todo different offsets in jap version???
					{
					}
					else
					{
					}
					me3_offset = ME3_OFFSET_RS;
		        	me3_size = ME3_SIZE_RS;
		        		
		        	ect_offset = ECT_OFFSET_RS;
		        	
		        	//TV data
					tv_event_offset = TV_EVENT_RS;
        			tv_outbreak_offset = TV_OUTBREAK_RS;
        			tv_shows_offset = TV_SHOWS_RS;
        			tv_outbreak_data_offset = TV_OUTBREAK_DATA_RS;
		        	
					break;
				case 1: //Emerald
					DATALEN = EMAP;
					team_offset = TEAM_RSE;
					
					if(isjap)
					{
						wc_offset = WC_OFFSET_E_jap;
						wc_script_offset = WC_SCRIPT_OFFSET_E_jap;
						wcn_offset = WCN_OFFSET_E_jap;
					}
					else
					{
						wc_offset = WC_OFFSET_E;
						wc_script_offset = WC_SCRIPT_OFFSET_E;
						wcn_offset = WCN_OFFSET_E;
					}
	
					me3_offset = ME3_OFFSET_E;
					me3_size = ME3_SIZE_E;
					
					ect_offset = ECT_OFFSET_E;
					
					//TV data
					tv_event_offset = TV_EVENT_E;
        			tv_outbreak_offset = TV_OUTBREAK_E;
        			tv_shows_offset = TV_SHOWS_E;
        			tv_outbreak_data_offset = TV_OUTBREAK_DATA_E;
					
					break;
				case 2: //Fire Red/Leaf Green
					DATALEN = FRLGMAP;
					team_offset = TEAM_FRLG;
					
					if(isjap)
					{
						wc_offset = WC_OFFSET_FRLG_jap;
						wc_script_offset = WC_SCRIPT_OFFSET_FRLG_jap;
						wcn_offset = WCN_OFFSET_FRLG_jap;
					}
					else
					{
						wc_offset = WC_OFFSET_FRLG;
						wc_script_offset = WC_SCRIPT_OFFSET_FRLG;
						wcn_offset = WCN_OFFSET_FRLG;
					}
	
					ect_offset = ECT_OFFSET_FRLG;
					
					break;
        	}
		    has_Mistery();
		    has_WC3();
		    hasWCN();
		    has_EggEvent_Flag();
        }
        public void whichgame()
        {
        	byte[] gamecode = getDataFromBlock(0x00AC, 4, 0);
        	if ( BitConverter.ToUInt32(gamecode, 0) == 0x00) {
				game = 0; // Ruby or Sapphire

			} else if (BitConverter.ToUInt32(gamecode, 0) == 0x01) {
				game = 2; //Fire Red or Leaf Green
			} else {
				game = 1; //Emerald
			}
        	updateOffsets();
        }
        private void buildBoxBuffer()
        {
        	//Build full box buffer
        	int i;
        	for (i=0; i<8; i++)
        	{
        		getDataFromBlock(0, 3968, 5+i).CopyTo(boxbuffer, i*3968);
        	}
        	getDataFromBlock(0, 2000, 13).CopyTo(boxbuffer, 8*3968);
        }
        public byte[] getPkmFromBox(int index, int box)
        {
        	
        	byte[] pkm = new byte[0x50];        	
        	boxbuffer.Skip(4+index*0x50+(0x50*30*box)).Take(0x50).ToArray().CopyTo(pkm, 0);
        	
        	return pkm;
        }
		
        public void getLanguage()
        {
        	int[] count = new int[7];
        	int i;
        	UInt16 lang;
        	
        	//Check party pokemon language
        	UInt32 teamSize = BitConverter.ToUInt32(getDataFromBlock(team_offset, 4, 1), 0);
		    if (teamSize > 6 || teamSize == 0)
		    	teamSize = 1;//Should never happen

		    for (i = 0; i < teamSize; i++)
		    {
		    	lang = BitConverter.ToUInt16(getDataFromBlock((team_offset+4) + (0x64*i) + 0x12, 2, 1), 0);
		    	switch (lang)
		    	{
		    		case 0x0201:
		    			count[0]++;
		    			break;
		    		case 0x0202:
		    			count[1]++;
		    			break;
		    		case 0x0203:
		    			count[2]++;
		    			break;
		    		case 0x0204:
		    			count[3]++;
		    			break;
		    		case 0x0205:
		    			count[4]++;
		    			break;
		    		case 0x0206:
		    			count[5]++;
		    			break;
		    		case 0x0207:
		    			count[6]++;
		    			break;
		    	}

		    }
        	//Check pc pokemon language
        	int box;
        	byte[] pkm;
        	for (box=0; box < 14; box++)
        	{
	        	for (i=0; i<30; i++)
	        	{
	        		pkm = getPkmFromBox(i, box);
	        		lang = BitConverter.ToUInt16(pkm, 0x12);
			    	switch (lang)
			    	{
			    		case 0x0201:
			    			count[0]++;
			    			break;
			    		case 0x0202:
			    			count[1]++;
			    			break;
			    		case 0x0203:
			    			count[2]++;
			    			break;
			    		case 0x0204:
			    			count[3]++;
			    			break;
			    		case 0x0205:
			    			count[4]++;
			    			break;
			    		case 0x0206:
			    			count[5]++;
			    			break;
			    		case 0x0207:
			    			count[6]++;
			    			break;
			    	}
	        	}
        	}

        	//Check Daycare pokemon language
/*
 * Todo
		RS offsets:
        	dayCare1Offset = 0x11C;
        	dayCare2Offset = 0x16C;

		Emerald offsets:
        	dayCare1Offset = 0x1B0;
        	dayCare2Offset = 0x23C;
        
		FRLG offsets?
*/

        	//Get the most frecuent language
        	for (i = 0; i<7; i++)
        	{
        		if (count.Max() == count[i]){
        			if(count[i]==0){
        				MessageBox.Show("Couldn't auto-detect savegame's language. Defaulting to English, please select the correct value");
        				language = 2; //Default to english
        			}else{
        				language = i+1;
        			}
        			break;
        		}
        	}
        	return;
        }
        
        public void hasWCN()
        {
        	byte[] wcn = new byte[0x4];
        	byte[] temp = getDataFromBlock(wcn_offset, 0x4, 4);// Checksum
        	
        	if (BitConverter.ToInt32(temp, 0) == 0)
        		has_WCN = false;
        	else
        		has_WCN = true;
        }
        
        public void has_WC3()
        {
        	byte[] wc3 = new byte[0x4];
        	byte[] temp = getDataFromBlock(wc_offset, 0x4, 4);// Checksum
        	
        	if (BitConverter.ToInt32(temp, 0) == 0)
        		has_WC = false;
        	else
        		has_WC = true;
        }
        public void has_Mistery()
        {
	        //Check if save has enabled mistery gift
	        byte[] check = new byte[1];
	        switch (game)
	        {
	            case 0://Not that it has wondercards...but let's see the code for it
	        		check = getDataFromBlock(0x3A9, 1, 2);
	        		if ( (check[0]&0x10) == 0)
	                  	has_mistery_event = false;
	                else
	                	has_mistery_event = true;
	                break;

	            case 1: //Emerald
	                check = getDataFromBlock(0x405, 1, 2);
	                if ( (check[0]&0x10) == 0)
	                  	has_mistery_event = false;
	                else
	                	has_mistery_event = true;

	                check = getDataFromBlock(0x40B, 1, 2);
	                if ( (check[0]&0x8) == 0)
	                  	has_mistery_gift = false;
	                else
	                	has_mistery_gift = true;
	                break;
	            case 2: //FRLG
	                check = getDataFromBlock(0x67, 1, 2);
	                if ( (check[0]&0x2) == 0)
	                  	has_mistery_gift = false;
	                else
	                	has_mistery_gift = true;
	                break;
	        }
        }
        public void enable_Mistery() //TO DO: emerald mistery event on non-jap?
        {
	        //Check if save has enabled mistery gift
	        byte[] check = new byte[1];
	        switch (game)
	        {
	            case 0://Not that it has wondercards...but let's see the code for it
	        		check = getDataFromBlock(0x3A9, 1, 2);
	        		if ( (check[0]&0x10) == 0){
	        			Data[getBlockOffset(0x3A9, 2)] = (byte)(check[0]|0x10);
	        			update_section_chk(2);
	        		}
	                break;

	            case 1: //Emerald
	                if (isjap == true) // Mistery event. Save gets deleted if enabled in EUR/USA version
	                {
		                check = getDataFromBlock(0x405, 1, 2);
		        		if ( (check[0]&0x10) == 0){
		        			Data[getBlockOffset(0x405, 2)] = (byte)(check[0]|0x10);
		        			update_section_chk(2);
		        		}
	                }

	                check = getDataFromBlock(0x40B, 1, 2);
	        		if ( (check[0]&0x8) == 0){
	        			Data[getBlockOffset(0x40B, 2)] = (byte)(check[0]|0x8);
	        			update_section_chk(2);
	        		}
	                break;
	            case 2: //FRLG
	                check = getDataFromBlock(0x67, 1, 2);
	                if ( (check[0]&0x2) == 0){
	        			Data[getBlockOffset(0x67, 2)] = (byte)(check[0]|0x2);
	        			update_section_chk(2);
	        		}
	                break;
	        }
	        has_Mistery();
        }
        public byte[] get_WC3()
        {
        	byte[] wc3;
        	if (isjap)
        	{
        		wc3 = new byte[0x4 + 0xA4 + 0x28 + 0x28 + 4 + 0x3E8]; // Checksum + WC + two extra regions + Checksum + Script
	        	getDataFromBlock(wc_offset, 0x4 + 0xA4 + 0x28, 4).CopyTo(wc3, 0);// Checksum + WC + 40 bytes region (includes icon)
	        	getDataFromBlock(wc_offset + 0x4 + 0x14C + 0x28 + 0xC, 0x28, 4).CopyTo(wc3, 0x4 + 0xA4 + 0x28);//0x28 bytes after survey data
	        	getDataFromBlock(wc_script_offset, 4 + 1000 , 4).CopyTo(wc3, 0x4 + 0xA4 + 0x28 + 0x28);//script data
        	}else
        	{
	        	wc3 = new byte[0x4 + 0x14C + 0x28 + 0x28 + 4 + 0x3E8];
	        	/*
	        	byte[] temp = getDataFromBlock(wc_offset, 0x4 + 0x14C + 0x28, 4);// Checksum + WC + 40 bytes region (includes icon)
	        	temp.CopyTo(wc3, 0);
	        	temp = getDataFromBlock(wc_offset + 0x4 + 0x14C + 0x28 + 0xC, 0x28, 4);//0x28 bytes after survey data
	        	temp.CopyTo(wc3, 0x4 + 0x14C + 0x28);
	        	temp = getDataFromBlock(wc_script_offset, 4 + 1000 , 4);//script data
	        	temp.CopyTo(wc3, 0x4 + 0x14C + 0x28 + 0x28);
	        	*/
	        	getDataFromBlock(wc_offset, 0x4 + 0x14C + 0x28, 4).CopyTo(wc3, 0);// Checksum + WC + 40 bytes region (includes icon)
	        	getDataFromBlock(wc_offset + 0x4 + 0x14C + 0x28 + 0xC, 0x28, 4).CopyTo(wc3, 0x4 + 0x14C + 0x28);//0x28 bytes after survey data
	        	getDataFromBlock(wc_script_offset, 4 + 1000 , 4).CopyTo(wc3, 0x4 + 0x14C + 0x28 + 0x28);//script data
        	}
        	return wc3;
        }
        
        public void set_WC3(byte[] wc3)
        {
        	if (isjap)
        	{
	        	setDataToBlock(wc3.Skip(0).Take(0x4 + 0xA4).ToArray(), wc_offset, 4);// Checksum + WC
	        	setDataToBlock(wc3.Skip(0x4 + 0xA4 + 0xA).Take(0x2).ToArray(), wc_offset + 0x4 + 0xA4 + 0xA, 4);// Icon
	        	//setDataToBlock(wc3.Skip(0x4 + 0xA4 + 0x28).Take(0x28).ToArray(), wc_offset + 0x4 + 0xA4 + 0x28 + 0xC, 4);//0x28 bytes after survey data
	        	setDataToBlock(wc3.Skip(0x4 + 0xA4 + 0x28 + 0x28).Take(4+1000).ToArray(), wc_script_offset, 4);//script data
        	}
        	else
        	{
	        	//setDataToBlock(wc3.Skip(0).Take(0x4 + 0x14C + 0x28).ToArray(), wc_offset, 4);// Checksum + WC + 40 bytes region (includes icon)
	        	setDataToBlock(wc3.Skip(0).Take(0x4 + 0x14C).ToArray(), wc_offset, 4);// Checksum + WC
	        	setDataToBlock(wc3.Skip(0x4 + 0x14C + 0xA).Take(0x2).ToArray(), wc_offset + 0x4 + 0x14C + 0xA, 4);// Icon
	        	//setDataToBlock(wc3.Skip(0x4 + 0x14C + 0x28).Take(0x28).ToArray(), wc_offset + 0x4 + 0x14C + 0x28 + 0xC, 4);//0x28 bytes after survey data
	        	setDataToBlock(wc3.Skip(0x4 + 0x14C + 0x28 + 0x28).Take(4+1000).ToArray(), wc_script_offset, 4);//script data
        	}
        }    

        public byte[] get_WCN()
        {
        	byte[] wcn;
        	if(isjap)
        	{
        	   	wcn = new byte[WCN_SIZE_jap];
        	   	getDataFromBlock(wcn_offset, WCN_SIZE_jap, 4).CopyTo(wcn, 0);
        	}
        	else
        	{
	        	wcn = new byte[WCN_SIZE];
	        	getDataFromBlock(wcn_offset, WCN_SIZE, 4).CopyTo(wcn, 0);
        	}

        	return wcn;
        }
        
        public void set_WCN(byte[] wcn)
        {
        	if(isjap)
        	{
        		setDataToBlock(wcn.Skip(0).Take(WCN_SIZE_jap).ToArray(), wcn_offset, 4);// Checksum + WCN
        	}
        	else
        	{
        		setDataToBlock(wcn.Skip(0).Take(WCN_SIZE).ToArray(), wcn_offset, 4);// Checksum + WCN
        	}
        }

        public byte[] get_ECT()
        {
        	byte[] ect = new byte[ECT.SIZE_ECT];
        	getDataFromBlock(ect_offset, ECT.SIZE_ECT, 0).CopyTo(ect, 0);
        	
        	return ect;
        }
        
        public void set_ECT(byte[] ect)
        {
        	setDataToBlock(ect.Skip(0).Take(ECT.SIZE_ECT).ToArray(), ect_offset, 0);
        }
        
        public byte[] get_ECB()
        {
        	byte[] berry = new byte[BERRY_SIZE];
        	getDataFromBlock(BERRY_OFFSET_RS, BERRY_SIZE, 4).CopyTo(berry, 0);
        	
        	return berry;
        }
        
        public void set_ECB(byte[] berry)
        {
        	set_Enigma_Flag();
        	setDataToBlock(berry.Skip(0).Take(BERRY_SIZE).ToArray(), BERRY_OFFSET_RS, 4);
        } 

        public bool has_berry()
        {
        	byte[] check = getDataFromBlock(BERRY_OFFSET_RS, 1, 4);
        	if (check[0] == 0x00)
        		return false;
        	else
        		return true;
        } 
        
        public int has_ME3()
        {
        	byte[] me3 = get_ME3();
        	//MessageBox.Show(me3.Length.ToString());
        	
        	if (BitConverter.ToInt32(me3, 0) == 0) // No script
        	{	//MessageBox.Show(BitConverter.ToInt32(me3, 0).ToString());
        		//MessageBox.Show(BitConverter.ToInt32(me3, me3_size-ME3_ITEM_SIZE).ToString());
        		//MessageBox.Show(me3[1004].ToString());
        		if (BitConverter.ToInt32(me3, me3_size-ME3_ITEM_SIZE) == 0) //No item either
        			return 0; //No me3
        		else
        			return 2; //No me3, but item data is present
        	}
        	
        	return 1;
        }
        public byte[] get_ME3()
        {
        	byte[] me3 = new byte[me3_size];
        	getDataFromBlock(me3_offset, me3_size, 4).CopyTo(me3, 0);
        	
        	return me3;
        }      
        public void set_ME3(byte[] me3)
        {
        	setDataToBlock(me3.Skip(0).Take(me3_size).ToArray(), me3_offset, 4);// Script+item
        } 
        public byte[] get_decorations()
        {
        	byte[] decor = new byte[150];
        	if (game == 0){
        		getDataFromBlock(0x7a0, 150, 3).CopyTo(decor, 0);
        	}else if (game == 1)
        	{
        		getDataFromBlock(0x834, 150, 3).CopyTo(decor, 0);
        	}       	
        	return decor;
        }
        public void set_decoration(byte[] decor)
        {	
        	if (game == 0)
        		setDataToBlock(decor.Skip(0).Take(150).ToArray(), 0x7a0, 3);
        	else if (game == 1)
        		setDataToBlock(decor.Skip(0).Take(150).ToArray(), 0x834, 3);
        }
        
        //TV shows
        public byte[] get_TV_EVENT()
        {
        	byte[] tvevent = new byte[0x4*16];
        	getDataFromBlock(tv_event_offset, 0x4*16, 3).CopyTo(tvevent, 0);
        	
        	return tvevent;
        }
        
        public void set_TV_EVENT(byte[] tvevent)
        {
        	setDataToBlock(tvevent.Skip(0).Take(0x4*16).ToArray(), tv_event_offset, 3);
        }
        public byte[] get_TV_OUTBREAK()
        {
        	byte[] tvoutbreak = new byte[0x24];
        	getDataFromBlock(tv_outbreak_offset, 0x24, 3).CopyTo(tvoutbreak, 0);
        	
        	return tvoutbreak;
        }
        public void set_TV_OUTBREAK(byte[] tvoutbreak)
        {
        	setDataToBlock(tvoutbreak.Skip(0).Take(0x24).ToArray(), tv_outbreak_offset, 3);
        }
        
        public byte[] get_TV_SHOWS()
        {
        	byte[] tvshows = new byte[0x24*7];
        	getDataFromBlock(tv_shows_offset, 0x24*7, 3).CopyTo(tvshows, 0);
        	
        	return tvshows;
        }
        public void set_TV_SHOWS(byte[] tvshows)
        {
        	setDataToBlock(tvshows.Skip(0).Take(0x24*7).ToArray(), tv_shows_offset, 3);
        }
        
        public byte[] get_TV_OUTBREAK_EXTRA()
        {
        	byte[] tvoutbreak_extra = new byte[0x14];
        	getDataFromBlock(tv_outbreak_data_offset, 0x14, 3).CopyTo(tvoutbreak_extra, 0);
        	
        	return tvoutbreak_extra;
        }
        public void set_TV_OUTBREAK_EXTRA(byte[] tvoutbreak_extra)
        {
        	setDataToBlock(tvoutbreak_extra.Skip(0).Take(0x14).ToArray(), tv_outbreak_data_offset, 3);
        }
        
		// check for the nocash signature
		private void checkNocash()
		{
		
		    if (Data[0x0] == 0x4E && Data[0x01] == 0x6F && Data[0x02] == 0x63 &&
		        Data[0x03] == 0x61 && Data[0x04] == 0x73 && Data[0x05] == 0x68)
		    {
		        noCash = 0x4C;
		    }
		    else
		    {
		        noCash = 0x0;
		    }
		}
		// find current save by comparing both save counters from first and second save block
		void checkCurrentSav()
		{
		    UInt64 savIndex1, savIndex2;
		
		    savIndex1 = (UInt64) (
		    (Data[0xFFF + noCash] <<24 & 0xFFFFFFFF) +
		    (Data[0xFFE + noCash] <<16 & 0xFFFFFF) +
		    (Data[0xFFD + noCash] <<8 & 0xFFFF) +
		    (Data[0xFFC + noCash] & 0xFF) );
		    savIndex2 = (UInt64) (
		    (Data[0xEFFF + noCash] <<24 & 0xFFFFFFFF) +
		    (Data[0xEFFE + noCash] <<16 & 0xFFFFFF) +
		    (Data[0xEFFD + noCash] <<8 & 0xFFFF) +
		    (Data[0xEFFC + noCash] & 0xFF) );
		    
		    if (savIndex1 >= savIndex2)
		    {
		    	currentSav = (UInt16) (0x0 + noCash);
		        oldSav = (UInt16) (0xE000 + noCash);
		    }
		    else if (savIndex1 < savIndex2)
		    {
		    	currentSav = (UInt16) (0xE000 + noCash);
		    	oldSav = (UInt16) (0x0 + noCash);
		    }
		}
		//From Kaphoticc's PSavFixV2
		private Int32 Chksum(int length, byte[] Data)
		{
			Int32 Chk,i,tmp;
			length = length>>2;
			Chk=0;
			
			for(i=0; i<length; i++){
				Chk = unchecked( Chk + (Int32) BitConverter.ToInt32(Data, i*4));
				//MessageBox.Show(BitConverter.ToInt32(Data, i*4).ToString("X"));
			}
			//MessageBox.Show(Chk.ToString("X"));
			tmp = (Int32)(Chk>>16);
			tmp +=Chk;
		
			Chk = (Int32)(tmp&0xFFFF);

			return Chk;
		}
		public void update_section_chk(int block)
		{
			ushort chk = (ushort)(Chksum(DATALEN[block], getDataFromBlock(0, DATALEN[block], block)) & 0x0000FFFF);
			//MessageBox.Show(chk.ToString("X"));
			setDataToBlock(BitConverter.GetBytes(chk), 0xFF6, block);
		}
		public void update_section_chk_old(int block)
		{
			ushort chk = (ushort)(Chksum(DATALEN[block], getDataFromBlock_old(0, DATALEN[block], block)) & 0x0000FFFF);
			//MessageBox.Show(chk.ToString("X"));
			setDataToBlock_old(BitConverter.GetBytes(chk), 0xFF6, block);
		}
		public void fix_section_checksums()
		{
			//update_section_chk(2);
			int i=0;
			for(i=0;i<14;i++)
				update_section_chk(i);
			for(i=0;i<14;i++)
				update_section_chk_old(i);
		}
		public byte[] getSortedSave(int save)
		{
			byte[] sortedsave = new byte[0x1000*14];
			int i=0;
			for (i=0;i<14;i++)
			{
				if (save == 0)
					getDataFromBlock(0, 0x1000, i).CopyTo(sortedsave, 0x1000*i);
				else
					getDataFromBlock_old(0, 0x1000, i).CopyTo(sortedsave, 0x1000*i);
			}
			
			return sortedsave;
		}
		
		public void enable_eon_emerald()
		{
			byte flag;
			flag = getDataFromBlock(0x49A, 1, 2)[0];
			flag = (byte)(flag|0x01);
			Data[getBlockOffset(0x49A, 2)] = flag;
			update_section_chk(2);
			
			//Input distro item
			Data[getBlockOffset(0xC94, 4)] = 0xAC;
			Data[getBlockOffset(0xC95, 4)] = 0x0;
			Data[getBlockOffset(0xC96, 4)] = 0x0;
			Data[getBlockOffset(0xC97, 4)] = 0x0;
			//Item
			Data[getBlockOffset(0xC98, 4)] = 0x01;
			Data[getBlockOffset(0xC99, 4)] = 0x97;
			Data[getBlockOffset(0xC9A, 4)] = 0x13;
			Data[getBlockOffset(0xC9B, 4)] = 0x01;
			
			update_section_chk(4);
		}
        public bool has_EggEvent_Flag()
        {
	        //Check if save has enabled mistery gift
	        byte[] check = new byte[1];
	        switch (game)
	        {
	           /* case 0://Not that it has wondercards...but let's see the code for it
	        		check = getDataFromBlock(0x3A9, 1, 2);
	        		if ( (check[0]&0x10) == 0)
	                  	has_mistery_event = false;
	                else
	                	has_mistery_event = true;
	                break;
*/
	            case 1: //Emerald
	                check = getDataFromBlock(0x32C, 1, 2);
	                if ( (check[0]&0x10) == 0)
	                  	return false;
	                else
	                	return true;
	                //break;
	            case 2: //FRLG
	                check = getDataFromBlock(0xf5B, 1, 1);
	                if ( (check[0]&0x01) == 0)
	                  	return false;
	                else
	                	return true;
	                //break;
	        }
	        return false;
        }
        public void clear_EggEvent_Flag()
        {
	        //Check if save has enabled mistery gift
	        byte[] check = new byte[1];
	        switch (game)
	        {
	            case 1: //Emerald
	                check = getDataFromBlock(0x32C, 1, 2);
	                if ( (check[0]&0x10) != 0)
	                {
	                	check[0] = (byte)(check[0]&(~0x10));
	                  	setDataToBlock(check, 0x32C, 2);
	                  	update_section_chk(2);
	                }
	                break;
	            case 2: //FRLG
	                check = getDataFromBlock(0xf5B, 1, 1);
	                if ( (check[0]&0x01) != 0)
	                {
	                	check[0] = (byte)(check[0]&(~0x01));
	                  	setDataToBlock(check, 0xf5b, 1);
	                  	update_section_chk(1);
	                }
	                break;
	        }
        }
        public void set_Enigma_Flag()
        {
	        //Check if save has enabled mistery gift
	        byte[] check = new byte[1];
	        switch (game)
	        {
	            case 0: //RS
	               Data[getBlockOffset(0x41A, 2)] = 0x01;
	               update_section_chk(2);
	               break;
	        }
        }
		
	}
}
