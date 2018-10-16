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
    public string[] BossName = new string[4];
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
            if (PlayerStatsSingleton.level == 5)
            {
                bossNameC.text = BossName[0];
                enemyName.text = BossName[0];
            }
            if (PlayerStatsSingleton.level == 10)
            {
                bossNameC.text = BossName[1];
                enemyName.text = BossName[1];
            }
            if (PlayerStatsSingleton.level == 15)
            {
                bossNameC.text = BossName[2];
                enemyName.text = BossName[2];
            }
            if (PlayerStatsSingleton.level == 20)
            {
                bossNameC.text = BossName[3];
                enemyName.text = BossName[3];
            }
            if (PlayerStatsSingleton.level == 25)
            {
                bossNameC.text = BossName[4];
                enemyName.text = BossName[4];
            }
            if (PlayerStatsSingleton.level == 30)
            {
                bossNameC.text = BossName[5];
                enemyName.text = BossName[5];
            }
            if (PlayerStatsSingleton.level == 35)
            {
                bossNameC.text = BossName[6];
                enemyName.text = BossName[6];
            }
            if (PlayerStatsSingleton.level == 40)
            {
                bossNameC.text = BossName[7];
                enemyName.text = BossName[7];
            }
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
            if (PlayerStatsSingleton.level == 5)
            {
                enemyNameC.text = BossName[0];
            }
            if (PlayerStatsSingleton.level == 10)
            {
                enemyNameC.text = BossName[1];
            }
            if (PlayerStatsSingleton.level == 15)
            {
                enemyNameC.text = BossName[2];
            }
            if (PlayerStatsSingleton.level == 20)
            {
                enemyNameC.text = BossName[3];
            }
            if (PlayerStatsSingleton.level == 25)
            {
                enemyNameC.text = BossName[4];
            }
            if (PlayerStatsSingleton.level == 30)
            {
                enemyNameC.text = BossName[5];
            }
            if (PlayerStatsSingleton.level == 35)
            {
                enemyNameC.text = BossName[6];
            }
            if (PlayerStatsSingleton.level == 40)
            {
                enemyNameC.text = BossName[7];
            }
        }
        playerNameC.text = CharacterCreation.username;
    }
}
