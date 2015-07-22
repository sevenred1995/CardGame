using UnityEngine;
using System.Collections;

public class HeroUI : MonoBehaviour {

    void Start()
    {
        open();
    }
    public void open()
    {
        gameObject.SetActive(true);
    }
    public void close()
    {
        gameObject.SetActive(false);
    }
}
