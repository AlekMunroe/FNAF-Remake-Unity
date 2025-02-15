using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animation doorAnim;
    [SerializeField] private GameObject[] buttonState;
    [SerializeField] private DoorController otherDoorController;
    [SerializeField] private GameObject lightOnBackground;
    private bool _isDoorOpen = true;
    private bool _isLightOn;

    public void ToggleDoor()
    {
        if (!_isDoorOpen)
        {
            _isDoorOpen = true;
            
            //Open door animation
            doorAnim.Play("DoorOpenAnim");
            
            BatteryController.instance.DecreasePower();
        }
        else
        {
            _isDoorOpen = false;
            
            //Close door animation
            doorAnim.Play("DoorCloseAnim");
            
            BatteryController.instance.IncreasePower();
        }
        
        ChangeButtonState();
    }

    public void ToggleLight()
    {
        if (!_isLightOn)
        {
            _isLightOn = true;
            
            //Turn light on
            BatteryController.instance.IncreasePower();
            
            lightOnBackground.SetActive(true);
            
            //If other light is on, turn it off
            if (otherDoorController.isLightOn())
            {
                Debug.Log("Other light is on, turning it off.");
                otherDoorController.ToggleLight();
            }
        }
        else
        {
            _isLightOn = false;
            
            //Turn light off
            BatteryController.instance.DecreasePower();
            
            lightOnBackground.SetActive(false);
        }
        
        ChangeButtonState();
    }

    void ChangeButtonState()
    {
        buttonState[0].SetActive(false);
        buttonState[1].SetActive(false);
        buttonState[2].SetActive(false);
        buttonState[3].SetActive(false);
        
        //X - Door Light
        //0 - Open Off
        //1 - Closed Off
        //2 - Open On
        //3 - Closed On
        
        //_isDoorOpen = True (Door is open)
        //_isDoorOpen = False (Door is closed)
        //_isLightOn = True (Light is on)
        //_isLightOn = false (Light is off)
        if (_isDoorOpen && !_isLightOn)
        {
            //Door open, Light off
            buttonState[0].SetActive(true);
        }
        else if (!_isDoorOpen && !_isLightOn)
        {
            //Door closed, Light off
            buttonState[1].SetActive(true);
        }
        else if (_isDoorOpen && _isLightOn)
        {
            //Door open, Light on
            buttonState[2].SetActive(true);
        }
        else if (!_isDoorOpen && _isLightOn)
        {
            //Door closed, Light on
            buttonState[3].SetActive(true);
        }
        else
        {
            //Default to off
            buttonState[0].SetActive(false);
        }
    }
    
    public bool isDoorOpen()
    {
        return _isDoorOpen;
    }

    public bool isLightOn()
    {
        return _isLightOn;
    }
}
