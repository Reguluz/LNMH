using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemController : MonoBehaviour
{

	public GameObject BagUi;

	public GameObject SkillTreeUi;

	public GameObject TaskUi;

	public GameObject MainBoardUI;
	// Use this for initialization
	void Start () {
		BagUi.SetActive(false);
		SkillTreeUi.SetActive(false);
		TaskUi.SetActive(false);
		MainBoardUI.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bag()
	{
		if (BagUi.active)
		{
			BagUi.SetActive(false);
		}
		else
		{
			BagUi.SetActive(true);
		}
	}

	
	public void SkillTree()
	{
		if (SkillTreeUi.active)
		{
			SkillTreeUi.SetActive(false);
		}
		else
		{
			SkillTreeUi.SetActive(true);
		}
	}

	
	
	public void Task()
	{
		if (TaskUi.active)
		{
			TaskUi.SetActive(false);
		}
		else
		{
			TaskUi.SetActive(true);
		}
	}

	
	
	public void MainBoard()
	{
		if (MainBoardUI.active)
		{
			MainBoardUI.SetActive(false);
		}
		else
		{
			MainBoardUI.SetActive(true);
		}
	}

	
}
