using UnityEngine;

namespace Character
{
    public class StatsBase
    {
        public float HpM;
        public float Atk;
        public float Def;
        public double SpdM;
        public double SpdA;

        public int MpM;
        public float CritP;
        public float CritM;
        

        public float MgM;

        public StatsBase()
        {
          
            
            this.HpM =0;
            this.Atk =0;
            this.Def =0;
            this.SpdM =0;
            this.SpdA =0;
          
            this.MpM =0;
            this.CritP =0;
            this.CritM =0;
            
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
            Atk += data1.Atk;
            Def += data1.Def;
            SpdM += data1.SpdM;
            SpdA += data1.SpdA;

            MpM += data1.MpM;
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