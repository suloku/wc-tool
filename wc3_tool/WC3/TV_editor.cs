/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 13/05/2016
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of TV_editor.
	/// </summary>
	public partial class TV_editor : Form
	{

		SAV3 sav3file;
		public string savfilter = MainScreen.savfilter;
		
		//TV data
		TV_EVENTS events;
		SHOW ingame_swarm;
		TV_SHOWS shows;
		SWARM swarm;
		
		public TV_editor(SAV3 save)
		{
			InitializeComponent();
			
			sav3file = save;
			
			events = new TV_EVENTS (sav3file.get_TV_EVENT());
			ingame_swarm = new SHOW(sav3file.get_TV_OUTBREAK());
			shows = new TV_SHOWS(sav3file.get_TV_SHOWS());
			swarm = new SWARM(sav3file.get_TV_OUTBREAK_EXTRA());
			
			load_data();
			
		}
		
		void load_data()
		{
			load_event();
			load_swarm();
			load_show();
		}
		
		void load_event()
		{
			event_id.SelectedIndex = events.events[(int)event_slot.Value].ID;
			event_status.SelectedIndex = events.events[(int)event_slot.Value].status;
			event_days.Value = events.events[(int)event_slot.Value].days_to_tv;
		}
		void set_event()
		{
			events.events[(int)event_slot.Value].ID = (byte)event_id.SelectedIndex;
			events.events[(int)event_slot.Value].status = (byte)event_status.SelectedIndex;
			events.events[(int)event_slot.Value].days_to_tv = (UInt16)event_days.Value;
		}
		
		void load_swarm()
		{
			current_species.SelectedIndex = swarm.species;
			current_level.Value = swarm.level;
			current_move1.SelectedIndex = swarm.move1;
			current_move2.SelectedIndex = swarm.move2;
			current_move3.SelectedIndex = swarm.move3;
			current_move4.SelectedIndex = swarm.move4;
			current_map.Value = swarm.map;
			current_appearance.Value = swarm.appearance;
			current_remaining.Value = swarm.remaining_days;
		}
		void set_swarm()
		{
			swarm.species = (UInt16)current_species.SelectedIndex;
			swarm.level = (byte)current_level.Value;
			swarm.move1 = (UInt16)current_move1.SelectedIndex;
			swarm.move2 = (UInt16)current_move2.SelectedIndex;
			swarm.move3 = (UInt16)current_move3.SelectedIndex;
			swarm.move4 = (UInt16)current_move4.SelectedIndex;
			swarm.map = (UInt16)current_map.Value;
			swarm.appearance = (byte)current_appearance.Value;
			swarm.remaining_days = (byte)current_remaining.Value;
		}
		void load_show()
		{
			                          
			if (tv_slot.Value == 0)
			{
				tv_id.Value = ingame_swarm.ID;
				tv_status.SelectedIndex = ingame_swarm.status;
				tv_tid.Value = ingame_swarm.TID_own;
				tv_mix_tid.Value = ingame_swarm.TID_mixed;
				
			}else
			{
				tv_id.Value = shows.shows[(int)(tv_slot.Value-1)].ID;
				tv_status.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].status;
				tv_tid.Value = shows.shows[(int)(tv_slot.Value-1)].TID_own;
				tv_mix_tid.Value = shows.shows[(int)(tv_slot.Value-1)].TID_mixed;
			}
			
			load_outbreak();
		}
		
		void Save_butClick(object sender, EventArgs e)
		{
			events.set_events();
			shows.set_shows();
			
			sav3file.set_TV_EVENT(events.Data);
			sav3file.set_TV_OUTBREAK(ingame_swarm.Data);
			sav3file.set_TV_SHOWS(shows.Data);
			sav3file.set_TV_OUTBREAK_EXTRA(swarm.Data);
			sav3file.update_section_chk(3);
			FileIO.save_data(sav3file.Data, savfilter);
		}
		void Event_slotValueChanged(object sender, EventArgs e)
		{
			load_event();
		}
		void Swarm_deleteClick(object sender, EventArgs e)
		{
			delete_current_swarm();
			load_swarm();
		}
		void delete_current_swarm()
		{
			int i = 0;
			for (i=0; i<SWARM.swarm_size;i++)
			{
				swarm.Data[i] = 0;
			}
		}
		void load_outbreak()
		{
			if (tv_slot.Value == 0) //Ingame outbreak
			{
				tv_outbreak_group.Enabled = true;
				
				outbreak_activation.Value = ingame_swarm.outbreak_days_to_tv;
				outbreak_map.Value = ingame_swarm.outbreak_map;
				outbreak_availability.Value = ingame_swarm.outbreak_appearance;
				outbreak_remaining.Value = ingame_swarm.outbreak_appearance;
				
				outbreak_species.SelectedIndex = ingame_swarm.outbreak_species;
				outbreak_level.Value = ingame_swarm.outbreak_level;
				outbreak_move1.SelectedIndex = ingame_swarm.outbreak_move1;
				outbreak_move2.SelectedIndex = ingame_swarm.outbreak_move2;
				outbreak_move3.SelectedIndex = ingame_swarm.outbreak_move3;
				outbreak_move4.SelectedIndex = ingame_swarm.outbreak_move4;
				
				
			}else if (tv_slot.Value != 0 && tv_id.Value == 0x29)
			{
				tv_outbreak_group.Enabled = true;
				
				outbreak_activation.Value = shows.shows[(int)(tv_slot.Value-1)].outbreak_days_to_tv;
				outbreak_map.Value = shows.shows[(int)(tv_slot.Value-1)].outbreak_map;
				outbreak_availability.Value = shows.shows[(int)(tv_slot.Value-1)].outbreak_appearance;
				outbreak_remaining.Value = shows.shows[(int)(tv_slot.Value-1)].outbreak_appearance;
				
				outbreak_species.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].outbreak_species;
				outbreak_level.Value = shows.shows[(int)(tv_slot.Value-1)].outbreak_level;
				outbreak_move1.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].outbreak_move1;
				outbreak_move2.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].outbreak_move2;
				outbreak_move3.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].outbreak_move3;
				outbreak_move4.SelectedIndex = shows.shows[(int)(tv_slot.Value-1)].outbreak_move4;
			}
			else{
				tv_outbreak_group.Enabled = false;
			}
		}
		
		void Outbreak_applyClick(object sender, EventArgs e)
		{
			if (tv_slot.Value == 0) //Ingame outbreak show
			{
				ingame_swarm.outbreak_days_to_tv = (UInt16)outbreak_activation.Value;
				ingame_swarm.outbreak_map = (UInt16)outbreak_map.Value;
				ingame_swarm.outbreak_appearance = (byte)outbreak_availability.Value;
				ingame_swarm.outbreak_appearance = (byte)outbreak_remaining.Value;
				
				ingame_swarm.outbreak_species = (UInt16)outbreak_species.SelectedIndex;
				ingame_swarm.outbreak_level = (byte)outbreak_level.Value;
				ingame_swarm.outbreak_move1 = (UInt16)outbreak_move1.SelectedIndex;
				ingame_swarm.outbreak_move2 = (UInt16)outbreak_move2.SelectedIndex;
				ingame_swarm.outbreak_move3 = (UInt16)outbreak_move3.SelectedIndex;
				ingame_swarm.outbreak_move4 = (UInt16)outbreak_move4.SelectedIndex;
				
				
			}else if (tv_slot.Value != 0 && tv_id.Value == 0x29)
			{			
				shows.shows[(int)(tv_slot.Value-1)].outbreak_days_to_tv = (UInt16)outbreak_activation.Value;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_map = (UInt16)outbreak_map.Value;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_appearance = (byte)outbreak_availability.Value;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_appearance = (byte)outbreak_remaining.Value;
				
				shows.shows[(int)(tv_slot.Value-1)].outbreak_species = (UInt16)outbreak_species.SelectedIndex;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_level = (byte)outbreak_level.Value;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_move1 = (UInt16)outbreak_move1.SelectedIndex;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_move2 = (UInt16)outbreak_move2.SelectedIndex;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_move3 = (UInt16)outbreak_move3.SelectedIndex;
				shows.shows[(int)(tv_slot.Value-1)].outbreak_move4 = (UInt16)outbreak_move4.SelectedIndex;
			}
			
			MessageBox.Show("Outbreak Show Updated!");
		}
		void Tv_statusSelectedIndexChanged(object sender, EventArgs e)
		{
			if (tv_slot.Value == 0)
			{
				ingame_swarm.status = (byte)tv_status.SelectedIndex;
			}else
			{
				shows.shows[(int)(tv_slot.Value-1)].status = (byte)tv_status.SelectedIndex;
			}
		}
		void Tv_tidValueChanged(object sender, EventArgs e)
		{
			if (tv_slot.Value == 0)
			{
				ingame_swarm.TID_own = (UInt16)tv_tid.Value;
			}else
			{
				shows.shows[(int)(tv_slot.Value-1)].TID_own = (UInt16)tv_tid.Value;
			}
		}
		void Tv_mix_tidValueChanged(object sender, EventArgs e)
		{
			if (tv_slot.Value == 0)
			{
				ingame_swarm.TID_mixed = (UInt16)tv_mix_tid.Value;
			}else
			{
				shows.shows[(int)(tv_slot.Value-1)].TID_mixed = (UInt16)tv_mix_tid.Value;
			}
		}
		void Tv_idValueChanged(object sender, EventArgs e)
		{
			if (tv_slot.Value == 0)
			{
				tv_id.Value = ingame_swarm.ID;				
			}else
			{
				tv_id.Value = shows.shows[(int)(tv_slot.Value-1)].ID;
			}
		}
		void Tv_slotValueChanged(object sender, EventArgs e)
		{
			load_show();
		}
		void Event_statusSelectedIndexChanged(object sender, EventArgs e)
		{

		}
		void Event_idSelectedIndexChanged(object sender, EventArgs e)
		{

		}
		void Event_daysValueChanged(object sender, EventArgs e)
		{

		}
		void Swarm_applyClick(object sender, EventArgs e)
		{
			set_swarm();
		}
		void Event_applyClick(object sender, EventArgs e)
		{
			set_event();
		}
	}
}
