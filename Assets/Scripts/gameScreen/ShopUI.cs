using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
using System;
public class ShopUI : MonoBehaviour {
    //实现对商店列表的更新

    public GameObject shopPrefabs;
    public bool isFirst = true;
    public Transform Parent;
    public float startY = 0f;
    public float distance = 100f;

    private int index = 0;

    public GameObject lbdata;

    void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void OpenDefault()
    {
        StartCoroutine(initList());
        lbdata.SetActive(true);
    }
    public void Close()
    {
        lbdata.SetActive(false);
    }
    IEnumerator initList()
    {
        if(isFirst)
        {
            foreach (var cloth in GameDataUtil.Clothdatas.Values)
            {
                GameObject go = Instantiate(shopPrefabs) as GameObject;
                go.transform.parent = Parent;
                go.transform.localPosition = new Vector3(0, startY - distance * index, 0);
                go.transform.localScale = Vector3.one;
                shopItem _shopitem = go.GetComponent<shopItem>();
                ClothData datas = GameDataUtil.Clothdatas[cloth.type];
                string picture = datas.picture.Substring(0, datas.picture.IndexOf('.'));
                string name1, name2;
                int price = (datas.ap + datas.hp + datas.magic + datas.defend) / 5 * Math.Max(1, datas.star / 2);//价格
                if(datas.magic>0||datas.defend>0)
                {
                    name1 = "fang";
                    name2 = "fang";
                    _shopitem.InitShopList(picture, datas.name, 0, datas.magic, datas.defend, price, datas.type,name1,name2);
                }
                else
                {
                    name1 = "heart";
                    name2 = "swordicon";
                    _shopitem.InitShopList(picture, datas.name, 0, datas.hp, datas.ap, price, datas.type, name1, name2);
                }
                index++;
            }
            isFirst = false;
        }
        else
        {

        }
        yield return null;
    }
}
