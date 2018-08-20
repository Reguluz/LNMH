using System.Collections;
using System.Collections.Generic;
using Character.Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour,UIFunction
{

	public Text HP;


	// Use this for initialization
	void Start ()
	{
		CenterControl.Centerctrl.RegisterUI(this);	//向总控注册该UI
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void RefreshUI()
	{
		HP.text = "HP:" + PlayerData.Player.TotalIntime.HpI + "  /  " + PlayerData.Player.TotalStats.HpM;	
	}
}
