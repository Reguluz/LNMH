using Character;
using Character.Player;
using ID;
using UnityEngine;

namespace Items.Equips
{
    
    [System.Serializable]
    public class Equip:Item
    {
        public Equiptype Equiptype;
        public Rarity Rarity;
        public StatsBase PProperties = new StatsBase();
        public StatsBase MProperties = new StatsBase();
        public StatsBase MFProperties = new StatsBase();
        
        public Equip()
        {
            Objindex.Id = 100;
            Objindex.Name = "示例装备1";
            Objindex.Comments = "示例装备1的说明";
            Itemtype = ItemType.Equipments;
            Price = 1000;
            IsMarketable = true;
            Bagshow = null;
            Equiptype = Equiptype.Weapon;
            Rarity = Rarity.Normal;
            PProperties.HpM = 100;
            MProperties.HpM = 0.2f;
        }

        //重载使用道具（装备）
        public override void UseItem()
        {
            //判定是否可装备
            
            //装上装备
            CheckMProperties();
        }

        //计算百分比制加成结果
        private void CheckMProperties()
        {
            MFProperties = StatsBase.Multi(PlayerData.Player.PlayerStats,MProperties);
        }
    }
}