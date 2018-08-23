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
        //public StatsIntime TotalBuffRecover;
        
        
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
                
                foreach (Buff buff in Bufflist)
                {
                    
                        TotalBuff.Add(buff.EffectStats);
                    

                    buff.EffectTime--;
                    if (buff.EffectTime <= 0)
                    {
                        Bufflist.Remove(buff);
                    }
                }
                yield return new WaitForSeconds(1f);
            }
        }
        
        

        public void RefreshData()
        {
            //重新计算装备总值、道具总值、基础总值、buff总值（按顺序）
            
            PlayerEquipment.RefreshData(); //装备总值
            foreach (StatsBase item in ItemEnternalStats)    //道具总值
            {
                TotalItemStats.Add(item);
            }

            RefreshBase(); //基础总值
            //BuffRefresh()周期更新buff总值
            RefreshRecover();
            RefreshStats();

            /*TotalStats = new StatsBase();
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
            
            TotalIntimeRecover.Add(new StatsIntime(){HpI = TotalStats.HpR + TotalBuffRecover.HpI,MpI = TotalStats.MpR + TotalBuffRecover.MpI});*/

            //TotalIntime.DataCheck(TotalStats);
        }

        public void RefreshBase()
        {
            BaseStats.HpM = PlayerStats.HpM + TotalItemStats.HpM;
            BaseStats.HpR = PlayerStats.HpR + TotalItemStats.HpR;
            BaseStats.Atk = PlayerStats.Atk + TotalItemStats.Atk;
            BaseStats.NAtk = PlayerStats.NAtk + TotalItemStats.NAtk;
            BaseStats.FAtk = PlayerStats.FAtk + TotalItemStats.FAtk;
            BaseStats.Def = PlayerStats.Def + TotalItemStats.Def;
            BaseStats.SpdM = PlayerStats.SpdM + TotalItemStats.SpdM;
            BaseStats.SpdA = PlayerStats.SpdA + TotalItemStats.SpdA;
            BaseStats.MpM = PlayerStats.MpM + TotalItemStats.MpM;
            BaseStats.MpR = PlayerStats.MpR + TotalItemStats.MpR;
            BaseStats.CritP = PlayerStats.CritP + TotalItemStats.CritP;
            BaseStats.CritM = PlayerStats.CritM + TotalItemStats.CritM;
            BaseStats.MgM = PlayerStats.MgM + TotalItemStats.MgM;
        }
        public void RefreshRecover()
        {
            TotalIntimeRecover.HpI = PlayerStats.HpR + TotalBuff.HpR + TotalItemStats.HpR;
            TotalIntimeRecover.MpI = PlayerStats.MpR + TotalBuff.MpR + TotalItemStats.MpR;
        }

        public void RefreshStats()
        {
            TotalStats.HpM = TotalBuff.HpM + PlayerEquipment.TotalEquips.HpM + BaseStats.HpM;
            TotalStats.HpR = TotalBuff.HpR + PlayerEquipment.TotalEquips.HpR + BaseStats.HpR;
            TotalStats.Atk = TotalBuff.Atk + PlayerEquipment.TotalEquips.Atk + BaseStats.Atk;
            TotalStats.NAtk = TotalBuff.NAtk + PlayerEquipment.TotalEquips.NAtk + BaseStats.NAtk;
            TotalStats.FAtk = TotalBuff.FAtk + PlayerEquipment.TotalEquips.FAtk + BaseStats.FAtk;
            TotalStats.Def = TotalBuff.Def + PlayerEquipment.TotalEquips.Def + BaseStats.Def;
            TotalStats.SpdM = TotalBuff.SpdM + PlayerEquipment.TotalEquips.SpdM + BaseStats.SpdM;
            TotalStats.SpdA = TotalBuff.SpdA + PlayerEquipment.TotalEquips.SpdA + BaseStats.SpdA;
            TotalStats.MpM = TotalBuff.MpM + PlayerEquipment.TotalEquips.MpM + BaseStats.MpM;
            TotalStats.MpR = TotalBuff.MpR + PlayerEquipment.TotalEquips.MpR + BaseStats.MpR;
            TotalStats.CritP = TotalBuff.CritP + PlayerEquipment.TotalEquips.CritP + BaseStats.CritP;
            TotalStats.CritM = TotalBuff.CritM + PlayerEquipment.TotalEquips.CritM + BaseStats.CritM;
            TotalStats.MgM = TotalBuff.MgM + PlayerEquipment.TotalEquips.MgM + BaseStats.MgM;
        }
        
    
    }
    
}