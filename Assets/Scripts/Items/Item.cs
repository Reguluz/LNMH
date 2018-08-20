using Character.Player;
using ID;
using UnityEngine.UI;

namespace Items
{
    public abstract class Item:IItem
    {
        public ObjectIndex Objindex = new ObjectIndex();
        public ItemType Itemtype;
        public int Price;
        public bool IsMarketable;
        public Image Bagshow;

        

        public abstract void UseItem();
    }
}