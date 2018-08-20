using System.Collections;
using System.Collections.Generic;
using Character.Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class TestShow : MonoBehaviour
{

	public Text show;
	// Use this for initialization
	void Start ()
	{
		show = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CenterControl.Centerctrl.OnMouse != null)
		{
			show.text = "当前鼠标焦点在序号： " + CenterControl.Centerctrl.Intervalplace + '\n'
			            + "鼠标拖动的装备为" + CenterControl.Centerctrl.OnMouse.item.Objindex.Name + '\n'
				+"总血量上限" + PlayerData.Player.TotalStats.HpM + '\n'
				+"基础血量上限" + PlayerData.Player.PlayerStats.HpM + '\n'
				+"装备提供血量上限" + PlayerData.Player.PlayerEquipment.TotalEquips.HpM;
		}
		else
		{
			show.text = "当前鼠标焦点在序号： " + CenterControl.Centerctrl.Intervalplace + '\n'
			            +"总血量上限" + PlayerData.Player.TotalStats.HpM + '\n'
			            +"基础血量上限" + PlayerData.Player.PlayerStats.HpM + '\n'
			            +"装备提供血量上限" + PlayerData.Player.PlayerEquipment.TotalEquips.HpM;
		}
	
				/*+ "鼠标拖动的装备为" + BagControl.onMouse.Objindex.Name + '\n' + '\n'
				/*+ "当前装备" + PlayerData.Player.PlayerEquipment.onwear[0].Objindex.Name + '\n'
				+ PlayerData.Player.PlayerEquipment.onwear[1].Objindex.Name + '\n'
				+ PlayerData.Player.PlayerEquipment.onwear[2].Objindex.Name + '\n'
				+ PlayerData.Player.PlayerEquipment.onwear[3].Objindex.Name + '\n'	
				+ PlayerData.Player.PlayerEquipment.onwear[4].Objindex.Name + '\n'
				+ PlayerData.Player.PlayerEquipment.onwear[5].Objindex.Name + '\n'*/
	}
}
