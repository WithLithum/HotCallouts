﻿// HotCallouts
// Copyright (C) 2019 RelaperCrystal
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;
using System.Collections.Generic;
using GTA;
using LCPD_First_Response.Engine.Scripting.Plugins;
using LCPD_First_Response.LCPDFR.API;
using LCPD_First_Response.Engine;

namespace HotCallouts
{
	/// <summary>
	/// HighHot
	/// </summary>
	[PluginInfo("HotCallouts", false, true)]
	public class HighHot : Plugin
	{
		public HighHot()
		{
			Log.Info("HotCallouts Constructor Loaded", "HighHot");
		}

		void OnDutyStateChanged(bool onDuty)
		{
			Log.Info("Player Onduty: " + onDuty, this);
			if (onDuty)
			{
				Functions.AddTextToTextwall("HotCallout, (C) 2019 RelaperCrystal", "SYSTEM");
				
				Functions.RegisterCallout(typeof(Callouts.DangerousDriver));
				Functions.RegisterCallout(typeof(Callouts.FirearmAttackOnOfficer));
				
				Functions.AddWorldEvent(typeof(WorldEvents.HMugging), "Mugging");
			}
		}
		public override void Initialize()
		{
			Log.Info("Initialized HotCallouts", this);
			this.RegisterConsoleCommands();
			
			Functions.OnOnDutyStateChanged += this.OnDutyStateChanged;
		}
		
		public override void Process()
		{
			
		}
		
		public override void Finally()
		{
			Log.Info("HighHotCallouts Unloaded", this);
		}
	}
}