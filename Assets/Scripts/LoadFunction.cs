using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFunction : MonoBehaviour {
    


	public void Load ()
    {
        CharacterCreation.username = PlayerPrefs.GetString("Name");
        Money.coin = PlayerPrefs.GetInt("Money");
        PlayerStatsSingleton.level = PlayerPrefs.GetInt("Level");
        WinLoseCanvas.currentXP = PlayerPrefs.GetInt("XP");
        ButtonSceneSwitch.levelCap = PlayerPrefs.GetInt("TournamentProgress");

        PlayerCombat.tierRanged = PlayerPrefs.GetInt("Bowdmg");
        PlayerCombat.tierWeapon = PlayerPrefs.GetInt("Weapondmg");

        CharacterCreation.STR = PlayerPrefs.GetInt("STR");
        CharacterCreation.END = PlayerPrefs.GetInt("END");
        CharacterCreation.DEX = PlayerPrefs.GetInt("DEX");
        CharacterCreation.VIT = PlayerPrefs.GetInt("VIT");
        CharacterCreation.LUC = PlayerPrefs.GetInt("LUCK");
        CharacterCreation.CHAR = PlayerPrefs.GetInt("MAGICDAMAGE");

        PlayerLooks.helmNumber = PlayerPrefs.GetInt("helm");
        PlayerLooks.bodyNumber = PlayerPrefs.GetInt("body");
        PlayerLooks.shouldersNumber = PlayerPrefs.GetInt("shoulders");
        PlayerLooks.glovesNumber = PlayerPrefs.GetInt("gloves");
        PlayerLooks.legsNumber = PlayerPrefs.GetInt("legs");
        PlayerLooks.shoesNumber = PlayerPrefs.GetInt("shoes");
        PlayerLooks.shieldNumber = PlayerPrefs.GetInt("shield");

        CharacterCreation.beardNumberGlobal = PlayerPrefs.GetInt("Beard");
        CharacterCreation.hairNumberGlobal = PlayerPrefs.GetInt("Hair");

        PlayerLooks.weapon = PlayerPrefs.GetInt("Sword");
        PlayerLooks.bow = PlayerPrefs.GetInt("Bow");
        SceneManager.LoadScene(2);
    }

}
