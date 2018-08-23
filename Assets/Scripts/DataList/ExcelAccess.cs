using System;
using UnityEngine;
using Excel;
using System.Data;
using System.IO;
using System.Collections.Generic;
using Buffs;
using Character;
using ID;
using Items;
using Items.Props;
using UnityEditor;

namespace DataList
{
    public class ExcelAccess
    {
        static string excelName = "ItemTable.xlsx";
        //查询PropEnternal表
        public static List<PropEnternal> SelectPropEnternalTable()
        {
            string sheetName = "PropEnternal";
            DataRowCollection collect = ExcelAccess.ReadExcel(excelName, 0);
            List<PropEnternal> propEArray = new List<PropEnternal>();
            for (int i = 1; i < collect.Count; i++)
            {
                if (collect[i][1].ToString() == "") continue;
 
                PropEnternal PropE = new PropEnternal
                {
                    Objindex = new ObjectIndex()
                    {
                        Id = Convert.ToInt32(collect[i][0].ToString()),
                        Name = collect[i][1].ToString(),
                        Comments = collect[i][2].ToString(),
                    },
                    Itemtype = ItemType.Properties,
                    Price = Convert.ToInt32(collect[i][3].ToString()),
                    IsMarketable = Convert.ToBoolean(collect[i][4].ToString()),
                    Bagshow = Resources.Load<Sprite>("Item/"+Convert.ToInt32(collect[i][0].ToString())),
                    PProperties = new StatsBase()
                    {
                        HpM = Convert.ToSingle(collect[i][6].ToString()),
                        HpR = Convert.ToSingle(collect[i][7].ToString()),
                        Atk = Convert.ToSingle(collect[i][8].ToString()),
                        NAtk = Convert.ToSingle(collect[i][9].ToString()),
                        FAtk = Convert.ToSingle(collect[i][10].ToString()),
                        Def = Convert.ToSingle(collect[i][11].ToString()),
                        SpdM = Convert.ToSingle(collect[i][12].ToString()),
                        SpdA = Convert.ToSingle(collect[i][13].ToString()),
                        MpM = Convert.ToInt32(collect[i][14].ToString()),
                        MpR = Convert.ToInt32(collect[i][15].ToString()),
                        CritP = Convert.ToSingle(collect[i][16].ToString()),
                        CritM = Convert.ToSingle(collect[i][17].ToString()),
                        MgM = Convert.ToSingle(collect[i][18].ToString()),
                    }
                    
                    /*m_Id = collect[i][0].ToString(),
                    m_level = collect[i][1].ToString(),
                    m_parentId = collect[i][2].ToString(),
                    m_name = collect[i][3].ToString()*/
                };
                propEArray.Add(PropE);
            }
            return propEArray;
        }
        
        public static List<PropRecover> SelectPropRecoverTable()
        {
            string sheetName = "PropRecover";
            DataRowCollection collect = ExcelAccess.ReadExcel(excelName, 1);
 
            List<PropRecover> PropRArray = new List<PropRecover>();
            for (int i = 1; i < collect.Count; i++)
            {
                if (collect[i][1].ToString() == "") continue;
 
                PropRecover PropR = new PropRecover
                {
                    Objindex = new ObjectIndex()
                    {
                        Id = Convert.ToInt32(collect[i][0].ToString()),
                        Name = collect[i][1].ToString(),
                        Comments = collect[i][2].ToString(),
                    },
                    Itemtype = ItemType.Properties,
                    Price = Convert.ToInt32(collect[i][3].ToString()),
                    IsMarketable = Convert.ToBoolean(collect[i][4].ToString()),
                    Bagshow = Resources.Load<Sprite>("Item/"+Convert.ToInt32(collect[i][0].ToString())),
                    PIntimeProperties = new StatsIntime()
                    {
                        HpI = Convert.ToSingle(collect[i][6].ToString()),
                        MpI = Convert.ToSingle(collect[i][7].ToString()),
                        MgI = Convert.ToSingle(collect[i][8].ToString()),
                    },
                    Buffs = new List<int>()
                };
                for (int j = 9;j<16; j++)
                {
                    if (collect[i][j] != null)
                    {
                        PropR.Buffs.Add(Convert.ToInt32(collect[i][j].ToString()));
                    }
                    else
                    {
                        break;
                    }
                }
                PropRArray.Add(PropR);
            }
            return PropRArray;
        }
        
        public static List<Buff> SelectBuffTable()
        {
            string sheetName = "Buff";
            DataRowCollection collect = ExcelAccess.ReadExcel(excelName, 2);
 
            List<Buff> BuffArray = new List<Buff>();
            for (int i = 1; i < collect.Count; i++)
            {
                if (collect[i][1].ToString() == "") continue;
 
                Buff buff = new Buff()
                {
                    Objindex = new ObjectIndex()
                    {
                        Id = Convert.ToInt32(collect[i][0].ToString()),
                        Name = collect[i][1].ToString(),
                        Comments = collect[i][2].ToString(),
                    },
                    Buffshow = Resources.Load<Sprite>("Item/"+Convert.ToInt32(collect[i][0].ToString())),
                    IsRecover = (bool) collect[i][4],
                    IsInterruptible = (bool)collect[i][5],
                    EffectRecoverP = new StatsIntime()
                    {
                        HpI = Convert.ToSingle(collect[i][6].ToString()),
                        MpI = Convert.ToSingle(collect[i][7].ToString()),
                        MgI = Convert.ToSingle(collect[i][8].ToString()),
                    },
                    EffectStats = new StatsBase()
                    {
                        HpM = Convert.ToSingle(collect[i][9].ToString()),
                        HpR = Convert.ToSingle(collect[i][10].ToString()),
                        Atk = Convert.ToSingle(collect[i][11].ToString()),
                        NAtk = Convert.ToSingle(collect[i][12].ToString()),
                        FAtk = Convert.ToSingle(collect[i][13].ToString()),
                        Def = Convert.ToSingle(collect[i][14].ToString()),
                        SpdM = Convert.ToSingle(collect[i][15].ToString()),
                        SpdA = Convert.ToSingle(collect[i][16].ToString()),
                        MpM = Convert.ToInt32(collect[i][17].ToString()),
                        MpR = Convert.ToInt32(collect[i][18].ToString()),
                        CritP = Convert.ToSingle(collect[i][19].ToString()),
                        CritM = Convert.ToSingle(collect[i][20].ToString()),
                        MgM = Convert.ToSingle(collect[i][21].ToString()),
                    },
                    EffectTime = Convert.ToInt32(collect[i][22].ToString()),
                };
                BuffArray.Add(buff);
            }
            return BuffArray;
        }
        
 
        /// <summary>
        /// 读取 Excel ; 需要添加 Excel.dll; System.Data.dll;
        /// </summary>
        /// <param name="excelName">excel文件名</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns>DataRow的集合</returns>
        static DataRowCollection ReadExcel(string excelName,int sheetName)
        {
            
            string path= Application.dataPath + "/Scripts/DataList/" + excelName;
            FileStream stream = File.Open(Application.dataPath + "/Scripts/DataList/"+excelName, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();
            //int columns = result.Tables[0].Columns.Count;
            //int rows = result.Tables[0].Rows.Count;

            //tables可以按照sheet名获取，也可以按照sheet索引获取
            //return result.Tables[0].Rows;
            return result.Tables[sheetName].Rows;
        }

    }
}