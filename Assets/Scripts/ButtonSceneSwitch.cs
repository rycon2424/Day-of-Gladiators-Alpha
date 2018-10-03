using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwitch : MonoBehaviour {

    public string sceneName;
    public string tournamentMap;

    public static int levelCap = 5;

    public void SceneSwap()
    {

        SceneManager.LoadScene(sceneName);

    }

    public void StartTournament()
    {
        if (PlayerStatsSingleton.level == levelCap)
        {
            levelCap = levelCap + 5;
            BeforeTheFight.isTournament = true;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
