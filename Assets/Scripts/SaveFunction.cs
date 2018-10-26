using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFunction : MonoBehaviour {

    public GameObject textCloud;
    public Text info;

    public Text price;
    public int cost;

    private void Update()
    {
        price.text = cost.ToString();
    }

    public void Save()
    {
        if (Money.coin > cost || Money.coin == cost)
        {
            PlayerPrefs.SetString("Name", CharacterCreation.username);
            PlayerPrefs.SetInt("Money", Money.coin);
            PlayerPrefs.SetInt("Level", PlayerStatsSingleton.level);
            PlayerPrefs.SetInt("XP", WinLoseCanvas.currentXP);
            PlayerPrefs.SetInt("TournamentProgress", ButtonSceneSwitch.levelCap);

            PlayerPrefs.SetInt("Bowdmg", PlayerCombat.tierRanged);
            PlayerPrefs.SetInt("Weapondmg", PlayerCombat.tierWeapon);

            PlayerPrefs.SetInt("STR", CharacterCreation.STR);
            PlayerPrefs.SetInt("END", CharacterCreation.END);
            PlayerPrefs.SetInt("DEX", CharacterCreation.DEX);
            PlayerPrefs.SetInt("VIT", CharacterCreation.VIT);
            PlayerPrefs.SetInt("LUCK", CharacterCreation.LUC);
            PlayerPrefs.SetInt("MAGICDAMAGE", CharacterCreation.CHAR);

            PlayerPrefs.SetInt("helm", PlayerLooks.helmNumber);
            PlayerPrefs.SetInt("body", PlayerLooks.bodyNumber);
            PlayerPrefs.SetInt("shoulders", PlayerLooks.shouldersNumber);
            PlayerPrefs.SetInt("gloves", PlayerLooks.glovesNumber);
            PlayerPrefs.SetInt("legs", PlayerLooks.legsNumber);
            PlayerPrefs.SetInt("shoes", PlayerLooks.shoesNumber);
            PlayerPrefs.SetInt("shield", PlayerLooks.shieldNumber);

            PlayerPrefs.SetInt("Beard", CharacterCreation.beardNumberGlobal);
            PlayerPrefs.SetInt("Hair", CharacterCreation.hairNumberGlobal);

            PlayerPrefs.SetInt("Sword", PlayerLooks.weapon);
            PlayerPrefs.SetInt("Bow", PlayerLooks.bow);
            Money.coin = Money.coin - cost;
            cost = cost + Random.Range(50, 201);
        }
        else if (Money.coin < cost)
        {
            textCloud.SetActive(true);
            info.text = "You have insufficient coin to pay for this.";
        }
    }

    public void Hide()
    {
        textCloud.SetActive(false);
    }

}
