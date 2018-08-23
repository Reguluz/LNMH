using System;
using Character;
using Character.Player;
using ID;
using UnityEngine;

namespace Buffs
{
    [Serializable]
    public class Buff
    {
        public ObjectIndex Objindex;
        public Sprite Buffshow;

        public bool IsRecover;
        public bool IsInterruptible;

        public StatsBase EffectStats;
        public StatsIntime EffectRecover;

        public int EffectTime;

        public Buff()
        {
            
        }

        public void CalRecover()
        {
            EffectRecover.HpI = EffectStats.HpR * PlayerData.Player.TotalStats.HpM / EffectTime;
            // ReSharper disable once PossibleLossOfFraction
            EffectRecover.MpI = EffectStats.MpR * PlayerData.Player.TotalStats.MpM / EffectTime;
        }
    }
}