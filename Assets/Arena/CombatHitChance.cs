using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHitChance : MonoBehaviour {
    
    public Text chanceText, daamgeText, staminaText;
    public GameObject display, damageDisplay, staminaDisplay;
    public PlayerCombat pc;
    public bool lightC, mediumC, heavyC, rangedL;
    
    void OnMouseOver()
    {
        display.SetActive(true);
        staminaDisplay.SetActive(true);
        if (lightC)
        {
            damageDisplay.SetActive(true);
            chanceText.text = "Hit chance:  " + pc.lightChance.ToString() + "%";
            daamgeText.text = pc.lightDamage.ToString() + " Dmg";
            staminaText.text = "Cost " + pc.LightCost.ToString();
        }
        if (mediumC)
        {
            damageDisplay.SetActive(true);
            chanceText.text = "Hit chance: " + pc.mediumChance.ToString() + "%";
            daamgeText.text = pc.mediumDamage.ToString() + " Dmg";
            staminaText.text = "Cost " + pc.MediumCost.ToString();
        }
        if (heavyC)
        {
            damageDisplay.SetActive(true);
            chanceText.text = "Hit chance: " + pc.heavyChance.ToString() + "%";
            daamgeText.text = pc.heavyDamage.ToString() + " Dmg";
            staminaText.text = "Cost " + pc.HeavyCost.ToString();
        }
        if (rangedL)
        {
            damageDisplay.SetActive(true);
            chanceText.text = "Hit chance: " + pc.lightChance.ToString() + "%";
            daamgeText.text = pc.arrowDamageLight.ToString() + " Dmg";
            staminaText.text = "Cost " + pc.lightShotCost.ToString();
        }
    }

    void OnMouseExit()
    {
        display.SetActive(false);
        damageDisplay.SetActive(false);
        staminaDisplay.SetActive(false);
    }

}
