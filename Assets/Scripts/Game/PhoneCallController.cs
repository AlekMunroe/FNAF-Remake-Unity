using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallController : MonoBehaviour
{
    [SerializeField] private GameObject[] phoneCall;
    private int currentLevel;

    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentNight");

        phoneCall[currentLevel - 1].SetActive(true);
    }

    public void MuteCall(GameObject muteButton)
    {
        phoneCall[currentLevel - 1].SetActive(false);
        Destroy(muteButton);
    }
}
