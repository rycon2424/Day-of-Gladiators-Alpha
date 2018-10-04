using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeforeTheFight : MonoBehaviour
{
    [Header("Disabled on duels")]
    public GameObject mainCamera;
    public GameObject uiCanvas;
    public Text playerName, playerNameC;
    public Text enemyName, enemyNameC, bossNameC;
    public string enemysFullname;
    public string[] firstNames = new string[21];
    public string[] surNames = new string[21];

    [Header("On Tournaments")]
    public string BossName;
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
            tournamentCanvas.SetActive(true);
            duelCanvas.SetActive(false);
        }
        NameGen();
        mainCamera.SetActive(false);
        uiCanvas.SetActive(false);
    }

    public void MusicBoss()
    {
        bossFightOst.SetActive(true);
    }

    public void NameGen()
    {
        if (isTournament)
        {
            bossNameC.text = BossName;
            enemyName.text = BossName;
        }
        if (!isTournament)
        {
            enemysFullname = firstNames[Random.Range(1, firstNames.Length)] + " " + surNames[Random.Range(1, surNames.Length)];
            enemyName.text = enemysFullname;
        }
        playerName.text = CharacterCreation.username;
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
        if (!isTournament)
        {
            enemyNameC.text = enemysFullname;
        }
        if (isTournament)
        {
            enemyNameC.text = BossName;
        }
        playerNameC.text = CharacterCreation.username;
    }
}
