using UnityEngine;
using System.Collections;

public class heroItem : MonoBehaviour {

    /// <summary>
    /// 更新武将面板的相关信息
    /// </summary>
    public UILabel Name;
    public UILabel Starname;
    public UISprite HeadSprite;
    private int HeroId;

    public int gd_code;
    public GameObject lookBtn;//列表上的Button
    public heroInfo _heroInfo;
    void Start()
    {
        _heroInfo = GameObject.FindObjectOfType<heroInfo>();
    }
    public void InitList(string name,string strname,int code,int id)
    {
        Name.text = name;
        Starname.text = strname;
        HeadSprite.spriteName = "head" + code;
        gd_code = code;
        HeroId = id;
        UIEventListener.Get(lookBtn).onClick = OnFindClick;
    }
    public void OnFindClick(GameObject lookBtn)
    {
        _heroInfo.gameObject.SetActive(true);
        _heroInfo.InitInfo(gd_code);
    }
}
