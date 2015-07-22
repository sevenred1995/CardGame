using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class homeEquip : MonoBehaviour {
    //用于管理装备列表
    public GameObject EquipPrefabs;
    public bool isFirst = true;
    public Transform Parent;
    public float startY = 0f;
    public float distance = 100f;

    private int index = 0;

 
    public void OpenWindow()
    {
       Debug.Log("装备卡牌数据初始化");
       StartCoroutine(InitCloth());
    }
    IEnumerator InitCloth()
    {
        if(isFirst)
        {
            foreach(var cloth in GameDataUtil.MyCloth.Values)
            {
                GameObject go = Instantiate(EquipPrefabs) as GameObject;
                go.transform.parent = Parent;
                go.transform.localPosition = new Vector3(0, startY - distance * index, 0);
                go.transform.localScale = Vector3.one;
                equipItem _equipitem = go.GetComponent<equipItem>();
                ClothData datas = GameDataUtil.Clothdatas[cloth.type];
                string picture = datas.picture.Substring(0, datas.picture.IndexOf('.'));
                string name1, name2;
                if(datas.magic>0||datas.defend>0)
                {
                    name1 = "fang";
                    name2 = "fang";
                    _equipitem.InitList(datas.name, cloth.level.ToString(), cloth.magic.ToString(), cloth.defend.ToString(), picture, cloth.id, cloth.type, name1, name2);
                }
                else
                {
                    name1 = "heart";
                    name2 = "swordicon";
                    _equipitem.InitList(datas.name,cloth.level.ToString(),cloth.hp.ToString(),cloth.ap.ToString(),picture,cloth.id,cloth.type,name1,name2);
                }

                //_equipitem.InitList(datas.name,cloth.level.ToString(),cloth.magic.ToString(),cloth.defend.ToString(),picture,cloth.id,cloth.type);
                index++;
            }
            isFirst = false;
			GameDataUtil.NewClothList.Clear ( );
        }
        else
        {
            Debug.Log("新增加的装备数量"+GameDataUtil.NewClothList.Count);
			if ( GameDataUtil.NewClothList.Count > 0 )
			{

				foreach ( var cloth in GameDataUtil.NewClothList.Values )
				{
					GameObject go = Instantiate ( EquipPrefabs ) as GameObject;
					go.transform.parent = Parent;
					go.transform.localPosition = new Vector3 ( 0, startY - distance * index, 0 );
					go.transform.localScale = Vector3.one;
					equipItem _equipitem = go.GetComponent<equipItem> ( );
					ClothData datas = GameDataUtil.Clothdatas[cloth.type];
					string picture = datas.picture.Substring ( 0, datas.picture.IndexOf ( '.' ) );
					string name1, name2;
					if ( datas.magic > 0 || datas.defend > 0 )
					{
						name1 = "fang";
						name2 = "fang";
						_equipitem.InitList ( datas.name, cloth.level.ToString ( ), cloth.magic.ToString ( ), cloth.defend.ToString ( ), picture, cloth.id, cloth.type, name1, name2 );
					}
					else
					{
						name1 = "heart";
						name2 = "swordicon";
						_equipitem.InitList ( datas.name, cloth.level.ToString ( ), cloth.hp.ToString ( ), cloth.ap.ToString ( ), picture, cloth.id, cloth.type, name1, name2 );
					}
					index++;
				}
				GameDataUtil.NewClothList.Clear ( );
			}
		}
        yield return null;
    }

}
