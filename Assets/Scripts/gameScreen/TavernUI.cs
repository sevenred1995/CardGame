using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;
public class TavernUI : MonoBehaviour {
    public GameObject CardPrefabs;
    public bool isFirst = true;
    public Transform Parent;
    public void openDefault()
    {
        OpenWindow();
    }

    private void OpenWindow()
    {
        gameObject.SetActive(true);
        StartCoroutine(initCards());
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
    IEnumerator initCards()
    {
        if(isFirst)
        {
            foreach(var cardCode in GameDataUtil.Herodatas.Keys)
            {
                GameObject go = Instantiate(CardPrefabs) as GameObject;
                go.transform.parent = Parent;
                go.transform.localScale = Vector3.one;
                tavernItem _taverItem = go.transform.GetComponent<tavernItem>();
                _taverItem.initCards(cardCode);
            }
        }
        else
        {

        }
        yield return null;
    }
}
