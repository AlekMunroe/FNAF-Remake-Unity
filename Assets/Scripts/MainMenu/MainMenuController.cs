using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject newGameScreen;
    
    [Header("Audio")]
    [SerializeField] private GameObject backgroundAudio;

    [Header("UI")] 
    [SerializeField] private TMP_Text nightText;

    private int levelIndex = 0;

    void Awake()
    {
        //Initialise staring values
        startScreen.SetActive(true);
        backgroundAudio.SetActive(false);
        newGameScreen.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(StartScreenStartup());

        if (PlayerPrefs.HasKey("currentNight"))
        {
            levelIndex = PlayerPrefs.GetInt("currentNight");
            nightText.text = "Night " + levelIndex.ToString();
        }
        else
        {
            //Game has never been played
            PlayerPrefs.SetInt("currentNight", 1);
            levelIndex = 1;
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGame());
    }

    public void ContinueGameButton()
    {
        if (levelIndex == 1)
        {
            //Load new game
            StartCoroutine(NewGame());
        }
        else
        {
            //Load into current night
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator NewGame()
    {
        PlayerPrefs.SetInt("currentNight", 1);
        
        newGameScreen.SetActive(true);

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("Game");
    }

    IEnumerator StartScreenStartup()
    {
        Animation anim = startScreen.GetComponent<Animation>();
        
        //Play the animation
        anim.Play("StartScreenFadeOut");
        
        yield return new WaitForSeconds(anim.clip.length);
        
        //Destroy the start screen
        Destroy(startScreen);

        //Start the audio
        backgroundAudio.SetActive(true);
    }
}
