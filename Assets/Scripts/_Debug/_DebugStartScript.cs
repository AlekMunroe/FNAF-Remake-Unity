using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DebugStartScript : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private bool showStartScreen = true;
    [SerializeField] private bool playPhoneCall = true;

    [Header("Objects")] 
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject phoneCall;

    void Start()
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        StartCoroutine(SetDebugDelay());
#endif
    }

    IEnumerator SetDebugDelay()
    {
        yield return new WaitForSeconds(0.01f);
        
        startScreen.SetActive(showStartScreen);
        phoneCall.SetActive(playPhoneCall);
    }
}
