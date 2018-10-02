using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPriceSystem : MonoBehaviour {

    public int price;
    public static int weaponNumber;
    public int whatWeaponNumber;
    public int tier;

    public Text priceTag;

    private void Update()
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

    public void Cost()
    {
        if (Money.coin > price || Money.coin == price)
        {
            if (weaponNumber == whatWeaponNumber)
            {
                return;
            }
            else
            {
                print("PURCHASED");
                weaponNumber = whatWeaponNumber;
                Money.coin = Money.coin - price;
                PlayerLooks.weapon = weaponNumber;
                PlayerCombat.tierWeapon = tier;
                Debug.Log("Current Coins = " + Money.coin);
            }
        }
    }

}
