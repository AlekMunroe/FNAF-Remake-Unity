using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldInformation : MonoBehaviour
{
    public static GameWorldInformation instance;
    
    [SerializeField] private DoorController leftDoorController;
    [SerializeField] private DoorController rightDoorController;
    [SerializeField] private BatteryController batteryController;
    private TimeController timeController;
    
    private bool _isLeftDoorOpen;
    private bool _isRightDoorOpen;
    private bool _isLeftLightOn;
    private bool _isRightLightOn;
    private float _currentPower;
    private int _currentBatteryUsage;
    private int _currentTime;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        timeController = TimeController.instance;
    }
    
    void Update()
    {
        _isLeftDoorOpen = leftDoorController.isDoorOpen();
        _isRightDoorOpen = rightDoorController.isDoorOpen();
        _isLeftLightOn = leftDoorController.isLightOn();
        _isRightLightOn = rightDoorController.isLightOn();
        _currentPower = batteryController.currentPower();
        _currentBatteryUsage = batteryController.batteryUsage();
        _currentTime = timeController.currentTime();
    }

    public bool isLeftDoorOpen()
    {
        return _isLeftDoorOpen;
    }

    public bool isRightDoorOpen()
    {
        return _isRightDoorOpen;
    }

    public bool isLeftLightOn()
    {
        return _isLeftLightOn;
    }

    public bool isRightLightOn()
    {
        return _isRightLightOn;
    }

    public float currentPower()
    {
        return _currentPower;
    }

    public int currentBatteryUsage()
    {
        return _currentBatteryUsage;
    }
    
    public int time()
    {
        return _currentTime;
    }
}
