using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class GameManager : MonoBehaviour {
    /// <summary>
    /// 整个游戏界面的控制
    /// </summary>
    [SerializeField]
    private UIButton home;
    [SerializeField]
    private UIButton hero;
    [SerializeField]
    private UIButton war;
    [SerializeField]
    private UIButton tujian;
    [SerializeField]
    private UIButton store;

    private UIButton selected;

    [SerializeField]
    private HomeUI homeUI;
    [SerializeField]
    private HeroUI heroUI;
    [SerializeField]
    private ShopUI shopUI;
    [SerializeField]
    private TavernUI tavernUI;

    void Start()
    {
       // home.isEnabled = false;
        selected = home;
        Read();//开始读取英雄卡牌数据//读取装备数据
    }
	public void RefreshPlayerInfo()
	{
		GameDataUtil.playerInfo = WebService1.service.getPlayer ( GameDataUtil.session );
	}
    public void homeClick()
    {
        //home.isEnabled = false;
		RefreshPlayerInfo ( );
        CloseLast();
        selected = home;
        homeUI.OpenDefault();
    }
    public void heroClick()
    {
		RefreshPlayerInfo ( );
        hero.isEnabled = false;
        CloseLast();
        selected = hero;
        heroUI.open();
    }
    public void warClick()
    {
		RefreshPlayerInfo ( );
        war.isEnabled = false;
        CloseLast();
        selected = war;
    }
    public void tujianClick()
    {
		RefreshPlayerInfo ( );
        tujian.isEnabled = false;
        CloseLast();
        tavernUI.openDefault();
        selected = tujian;
    }
    public void storeClick()
    {
		RefreshPlayerInfo ( );
        store.isEnabled = false;
        CloseLast();
        shopUI.OpenDefault();
        selected = store;
    }
    public void CloseLast()
    {
        selected.isEnabled = true;
        if(selected.Equals(home))
        {
            homeUI.close();
        }else if(selected.Equals(hero))
        {
            heroUI.close();
        }else if(selected.Equals(war))
        {

        }else if(selected.Equals(tujian))
        {
            tavernUI.close();
        }else if(selected.Equals(store))
        {
            shopUI.Close();
        }
    }
    /// <summary>
    /// 读取玩家英雄卡牌列表和读取所有英雄卡牌列表，
    /// </summary>
    private void Read()
    {
        ReadHeroData();
        ReadClothData();
        ReadDeploymentData();
    }

    private void ReadDeploymentData()
    {
        throw new System.NotImplementedException();
    }
    public void ReadClothData()
    {
        //读取装备信息，
        Cloth[] cloths = WebService1.service.getClothList(GameDataUtil.playerInfo.account_id, GameDataUtil.session);
        foreach (Cloth cloth in cloths)
        {
            GameDataUtil.MyCloth.Add(cloth.id, cloth);
        }
        string result2 = ReadFile.Read("cloth.json");
        ClothData[] clothdatas = LitJson.JsonMapper.ToObject<ClothData[]>(result2);
        foreach (ClothData clothdata in clothdatas)
        {
            GameDataUtil.Clothdatas.Add(clothdata.type, clothdata);
        }
      
    }
    public void ReadHeroData()
    {
        Card[] cards = WebService1.service.getHeroList(GameDataUtil.playerInfo.account_id, GameDataUtil.session);//从服务器的card数据库获取数据
        foreach (Card card in cards)
        {
            GameDataUtil.MyCard.Add(card.id, card);//读取数据到缓存层
        }
        string result = ReadFile.Read("hero.json");
        HeroData[] datas = LitJson.JsonMapper.ToObject<HeroData[]>(result);
        foreach (HeroData data in datas)
        {
            GameDataUtil.Herodatas.Add(data.code, data);//读取数据到缓存层；
        }
        //读取英雄图片资源。
        Texture2D[] temp = Resources.LoadAll<Texture2D>("card");
        foreach (Texture2D texture2D in temp)
        {
            GameDataUtil.HeroPictures.Add(texture2D.name + ".png", texture2D);//将图片资源保存到缓存层中
        }
    }

}
