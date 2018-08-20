using Boo.Lang;
using Items;
using Items.Bag;
using Items.Equips;
using Items.Props;
using UI;
using UnityEngine;

namespace Character.Player
{
    public class PlayerData : MonoBehaviour,RefreshData
    {
        public LevelData PlayerLevel;
        
        public StatsBase PlayerStats;
        public List<StatsBase> ItemStats;
        public StatsBase TotalItemStats;

        public StatsBase BaseStats;
        
        public Equipment PlayerEquipment;
        public List<StatsBase>  BuffStats;
        
        public StatsBase TotalStats;
        public StatsIntime TotalIntime;
        
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
            ItemStats = new List<StatsBase>();
            BaseStats = new StatsBase();
            
            
            PlayerEquipment = new Equipment();
            BuffStats = new List<StatsBase>();
            
            TotalStats = new StatsBase();
            TotalIntime = new StatsIntime();
            TotalItemStats = new StatsBase();
            
            TotalIntime.HpI = 50;
            PlayerStats.HpM = 100;
            
            CenterControl.Centerctrl.RegisterData(this);
        }

        public void RefreshData()
        {
            TotalStats = new StatsBase();
            BaseStats = new StatsBase();
            TotalItemStats = new StatsBase();
            foreach (StatsBase item in ItemStats)
            {
                TotalItemStats.Add(item);
            }
            
            BaseStats.Add(PlayerStats);
           
            BaseStats.Add(TotalItemStats);
            
            TotalStats.Add(BaseStats);
            
            TotalStats.Add(PlayerEquipment.TotalEquips);
            //TotalStats.Plus(TotalStats,BuffStats);
            TotalIntime.DataCheck(TotalStats);
        }
        
        
    
    }
    
}