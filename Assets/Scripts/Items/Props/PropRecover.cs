using System;
using Character;
using Character.Player;
using UnityEngine;

namespace Items.Props
{
    public class PropRecover:Prop
    {
        public Boolean byValue = true;
        public StatsIntime PIntimeProperties = new StatsIntime();
        public StatsIntime MIntimeProperties = new StatsIntime();
        public StatsIntime MFIntimeProperties = new StatsIntime();


        public override void UseItem()
        {
            if (byValue)
            {
                PlayerData.Player.TotalIntime.Add(PIntimeProperties);
            }
            else
            {
                Debug.Log("run");
                
                MFIntimeProperties = StatsIntime.Multi(PlayerData.Player.TotalStats, MIntimeProperties);
                PlayerData.Player.TotalIntime.Add(MFIntimeProperties);
            }
            
        }
    }
}