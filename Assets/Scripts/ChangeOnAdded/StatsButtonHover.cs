using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsButtonHover : StatsBehaviour
{

    public GameObject stats;

    public Text Name;
    public Text LEVEL;
    public Text STR;
    public Text END;
    public Text DEX;
    public Text VIT;
    public Text LUCK;
    public Text MAG;
    public Text ARMOUR;

    void Start ()
    {
        Name.text = CharacterCreation.username;
        baseHp = 15;
        baseDamage = 2;
        baseSpeed = 1;
        baseStamina = 30;
        baseMgcDamage = 20;
        
        hp = baseHp + (15 * CharacterCreation.VIT);
        stamina = baseStamina + (10 * CharacterCreation.END);
        movementSpeed = baseSpeed + (0.4f * CharacterCreation.DEX);
        magicDamage = baseMgcDamage + (10 * CharacterCreation.CHAR);
        
        #region LuckChance
        lightChance = 70 + CharacterCreation.LUC - 1;
        mediumChance = 50 + CharacterCreation.LUC - 1;
        heavyChance = 30 + CharacterCreation.LUC - 1;
        #endregion

        stats.SetActive(false);
	}

    void DamageBasedOnTiers()
    {
        if (PlayerCombat.tierWeapon == 1)
        {
            weaponDamage = 2;
        }
        if (PlayerCombat.tierWeapon == 2)
        {
            weaponDamage = 5;
        }
        if (PlayerCombat.tierWeapon == 3)
        {
            weaponDamage = 10;
        }
        if (PlayerCombat.tierWeapon == 4)
        {
            weaponDamage = 18;
        }

        if (PlayerCombat.tierWeapon == 5)
        {
            weaponDamage = 25;
        }
        if (PlayerCombat.tierWeapon == 6)
        {
            weaponDamage = 30;
        }
        if (PlayerCombat.tierWeapon == 7)
        {
            weaponDamage = 35;
        }
        if (PlayerCombat.tierWeapon == 8)
        {
            weaponDamage = 50;
        }
    }

    void Update ()
    {
        LEVEL.text = PlayerStatsSingleton.level.ToString();
        STR.text = lightDamage.ToString() + "L " + mediumDamage.ToString() + "M " + heavyDamage.ToString() + "H";
        END.text = stamina.ToString() + " / " + stamina.ToString();
        DEX.text = movementSpeed.ToString();
        VIT.text = hp.ToString() + " / " + hp.ToString();
        LUCK.text = lightChance.ToString() + "% " + mediumChance.ToString() + "% " + heavyChance.ToString() + "%";
        MAG.text = "??";
        armour = PlayerCombat.helmArmour + PlayerCombat.bodyArmour + PlayerCombat.shoulderArmour
               + PlayerCombat.legsArmour + PlayerCombat.shoesArmour + PlayerCombat.glovesArmour
               + PlayerCombat.shieldArmour;
        ARMOUR.text = armour.ToString();

        #region Damage
        DamageBasedOnTiers();

        lightDamage = baseDamage + (1 * CharacterCreation.STR) + weaponDamage;
        mediumDamage = baseDamage + (3 * CharacterCreation.STR) + weaponDamage;
        heavyDamage = baseDamage + (7 * CharacterCreation.STR) + weaponDamage;
        #endregion
    }

    void OnMouseOver()
    {
        stats.SetActive(true);
    }

    void OnMouseExit()
    {
        stats.SetActive(false);
    }

}
