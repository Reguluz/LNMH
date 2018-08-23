using Buffs;
using UnityEngine;
using UnityEditor;
using Excel;

namespace DataList
{
    
    

    public class BuildAsset : Editor {
 
        [MenuItem("BuildAsset/Build Scriptable Asset")]
        public static void ExcuteBuild()
        {
            PropEnternalHolder PEholder = ScriptableObject.CreateInstance<PropEnternalHolder>();
            PropRecoverHolder PRholder = ScriptableObject.CreateInstance<PropRecoverHolder>();
            BuffHolder Bholder = ScriptableObject.CreateInstance<BuffHolder>();
            
            //查询excel表中数据，赋值给asset文件
            PEholder.EnternalPropList = ExcelAccess.SelectPropEnternalTable();
            PRholder.RecoverPropList = ExcelAccess.SelectPropRecoverTable();
            Bholder.BuffList = ExcelAccess.SelectBuffTable();
 
            string PEpath= "Assets/Resources/PropEnternals.asset";
            string PRpath= "Assets/Resources/PropRecovers.asset";
            string Bpath= "Assets/Resources/Buffs.asset";
 
            AssetDatabase.CreateAsset(PEholder, PEpath);
            AssetDatabase.CreateAsset(PRholder, PRpath);
            AssetDatabase.CreateAsset(Bholder, Bpath);
            AssetDatabase.Refresh();
 
            Debug.Log("BuildAsset Success!");

        }
    }
}