using UnityEngine;
using System.Collections;

public class WarningWindow : MonoBehaviour {
    [SerializeField]
    private UILabel warningLabel;
 
    public void setActive(string tip)
    {
        warningLabel.text = tip;
        gameObject.SetActive(true);   
    }
    public void OnWarningBtnClick()
    {
        gameObject.SetActive(false);
    }
    internal static void ShowWarningWindow(string p)
    {
        throw new System.NotImplementedException();
    }
}
