using System.Collections;
using Boo.Lang;
using Buffs;
using DataList;
using Items;
using Items.Bag;
using Items.Equips;
using Items.Props;
using UI;
using UnityEditor;
using UnityEngine;

namespace Character.Player
{
    public class PlayerData : MonoBehaviour,RefreshData
    {
        public LevelData PlayerLevel;
        
        public StatsBase PlayerStats;
        public List<StatsBase> ItemEnternalStats;
        public StatsBase TotalItemStats;

        public StatsBase BaseStats;
        
        public Equipment PlayerEquipment;
        public List<Buff>  Bufflist;
        public StatsBase TotalBuff;
        public StatsIntime TotalBuffRecover;
        
        
        public StatsBase TotalStats;
        public StatsIntime TotalIntime;

        public StatsIntime TotalIntimeRecover;
        
        public PlayerBag PlayerBag;

        public static PlayerData Player;
        
        private void Awake()    //设置单例
        {
            if (Player == null)
            {
                Player = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        
        

        private void Start()
        {
            PlayerStats = new StatsBase();
            PlayerLevel = new LevelData();
            ItemEnternalStats = new List<StatsBase>();
            BaseStats = new StatsBase();
            
            
            PlayerEquipment = new Equipment();
            Bufflist = new List<Buff>();
            
            TotalStats = new StatsBase();
            TotalIntime = new StatsIntime();
            TotalItemStats = new StatsBase();
            
            TotalIntime.HpI = 50;
            PlayerStats.HpM = 100;

            StartCoroutine(BuffRefresh());
            StartCoroutine(AutoRecover());
            
            CenterControl.Centerctrl.RegisterData(this);
        }

        
        public void getBuff(int num)
        {
            BuffHolder bufflist = AssetDatabase.LoadAssetAtPath<BuffHolder>("Assets/Resources/Buffs.asset");
            
            Buff temp = new Buff();
            foreach (Buff buff in bufflist.BuffList)
            {
                if (buff.Objindex.Id.Equals(num))
                {
                    temp = buff;
                }
            }/*
            {
                Buffshow = buff.Buffshow,
                EffectRecover = buff.EffectRecover,
                EffectStats = buff.EffectStats,
                EffectTime = buff.EffectTime,
                IsInterruptible = buff.IsInterruptible,
                IsRecover = buff.IsInterruptible,
                ObjectIndex = buff.ObjectIndex
            };*/
            foreach (Buff buffs in Bufflist)
            {
                if (buffs.Objindex.Id.Equals(temp.Objindex.Id))
                {
                    Bufflist.Remove(buffs);
                }
            }

            if (temp.IsRecover)
            {
                temp.CalRecover();
            }
            Bufflist.Add(temp);
        }


        IEnumerator AutoRecover()
        {
            while (true)
            {
                TotalIntime.Add(TotalIntimeRecover);
                RefreshData();
                yield return new WaitForSeconds(1f);
            }
            
        }
        IEnumerator BuffRefresh()
        {
            while (true)
            {
                TotalBuff = new StatsBase();
                TotalBuffRecover = new StatsIntime();
                
                foreach (Buff buff in Bufflist)
                {
                    if (buff.IsRecover)
                    {
                        TotalBuffRecover.Add(buff.EffectRecover);
                    }
                    else
                    {
                        TotalBuff.Add(buff.EffectStats);
                    }

                    buff.EffectTime--;
                    if (buff.EffectTime <= 0)
                    {
                        Bufflist.Remove(buff);
                    }
                }
                RefreshData();
                yield return new WaitForSeconds(1f);
            }
        }
        
        

        public void RefreshData()
        {
            TotalStats = new StatsBase();
            BaseStats = new StatsBase();
            TotalItemStats = new StatsBase();
            TotalIntimeRecover = new StatsIntime();
            foreach (StatsBase item in ItemEnternalStats)
            {
                TotalItemStats.Add(item);
            }
            
            BaseStats.Add(PlayerStats);
           
            BaseStats.Add(TotalItemStats);
            
            TotalStats.Add(BaseStats);
            
            TotalStats.Add(PlayerEquipment.TotalEquips);
            
            TotalIntimeRecover.Add(new StatsIntime(){HpI = TotalStats.HpM + TotalBuffRecover.HpI,MgI = TotalStats.MgM + TotalBuffRecover.MgI});
            
            //TotalIntime.DataCheck(TotalStats);
        }

        
        
    
    }
    
}