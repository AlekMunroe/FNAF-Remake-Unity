using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject[] cameraScreens;

    public void SetScreen(string screenName)
    {
        for (int i = 0; i < cameraScreens.Length; i++)
        {
            cameraScreens[i].SetActive(false);
        }

        int screenToEnable = 0;
        
        if (screenName == "1A") screenToEnable = 0;
        else if (screenName == "1B") screenToEnable = 1;
        else if (screenName == "1C") screenToEnable = 2;
        else if (screenName == "2A") screenToEnable = 3;
        else if (screenName == "2B") screenToEnable = 4;
        else if (screenName == "3") screenToEnable = 5;
        else if (screenName == "4A") screenToEnable = 6;
        else if (screenName == "4B") screenToEnable = 7;
        else if (screenName == "5") screenToEnable = 8;
        else if (screenName == "6") screenToEnable = 9;
        else if (screenName == "7") screenToEnable = 10;
        else Debug.LogError("Invalid screen name: " + screenName);

        cameraScreens[screenToEnable].SetActive(true);
    }
}
