using System;
using System.Collections.Generic;
using Buffs;
using Character;
using Character.Player;
using UnityEngine;

namespace Items.Props
{
    [System.Serializable]
    public class PropRecover:Prop
    {
        public StatsIntime PIntimeProperties;
        public List<int> Buffs = new List<int>();

        public override void UseItem()
        {
            PlayerData.Player.TotalIntime.Add(PIntimeProperties);
            foreach (int effect in Buffs)
            {
                PlayerData.Player.getBuff(effect);
            }
        }
    }
}