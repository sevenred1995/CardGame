using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.tools
{
    /// <summary>
    /// 游戏中的数据管理类
    /// </summary>
    public class GameDataUtil
    {
        public static string session = null;//保存的是密钥

        public static Player playerInfo;//保存登录玩家

        /// <summary>
        /// 该信息通过登陆的时候所保存的playerInfo获取；
        /// </summary>
        public static Dictionary<int, Card> MyCard = new Dictionary<int, Card>();//本地保存当前玩家的卡牌的数据库信息

        /// <summary>
        /// int 代表卡牌的唯一标识码 code
        /// </summary>
        public static Dictionary<int, HeroData> Herodatas = new Dictionary<int, HeroData>();//本地保存英雄卡牌的所有信息

        /// <summary>
        /// 存放装备卡牌，int 代表的是装备的唯一标识码Type
        /// </summary>
        public static Dictionary<int, ClothData> Clothdatas = new Dictionary<int, ClothData>(); 

        /// <summary>
        /// 存放武将图片
        /// </summary>
        public static Dictionary<string, Texture2D> HeroPictures = new Dictionary<string, Texture2D>();//string存放图片的名称
      
        /// <summary>
        /// 保存当前玩家所拥有的装备，
        /// </summary>
        public static Dictionary<int, Cloth> MyCloth = new Dictionary<int, Cloth>();

        /// <summary>
        /// 保存玩家新增的卡牌
        /// </summary>
        public static Dictionary<int, Cloth> NewClothList = new Dictionary<int, Cloth>();

        /// <summary>
        /// 保存玩家新增的英雄卡牌
        /// </summary>
        public static Dictionary<int, Card> NewCardList = new Dictionary<int, Card>();

        public static Deployment MyDeployment = new Deployment();
        public static int DeploymentGridID, DeploymentTypeID, ItemChangeItemID;
        public static  DeploymentGridModel GetDeploymentGridModel(int index)
        {
            switch(index)
            {
                case 1:
                    return MyDeployment.grid1;
                case 2:
                    return MyDeployment.grid2;
                case 3:
                    return MyDeployment.grid3;
                case 4:
                    return MyDeployment.grid4;
                case 5:
                    return MyDeployment.grid5;
                default:
                    return null;
            }
        }

    }
}
