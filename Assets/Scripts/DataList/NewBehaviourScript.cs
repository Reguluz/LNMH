using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Excel;
using System.Data;
using DataList;

public class NewBehaviourScript : MonoBehaviour 
{
	void Start () 
	{		
		XLSX();

	}
	
	void XLSX()
	{
		FileStream stream = File.Open(Application.dataPath + "/Scripts/DataList/ItemTable.xlsx", FileMode.Open, FileAccess.Read);
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
	
		do{
			// sheet name
			Debug.Log(excelReader.Name);
			while (excelReader.Read()) {
				for (int i = 0; i < excelReader.FieldCount; i++) {
					string value = excelReader.IsDBNull(i) ? "" : excelReader.GetString(i);
					Debug.Log(value);
				}
			}
		}while(excelReader.NextResult());
	}

}
