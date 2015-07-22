using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class homeHero : MonoBehaviour {
    //用于管理武将卡牌列表
    public GameObject HeroPrefabs;
    public bool isFirst=true;
    public Transform Parent;
    public float startY=0f;
    public float distance = 100f;

    private int index=0;
    public void OpenWindow()
    {
        Debug.Log("武将卡牌数据初始化");
        StartCoroutine(InitCards());
    }
    IEnumerator InitCards()
    {
        if(isFirst)
        {
            foreach(var card in GameDataUtil.MyCard.Values)
            {
                GameObject go = Instantiate(HeroPrefabs) as GameObject;
                go.transform.parent = Parent;
                go.transform.localPosition = new Vector3(0, startY-distance*index, 0);
                go.transform.localScale = Vector3.one;
                heroItem heroitem = go.GetComponent<heroItem>();
                HeroData datas=GameDataUtil.Herodatas[card.gd_code];
                heroitem.InitList(datas.name, datas.starname, card.gd_code, card.id);
                index++;
            }
            GameDataUtil.NewClothList.Clear();
            isFirst = false;
        }
        else
        {
            foreach (var card in GameDataUtil.NewCardList.Values)
            {
                GameObject go = Instantiate(HeroPrefabs) as GameObject;
                go.transform.parent = Parent;
                go.transform.localPosition = new Vector3(0, startY - distance * index, 0);
                go.transform.localScale = Vector3.one;
                heroItem heroitem = go.GetComponent<heroItem>();
                HeroData datas = GameDataUtil.Herodatas[card.gd_code];
                heroitem.InitList(datas.name, datas.starname, card.gd_code, card.id);
                index++;
            }
            GameDataUtil.NewClothList.Clear();
        }
        yield return null;
    }
}
