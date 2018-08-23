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
        public StatsIntime EffectRecoverP;

        public int EffectTime;

        public Buff()
        {
            
        }

        public void CalRecover()
        {
            EffectRecoverP.HpI = EffectStats.HpR * PlayerData.Player.BaseStats.HpM / EffectTime;
            // ReSharper disable once PossibleLossOfFraction
            EffectRecoverP.MpI = EffectStats.MpR * PlayerData.Player.BaseStats.MpM / EffectTime;
        }
    }
}