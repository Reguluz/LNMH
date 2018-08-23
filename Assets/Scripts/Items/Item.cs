using Character.Player;
using ID;
using UnityEngine;

namespace Items
{
    [System.Serializable]
    public abstract class Item:IItem
    {
        public ObjectIndex Objindex = new ObjectIndex();
        public ItemType Itemtype;
        public int Price;
        public bool IsMarketable;
        public Sprite Bagshow;

        

        public abstract void UseItem();
    }
}