using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarningUtil : MonoBehaviour {
    private static List<string> list = new List<string>();
    [SerializeField]
    private WarningWindow window;
    public static void ShowWarningWindow(string message)
    {
        list.Add(message);
    }
    void Update()
    {
        if (!window.gameObject.activeSelf)
        {
            if (list.Count > 0)
            {
                window.setActive(list[0]);
                list.RemoveAt(0);
            }
        }

    }
}
