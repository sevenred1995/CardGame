using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class tavernItem : MonoBehaviour {
    public UISprite lbHead;
    public UILabel lbName;
    public UILabel lbStarname;
    public UILabel lbGold;
    public UIButton tavernBtn;
    private UIGrid grid;
    private int cardcode;
    void Start()
    {
        grid = transform.parent.GetComponent<UIGrid>();
        EventDelegate.Set(tavernBtn.onClick, () =>
        {
             //招募英雄
            GameDataUtil.playerInfo = WebService1.service.getPlayer(GameDataUtil.session);
            if (GameDataUtil.playerInfo.gold < int.Parse(lbGold.text))
            {
                WarningUtil.ShowWarningWindow("元宝不足！");
                return;
            }
            Card c = WebService1.service.AddCard(GameDataUtil.playerInfo.account_id, GameDataUtil.session, cardcode); 
            if(c==null)
            {
                WarningUtil.ShowWarningWindow("招募失败");
                return;
            }
            GameDataUtil.NewCardList.Add(c.id, c);
            GameDataUtil.MyCard.Add(c.id, c);
            WarningUtil.ShowWarningWindow("招募成功");
        }); 

    }
    public void initCards(int cardCode)
    {
        lbHead.spriteName = "head" + cardCode;
        lbName.text = GameDataUtil.Herodatas[cardCode].name;
        lbStarname.text = GameDataUtil.Herodatas[cardCode].starname;
        lbGold.text = GameDataUtil.Herodatas[cardCode].price.ToString();
        cardcode = cardCode;
    }
}
