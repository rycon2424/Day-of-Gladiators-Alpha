using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeTheFight : MonoBehaviour
{
    [Header("Disabled on duels")]
    public GameObject mainCamera;
    public GameObject uiCanvas;

    [Header("on Tournaments")]
    public GameObject duelCanvas;
    public GameObject tournamentCanvas;

    public bool isTournament;

    void Start()
    {
        if (!isTournament)
        {
            duelCanvas.SetActive(true);
            tournamentCanvas.SetActive(false);
        }
        if (isTournament)
        {
            tournamentCanvas.SetActive(true);
            duelCanvas.SetActive(false);
        }
        mainCamera.SetActive(false);
        uiCanvas.SetActive(false);
    }

    void Update()
    {

    }

    public void StartFight()
    {
        if (isTournament)
        {
            tournamentCanvas.SetActive(false);
        }
        if (!isTournament)
        {
            duelCanvas.SetActive(false);
        }
        mainCamera.SetActive(true);
        uiCanvas.SetActive(true);
    }
}
