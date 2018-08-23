using System;

namespace Character
{
    [Serializable]
    public class StatsIntime
    {
        public float HpI;
        public float MpI;
        public float MgI;

        public StatsIntime()
        {
            HpI = 0;
            MpI = 0;
            MgI = 0;
        }
        
        public void Add(StatsIntime data)
        {
            this.HpI += data.HpI;
            this.MpI += data.MpI;
            this.MgI += data.MgI;
        }

        public static StatsIntime Multi(StatsBase data,StatsIntime per)
        {
            StatsIntime temp = new StatsIntime();
            temp.HpI = data.HpM * per.HpI;
            temp.MgI = data.HpM * per.MgI;
            temp.MpI = data.HpM * per.MpI;
            return temp;
        }
        
        public void DataCheck(StatsBase data)    //上限检测
        {
            if (HpI > data.HpM)
            {
                HpI = data.HpM;
            }

            if (MpI > data.MpM)
            {
                MpI = data.MpM;
            }

            if (MgI > data.MgM)
            {
                MgI = data.MgM;
            }
        }
    }
}