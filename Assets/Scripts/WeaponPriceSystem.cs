using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPriceSystem : MonoBehaviour {

    public int price;
    public static int weaponNumber;
    public int whatWeaponNumber;
    public int tier;

    public bool isBow;
    public static int bowNumber;
    public int whatBowNumber;

    public Text priceTag;

    private void Update()
    {
        if (!isBow)
        {
            if (weaponNumber == whatWeaponNumber)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }
        if (isBow)
        {
            if (bowNumber == whatBowNumber)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }
    }

    public void Cost()
    {
        if (!isBow)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (weaponNumber == whatWeaponNumber)
                {
                    return;
                }
                else
                {
                    weaponNumber = whatWeaponNumber;
                    Money.coin = Money.coin - price;
                    PlayerLooks.weapon = weaponNumber;
                    PlayerCombat.tierWeapon = tier;
                    PlayerLooks.useBow = false;
                }
            }
        }

        if (isBow)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (bowNumber == whatBowNumber)
                {
                    return;
                }
                else
                {
                    print("Bow PURCHASED");
                    bowNumber = whatBowNumber;
                    Money.coin = Money.coin - price;
                    PlayerLooks.bow = bowNumber;
                    PlayerLooks.useBow = true;
                }
            }
        }
    }

}
