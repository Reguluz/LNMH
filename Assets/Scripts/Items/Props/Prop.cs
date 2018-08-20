using Character;
using Character.Player;
using ID;
using UnityEngine;

namespace Items.Props
{
    public class Prop:Item
    {
          

        public Prop()
        {
            Objindex.Id = 1;
            Objindex.Name = "示例道具1";
            Objindex.Comments = "示例道具1的说明";
            Itemtype = ItemType.Properties;
            Price = 10;
            IsMarketable = true;
            Bagshow = null;
        }

        public override void UseItem()
        {
            
        }

        
    }
}