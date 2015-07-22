using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class heroInfo : MonoBehaviour {
    public UILabel thisName;
    public UILabel thisExname;
    public UILabel thisStarname;
    public UILabel thisStar;
    public UILabel thisInfo;
    public UITexture thisHero;

    public void InitInfo(int CardCode)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        HeroData _heroData=GameDataUtil.Herodatas[CardCode];
        thisName.text=_heroData.name;
        thisExname.text=_heroData.exname;
        thisStarname.text=_heroData.starname;
        thisStar.text=starNum(_heroData. star);
        thisInfo.text=_heroData.des;
        thisHero.mainTexture =GameDataUtil.HeroPictures[_heroData.picture];
    }

    public void OnCloseClick()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private string starNum(int star)
    {
        if (star == 1)
        {
            return "★";
        }
        else if (star == 2)
        {
            return "★★";
        }
        else if (star == 3)
        {
            return "★★★";
        }
        else if (star == 4)
        {
            return "★★★★";
        }
        else if (star == 5)
        {
            return "★★★★★";
        }
        else
          return null;
    }
}
