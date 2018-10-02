using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpCheck : MonoBehaviour {

    public string sceneName;
    public string levelUpScene;
    public int oldLevel;

    private void Start()
    {
        oldLevel = PlayerStatsSingleton.level;
    }
    public void SceneSwap()
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
}
