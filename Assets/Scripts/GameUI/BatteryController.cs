using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryController : MonoBehaviour
{
    public static BatteryController instance;
    
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private GameObject[] batteryUI;
    [SerializeField] private int batteryAmount = 1;
    private float _powerDecreaseSpeed = 9.6f;

    private float _currentPower = 99f;
    private float _previousPower = 99f;

    void Start()
    {
        instance = this;
        
        StartCoroutine(DrainPower());
    }

    void Update()
    {
        if (batteryAmount == 1 && !batteryUI[0].active)
        {
            Debug.Log("Enabling battery 1");
            _powerDecreaseSpeed = 9.6f;
            disableBatteryUI();
            batteryUI[0].SetActive(true);
        }
        else if (batteryAmount == 2 && !batteryUI[1].active)
        {
            Debug.Log("Enabling battery 2");
            _powerDecreaseSpeed = 4.8f;
            disableBatteryUI();
            batteryUI[1].SetActive(true);
        }
        else if(batteryAmount == 3 && !batteryUI[2].active)
        {
            Debug.Log("Enabling battery 3");

            DecreasePowerPattern();
            
            disableBatteryUI();
            batteryUI[2].SetActive(true);
        }
        else if(batteryAmount == 4 && !batteryUI[3].active)
        {
            Debug.Log("Enabling battery 4");
            
            DecreasePowerPattern();
            
            disableBatteryUI();
            batteryUI[3].SetActive(true);
        }
        else if(batteryAmount == 5 && !batteryUI[4].active)
        {
            Debug.Log("Enabling battery 5");

            _powerDecreaseSpeed = 1f;
            disableBatteryUI();
            batteryUI[4].SetActive(true);
        }
    }

    void disableBatteryUI()
    {
        batteryUI[0].SetActive(false);
        batteryUI[1].SetActive(false);
        batteryUI[2].SetActive(false);
        batteryUI[3].SetActive(false);
        batteryUI[4].SetActive(false);
    }

    void DecreasePowerPattern()
    {
        if (_currentPower != _previousPower) //If the power percentage changes
        {
            if (batteryAmount == 3) //If the battery is on 3
            {
                //Switch between the power
                if (_powerDecreaseSpeed == 2.8f)
                {
                    _powerDecreaseSpeed = 2.9f;
                }
                else if (_powerDecreaseSpeed == 2.9f)
                {
                    _powerDecreaseSpeed = 3.9f;
                }
                else
                {
                    _powerDecreaseSpeed = 2.8f;
                }
            }
            else if (batteryAmount == 4) //If the battery is on 4
            {
                if (_powerDecreaseSpeed == 1.9f)
                {
                    _powerDecreaseSpeed = 2.9f;
                }
                else
                {
                    _powerDecreaseSpeed = 1.9f;
                }
            }
        }
    }

    IEnumerator DrainPower()
    {
        powerText.text = "Power Left: " + _currentPower.ToString() + "%";
        
        yield return new WaitForSeconds(_powerDecreaseSpeed);

        _currentPower = _currentPower - 1;

        StartCoroutine(DrainPower());
    }

    public void IncreasePower()
    {
        batteryAmount = batteryAmount + 1;
    }

    public void DecreasePower()
    {
        batteryAmount = batteryAmount - 1;
    }

    public float currentPower()
    {
        return _currentPower;
    }

    public int batteryUsage()
    {
        return batteryAmount;
    }
}
