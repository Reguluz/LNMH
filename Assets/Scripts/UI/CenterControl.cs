using System.Collections;
using System.Collections.Generic;
using Character;
using Items.Bag;
using UnityEngine;

namespace UI
{
    public class CenterControl:MonoBehaviour
    {
        public ArrayList UiBlocks;
        public ArrayList DataBlocks;
        public static CenterControl Centerctrl;
        public Bagitem OnMouse;
        
        [HideInInspector]
        public int Intervalplace;
        [HideInInspector]
        public int Rightlistchosen;
        [HideInInspector]
        public bool IsSell;
        [HideInInspector]
        public int Setnum;
        
        private void Awake()    //设置单例
        {
            if (Centerctrl == null)
            {
                Centerctrl = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public CenterControl()    //初始化参数
        {
            UiBlocks = new ArrayList();
            DataBlocks = new ArrayList();
            //OnMouse = new Bagitem();
            Setnum = 1;
            Intervalplace = 99;
            Rightlistchosen = 99;
            IsSell = true;
        }

        public void Refresh()
        {
            RefreshData();
            RefreshAllUi();
        }
        
        public void RefreshAllUi()    //刷新所有注册UI
        {
            foreach (UIFunction UI in UiBlocks)
            {
                UI.RefreshUI();
            }
        }

        public void RefreshData()    //刷新所有注册数据
        {
            foreach (RefreshData data in DataBlocks)
            {
                data.RefreshData();
            }
        }


        
        public void RegisterUI(UIFunction d)    //注册UI的函数
        {
            UiBlocks.Add(d);
        }

        public void RegisterData(RefreshData d)
        {
            DataBlocks.Add(d);
        }
       
        
    }
}