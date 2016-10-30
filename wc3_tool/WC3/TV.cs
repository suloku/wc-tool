/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 13/05/2016
 * Time: 14:03
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
	public class TV_EVENTS
	{
		private int tv_event_size = 0x4*16;
		
		public byte[] Data;
        
        public TV_EVENTS(byte[] data)
        {
            Data = (byte[])(data ?? new byte[tv_event_size]).Clone();
            
            load_events();

            return;
        }
        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
        }
        
        public EVENT[] events = new EVENT[16];
        public void load_events()
        {
        	int i=0;
        	for(i=0;i<16;i++)
        	{
        		events[i] = new EVENT(getData(EVENT.event_size*i, EVENT.event_size));
        	}
        }
		public void set_events()
        {
        	int i=0;
        	for(i=0;i<16;i++)
        	{
        		setData(events[i].Data, EVENT.event_size*i);
        	}
        }
	}
	public class TV_SHOWS
	{
		private int tv_size = 0x24*7;
		
		public byte[] Data;
        
        public TV_SHOWS(byte[] data)
        {
            Data = (byte[])(data ?? new byte[tv_size]).Clone();

            load_shows();

            return;
        }
        public byte[] getData(int Offset, int Length)
        {
            return Data.Skip(Offset).Take(Length).ToArray();
        }
        public void setData(byte[] input, int Offset)
        {
            input.CopyTo(Data, Offset);
        }
        
        public SHOW[] shows = new SHOW[7];
        public void load_shows()
        {
        	int i=0;
        	for(i=0;i<7;i++)
        	{
        		shows[i] = new SHOW(getData(SHOW.show_size*i, SHOW.show_size));
        	}
        }
		public void set_shows()
        {
        	int i=0;
        	for(i=0;i<7;i++)
        	{
        		setData(shows[i].Data, SHOW.show_size*i);
        	}
        }
	}
		public class EVENT
        {
			public static int event_size = 0x4;
			
			public byte[] Data;
	        public EVENT(byte[] data)
	        {
	            Data = (byte[])(data ?? new byte[event_size]).Clone();
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
			public byte ID
	        {
				get{ return Data[0x0];}
	        	set{ Data[0x0] = (byte)value;}
	        }
			public byte status
	        {
	        	
				get{ return Data[0x1];}
	        	set{ Data[0x1] = (byte)value;}
	        }
			public UInt16 days_to_tv
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x2, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x2);}
	        }
		}
/*
Offsets
RAM	0x281F0 - 0x2822F (RS)
	0x28550 - 0x2858F (E)

Save	Section 3 0xBBC - 0xBFB (RS)
	Section 3 0xC50 - 0xC8F (E)


Structure
0x01		Event ID
0x02		Status (0 - seen, 1 - not yet seen, 2 - seen + event active)
0x03 - 0x04	Days remaining until event is active (announcement starts 2 days before)

Event ID
1	Big Sale (Slateport Energy Guru)
2	Service Day (Mauville Game Corner)
3	Clear-Out-Sale (Lilycove Department Store)
4	Blend Master (Lilycove Contest Hall) (Emerald only!)
*/
        public class SHOW
        {
			public static int show_size = 0x24;
			
			public byte[] Data;
	        public SHOW(byte[] data)
	        {
	            Data = (byte[])(data ?? new byte[show_size]).Clone();
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        //Data common to all shows
			public byte ID
	        {
				get{ return Data[0x0];}
	        	set{ Data[0x0] = (byte)value;}
	        }
			public byte status
	        {
	        	
				get{ return Data[0x1];}
	        	set{ Data[0x1] = (byte)value;}
	        }
			/*
			public bool status
	        {
	        	
				get{ if(Data[0x1] == 1) return true; else return false;}
				set{ if (value == true) Data[0x1] = 0x01; else Data[0x1] = 0;}
	        }
	        */
			public UInt16 TID_own
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x20, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x20);}
	        }
			public UInt16 TID_mixed
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x22, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x22);}
	        }
			
			//Data dependent of show
			
			//ID 0x29 (Outbreak)

	        public UInt16 outbreak_move1
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x04, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x04);}
	        }
	        public UInt16 outbreak_move2
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x06, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x06);}
	        }
	        public UInt16 outbreak_move3
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x08, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x08);}
	        }
	        public UInt16 outbreak_move4
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x0A, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x0A);}
	        }
	        public UInt16 outbreak_species
	        {
	        	get{ return BitConverter.ToUInt16(getData(0xC, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0xC);}
	        }
	        public UInt16 outbreak_map
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x10, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x10);}
	        }
	        public byte outbreak_level
	        {
	        	get{ return Data[0x14];}
	        	set{ Data[0x14] = (byte)value;}
	        }
			public byte outbreak_appearance
	        {
	        	get{ return Data[0x13];}
	        	set{ Data[0x13] = (byte)value;}
	        }
			public UInt16 outbreak_days_to_tv
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x16, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x16);}
	        }
			public UInt16 outbreak_remaining_days
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x18, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x18);}
	        }
			//End of outbreak data
        }
/*
Outbreak TV Show
When you watched the Outbreak announcement, data gets written to the Extra Data (see below).

Offsets
RAM	0x27E6C - 0x281CB (RS)
	0x281CC - 0x2852B (E)
Save	Section 3 0x838 - 0xB97 (RS)
	Section 3 0x8CC - 0xC2B (E)

Structure
0x00		Show ID (0x29 for Outbreak)
0x01		Status (0 - seen, 1 - not yet seen; you can't see the announcement if you already have an active outbreak)
0x02 - 0x03	00 00
0x04 - 0x05	Move 1
0x06 - 0x07	Move 2
0x08 - 0x09	Move 3
0x0A - 0x0B	Move 4
0x0C - 0x0D	Species ID
0x0E - 0x0F	00 00
0x10 - 0x11	Location Map Index (use Advance Map to see them)
0x12		00
0x13		Appearance rate (50% (0x32) by default)
0x14		Level
0x15		00
0x16 - 0x17	Days remaining until show is on TV (set to 1 if received via record mixing)
0x18 - 0x19	Days the outbreak will last (2 by default)
0x1A - 0x1F	00 00 00 00 00 00
0x20 - 0x21	Own Trainer ID
0x22 - 0x23	Trainer ID of the game from which the data was received via record mixing
*/
        public class SWARM
        {
			public static int swarm_size = 0x14;
			
			public byte[] Data;
	        public SWARM(byte[] data)
	        {
	            Data = (byte[])(data ?? new byte[swarm_size]).Clone();
	        }
	        public byte[] getData(int Offset, int Length)
	        {
	            return Data.Skip(Offset).Take(Length).ToArray();
	        }
	        public void setData(byte[] input, int Offset)
	        {
	            input.CopyTo(Data, Offset);
	        }
	        
	        public UInt16 species
	        {
	        	get{ return BitConverter.ToUInt16(getData(0, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0);}
	        }
	        public UInt16 map
	        {
	        	get{ return BitConverter.ToUInt16(getData(2, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 2);}
	        }
	        public byte level
	        {
	        	get{ return Data[0x4];}
	        	set{ Data[0x4] = (byte)value;}
	        }
	        public UInt16 move1
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x08, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x08);}
	        }
	        public UInt16 move2
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x0A, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x0A);}
	        }
	        public UInt16 move3
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x0C, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x0C);}
	        }
	        public UInt16 move4
	        {
	        	get{ return BitConverter.ToUInt16(getData(0x0E, 2), 0);}
	        	set{ setData(BitConverter.GetBytes((UInt16)value), 0x0E);}
	        }
			public byte appearance
	        {
	        	get{ return Data[0x11];}
	        	set{ Data[0x11] = (byte)value;}
	        }
			public byte remaining_days
	        {
	        	get{ return Data[0x12];}
	        	set{ Data[0x12] = (byte)value;}
	        }
        }
}

/*
Outbreak Extra Data
When you watched the Outbreak announcement, data gets written here.
It's stored here until the counter at 0x12 reaches 0.

Offsets
RAM	0x28230 - 0x28243 (RS)
	0x28590 - 0x285A3 (E)
Save	Section 3 0xBFC - 0xC0F (RS)
	Section 3 0xC90 - 0xCA3 (E)

Structure
0x00 - 0x01	Species ID
0x02 - 0x03	Location Map Index (use Advance Map to see them)
0x04		Level
0x05 - 0x07	00 00 00
0x08 - 0x09	Move 1
0x0A - 0x0B	Move 2
0x0C - 0x0D	Move 3
0x0E - 0x0F	Move 4
0x10		00    
0x11		Appearance rate (50% (0x32) by default)
0x12		Days the outbreak will last (2 by default; counts down daily)
*/