using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeTheFight : MonoBehaviour
{
    [Header("Disabled on duels")]
    public GameObject mainCamera;
    public GameObject uiCanvas;

    [Header("On Tournaments")]
    public GameObject duelCanvas;
    public GameObject tournamentCanvas;
    public GameObject bossFightOst;

    public static bool isTournament;

    void Start()
    {
        if (!isTournament)
        {
            bossFightOst.SetActive(false);
            duelCanvas.SetActive(true);
            tournamentCanvas.SetActive(false);
        }
        if (isTournament)
        {
            StartCoroutine(MusicBoss());
            tournamentCanvas.SetActive(true);
            duelCanvas.SetActive(false);
        }
        mainCamera.SetActive(false);
        uiCanvas.SetActive(false);
    }

    IEnumerator MusicBoss()
    {
        yield return new WaitForSeconds(16);
        bossFightOst.SetActive(true);
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
