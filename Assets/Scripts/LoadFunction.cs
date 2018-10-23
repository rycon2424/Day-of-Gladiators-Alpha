using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadFunction : MonoBehaviour
{

    public GameObject textBox;
    public GameObject yesButton;
    public Text warningText;

    public bool newgame = false, removesave = false;

    public void Load()
    {
        PlayerStatsSingleton.level = PlayerPrefs.GetInt("Level");
        if (PlayerStatsSingleton.level > 0)
        {
            CharacterCreation.username = PlayerPrefs.GetString("Name");
            Money.coin = PlayerPrefs.GetInt("Money");
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
            PlayerStatsSingleton.level = PlayerStatsSingleton.level + 1;
            SceneManager.LoadScene(2);
        }
        else
        {
            textBox.SetActive(true);
            warningText.text = "No save file has been found, start new game?";
            newgame = true;
        }
    }

    public void NewgameCheck()
    {
        PlayerStatsSingleton.level = PlayerPrefs.GetInt("Level");
        if (PlayerStatsSingleton.level > 0)
        {
            textBox.SetActive(true);
            warningText.text = "Want to remove all progress and start new game?";
            newgame = true;
        }
        else
        {
            Newgame();
        }
    }

    public void Newgame()
    {
        PlayerPrefs.DeleteAll();
        PlayerStatsSingleton.level = PlayerStatsSingleton.level + 1;
        SceneManager.LoadScene(1);
    }

    public void RemoveSaveCheck()
    {
        PlayerStatsSingleton.level = PlayerPrefs.GetInt("Level");
        if (PlayerStatsSingleton.level > 0)
        {
            removesave = true;
            textBox.SetActive(true);
            warningText.text = "You sure you want to delete all progress made?";
        }
        else
        {
            textBox.SetActive(true);
            yesButton.SetActive(false);
            warningText.text = "There is no save file to delete.";
        }
    }

    public void RemoveSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Confirm()
    {
        if (newgame)
        {
            Newgame();
        }
        if (removesave)
        {
            RemoveSave();
        }
        Hide();
    }

    public void Hide()
    {
        newgame = false;
        removesave = false;
        yesButton.SetActive(true);
        textBox.SetActive(false);
    }

}
