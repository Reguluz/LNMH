using System;
using Character;
using Character.Player;
using UnityEngine;

namespace Items.Props
{
    
    [System.Serializable]
    public class PropEnternal:Prop
    {
        public StatsBase PProperties = new StatsBase();
        

        public override void UseItem()
        {
            PlayerData.Player.ItemEnternalStats.Add(PProperties);
        }
    }
}