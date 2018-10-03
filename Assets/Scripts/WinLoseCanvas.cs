using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseCanvas : MonoBehaviour {

    public int goldEarnedLost;

    public PlayerCombat playerValues;
    public EnemyCombat enemyValues;

    public Text textWinLose;
    public Text gold;

    public bool doOnce;
    public bool doOnceLevelUp;

    [Header("XpSystem")]
    public Text levelT;
    public static int currentXP;
    public Text currentXPT;
    public int xpGained;
    public Text xpGainT;
    public float maxXP;
    public Text maxpXPText;
    public Slider xpBar;

    [Header("ImportantXP")]
    public int minimalXP;
    public int maximalXP;

    public GameObject layOut, fightCanvas, playerButtons, toVillage;
    public AudioSource levelUpSound;

    void Start ()
    {
        toVillage.SetActive(false);
        doOnceLevelUp = true;
        doOnce = true;
        layOut.SetActive(false);
        maxXP = 500 * PlayerStatsSingleton.level;
        xpBar.maxValue = maxXP;
	}
	
	void Update ()
    {
        if (playerValues.hp < 1 && doOnce == true)
        {
            goldEarnedLost = Random.Range(200, 801);
            layOut.SetActive(true);
            fightCanvas.SetActive(false);

            Money.coin = Money.coin - goldEarnedLost;
            textWinLose.text = "You lost and lose some of your coin but live to see another day. (" + goldEarnedLost.ToString() + ")";
            if (Money.coin < 0)
            {
                Money.coin = 0;
            }
            gold.text = Money.coin.ToString();

            currentXPT.text = currentXP.ToString();
            maxpXPText.text = "/ " + maxXP.ToString();
            xpGainT.text = "Gained no XP";
            xpBar.value = 0;
            levelT.text = PlayerStatsSingleton.level.ToString();

            doOnce = false;
        }

        if (enemyValues.hp < 1 && doOnce == true)
        {
            goldEarnedLost = Random.Range(200, 801) + (50 * PlayerStatsSingleton.level);
            layOut.SetActive(true);
            fightCanvas.SetActive(false);
            
            Money.coin = Money.coin + goldEarnedLost;
            textWinLose.text = "You won and earned some gold, well played! (" + goldEarnedLost.ToString() + ")";
            gold.text = Money.coin.ToString();

            xpGained = Random.Range(minimalXP, maximalXP) + (100 * PlayerStatsSingleton.level);
            currentXP = currentXP + xpGained;
            currentXPT.text = currentXP.ToString();
            maxpXPText.text =  "/ " + maxXP.ToString();
            xpGainT.text = "Gained +" + xpGained.ToString() + " XP!";
            xpBar.value = 0;
            levelT.text = PlayerStatsSingleton.level.ToString();

            doOnce = false;
        }

        if (enemyValues.hp < 1 || playerValues.hp < 1)
        {
            playerButtons.SetActive(false);
            XpSystem();
        }
    }

    void XpSystem()
    {
        if (xpBar.value < currentXP)
        {
            if (PlayerStatsSingleton.level > 1)
            {
                xpBar.value = xpBar.value + 6f * PlayerStatsSingleton.level;
            }
            else
            {
                xpBar.value = xpBar.value + 6f;
            }
        }
        if (xpBar.value == currentXP || xpBar.value > currentXP)
        {
            toVillage.SetActive(true);
        }
        if (xpBar.value > maxXP || xpBar.value == maxXP && doOnceLevelUp == true)
        {
            toVillage.SetActive(true);
            levelUpSound.Play();
            PlayerStatsSingleton.level = PlayerStatsSingleton.level + 1;
            levelT.text = PlayerStatsSingleton.level.ToString();
            currentXPT.text = "LEVEL";
            maxpXPText.text = "UP!";
            currentXP = 0;
            Debug.Log("Level Up");
            doOnceLevelUp = false;
        }
    }

}
