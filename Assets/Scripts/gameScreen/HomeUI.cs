using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;

public class HomeUI : MonoBehaviour
{
    #region playerInfocomponet
    public UILabel CoinLabel;
    public UILabel GoldLabel;
    public UILabel PlayerNameLabel;
    public UILabel ExpLabel;
    public UILabel LevelLabel;
    #endregion

    public GameObject[] HomeUIList;
 
    private int currentState;
    void Start()
    {
        RefreshUI();//打开的时候更新玩家数据。
        OpenDefault();
    }
	public void OpenDefault()
    {
        OpenChildWindow(HomeStateUtil.BASE);//默认最开始打开基础界面。
        gameObject.SetActive(true);
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// 打开子菜单界面。
    /// </summary>
    /// <param name="state"></param>
    private void OpenChildWindow(int state)
    {
        if(state!=currentState)
        {
            CloseLastChildWindow();
            //关闭之前的窗口；
            currentState = state;
        }
        switch(state)
        {
            case HomeStateUtil.BASE: 
                HomeUIList[HomeStateUtil.BASE].SetActive(true);
                RefreshUI();///在home界面的基础界面上显示相关的角色信息；
                break;
            case HomeStateUtil.HEROLIST:
                HomeUIList[HomeStateUtil.HEROLIST].SetActive(true);

                HomeUIList[HomeStateUtil.HEROLIST].SendMessage("OpenWindow", SendMessageOptions.DontRequireReceiver);//传递消息，通知在其他地方的操作 读取数据
                break;
            case HomeStateUtil.EQUIPLIST:
                HomeUIList[HomeStateUtil.EQUIPLIST].SetActive(true);

                HomeUIList[HomeStateUtil.EQUIPLIST].SendMessage("OpenWindow", SendMessageOptions.DontRequireReceiver);//传递消息
                break;

        }
    }

    private void RefreshUI()
    {
		GameDataUtil.playerInfo = WebService1.service.getPlayer (GameDataUtil.session );
        //数值得更新，从数据库获取
        LevelLabel.text = GameDataUtil.playerInfo.level.ToString();
        CoinLabel.text = GameDataUtil.playerInfo.money.ToString();
        GoldLabel.text = GameDataUtil.playerInfo.gold.ToString();
        PlayerNameLabel.text=GameDataUtil.playerInfo.name;
        ExpLabel.text = GameDataUtil.playerInfo.exp.ToString();
    }
    /// <summary>
    /// 关闭当前显示的窗口
    /// </summary>
    public void CloseLastChildWindow()
    {
        HomeUIList[currentState].SetActive(false);
    }
    /// <summary>
    /// 英雄按钮点击按钮触发事件
    /// </summary>
    public void OnHeroClick()
    {
        OpenChildWindow(HomeStateUtil.HEROLIST);
    }
    /// <summary>
    /// 装备列表点击按钮
    /// </summary>
    public void OnEquipClick()
    {
        OpenChildWindow(HomeStateUtil.EQUIPLIST);
    }
}
