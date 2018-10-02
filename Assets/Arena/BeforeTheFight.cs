using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeTheFight : MonoBehaviour
{
    [Header("Disabled on duels")]
    public GameObject mainCamera;
    public GameObject uiCanvas;
    public GameObject firstCamera;

    void Start()
    {
        firstCamera.SetActive(true);
        mainCamera.SetActive(false);
        uiCanvas.SetActive(false);
    }

    void Update()
    {

    }

    public void StartFight()
    {
        firstCamera.SetActive(false);
        mainCamera.SetActive(true);
        uiCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
