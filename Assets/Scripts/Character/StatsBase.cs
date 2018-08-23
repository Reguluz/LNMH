using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class StatsBase
    {
        public float HpM;
        public float HpR;
        public float Atk;
        public float NAtk;    //系数
        public float FAtk;    //系数
        public float Def;
        public double SpdM;
        public double SpdA;

        public int MpM;
        public int MpR;
        public float CritP;
        public float CritM;
        

        public float MgM;
        public StatsBase()
        {
          
            
            this.HpM = 0;
            this.HpR = 0;
            this.Atk = 0;
            this.NAtk = 0;
            this.FAtk = 0;
            this.Def = 0;
            this.SpdM = 0;
            this.SpdA = 0;
          
            this.MpM = 0;
            this.MpR = 0;
            this.CritP = 0;
            this.CritM = 0;
            
            this.MgM =0;
        }

        /*public StatsBase Plus(StatsBase data1,StatsBase data2)
        {        
            StatsBase temp = new StatsBase();
            
            temp.HpM = data1.HpM + data2.HpM;
            Debug.Log(temp.HpM  + "   " + data1.HpM + "   " + data2.HpM);
            temp.Atk = data1.Atk + data2.Atk;
            temp.Def = data1.Def + data2.Def;
            temp.SpdM = data1.SpdM + data2.SpdM;
            temp.SpdA = data1.SpdA + data2.SpdA;

            temp.MpM = data1.MpM + data2.MpM;
            temp.CritP = data1.CritP + data2.CritP;
            temp.CritM = data1.CritM + data2.CritM;
        
            temp.MgM = data1.MgM + data2.MgM;
            return temp;
        }*/
        
        public void Add(StatsBase data1)
        {        
            HpM += data1.HpM;
            HpR += data1.HpR;
            Atk += data1.Atk;
            NAtk += data1.NAtk;
            FAtk += data1.FAtk;
            Def += data1.Def;
            SpdM += data1.SpdM;
            SpdA += data1.SpdA;

            MpM += data1.MpM;
            MpR += data1.MpR;
            CritP += data1.CritP;
            CritM += data1.CritM;
        
            MgM += data1.MgM;
        }

        public static StatsBase Multi(StatsBase data,StatsBase per)
        {
            StatsBase temp = new StatsBase();
            
            temp.HpM = data.HpM * per.HpM;
            temp.Atk = data.Atk * per.Atk;
            temp.Def = data.Def * per.Def;
            temp.SpdM = data.SpdM * per.SpdM;
            temp.SpdA = data.SpdA * per.SpdA;


            temp.MpM = data.MpM * per.MpM;
            temp.CritP = data.CritP * per.CritP;
            temp.CritM = data.CritM * per.CritM;

            temp.MgM = data.MgM * per.MgM;

            return temp;
        }

        

        
    }
    
}