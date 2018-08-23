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
		
			show.text = "当前鼠标焦点在序号： " + CenterControl.Centerctrl.Intervalplace + '\n'
			            + "鼠标拖动的装备为" + CenterControl.Centerctrl.OnMouse.item.Objindex.Name + '\n' + '\n'
			            + "以下格式为 当前 / 总量 / 回复值 / 基础回复值 / Buff附加值 / 永久道具附加值" + '\n'
			            + "实时体力  " + PlayerData.Player.TotalIntime.HpI + " / "
										+ PlayerData.Player.TotalStats.HpM + " / "
										+ PlayerData.Player.TotalIntimeRecover.HpI + " / "
										+ PlayerData.Player.PlayerStats.HpR + " / "
										+ PlayerData.Player.TotalBuff.HpR + " / "
										+ PlayerData.Player.TotalItemStats.HpR + '\n'
			            + "实时灵力  " + PlayerData.Player.TotalIntime.MpI + " / "
										+ PlayerData.Player.TotalStats.MpM + " / "
										+ PlayerData.Player.TotalIntimeRecover.MpI + " / "
										+ PlayerData.Player.PlayerStats.MpR + " / "
										+ PlayerData.Player.TotalBuff.MpR + " / "
										+ PlayerData.Player.TotalItemStats.MpR + '\n'
			            + "实时无双  " + PlayerData.Player.TotalIntime.MpI + " / "
										+ PlayerData.Player.TotalStats.MpM  + '\n' + '\n'
			            + "以下格式为 总状态 / Buff附加值 / 装备附加值 / 永久状态 / 永久道具附加值 / 基础状态" + '\n'
			            + "攻击" + PlayerData.Player.TotalStats.Atk + " / "
								+ PlayerData.Player.TotalBuff.Atk + " / "
								+ PlayerData.Player.PlayerEquipment.TotalEquips.Atk + " / "
								+ PlayerData.Player.BaseStats.Atk + " / "
								+ PlayerData.Player.TotalItemStats.Atk + " / "
								+ PlayerData.Player.PlayerStats.Atk + " / " + '\n'
			            + "近程系数" + PlayerData.Player.TotalStats.NAtk + " / "
								+ PlayerData.Player.TotalBuff.NAtk + " / "
								+ PlayerData.Player.PlayerEquipment.TotalEquips.NAtk + " / "
								+ PlayerData.Player.BaseStats.NAtk + " / "
								+ PlayerData.Player.TotalItemStats.NAtk + " / "
								+ PlayerData.Player.PlayerStats.NAtk + " / " + '\n'
			            + "远程系数" + PlayerData.Player.TotalStats.FAtk + " / "
								+ PlayerData.Player.TotalBuff.FAtk + " / "
								+ PlayerData.Player.PlayerEquipment.TotalEquips.FAtk + " / "
								+ PlayerData.Player.BaseStats.FAtk + " / "
								+ PlayerData.Player.TotalItemStats.FAtk + " / "
								+ PlayerData.Player.PlayerStats.FAtk + " / " + '\n'
			            + "防御" + PlayerData.Player.TotalStats.Def + " / "
								+ PlayerData.Player.TotalBuff.Def + " / "
								+ PlayerData.Player.PlayerEquipment.TotalEquips.Def + " / "
								+ PlayerData.Player.BaseStats.Def + " / "
								+ PlayerData.Player.TotalItemStats.Def + " / "
								+ PlayerData.Player.PlayerStats.Def + " / " + '\n'
			            + "移动速度" + PlayerData.Player.TotalStats.SpdM + " / "
									+ PlayerData.Player.TotalBuff.SpdM + " / "
									+ PlayerData.Player.PlayerEquipment.TotalEquips.SpdM + " / "
									+ PlayerData.Player.BaseStats.SpdM + " / "
									+ PlayerData.Player.TotalItemStats.SpdM + " / "
									+ PlayerData.Player.PlayerStats.SpdM + " / " + '\n'
			            + "攻击速度" + PlayerData.Player.TotalStats.SpdA + " / "
									+ PlayerData.Player.TotalBuff.SpdA + " / "
									+ PlayerData.Player.PlayerEquipment.TotalEquips.SpdA + " / "
									+ PlayerData.Player.BaseStats.SpdA + " / "
									+ PlayerData.Player.TotalItemStats.SpdA + " / "
									+ PlayerData.Player.PlayerStats.SpdA + " / " + '\n'
			            + "暴击率" + PlayerData.Player.TotalStats.CritP + " / "
									+ PlayerData.Player.TotalBuff.CritP + " / "
									+ PlayerData.Player.PlayerEquipment.TotalEquips.CritP + " / "
									+ PlayerData.Player.BaseStats.CritP + " / "
									+ PlayerData.Player.TotalItemStats.CritP + " / "
									+ PlayerData.Player.PlayerStats.CritP + " / " + '\n'
			            + "暴击比例" + PlayerData.Player.TotalStats.CritM + " / "
									+ PlayerData.Player.TotalBuff.CritM + " / "
									+ PlayerData.Player.PlayerEquipment.TotalEquips.CritM + " / "
									+ PlayerData.Player.BaseStats.CritM + " / "
									+ PlayerData.Player.TotalItemStats.CritM + " / "
									+ PlayerData.Player.PlayerStats.CritM + " / " + '\n'
				
				;
		
	}
}
