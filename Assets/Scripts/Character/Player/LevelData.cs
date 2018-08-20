
namespace Character.Player
{
    public class LevelData
    {
        public float ExpI;//当前经验
        private float ExpM;//当前等级最大经验
        public int lv;

        public LevelData()
        {
            ExpI = 0;
            ExpM = 0;
            lv = 0;
        }
        //获取经验
        public void getExp(float exp)
        {
            //获得经验
            ExpI += exp;
            
            //经验超量（升级）
            while (ExpI > ExpM)    
            {
                LevelUp();                
            }
        }

        private void LevelUp()
        {
            lv++;
            ExpI = ExpI - ExpM;
            //重置经验上限
            ExpM = lv*1000;             /*@@@@@@需要数据支撑@@@@@@*/
        }
    }
    
    
}