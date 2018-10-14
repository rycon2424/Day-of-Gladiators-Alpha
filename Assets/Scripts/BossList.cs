using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossList : MonoBehaviour {

    public GameObject ColUI;
    public GameObject mainCamera;
    public GameObject list;

	
    public void ShowBosses()
    {
        ColUI.SetActive(false);
        mainCamera.SetActive(false);
        list.SetActive(true);
    }

    public void GoBack()
    {
        ColUI.SetActive(true);
        mainCamera.SetActive(true);
        list.SetActive(false);
    }

}
