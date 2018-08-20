using Character;
using Character.Player;

namespace Items.Props
{
    public class PropsBuff:Item
    {
        public StatsBase PProperties = new StatsBase();
        public StatsBase MProperties = new StatsBase();
        public StatsBase MFProperties = new StatsBase();

        public PropsBuff()
        {
            Objindex.Id = 1;
            Objindex.Name = "示例道具1Buff";
            Objindex.Comments = "示例道具1Buff的说明";
            Itemtype = ItemType.Properties;
            Price = 10;
            IsMarketable = true;
            Bagshow = null;
        }
        
        public override void UseItem()
        {
            MFProperties = StatsBase.Multi(PlayerData.Player.PlayerStats,MProperties);
            //Addbuff
            
        }
    }
}