using System.Collections;
using System.Collections.Generic;
using Character.Player;
using Items.Equips;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class EquipShow : MonoBehaviour,UIFunction
{

	public Button[] Equipment;
	private Text[] btnshow = new Text[6];
	// Use this for initialization
	void Start () {
		CenterControl.Centerctrl.RegisterUI(this);
		for (int i = 0; i < Equipment.Length; i++)
		{
			btnshow[i] = Equipment[i].GetComponentInChildren<Text>();
		}
		RefreshUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RefreshUI()
	{
		for (int i = 0; i < Equipment.Length; i++)
		{
			if (PlayerData.Player.PlayerEquipment.onwear[i]!= null)
			{
				btnshow[i].text = PlayerData.Player.PlayerEquipment.onwear[i].Objindex.Name;
			}
			else
			{
				btnshow[i].text = "空";
			}
		}
	}
}
