using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourPriceSystem1 : MonoBehaviour {

    public bool helm;
    public bool body;
    public bool shoulders;
    public bool gloves;
    public bool legs;
    public bool shoes;
    public bool shields;

    public int armourValue;
    public int numberType;
    public int price;
    public Text priceTag;

    private void Update()
    {
        if (helm)
        {
            if (PlayerLooks.helmNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (body)
        {
            if (PlayerLooks.bodyNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (shoulders)
        {
            if (PlayerLooks.shouldersNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (gloves)
        {
            if (PlayerLooks.glovesNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (legs)
        {
            if (PlayerLooks.legsNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (shoes)
        {
            if (PlayerLooks.shoesNumber == numberType)
            {
                priceTag.text = "Bought";
            }
            else
            {
                priceTag.text = price.ToString();
            }
        }

        if (shields)
        {
            if (PlayerLooks.shieldNumber == numberType)
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
        if (helm)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.helmNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.helmNumber = numberType;
                }
            }
        }

        if (body)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.bodyNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.bodyNumber = numberType;
                }
            }
        }

        if (shoulders)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.shouldersNumber == numberType)
                {
                    return;
                }
                else
	            {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.shouldersNumber = numberType;
                }
            }
        }

        if (gloves)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.glovesNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.glovesNumber = numberType;
                }
            }
        }

        if (legs)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.legsNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.legsNumber = numberType;
                }
            }
        }

        if (shoes)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.shoesNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.shoesNumber = numberType;
                }
            }
        }

        if (shields)
        {
            if (Money.coin > price || Money.coin == price)
            {
                if (PlayerLooks.shieldNumber == numberType)
                {
                    return;
                }
                else
                {
                    ArmourValue();
                    Money.coin = Money.coin - price;
                    PlayerLooks.shieldNumber = numberType;
                }
            }
        }
    }

    void ArmourValue()
    {
        if (helm)
        {
            if (numberType == 1)
            {
                PlayerCombat.helmArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.helmArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.helmArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.helmArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.helmArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.helmArmour = armourValue;
            }
        }

        if (body)
        {
            if (numberType == 1)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.bodyArmour = armourValue;
            }
        }

        if (shoulders)
        {
            if (numberType == 1)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.shoulderArmour = armourValue;
            }
        }

        if (gloves)
        {
            if (numberType == 1)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.glovesArmour = armourValue;
            }
        }

        if (legs)
        {
            if (numberType == 1)
            {
                PlayerCombat.legsArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.legsArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.legsArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.legsArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.legsArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.legsArmour = armourValue;
            }
        }

        if (shoes)
        {
            if (numberType == 1)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.shoesArmour = armourValue;
            }
        }

        if (shields)
        {
            if (numberType == 1)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
            if (numberType == 2)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
            if (numberType == 3)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
            if (numberType == 4)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
            if (numberType == 5)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
            if (numberType == 6)
            {
                PlayerCombat.shieldArmour = armourValue;
            }
        }
    }
}
