using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using Character.Player;
using DataList;
using Items;
using Items.Bag;
using Items.Equips;
using Items.Props;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{

	public PlayerBag Bag;

	public Prop[] ExpProp = new Prop[10];
	public Equip[] ExpEquip = new Equip[6];
	
	

	/*public Equip ExpEquip1 = new Equip();
	public Equip ExpEquip2 = new Equip();*/
	// Use this for initialization
	void Start ()
	{
		PropEnternalHolder propEnternalHolder = AssetDatabase.LoadAssetAtPath<PropEnternalHolder>("Assets/Resources/PropEnternals.asset");
		PropRecoverHolder propRecoverHolder = AssetDatabase.LoadAssetAtPath<PropRecoverHolder>("Assets/Resources/PropRecovers.asset");
		Equiptype[] equiptypes = Enum.GetValues(typeof(Equiptype)) as Equiptype[];

		for (int i = 0; i < 5; i++)
		{
			Item item = new PropEnternal();
			item = propEnternalHolder.EnternalPropList[i];
			Bag.getItem(item,i+1);
		}

		for (int i = 6; i < 10; i++)
		{
			Item item = new PropEnternal();
			item = propRecoverHolder.RecoverPropList[i-5];
			Bag.getItem(item,i-4);
		}
		
		/*ExpProp[0] = new PropRecover
			{
				Objindex =
				{
					Id = 1,
					Name = "数值回复10"
				},
				Price = 10,
				byValue = true,
				PIntimeProperties =
				{
					HpI = 10,
				}
				
			};
			Bag.getItem(ExpProp[0],10);
		
		ExpProp[1] = new PropRecover
		{
			Objindex =
			{
				Id = 2,
				Name = "比例回复20%"
			},
			Price = 10,
			byValue = false,
			MIntimeProperties = 
			{
				HpI = 0.2f,
			}
				
		};
		Bag.getItem(ExpProp[1],10);
		
		ExpProp[2] = new PropEnternal()
		{
			Objindex =
			{
				Id = 3,
				Name = "数值提升10上限"
			},
			Price = 10,
			PProperties = 
			{
				HpM = 10,
			}
			
		};
		Bag.getItem(ExpProp[2],10);*/
		
		for (int i = 0; i < 6; i++)
		{
			ExpEquip[i] = new Equip();
			ExpEquip[i].Objindex.Id = 100+i;
			
			if (equiptypes != null)
			{
				if (i < 5)
				{
					ExpEquip[i].Equiptype = equiptypes[i];
				}
				else
				{
					ExpEquip[i].Equiptype = equiptypes[4];
				}
			}
			ExpEquip[i].Objindex.Name = "装备" + ExpEquip[i].Equiptype + i;
			
			ExpEquip[i].Price = 100*i;
			Bag.getItem(ExpEquip[i],i+1);
		}
		
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
