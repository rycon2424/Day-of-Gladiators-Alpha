using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwitch : MonoBehaviour {

    public string sceneName;

    public void SceneSwap()
    {

        SceneManager.LoadScene(sceneName);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
