using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpCheck : MonoBehaviour {

    public string sceneName;
    public string levelUpScene;

    public string EndDemo;

    public int oldLevel;

    private void Start()
    {
        oldLevel = PlayerStatsSingleton.level;
    }
    public void SceneSwap()
    {
        if (!BeforeTheFight.isTournament)
        {
            if (oldLevel == PlayerStatsSingleton.level)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneManager.LoadScene(levelUpScene);
            }
        }

        if (BeforeTheFight.isTournament)
        {
            SceneManager.LoadScene(EndDemo);
        }
    }
}
