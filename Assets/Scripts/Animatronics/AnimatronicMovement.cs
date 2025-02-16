using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Clean up this script: Seperate into different classes, Use Enum for positions, Reduce repetition, State machine
public class AnimatronicMovement : MonoBehaviour
{
    [SerializeField] private string animatronicName;
    [SerializeField] private int currentNight;
    [SerializeField] private int aiLevel;
    private int _currentTime;
    private int _previousTime;
    private float _movementTimer;
   [SerializeField] private string currentPosition = "1A";
    private GameWorldInformation game;

    [Header("Default Camera Screens")] 
    [SerializeField] private string _IgnoreThis1 = "Ignore this";
    [SerializeField] private GameObject Default_1A, Default_1B, Default_1C, Default_2A, Default_2B, Default_3, Default_4A, Default_4B, Default_5, Default_6, Default_7;

    [Header("Bonnie Positions")] 
    [SerializeField] private string _IgnoreThis2 = "Ignore this";
    [SerializeField] private GameObject Bonnie_1A, Bonnie_1B_1, Bonnie_1B_2, Bonnie_2A, Bonnie_2B, Bonnie_3, Bonnie_5_1, Bonnie_5_2;

    private GameObject previousScreen;
    private GameObject nextScreen;

    void Start()
    {
        animatronicName = animatronicName.ToLower();
        currentNight = PlayerPrefs.GetInt("currentNight");
        game = GameWorldInformation.instance;
        previousScreen = Bonnie_1A;
        SetAiLevel();
        SetMovementTimer();
        StartCoroutine(StartMovementTimer());
    }

    void Update()
    {
        _currentTime = game.time();

        if (_currentTime != _previousTime)
        {
            _previousTime = _currentTime;
            
            SetAiLevel();
        }
    }
    
    void SetAiLevel()
    {
        //From https://steamcommunity.com/sharedfiles/filedetails/?id=2995834654
        if (animatronicName == "bonnie")
        {
            //Set AI level
            if (currentNight == 1)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 0;
                else if (_currentTime == 2) aiLevel = 1;
                else if(_currentTime == 3) aiLevel = 2;
                else if (_currentTime >= 4) aiLevel = 3;
            }
            else if (currentNight == 2)
            {
                if (_currentTime == 12 || _currentTime == 1 || _currentTime == 2) aiLevel = 3;
                else if(_currentTime == 3) aiLevel = 4;
                else if (_currentTime >= 4) aiLevel = 5;
            }
            else if (currentNight == 3)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 0;
                else if (_currentTime == 2) aiLevel = 1;
                else if(_currentTime == 3) aiLevel = 2;
                else if (_currentTime >= 4) aiLevel = 3;
            }
            else if (currentNight == 4)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 2;
                else if (_currentTime == 2) aiLevel = 3;
                else if(_currentTime == 3) aiLevel = 4;
                else if (_currentTime >= 4) aiLevel = 5;
            }
            else if (currentNight == 5)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 5;
                else if (_currentTime == 2) aiLevel = 6;
                else if(_currentTime == 3) aiLevel = 7;
                else if (_currentTime >= 4) aiLevel = 8;
            }
            else if (currentNight == 6)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 10;
                else if (_currentTime == 2) aiLevel = 11;
                else if(_currentTime == 3) aiLevel = 12;
                else if (_currentTime >= 4) aiLevel = 13;
            }
            else if (currentNight == 7)
            {
                aiLevel = 20;
            }

            Debug.Log("Bonnie AI Level: " + aiLevel);
        }
        else if (animatronicName == "freddy")
        {
            //Set AI level
            if (currentNight == 1 || currentNight == 2) aiLevel = 0;
            else if (currentNight == 3) aiLevel = 1;
            else if (currentNight == 4) aiLevel = Random.Range(1, 2); //Randomise between 1 and 2
            else if (currentNight == 5) aiLevel = 3;
            else if (currentNight == 6) aiLevel = 4;
            else if (currentNight == 7) aiLevel = 20;
        }
        else if (animatronicName == "chica")
        {
            //Set AI level
            if (currentNight == 1)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 0;
                else if (_currentTime == 2) aiLevel = 0;
                else if(_currentTime == 3) aiLevel = 1;
                else if (_currentTime >= 4) aiLevel = 2;
            }
            else if (currentNight == 2)
            {
                if (_currentTime == 12 || _currentTime == 1 || _currentTime == 2) aiLevel = 1;
                else if(_currentTime == 3) aiLevel = 2;
                else if (_currentTime >= 4) aiLevel = 3;
            }
            else if (currentNight == 3)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 5;
                else if (_currentTime == 2) aiLevel = 5;
                else if(_currentTime == 3) aiLevel = 6;
                else if (_currentTime >= 4) aiLevel = 7;
            }
            else if (currentNight == 4)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 4;
                else if (_currentTime == 2) aiLevel = 4;
                else if(_currentTime == 3) aiLevel = 5;
                else if (_currentTime >= 4) aiLevel = 6;
            }
            else if (currentNight == 5)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 7;
                else if (_currentTime == 2) aiLevel = 7;
                else if(_currentTime == 3) aiLevel = 8;
                else if (_currentTime >= 4) aiLevel = 9;
            }
            else if (currentNight == 6)
            {
                if (_currentTime == 12 || _currentTime == 1) aiLevel = 12;
                else if (_currentTime == 2) aiLevel = 12;
                else if(_currentTime == 3) aiLevel = 13;
                else if (_currentTime >= 4) aiLevel = 14;
            }
            else if (currentNight == 7)
            {
                aiLevel = 20;
            }
        }
    }

    IEnumerator StartMovementTimer()
    {
        Debug.Log("Randomising bonnie movement");
        yield return new WaitForSeconds(_movementTimer);
        
        //Generate a number between 1-20
        int randomMovement = Random.Range(1, 21);
        Debug.Log("Bonnie outcome: " + randomMovement);

        if (randomMovement >= 1 && randomMovement <= aiLevel)
        {
            Debug.Log("Can move");
            //Move animatronic
            if (animatronicName == "freddy")
            {
                //MoveFreddy();
            }
            else if (animatronicName == "bonnie")
            {
                MoveBonnie();
            }
            else if (animatronicName == "chica")
            {
                //MoveChica();
            }
            else if (animatronicName == "foxy")
            {
                //MoveFoxy();
            }
        }

        StartCoroutine(StartMovementTimer());
    }

    void SetMovementTimer()
    {
        if (animatronicName == "freddy") _movementTimer = 3.02f;
        else if (animatronicName == "bonnie") _movementTimer = 4.97f;
        else if (animatronicName == "chica") _movementTimer = 4.98f;
        else if(animatronicName == "foxy") _movementTimer = 5.01f;
    }

    void MoveBonnie()
    {
        //Set the new position
        if (currentPosition == "1A")
        {
            //Move options: 1B_1, 5
            int randomChoice = Random.Range(1, 3);

            if (randomChoice == 1)
            {
                currentPosition = "1B_1";
                nextScreen = Bonnie_1B_1;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "5_1";
                nextScreen = Bonnie_5_1;
            }
        }
        else if (currentPosition == "1B_1")
        {
            //Move options: 1B_2, 5
            int randomChoice = Random.Range(1, 3);
            
            if (randomChoice == 1)
            {
                currentPosition = "1B_2";
                nextScreen = Bonnie_1B_2;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "5_1";
                nextScreen = Bonnie_5_1;
            }
        }
        else if (currentPosition == "1B_2")
        {
            //Move options: 1B_1, 2A, 5
            int randomChoice = Random.Range(1, 4);
            
            if (randomChoice == 1)
            {
                currentPosition = "1B_1";
                nextScreen = Bonnie_1B_1;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "2A";
                nextScreen = Bonnie_2A;
            }
            else if (randomChoice == 3)
            {
                currentPosition = "5_1";
                nextScreen = Bonnie_5_1;
            }
        }
        else if (currentPosition == "2A")
        {
            //Move options: 2B, 3
            int randomChoice = Random.Range(1, 3);
            
            if (randomChoice == 1)
            {
                currentPosition = "2B";
                nextScreen = Bonnie_2B;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "3";
                nextScreen = Bonnie_3;
            }
        }
        else if (currentPosition == "2B")
        {
            //Move options: 3, Door
            int randomChoice = Random.Range(1, 3);
            
            if (randomChoice == 1)
            {
                currentPosition = "3";
                nextScreen = Bonnie_3;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "Door";
                Debug.LogWarning("Door not setup");
            }
        }
        else if (currentPosition == "3")
        {
            //Move options: 2A, Door
            int randomChoice = Random.Range(1, 3);
            
            if (randomChoice == 1)
            {
                currentPosition = "2A";
                nextScreen = Bonnie_2A;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "Door";
                Debug.LogWarning("Door not setup");
            }
        }
        else if (currentPosition == "5_1")
        {
            //Move options: 1B_1, 1B_2, 2A, 5_2
            int randomChoice = Random.Range(1, 5);
            
            if (randomChoice == 1)
            {
                currentPosition = "1B_1";
                nextScreen = Bonnie_1B_1;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "1B_2";
                nextScreen = Bonnie_1B_2;
            }
            else if (randomChoice == 3)
            {
                currentPosition = "2A";
                nextScreen = Bonnie_2A;
            }
            else if (randomChoice == 4)
            {
                currentPosition = "5_2";
                nextScreen = Bonnie_5_2;
            }
        }
        else if (currentPosition == "5_2")
        {
            //Move options: 1B_1, 1B_2, 2A, 5_1
            int randomChoice = Random.Range(1, 5);
            
            if (randomChoice == 1)
            {
                currentPosition = "1B_1";
                nextScreen = Bonnie_1B_1;
            }
            else if (randomChoice == 2)
            {
                currentPosition = "1B_2";
                nextScreen = Bonnie_1B_2;
            }
            else if (randomChoice == 3)
            {
                currentPosition = "2A";
                nextScreen = Bonnie_2A;
            }
            else if (randomChoice == 4)
            {
                currentPosition = "5_1";
                nextScreen = Bonnie_5_1;
            }
        }
        //TODO: Make Door work so this can be removed
        else if (currentPosition == "Door")
        {
            currentPosition = "5_1";
            nextScreen = Bonnie_5_1;
        }
        
        //Change screens
        if (previousScreen != null)
        {
            previousScreen.SetActive(false);
        }

        nextScreen.SetActive(true);

        previousScreen = nextScreen;

        Debug.Log("Moved Bonnie to: " + currentPosition);

    }
}
