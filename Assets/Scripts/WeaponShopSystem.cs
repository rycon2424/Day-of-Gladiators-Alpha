using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopSystem : MonoBehaviour {

    public GameObject sword;
    public GameObject axe;
    public GameObject spear;
    public GameObject ranged;

    public GameObject returnButton;

    public GameObject mainIcons;

    public GameObject swords;
    public GameObject axes;
    public GameObject spears;
    public GameObject rangedweapons;
    public GameObject backButton;

	void Start ()
    {

        sword.SetActive(true);
        axe.SetActive(true);
        spear.SetActive(true);
        ranged.SetActive(true);
        
        returnButton.SetActive(false);
        mainIcons.SetActive(true);

        swords.SetActive(false);
        axes.SetActive(false);
        spears.SetActive(false);
        rangedweapons.SetActive(false);

    }
	
	void Update ()
    {
		
	}

    public void ViewSwords()
    {

        backButton.SetActive(false);

        sword.SetActive(false);
        axe.SetActive(false);
        spear.SetActive(false);
        ranged.SetActive(false);

        swords.SetActive(true);

        mainIcons.SetActive(false);
        returnButton.SetActive(true);
    }

    public void ViewAxe()
    {

        backButton.SetActive(false);

        sword.SetActive(false);
        axe.SetActive(false);
        spear.SetActive(false);
        ranged.SetActive(false);

        axes.SetActive(true);

        mainIcons.SetActive(false);
        returnButton.SetActive(true);
    }

    public void ViewSpear()
    {

        backButton.SetActive(false);

        sword.SetActive(false);
        axe.SetActive(false);
        spear.SetActive(false);
        ranged.SetActive(false);

        spears.SetActive(true);

        mainIcons.SetActive(false);
        returnButton.SetActive(true);
    }

    public void ViewRanged()
    {

        backButton.SetActive(false);

        sword.SetActive(false);
        axe.SetActive(false);
        spear.SetActive(false);
        ranged.SetActive(false);

        rangedweapons.SetActive(true);

        mainIcons.SetActive(false);
        returnButton.SetActive(true);
    }

    public void Back()
    {

        backButton.SetActive(true);

        sword.SetActive(true);
        axe.SetActive(true);
        spear.SetActive(true);
        ranged.SetActive(true);

        swords.SetActive(false);
        axes.SetActive(false);
        spears.SetActive(false);
        rangedweapons.SetActive(false);

        mainIcons.SetActive(true);
        returnButton.SetActive(false);
    }

}