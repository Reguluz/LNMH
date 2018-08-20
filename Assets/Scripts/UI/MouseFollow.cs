using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour
{

	private Text text;
	// Use this for initialization
	void Start ()
	{
		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,pos.z);
		Vector3 realPos = Camera.main.ScreenToWorldPoint(mousePos);
		transform.position = new Vector3(realPos.x + 4,realPos.y-5,realPos.z);
	}
}
