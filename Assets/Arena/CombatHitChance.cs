using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHitChance : MonoBehaviour {
    
    public Text chanceText;
    public GameObject display;
    public PlayerCombat pc;
    public bool lightC, mediumC, heavyC;
    
    void OnMouseOver()
    {
        display.SetActive(true);
        if (lightC)
        {
            chanceText.text = "Hit chance:  " + pc.lightChance.ToString() + "%";
        }
        if (mediumC)
        {
            chanceText.text = "Hit chance: " + pc.mediumChance.ToString() + "%";
        }
        if (heavyC)
        {
            chanceText.text = "Hit chance: " + pc.heavyChance.ToString() + "%";
        }
    }

    void OnMouseExit()
    {
        display.SetActive(false);
    }

}
