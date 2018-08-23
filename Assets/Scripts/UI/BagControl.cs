using Character.Player;
using Items;
using Items.Bag;
using Items.Equips;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BagControl:MonoBehaviour,UIFunction
    {
        public Button[] Item = new Button[20];
        public Text Coin;

        public GameObject RightlistUi;
        public GameObject[] RightlistBtn;
        public GameObject MouseFollowUi;
        public GameObject NumInputUI;

        //private bool _areaCheck;
        private bool _isOnDrag = false;
        private int _mouseOver;
        private int _dragOver;
        
        private float _time = 0f; 
        //计数器
        private int _count = 0;
        private bool _isHold = false;
        private Bagitem _wearOnMouse;
        
        private void Start()
        {
            CenterControl.Centerctrl.RegisterUI(this);    //向总控注册该UI
            MouseFollowUi.SetActive(false);
            RightlistUi.SetActive(false);
            NumInputUI.SetActive(false);
            TabClick(1);
            //_areaCheck = true;
            CenterControl.Centerctrl.Rightlistchosen = 99;
        }

        private void OnEnable()
        {
            TabClick(1);
            CenterControl.Centerctrl.RefreshAllUi();
        }

        private void Update()
        {
            if (CenterControl.Centerctrl.OnMouse != null)
            {
                MouseFollowUi.GetComponentInChildren<Text>().text = CenterControl.Centerctrl.OnMouse.item.Objindex.Name;
            }

        }
        
        
        
        
        
        
        
        
        
        
        
        
        public void TabClick(int num)//选择选项卡切换
        {
            if (CheckInit() == false)
            {
                TotalInit();
            }
            
            switch (num)    
            {
                case 1:
                    PlayerData.Player.PlayerBag.ChangeTab(ItemType.Properties);break;
                case 2:
                    PlayerData.Player.PlayerBag.ChangeTab(ItemType.Equipments);break;
                case 3:
                    PlayerData.Player.PlayerBag.ChangeTab(ItemType.Materials);break;
            }
            CenterControl.Centerctrl.Refresh();
        }
        
        public void NextPage(bool isNext)//翻页功能
        {
            if (CheckInit() == false)
            {
                TotalInit();
            }
            
            if (isNext)//向下翻页
            {
                if (PlayerData.Player.PlayerBag.Intervalshow.page + 1 < 5)
                {
                    PlayerData.Player.PlayerBag.Intervalshow.page += 1;
                    PlayerData.Player.PlayerBag.SetInterval();
                }
            }
            else//向上翻页
            {
                if (PlayerData.Player.PlayerBag.Intervalshow.page - 1 > 0)
                {
                    PlayerData.Player.PlayerBag.Intervalshow.page -= 1;
                    PlayerData.Player.PlayerBag.SetInterval();
                }
            }
            CenterControl.Centerctrl.Refresh();
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public void LeftClick()//背包左键单双击效果
        {
            if (CheckInit())//如果状态为空状态
            {
                if (CheckDbClick())//监测双击
                {
                    Debug.Log("双击");
                    if (CheckInteractivity())//如果可操作
                    {
                        if (CenterControl.Centerctrl.Intervalplace < 0)
                        {
                            UninstallEquip(false);
                        }else if (CenterControl.Centerctrl.Intervalplace < 98)
                        {
                            if (PlayerData.Player.PlayerBag.Intervalshow.Type == ItemType.Properties)
                            {
                                Debug.Log("使用了");
                                PlayerData.Player.PlayerBag.UseProps(CenterControl.Centerctrl.Intervalplace);    //使用该栏位物品
                            }else if (PlayerData.Player.PlayerBag.Intervalshow.Type == ItemType.Equipments)
                            {
                                AutoInstall(false);  
                            }
                        }
                    }
                }
                
            }
            else
            {
                TotalInit();
            }
            CenterControl.Centerctrl.Refresh();
        }
        
        public void RightClick()//右键呼出菜单
        {
            if (CheckInit())
            {
                
                CenterControl.Centerctrl.Rightlistchosen = CenterControl.Centerctrl.Intervalplace;
                if (CheckInteractivity())
                {
                    if (CenterControl.Centerctrl.Rightlistchosen < 0)
                    {
                        RightlistBtn[0].GetComponentInChildren<Text>().text = "卸下";
                        RightlistBtn[1].SetActive(false);
                        RightlistBtn[2].SetActive(false);
                        var rect = RightlistUi.GetComponent<RectTransform>().rect;
                        rect.height = 40;
                        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,pos.z);
                        Vector3 realPos = Camera.main.ScreenToWorldPoint(mousePos);
                        RightlistUi.transform.position = new Vector3(realPos.x + 4,realPos.y-5,realPos.z);
                        RightlistUi.SetActive(true);
                    }else if (CenterControl.Centerctrl.Rightlistchosen < 98)
                    {
                        Debug.Log("true");
                        RightlistBtn[0].GetComponentInChildren<Text>().text = "使用";
                        RightlistBtn[1].SetActive(true);
                        RightlistBtn[1].SetActive(true);
                        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,pos.z);
                        Vector3 realPos = Camera.main.ScreenToWorldPoint(mousePos);
                        RightlistUi.transform.position = new Vector3(realPos.x + 4,realPos.y-5,realPos.z);
                        RightlistUi.SetActive(true);
                    }
                }
            }
            else
            {
                TotalInit();
            }
        }
        
        
        public void RightlistClick(int num)//背包右键菜单栏按钮效果
        {
            /*if (CenterControl.Centerctrl.OnMouse != null)
            {
                InitOnMouse();
            }*/
            switch (num)
            {
                case 0:
                {
                    if (CenterControl.Centerctrl.Rightlistchosen < 0)    //卸下装备
                    {
                        UninstallEquip(true);
                        TotalInit();
                    }
                    else if (CenterControl.Centerctrl.Rightlistchosen < 98)    //使用物品
                    {
                        if (PlayerData.Player.PlayerBag.Intervalshow.Type == ItemType.Properties)
                        {
                            PlayerData.Player.PlayerBag.UseProps(CenterControl.Centerctrl.Rightlistchosen);    //使用道具
                            TotalInit(); 
                        }else if (PlayerData.Player.PlayerBag.Intervalshow.Type == ItemType.Equipments)
                        {
                            AutoInstall(true);    //自动装备
                            TotalInit();
                        }
                    } 
                };break;
                
                case 1:
                    //扔
                    if (CenterControl.Centerctrl.Rightlistchosen < 0)
                    {
                        Debug.Log("装备栏不应该有丢弃");
                        TotalInit();
                        //ThrowItem(1);
                    }else if (CenterControl.Centerctrl.Rightlistchosen < 98)
                    {
                        if (PlayerData.Player.PlayerBag.listonshow[CenterControl.Centerctrl.Rightlistchosen].item.Itemtype != ItemType.Equipments)
                        {
                            InputNumUiPopup(false);
                        }
                        else
                        {
                            ThrowItem(1); 
                            TotalInit();
                        } 
                    }
                    else
                    {
                        Debug.Log("99/98不应该有右键菜单");
                        TotalInit();
                    }
                    break;
                
                case 2:
                    //卖
                    if (CenterControl.Centerctrl.Rightlistchosen < 0)
                    {
                        Debug.Log("装备栏不应该有售卖");
                        //ThrowItem(1);
                    }else if (CenterControl.Centerctrl.Rightlistchosen < 98)
                    {
                        if (PlayerData.Player.PlayerBag.listonshow[CenterControl.Centerctrl.Rightlistchosen].item.Itemtype != ItemType.Equipments)
                        {
                            InputNumUiPopup(true);
                        }
                        else
                        {
                            SellItem(1); 
                            TotalInit();
                        } 
                    }
                    else
                    {
                        Debug.Log("99不应该有右键菜单");
                        TotalInit();
                    }
                    break;
            }
            CenterControl.Centerctrl.Refresh();
        }
        
        public void OnDrag()    //按住开始拖拽
        {
            if (CheckInit())
            {
                if (CheckInteractivity())
                {
                    
                    if (CenterControl.Centerctrl.Intervalplace < 98)
                    {
                        _isOnDrag = true;
                        _dragOver = CenterControl.Centerctrl.Intervalplace;
                        ChooseItem();
                   
                    }
                    else
                    {
                        Debug.Log("不能拖");
                    }
                }
            }
            else
            {
                TotalInit();
            }
            
            CenterControl.Centerctrl.Refresh(); 
        }

        public void DragRelease()    //松鼠标
        {
            Debug.Log("鼠标松开" + "正在拖拽"+_isOnDrag);
            if (_isOnDrag)
            {
                if (CenterControl.Centerctrl.OnMouse != null)
                {
                        PullDownItem();
                       _dragOver = 999;
                }
            }
            //CenterControl.Centerctrl.Refresh();
        }
    
        public void UIOnFocus(int num)    //按钮获得焦点
        {
            //if(_areaCheck)    //如果没锁就返回相应序号
                CenterControl.Centerctrl.Intervalplace = num;
        }
        public void UIOffFocus()    //焦点移除
        {
            //if(_areaCheck)
                CenterControl.Centerctrl.Intervalplace = 99;  
        }

        
        
        
        
        
        
        
        
        
        
        
        

        public void RefreshUI()
        {
            for (int i = 0; i < 20; i++)    //逐物品重写内容
            {   
                if (i<PlayerData.Player.PlayerBag.Listshow.Count)    //此格有物品
                {
                    Item[i].GetComponent<Image>().sprite = PlayerData.Player.PlayerBag.Listshow[i].item.Bagshow;
                    Item[i].gameObject.GetComponentInChildren<Text>().text = PlayerData.Player.PlayerBag.Listshow[i].item.Objindex.Name + " : " + PlayerData.Player.PlayerBag.Listshow[i].num;
                    Item[i].interactable = true;
                }
                else
                {
                    Item[i].GetComponent<Image>().sprite = null;
                    Item[i].gameObject.GetComponentInChildren<Text>().text = " ";
                    Item[i].interactable = false;
                }
            }
            PlayerData.Player.PlayerBag.SetInterval();
            Coin.text = "Coins:  " + PlayerData.Player.PlayerBag.Coins+"    " + "Page:  "+PlayerData.Player.PlayerBag.Intervalshow.page;
            //RightlistUI.transform.position = new Vector3(-500,-650,0);
        }


        

        private bool CheckDbClick()
        {
            _count++;
            //当第一次点击鼠标，启动计时器
            if (_count == 1)
            {
                _time = Time.time;
                _mouseOver = CenterControl.Centerctrl.Intervalplace;
                return false;
            } 
            //当第二次点击鼠标，且时间间隔满足要求时双击鼠标
            if(2 == _count && Time.time - _time <= 0.5f&& _mouseOver == CenterControl.Centerctrl.Intervalplace)
            {
                _count = 0;
                return true;      
            }
            if(Time.time - _time > 0.5f)
            {
                _time = Time.time;
                _count = 1;
                _mouseOver = CenterControl.Centerctrl.Intervalplace;
                
                return false;
            }
            return false;
        }

        
        /*public void WearEquipment()
        {
            
            Debug.Log("鼠标装备了槽位"+CenterControl.Centerctrl.Intervalplace);
            if (CenterControl.Centerctrl.OnMouse != null)
            {
                Debug.Log("鼠标拖动不为空：" + CenterControl.Centerctrl.OnMouse.item.Objindex.Name);
                if (CenterControl.Centerctrl.Intervalplace < 0)
                {
                    if (CenterControl.Centerctrl.OnMouse.item.Itemtype == ItemType.Equipments)
                    {
                        Debug.Log("拖动的是装备");
                        PlayerData.Player.PlayerEquipment.Wear(-(CenterControl.Centerctrl.Intervalplace+1),(Equip)CenterControl.Centerctrl.OnMouse.item);
                    }
                    else
                    {
                        //提示不是装备
                        Debug.Log("拖动的不是装备,退回");
                        CenterControl.Centerctrl.Intervalplace = 99;
                        PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num);
                    }
                }
                else
                {
                    Debug.Log("放置错误，退回");
                    CenterControl.Centerctrl.Intervalplace = 99;
                    PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num);
                }
                MouseFollowUi.SetActive(false);
                _areaCheck = false;
                CenterControl.Centerctrl.Refresh();
            }
            
        }*/

        public void ChooseItem()
        {
            //执行贴图赋给鼠标的函数
            Debug.Log("将当前物品附着鼠标上");    
            
            if (_dragOver < 0)
            {
                Debug.Log("提取装备" + PlayerData.Player.PlayerEquipment.onwear[Bag2Equip(_dragOver)].Objindex.Name);
                //CenterControl.Centerctrl.OnMouse = new Bagitem();
                _wearOnMouse = new Bagitem();
                _wearOnMouse.num = 1;
                _wearOnMouse.item = PlayerData.Player.PlayerEquipment.onwear[Bag2Equip(_dragOver)];
                
                CenterControl.Centerctrl.OnMouse = _wearOnMouse;
                
                PlayerData.Player.PlayerEquipment.onwear[Bag2Equip(_dragOver)] = null;
            }
            else
            {
                Debug.Log("提取物品" + PlayerData.Player.PlayerBag.Listshow[_dragOver].item.Objindex.Name + PlayerData.Player.PlayerBag.Listshow[_dragOver].num + "个");
                CenterControl.Centerctrl.OnMouse = PlayerData.Player.PlayerBag.Listshow[_dragOver];
                
                /*CenterControl.Centerctrl.OnMouse.item = PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Intervalplace].item;
                CenterControl.Centerctrl.OnMouse.num =
                    PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Intervalplace].num;
                PlayerData.Player.PlayerBag.listonshow.RemoveAt(PlayerData.Player.PlayerBag.Page2Num(CenterControl.Centerctrl.Intervalplace));*/
            }
            SetMouseFollowUIActive(true);
        }
        
        
        
        
        
        
        

        private void UninstallEquip(bool isFromRightlist)    //卸下装备
        {
            if (isFromRightlist)
            {
                PlayerData.Player.PlayerEquipment.RemoveEquip(Bag2Equip(CenterControl.Centerctrl.Rightlistchosen));
            }
            else
            {
                PlayerData.Player.PlayerEquipment.RemoveEquip(Bag2Equip(CenterControl.Centerctrl.Intervalplace));
            }
            
        }
        
        public void ThrowItem(int num)    //丢弃物品
        {
            if (CenterControl.Centerctrl.OnMouse != null)
            {
                Debug.Log(CenterControl.Centerctrl.OnMouse.item.Objindex.Name);
                if (CenterControl.Centerctrl.OnMouse.num - num != 0)
                {
                    CenterControl.Centerctrl.OnMouse.num -= num;
                    //PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num - num);
                    Debug.Log("丢弃了" + num + "个" + CenterControl.Centerctrl.OnMouse.item.Objindex.Name);
                }
                else
                {
                    PlayerData.Player.PlayerBag.Listshow.Remove(CenterControl.Centerctrl.OnMouse) ;
                }
                CenterControl.Centerctrl.OnMouse = null;
            }else
            {
                if (PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num - num != 0)
                {
                    PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num -= num;
                }
                else
                {
                    Debug.Log("移除了");
                    PlayerData.Player.PlayerBag.listonshow.RemoveAt(PlayerData.Player.PlayerBag.Page2Num(CenterControl.Centerctrl.Rightlistchosen));
                }
                Debug.Log("丢弃了" + num + "个" + PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].item.Objindex.Name+'\n'+"剩余"+PlayerData.Player.PlayerBag.listonshow[CenterControl.Centerctrl.Rightlistchosen].num);
            }      
            TotalInit();
        }

        public void SellItem(int num)    //售卖物品
        {
            
                PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num -= num;
                PlayerData.Player.PlayerBag.GetCoins((int)(PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].item.Price * 0.2f * num));
                if (PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num == 0)
                {
                    PlayerData.Player.PlayerBag.listonshow.RemoveAt(PlayerData.Player.PlayerBag.Page2Num(CenterControl.Centerctrl.Rightlistchosen));
                }
                Debug.Log("售卖了" + CenterControl.Centerctrl.Setnum + "个" + PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].item.Objindex.Name);
            
            TotalInit();

        }
        
        private void AutoInstall(bool isFromRightlist)	//自动装备
        {
            if (isFromRightlist)
            {
                PlayerData.Player.PlayerEquipment.SearchSlot(PlayerData.Player.PlayerBag.PickEquipment(CenterControl.Centerctrl.Rightlistchosen));
                PlayerData.Player.PlayerBag.listonshow.RemoveAt(PlayerData.Player.PlayerBag.Page2Num(CenterControl.Centerctrl.Rightlistchosen));
            }
            else
            {
                PlayerData.Player.PlayerEquipment.SearchSlot(PlayerData.Player.PlayerBag.PickEquipment(CenterControl.Centerctrl.Intervalplace));
                PlayerData.Player.PlayerBag.listonshow.RemoveAt(PlayerData.Player.PlayerBag.Page2Num(CenterControl.Centerctrl.Intervalplace));
            }
            TotalInit();
        }

        
        
        

        /*public void LockCheck()
        {
            _areaCheck = false;
        }*/
        
        public void SetMouseFollowUIActive(bool isActive)    
        {
            if (isActive)
            {
                MouseFollowUi.SetActive(true);
            }
            else
            {
                MouseFollowUi.SetActive(false);
            }
        }

        public void SetRightListUIActive(bool isActive)
        {
            if (isActive)
            {
                RightlistUi.SetActive(true);
            }
            else
            {
                RightlistUi.SetActive(false);
            }
        }
        
        public void SetNumInputUIActive(bool isActive)
        {
            if (isActive)
            {
                NumInputUI.SetActive(true);
            }
            else
            {
                NumInputUI.SetActive(false);
            }
        }

        public void PullDownItem()
        {
            if (CenterControl.Centerctrl.OnMouse.item != null)
            {
                if (CenterControl.Centerctrl.Intervalplace<0)
                {
                    Debug.Log("在装备松开");
                    //在装备松开
                    Bagitem temp = new Bagitem();
                    temp = CenterControl.Centerctrl.OnMouse;
                    
                    PlayerData.Player.PlayerBag.listonshow.Remove(CenterControl.Centerctrl.OnMouse);
                    PlayerData.Player.PlayerEquipment.Wear(Bag2Equip(CenterControl.Centerctrl.Intervalplace),temp);
                    if (_dragOver < 0)
                    {
                        PlayerData.Player.PlayerEquipment.onwear[Bag2Equip(_dragOver)] = null;
                        
                    }
                    CenterControl.Centerctrl.OnMouse = null;
                    /*
                    else
                    {
                        Debug.Log("背包源" + PlayerData.Player.PlayerBag.listonshow[PlayerData.Player.PlayerBag.Page2Num(_dragOver)].item.Objindex.Name + PlayerData.Player.PlayerBag.listonshow[PlayerData.Player.PlayerBag.Page2Num(_dragOver)].num);
                        Debug.Log("清除后背包源" + PlayerData.Player.PlayerBag.listonshow[PlayerData.Player.PlayerBag.Page2Num(_dragOver)].item.Objindex.Name + PlayerData.Player.PlayerBag.listonshow[PlayerData.Player.PlayerBag.Page2Num(_dragOver)].num);
                    }*/
                    InitSpecialUI();
                    //PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,1);
                }else if (CenterControl.Centerctrl.Intervalplace < 99)
                {
                    //在背包松开
                    Debug.Log("收回物品" + CenterControl.Centerctrl.OnMouse.item.Objindex.Name);
                    if (_dragOver < 0)
                    {
                        PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num);
                        CenterControl.Centerctrl.OnMouse = null;
                    }
                    
                    InitOnMouse();
                }else if(CenterControl.Centerctrl.Intervalplace == 99){
                    if (_dragOver < 0)
                    {
                        PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num);
                        CenterControl.Centerctrl.OnMouse = null;
                    }else if (CenterControl.Centerctrl.OnMouse.item.Itemtype != ItemType.Equipments)
                    {
                        Debug.Log("丢的不是装备");
                        InputNumUiPopup(false);  
                    }
                    else
                    {
                        ThrowItem(1);
                    }
                }
            }
            TotalInit();
            _isOnDrag = false;
            _dragOver = 999;
            
            CenterControl.Centerctrl.Refresh();
        }


        private void InputNumUiPopup(bool isSell)
        {
            Debug.Log("打开mainboard");
            NumInputUI.SetActive(true);
            CenterControl.Centerctrl.IsSell = isSell;
            MouseFollowUi.SetActive(false);
            RightlistUi.SetActive(false);
        }

        public void InputNumUIPopDown()
        {
            SetNumInputUIActive(false);
            if (CenterControl.Centerctrl.IsSell)
            {
                
                SellItem(CenterControl.Centerctrl.Setnum);
            }
            else
            {
                
                ThrowItem(CenterControl.Centerctrl.Setnum);
                if (CenterControl.Centerctrl.OnMouse != null)
                {
                    CenterControl.Centerctrl.OnMouse = null;
                }
            } 
            TotalInit();
            CenterControl.Centerctrl.Refresh();
        }

        private void InitOnMouse()
        {
            if (CenterControl.Centerctrl.OnMouse != null)
            {
                Debug.Log("被初始化");
                //PlayerData.Player.PlayerBag.getItem(CenterControl.Centerctrl.OnMouse.item,CenterControl.Centerctrl.OnMouse.num);
                CenterControl.Centerctrl.OnMouse = null;
                SetMouseFollowUIActive(false);
            }
        }

        private void InitSpecialUI()
        {
            if (RightlistUi.active)
            {
                SetRightListUIActive(false);
                var rect = RightlistUi.GetComponent<RectTransform>().rect;
                rect.height = 100;
                foreach (GameObject button in RightlistBtn)
                {
                    button.SetActive(true);
                }
            }

            if (MouseFollowUi.active)
            {
                MouseFollowUi.SetActive(false);
            }

            if (NumInputUI.active)
            {
                NumInputUI.SetActive(false);
            }
        }

        private void InitStateCheck()
        {
            _isOnDrag = false;
            CenterControl.Centerctrl.Rightlistchosen = 99;
        }

        private void TotalInit()
        {
            InitOnMouse();
            InitSpecialUI();
            InitStateCheck();
            PlayerData.Player.PlayerBag.SetInterval();
        }

        private bool CheckInit()
        {
            if (RightlistUi.active || MouseFollowUi.active || NumInputUI.active ||
                CenterControl.Centerctrl.OnMouse != null || _isOnDrag)
            {
                Debug.Log("CenterControl.Centerctrl.OnMouse  " + CenterControl.Centerctrl.OnMouse);
                Debug.Log("_isOnDrag  " + _isOnDrag);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckInteractivity()
        {
            int tempBagSlot = CenterControl.Centerctrl.Intervalplace;
            if (tempBagSlot < 98)
            {
                if (tempBagSlot >= 0)
                {
                    if (tempBagSlot - PlayerData.Player.PlayerBag.Listshow.Count < 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }else if (tempBagSlot < 0)
                {
                    if (PlayerData.Player.PlayerEquipment.onwear[Bag2Equip(tempBagSlot)] != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        private int Bag2Equip(int slot)
        {
            return -(slot + 1);
        }

    }
}





