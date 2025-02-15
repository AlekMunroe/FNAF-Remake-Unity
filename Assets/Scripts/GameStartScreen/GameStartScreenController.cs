using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartScreenController : MonoBehaviour
{
    [SerializeField] private TMP_Text startText;
    [SerializeField] private TMP_Text nightText;
    [SerializeField] private GameObject startScreen;
    
    void Start()
    {
        startScreen.SetActive(true);
        
        int nightNumber = PlayerPrefs.GetInt("currentNight");
        string indicator = "st";
        
        if (nightNumber == 1 || nightNumber == 4 || nightNumber == 5 || nightNumber == 6 || nightNumber == 7){
            indicator = "st";
        }
        else if (nightNumber == 2)
        {
            indicator = "nd";
        }
        else if (nightNumber == 3)
        {
            indicator = "rd";
        }

        startText.text = "12:00 AM \n" + nightNumber.ToString() + indicator + " Night";
        nightText.text = "Night " + nightNumber.ToString();

        StartCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(4);
        Destroy(startScreen);
        this.GetComponent<GameStartScreenController>().enabled = false;
    }
}
