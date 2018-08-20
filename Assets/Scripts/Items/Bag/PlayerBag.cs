using System;
using System.Collections.Generic;
using Character.Player;
using Items.Equips;
using UI;
using UnityEngine;

namespace Items.Bag
{
    [Serializable]
    public class PlayerBag:MonoBehaviour
    {
        public int Coins;
        public List<Bagitem> Props = new List<Bagitem>();
        public List<Bagitem> Equips = new List<Bagitem>();
        public List<Bagitem> Materials = new List<Bagitem>();
        public List<Bagitem> Listshow = new List<Bagitem>();

        private static int ONEPAGE = 20;

        public struct intervalist
        {
            public ItemType Type;
            public int page;
        }

        public intervalist Intervalshow;
        public List<Bagitem> listonshow;
        
        //当前页选择
        public void ChangeTab(ItemType type)
        {
            Intervalshow.Type = type;
            Intervalshow.page = 1;
            SetInterval();
        }


        //设置当前页
        public void SetInterval()
        {
            Listshow = new List<Bagitem>();
            listonshow = CheckintervalType();
            
                for (int i = 0; i < ONEPAGE; i++)
                {
                    if (Page2Num(i)<listonshow.Count)
                    {        
                        Listshow.Add(listonshow[Page2Num(i)]);
                    }
                }
            
            
        }
        
        

        //使用道具
        public void UseProps(int serialnum)
        {
            Props[Page2Num(serialnum)].item.UseItem();
            //重新计数
            Props[Page2Num(serialnum)].num--;
            if (Props[Page2Num(serialnum)].num <= 0)
            {
                Props.RemoveAt(Page2Num(serialnum));
            }
            
        }
        
        //选择装备
        public Equip PickEquipment(int serialnum)
        {
            return (Equip)Equips[Page2Num(serialnum)].item;
        }
        
        //消耗材料
        
        //获得（生成）道具
        public void getItem(Item item,int num)
        {
            if (num > 0)
            {
                bool hasItem = false;
                Bagitem newitem = new Bagitem();
                newitem.item = item;
                newitem.num = num;

                if (newitem.item.Itemtype == ItemType.Equipments)
                {
                    
                    for(int i=0;i<num;i++){
                        Bagitem newEquip = new Bagitem();
                        newEquip.num = 1;
                        newEquip.item = newitem.item;
                        Equips.Add(newEquip);
                    }
                }else if (newitem.item.Itemtype == ItemType.Properties){
                    //查找是否已有道具
                    foreach (Bagitem bagitem in Props)
                    {
                        //叠加数量
                        if (bagitem.item.Objindex.Id == item.Objindex.Id)
                        {
                            bagitem.num += num;
                            hasItem = true;
                            break;
                        }
                    }
                    //新增道具
                    if (hasItem == false)
                    {
                        Props.Add(newitem);
                    }
                }else if (newitem.item.Itemtype == ItemType.Materials){
                    //查找是否已有道具
                    foreach (Bagitem bagitem in Materials)
                    {
                        //叠加数量
                        if (bagitem.item.Objindex.Id == item.Objindex.Id)
                        {
                            bagitem.num += num;
                            hasItem = true;
                            break;
                        }
                    }
                    //新增道具
                    if (hasItem == false)
                    {
                        Materials.Add(newitem);
                    }
                }
            }
            
        }
        
        
        
        
        //销毁道具
        public void DestoryItem(int serialnum,int num)
        {
            listonshow = CheckintervalType();
            listonshow[Page2Num(serialnum)].num -= num;
            if (listonshow[Page2Num(serialnum)].num == 0)
            {
                listonshow.RemoveAt(Page2Num(serialnum));
            }
        }
        

        

        //当前页数转序号
        public int Page2Num(int serial)
        {
            return (Intervalshow.page-1)*ONEPAGE + serial;
        }
        
        //识别当前页面类型
        private List<Bagitem> CheckintervalType()
        {
            if (Intervalshow.Type == ItemType.Properties)
            {
                return Props;
            }else if (Intervalshow.Type == ItemType.Equipments)
            {
                return Equips;
            }else if (Intervalshow.Type == ItemType.Materials)
            {
                return Materials;
            }
            else
            {
                return null;
            }
        }

        public void GetCoins(int i)
        {
            Coins += i;
        }
                
    }
}