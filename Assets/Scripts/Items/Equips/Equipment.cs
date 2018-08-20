using System.Collections.Generic;
using Character;
using Character.Player;
using Items.Bag;
using UI;
using UnityEngine;

namespace Items.Equips
{
    public class Equipment:RefreshData
    {
        private Equiptype[] _slot =new Equiptype[6]        //设置槽位
        {
            Equiptype.Weapon,
            Equiptype.Clothes,
            Equiptype.Glove,
            Equiptype.Shoes,
            Equiptype.Ornament,
            Equiptype.Ornament
        };
        
        public Equip[] onwear;
        public StatsBase TotalEquips;
        private Equip _equip1;

        public Equipment()
        {
            TotalEquips = new StatsBase();
            onwear = new Equip[6];
            // ReSharper disable once NotAccessedVariable
            /*for (int i = 0; i < 6; i++)
            {
                onwear[i] = new Equip();
            }*/
            CenterControl.Centerctrl.RegisterData(this);
        }

        public void RefreshData()    //刷新装备数据
        {
            TotalEquips = new StatsBase();
            foreach (Equip equip in onwear)
            {
                if (equip != null)
                {
                    TotalEquips.Add(equip.MFProperties);    
                    TotalEquips.Add(equip.PProperties);
                }
            }
        }


        public void SearchSlot(Equip equip)    //搜索槽位（自动）
        {
            Debug.Log(equip.Equiptype);
            if (equip.Equiptype.Equals(Equiptype.Ornament))
            {
                if (onwear[4] == null)
                {
                    Wear(4,new Bagitem()
                    {
                        item = equip,
                        num = 1
                    });
                }else if (onwear[5] == null)
                {
                    Wear(5,new Bagitem()
                    {
                        item = equip,
                        num = 1
                    });
                }else if (onwear[4].Objindex.Id - onwear[5].Objindex.Id <=0)
                {
                    Wear(4,new Bagitem()
                    {
                        item = equip,
                        num = 1
                    });
                }
                else
                {
                    Wear(5,new Bagitem()
                    {
                        item = equip,
                        num = 1
                    });
                }
                /*else 
                {
                    Wear(5,equip);
                    Debug.Log("5");
                }*/
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (equip.Equiptype.Equals(_slot[i]))
                    {
                        Wear(i,new Bagitem()
                        {
                            item = equip,
                            num = 1
                        });
                        Debug.Log(i);
                    }
                }
            }
        }
        

        //检测装备槽位（手动）
        public void Wear(int slot,Bagitem bagitem)
        {
            if (bagitem.item.Itemtype == ItemType.Equipments)
            {
                Equip equip = (Equip) bagitem.item;
                if (equip.Equiptype.Equals(_slot[slot]))
                {
                    if (onwear[slot] != null)
                    {
                        BackToBag(slot);
                        onwear[slot] = equip;
                    }
                    else
                    {
                        onwear[slot] = equip;
                    }
                    onwear[slot].UseItem();
                    CenterControl.Centerctrl.Refresh();
                }
                else
                {
                    PlayerData.Player.PlayerBag.getItem(bagitem.item,bagitem.num);
                    //返回提示不符合
                    Debug.Log("不是该处装备");
                }
            }
            else
            {
                PlayerData.Player.PlayerBag.getItem(bagitem.item,bagitem.num);
                Debug.Log("这不是装备");
            }  
        }
      

        //卸下装备
        public void RemoveEquip(int i)
        {
            Debug.Log("卸下装备"+i);
            BackToBag(i);
            onwear[i] = null;
            RefreshData();
            CenterControl.Centerctrl.Refresh();
        }
        
        //旧装备回背包
        private void BackToBag(int i)
        {
            PlayerData.Player.PlayerBag.getItem(onwear[i],1);
            Debug.Log("退回了装备"+onwear[i].Objindex.Name);
            RefreshData();
            CenterControl.Centerctrl.Refresh();
        }

    }
}