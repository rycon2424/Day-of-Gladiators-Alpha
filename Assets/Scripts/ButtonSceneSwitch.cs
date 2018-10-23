using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneSwitch : MonoBehaviour {

    public string sceneName;

    [Header("Tournament stuff")]
    public bool tournamentButton;
    public string tournamentMap;
    public int whatIsTheLevelcap;
    public static int levelCap = 5;
    public GameObject talkCloud;
    public Text cantEnter;
    public GameObject duelButton;

    private void Start()
    {
        if (tournamentButton)
        {
            talkCloud.SetActive(false);
        }
    }
    private void Update()
    {
        whatIsTheLevelcap = levelCap;
        if (tournamentButton)
        {
            if (PlayerStatsSingleton.level == levelCap)
            {
                duelButton.SetActive(false);
            }
            else
            {
                duelButton.SetActive(true);
            }
        }
    }

    public void SceneSwap()
    {

        SceneManager.LoadScene(sceneName);

    }
    
    public void StartTournament()
    {
        if (PlayerStatsSingleton.level == levelCap)
        {
            BeforeTheFight.isTournament = true;
            SceneManager.LoadScene(tournamentMap);
        }
        else
        {
            talkCloud.SetActive(true);
            cantEnter.text = "You need to be atleast level " + levelCap + " to enter the tournament.";
        }
    }

    public void HideText()
    {
        talkCloud.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
