using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class shopItem : MonoBehaviour {
    //同于商店装备数据更新
    public UISprite lbHead;
    public UILabel lbLevel;
    public UILabel lbHP;
    public UILabel lbDefend;
    public UILabel lbName;
    public UILabel lbPrice;
    public UISprite iconsprite1;
    public UISprite iconsprite2;
    private int clothType;

    public UIButton BuyButton;

    void Start()
    {
        EventDelegate.Set(BuyButton.onClick, () =>
        {
            OnBuyClick();
        }); 
    }
    public void InitShopList(string head,string name,int level,int hp,int defend,int price,int codeType,string name1,string name2)
    {
        lbHead.spriteName = head;
        lbName.text = name;
        lbLevel.text = "等级："+level;
        lbHP.text = "+" + hp;
        lbDefend.text = "+" + defend;
        lbPrice.text = price.ToString();
        clothType = codeType;//为新添加的卡牌
        iconsprite1.spriteName = name1;
        iconsprite2.spriteName = name2;
    }
    public void OnBuyClick()
    {
        //购买装备的操作，需要向缓存层添加，需要修改服务端的数据库；
        if (GameDataUtil.playerInfo.money < int.Parse(lbPrice.text))
        {
            WarningUtil.ShowWarningWindow("你的金钱不足！");
            return;
        }
		//GameDataUtil.NewClothList.Add ( );
        Cloth cloth = WebService1.service.AddCloth(GameDataUtil.playerInfo.account_id, GameDataUtil.session, clothType, 1);
		if(cloth==null)
		{
			WarningUtil.ShowWarningWindow ( "购买失败！" );
			return;
		}
        GameDataUtil.NewClothList.Add(cloth.id, cloth);//将新添加的数据保存到newClothList,
		GameDataUtil.MyCloth.Add ( cloth.id, cloth );
		WarningUtil.ShowWarningWindow ( "购买成功！" );
    }
}
