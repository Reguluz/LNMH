using System;
using Character;
using Character.Player;
using UnityEngine;

namespace Items.Props
{
    public class PropEnternal:Prop
    {
        public bool byValue;
        public StatsBase PProperties = new StatsBase();
        public StatsBase MProperties = new StatsBase();
        public StatsBase MFProperties = new StatsBase();

        public override void UseItem()
        {
            if (byValue)
            {
                PlayerData.Player.ItemStats.Add(PProperties);
            }
            else
            {
                Debug.Log("run");
                
                MFProperties = StatsBase.Multi(PlayerData.Player.TotalStats, MProperties);
                PlayerData.Player.ItemStats.Add(MProperties);
            }
            
        }
    }
}