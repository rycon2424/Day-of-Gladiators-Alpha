using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    public GameObject charDisplay;
    public GameObject typeNames;
    public GameObject Shop;

    public GameObject helmets;
    public GameObject bodys;
    public GameObject shoulders;
    public GameObject gloves;
    public GameObject legs;
    public GameObject shoes;
    public GameObject shields;

    public GameObject returnButton;
    public GameObject returnToTown;

    private void Start()
    {
        charDisplay.SetActive(true);
        typeNames.SetActive(true);
        returnToTown.SetActive(true);

        returnButton.SetActive(false);
        Shop.SetActive(false);
    }

    public void Back()
    {
        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(false);

        Shop.SetActive(false);
        charDisplay.SetActive(true);
        typeNames.SetActive(true);
        returnButton.SetActive(false);
        returnToTown.SetActive(true);
    }

    public void Helmet()
    {
        Shop.SetActive(true);

        helmets.SetActive(true);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Body()
    {
        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(true);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Shoulder()
    {
        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(true);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Glove()
    {
        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(true);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Leg()
    {
        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(true);
        shoes.SetActive(false);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Shoe()
    {
        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(true);
        shields.SetActive(false);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

    public void Shield()
    {

        Shop.SetActive(true);

        helmets.SetActive(false);
        bodys.SetActive(false);
        shoulders.SetActive(false);
        gloves.SetActive(false);
        legs.SetActive(false);
        shoes.SetActive(false);
        shields.SetActive(true);

        charDisplay.SetActive(false);
        typeNames.SetActive(false);
        returnButton.SetActive(true);
        returnToTown.SetActive(false);
    }

}
