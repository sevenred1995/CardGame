using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class equipItem : MonoBehaviour {
    //更新装备面板的相关信息
    public UISprite thisHeadsprite;
    public UILabel thisName;
    public UILabel thisLevel;
    public UILabel thisMagic;
    public UILabel thisDefend;

    private int clothType;
    private int clothId;
    public UIButton SellButton;
    public UISprite iconsprite1;
    public UISprite iconsprite2;

    public UIGrid uiGrid;
    void Start()
    {
        uiGrid = this.transform.parent.GetComponent<UIGrid>();
        EventDelegate.Set(SellButton.onClick, () =>
            {
                //出售一件装备，需要删除缓存层，需要删除服务器上的数据
                OnSellClick();
            });//为button添加响应事件
    }
    public void InitList(string name,string level,string magic,string defend,string headName,int id,int type,string name1,string name2)
    {
        thisHeadsprite.spriteName = headName;
        thisName.text = name;
        thisLevel.text = level;
        thisMagic.text = magic;
        thisDefend.text = defend;
        clothType = type;
        clothId = id;
        iconsprite1.spriteName = name1;
        iconsprite2.spriteName = name2;
    }
    public void OnSellClick()
    {
       int result=WebService1.service.DeleteCloth(GameDataUtil.playerInfo.account_id,GameDataUtil.session,clothId);
        if(result==-1)
        {
            WarningUtil.ShowWarningWindow("非法请求");
        }
        else if(result==-2)
        {
            WarningUtil.ShowWarningWindow("数据请求错误");
        }
        else if(result==-3)
        {
            WarningUtil.ShowWarningWindow("出售失败");
        }
        else if(result==1)
        {
            Destroy(this.gameObject);
            uiGrid.repositionNow = true;
            uiGrid.Reposition();
            GameDataUtil.MyCloth.Remove(clothId);
            WarningUtil.ShowWarningWindow("出售成功");
        }
    }
}
