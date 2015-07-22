using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.tools
{
    class DeploymentUtil
    {
        public static List<int> GetDeploymentCardsID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.cardId;
            temp[1] = GameDataUtil.MyDeployment.grid2.cardId;
            temp[2] = GameDataUtil.MyDeployment.grid3.cardId;
            temp[3] = GameDataUtil.MyDeployment.grid4.cardId;
            temp[4] = GameDataUtil.MyDeployment.grid4.cardId;
            temp[5] = GameDataUtil.MyDeployment.grid5.cardId;
            return temp;
        }
        public static List<int> GetDeploymentSwordID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.swordId;
            temp[1] = GameDataUtil.MyDeployment.grid2.swordId;
            temp[2] = GameDataUtil.MyDeployment.grid3.swordId;
            temp[3] = GameDataUtil.MyDeployment.grid4.swordId;
            temp[4] = GameDataUtil.MyDeployment.grid4.swordId;
            temp[5] = GameDataUtil.MyDeployment.grid5.swordId;
            return temp;
        }
        public static List<int> GetDeploymentHatID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.hatId;
            temp[1] = GameDataUtil.MyDeployment.grid2.hatId;
            temp[2] = GameDataUtil.MyDeployment.grid3.hatId;
            temp[3] = GameDataUtil.MyDeployment.grid4.hatId;
            temp[4] = GameDataUtil.MyDeployment.grid4.hatId;
            temp[5] = GameDataUtil.MyDeployment.grid5.hatId;
            return temp;
        }
        public static List<int> GetDeploymentClothID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.clothId;
            temp[1] = GameDataUtil.MyDeployment.grid2.clothId;
            temp[2] = GameDataUtil.MyDeployment.grid3.clothId;
            temp[3] = GameDataUtil.MyDeployment.grid4.clothId;
            temp[4] = GameDataUtil.MyDeployment.grid4.clothId;
            temp[5] = GameDataUtil.MyDeployment.grid5.clothId;
            return temp;
        }
        public static List<int> GetDeploymentBookID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.bookId;
            temp[1] = GameDataUtil.MyDeployment.grid2.bookId;
            temp[2] = GameDataUtil.MyDeployment.grid3.bookId;
            temp[3] = GameDataUtil.MyDeployment.grid4.bookId;
            temp[4] = GameDataUtil.MyDeployment.grid4.bookId;
            temp[5] = GameDataUtil.MyDeployment.grid5.bookId;
            return temp;
        }
        public static List<int> GetDeoloymentShooeID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.shooeId;
            temp[1] = GameDataUtil.MyDeployment.grid2.shooeId;
            temp[2] = GameDataUtil.MyDeployment.grid3.shooeId;
            temp[3] = GameDataUtil.MyDeployment.grid4.shooeId;
            temp[4] = GameDataUtil.MyDeployment.grid4.shooeId;
            temp[5] = GameDataUtil.MyDeployment.grid5.shooeId;
            return temp;
        }
        public static List<int> GetDeploymentHorseID()
        {
            List<int> temp = new List<int>(5);
            temp[0] = GameDataUtil.MyDeployment.grid1.horseId;
            temp[1] = GameDataUtil.MyDeployment.grid2.horseId;
            temp[2] = GameDataUtil.MyDeployment.grid3.horseId;
            temp[3] = GameDataUtil.MyDeployment.grid4.horseId;
            temp[4] = GameDataUtil.MyDeployment.grid4.horseId;
            temp[5] = GameDataUtil.MyDeployment.grid5.horseId;
            return temp;
        }
    }
}
