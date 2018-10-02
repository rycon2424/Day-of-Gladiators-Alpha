using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBehaviour : MonoBehaviour
{
    [Header("Base Statistics")]
    public int baseHp = 15;
    public int baseDamage = 2;
    public int baseSpeed = 1;
    public int baseStamina = 30;
    public int baseMgcDamage = 20;
    [Header("Ingame Calculated")]
    public int hp;
    public int weaponDamage;
    public float movementSpeed;
    public int armour;
    public int stamina;
    public float magicDamage;
    [Header("Damage Calculated")]
    public int lightDamage;
    public int mediumDamage;
    public int heavyDamage;
    [Header("Chances Calculated")]
    public float lightChance;
    public float mediumChance;
    public float heavyChance;
    [Header("Stamina Costs")]
    public int WalkCost;
    public int SleepCost;
    public int HeavyCost;
    public int MediumCost;
    public int LightCost;
    public int DabCost;
    public int StaminaRegen;

}
