using System;
using System.Collections;
using System.Collections.Generic;
using Character.Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class NumInputUI : MonoBehaviour
{

	public InputField InputField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnEnable()
	{
		InputField.text = "1";
		CenterControl.Centerctrl.Setnum = 1;
	}
	
	public void Addnum(int i)
	{
		CenterControl.Centerctrl.Setnum += i;
		Checknum();
	}

	public void Checknum()
	{
			if (CenterControl.Centerctrl.OnMouse != null)
			{
				Debug.Log("鼠标有东西");
				if (CenterControl.Centerctrl.OnMouse.num - CenterControl.Centerctrl.Setnum < 0)
				{
					CenterControl.Centerctrl.Setnum = CenterControl.Centerctrl.OnMouse.num;
				}else if (CenterControl.Centerctrl.Setnum < 1)
				{
					CenterControl.Centerctrl.Setnum = 1;
				}
			}
			
			else if(CenterControl.Centerctrl.Rightlistchosen<98)
			{
				Debug.Log("现在有选择");
				if (PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num - CenterControl.Centerctrl.Setnum < 0)
				{
					CenterControl.Centerctrl.Setnum = PlayerData.Player.PlayerBag.Listshow[CenterControl.Centerctrl.Rightlistchosen].num;
				}else if (CenterControl.Centerctrl.Setnum < 1)
				{
					CenterControl.Centerctrl.Setnum = 1;
				}
			}
			

			if (InputField.text != CenterControl.Centerctrl.Setnum.ToString())
			{
				InputField.text = CenterControl.Centerctrl.Setnum.ToString();
			}
		
			
	}

	public void SetNum()
	{
		if (InputField.text != null)
		{
			CenterControl.Centerctrl.Setnum = Convert.ToInt32(InputField.text);
		}
	}
}
