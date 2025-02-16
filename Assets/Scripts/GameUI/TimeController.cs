using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    [SerializeField] private TMP_Text timeText;
    private int _time;

    //12AM - 90 seconds
    //1AM-5AM - 89 seconds
    //6AM - Finish
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        timeText.text = "12 AM";
        StartCoroutine(Timer());
    }

    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        if (_time == 0)
        {
            yield return new WaitForSeconds(90f);

        }
        else if (_time == 6)
        {
            //End game
        }
        else
        {
            yield return new WaitForSeconds(89f);
        }
        
        //Add 1 to the time
        _time = _time + 1;
        timeText.text = _time.ToString() + " AM";

        StartCoroutine(Timer());
    }

    public int currentTime()
    {
        return _time;
    }
}
