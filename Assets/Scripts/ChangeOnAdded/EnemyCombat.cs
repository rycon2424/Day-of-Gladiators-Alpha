using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : StatsBehaviour
{

    [Header("Animator")]
    public Animator anim;

    [Header("SkillPoints")]
    public int strenght;
    public int endurance;
    public int dexterity;
    public int vitality;
    public int luck;
    public int charisma;

    [Header("HitDetection")]
    private Vector3 target;
    public Transform enemy;

    [Header("UI")]
    public Text currentHp;
    public Text maxHP;
    public Text currentStamina;
    public Text maxStamina;
    public Text currentArmour;
    public Text damageTaken;
    public GameObject damageUI;

    [Header("BeforeFight")]
    public Text maxHPB;
    public Text maxStaminaB;
    public Text maxArmour;
    public Text strengthText;

    [Header("Armour")]
    public GameObject shieldIcon;
    public Image shieldToChange;
    public Sprite shieldFull;
    public Sprite shieldHalf;
    public Sprite shieldDamaged;
    public int maxArmourInt;
    private int maxStaminaInt;
    private int maxHealthInt;

    [Header("Health & Stamina")]
    public Image healthToChange;
    public Sprite HPFull;
    public Sprite HPHalf;
    public Sprite HPLow;
    public Image StaminaToChange;
    public Sprite STFull;
    public Sprite STHalf;
    public Sprite STLow;
    public Image damageLogo;
    public Sprite blood, shield;

    [Header("Audio")]
    public AudioSource ac;
    public AudioClip[] attacks = new AudioClip[2];
    public AudioClip[] hits = new AudioClip[2];
    public AudioClip[] blocks = new AudioClip[2];

    private bool act;

    public PlayerCombat playerFunction;
    
    void Start()
    {
        damageUI.SetActive(false);

        act = true;

        if (BeforeTheFight.isTournament)
        {
            baseHp = 40;
            baseDamage = 3;
            baseSpeed = 3;
            baseStamina = 50;
        }

        strenght = CharacterCreation.STR + Random.Range(-2, 3);
        if (strenght < 0)
        {
            strenght = 1;
        }
        endurance = CharacterCreation.END + Random.Range(-2, 3);
        if (endurance < 0)
        {
            endurance = 1;
        }
        dexterity = CharacterCreation.DEX + Random.Range(-2, 3);
        if (dexterity < 0)
        {
            dexterity = 1;
        }
        vitality = CharacterCreation.VIT + Random.Range(-2, 3);
        if (vitality < 0)
        {
            vitality = 1;
        }
        luck = CharacterCreation.LUC + Random.Range(-2, 3);
        if (luck < 0)
        {
            luck = 1;
        }
        charisma = CharacterCreation.CHAR + Random.Range(-2, 3);
        if (charisma < 0)
        {
            charisma = 1;
        }

        hp = baseHp + (15 * vitality);
        stamina = baseStamina + (10 * endurance);
        movementSpeed = baseSpeed + (0.4f * dexterity);
        magicDamage = baseMgcDamage + (10 * charisma);

        DamageBasedOnTiers();

        armour = PlayerCombat.helmArmour + PlayerCombat.bodyArmour + PlayerCombat.shoulderArmour
               + PlayerCombat.legsArmour + PlayerCombat.shoesArmour + PlayerCombat.glovesArmour
               + PlayerCombat.shieldArmour + (Random.Range(-10, 20));

        if (armour < 1)
        {
            armour = (Random.Range(10, 30));
        }


        maxStaminaInt = stamina;
        maxHealthInt = hp;
        maxArmourInt = armour;

        maxArmour.text = maxArmourInt.ToString();
        
        maxHP.text = hp.ToString();
        maxStamina.text = stamina.ToString();

        maxArmour.text = maxArmourInt.ToString();
        maxHPB.text = hp.ToString();
        maxStaminaB.text = stamina.ToString();
        strengthText.text = strenght.ToString();

        #region Damage
        lightDamage = baseDamage + (1 * strenght) + weaponDamage;
        mediumDamage = baseDamage + (3 * strenght) + weaponDamage;
        heavyDamage = baseDamage + (7 * strenght) + weaponDamage;
        #endregion

        #region LuckChance
        lightChance = 70 + luck;
        mediumChance = 50 + luck;
        heavyChance = 30 + luck;
        #endregion

    }

    private void Update()
    {
        if (hp < 1)
        {
            anim.SetInteger("State", 7);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            armour = armour - 1;
        }
        target = enemy.transform.position;
        UIinfo();
        ArmourCalc();
        StaminaControl();
        HealthControl();
        if (act &&  PlayerCombat.playerTurn == false && hp > 0)
        {
            AIBrain();
        }
    }

    #region Health Stamina Ui Armour Damage Misc.

    void HealthControl()
    {
        if (hp > maxHealthInt)
        {
            hp = maxHealthInt;
        }
        if (hp < 0)
        {
            hp = 0;
        }
        if (hp > maxHealthInt / 2)
        {
            healthToChange.sprite = HPFull;
        }
        if (hp < maxHealthInt / 2 && hp > maxHealthInt / 4)
        {
            healthToChange.sprite = HPHalf;
        }
        if (hp < maxHealthInt / 4)
        {
            healthToChange.sprite = HPLow;
        }
    }

    void StaminaControl()
    {
        if (stamina > maxStaminaInt)
        {
            stamina = maxStaminaInt;
        }
        if (stamina < 0)
        {
            stamina = 0;
        }
        if (stamina > maxStaminaInt / 1.5f)
        {
            StaminaToChange.sprite = STFull;
        }
        if (stamina < maxStaminaInt / 1.5f && stamina > maxStaminaInt / 4)
        {
            StaminaToChange.sprite = STHalf;
        }
        if (stamina < maxStaminaInt / 4)
        {
            StaminaToChange.sprite = STLow;
        }
    }

    void UIinfo()
    {
        currentHp.text = hp.ToString();
        currentStamina.text = stamina.ToString();
        currentArmour.text = armour.ToString();
    }

    void ArmourCalc()
    {
        if (armour > maxArmourInt / 2)
        {
            shieldToChange.sprite = shieldFull;
        }
        if (armour < maxArmourInt / 2 && armour > maxArmourInt / 4)
        {
            shieldToChange.sprite = shieldHalf;
        }
        if (armour < maxArmourInt / 4 && armour > 1)
        {
            shieldToChange.sprite = shieldDamaged;
        }
        if (armour < 1)
        {
            shieldIcon.SetActive(false);
        }
    }

    void DamageBasedOnTiers()
    {
        if (PlayerCombat.tierWeapon == 1)
        {
            weaponDamage = Random.Range(2, 4);
        }
        if (PlayerCombat.tierWeapon == 2)
        {
            weaponDamage = Random.Range(5, 8);
        }
        if (PlayerCombat.tierWeapon == 3)
        {
            weaponDamage = Random.Range(10, 12);
        }
        if (PlayerCombat.tierWeapon == 4)
        {
            weaponDamage = Random.Range(18, 21);
        }

        if (PlayerCombat.tierWeapon == 5)
        {
            weaponDamage = Random.Range(25, 27);
        }
        if (PlayerCombat.tierWeapon == 6)
        {
            weaponDamage = Random.Range(30, 34);
        }
        if (PlayerCombat.tierWeapon == 7)
        {
            weaponDamage = Random.Range(35, 40);
        }
        if (PlayerCombat.tierWeapon == 8)
        {
            weaponDamage = Random.Range(50, 60);
        }
    }

    #endregion

    void AIBrain()
    {
        act = false;
        if (!PlayerCombat.playerTurn)
        {
            if (Vector3.Distance(target, transform.position) > 2.5f)
            {
                int chance;
                chance = Random.Range(1, 10);
                if (chance < 7)
                {
                    WalkForward();
                }
                if (chance > 7)
                {
                    WalkBack();
                }
                if (chance == 7)
                {
                    int sleepOrDab;
                    sleepOrDab = Random.Range(1, 5);
                    if (sleepOrDab == 1)
                    {
                        Dab();
                    }
                    else
                    {
                        Sleep();
                    }
                }
            }
             if (Vector3.Distance(target, transform.position) < 2.5f)
             {
                    int chance;
                    chance = Random.Range(1, 20);
                    if (chance < 5)
                    {
                        HeavyDamage();
                    }
                    if (chance < 12 && chance > 4)
                    {
                        MediumDamage();
                    }
                    if (chance > 12)
                    {
                        LightDamage();
                    }
                    if (chance == 12)
                    {
                        WalkBack();
                    }
             }
        }
    }

    #region Enemy Functions
    public void WalkBack()
    {
        if (stamina < WalkCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - WalkCost;
            transform.Rotate(0, 180, 0);
            StartCoroutine(WalkBackAnim());
            anim.SetInteger("State", 1);
        }
    }

    public void WalkForward()
    {
        if (stamina < WalkCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - WalkCost;
            StartCoroutine(WalkForwardAnim());
            anim.SetInteger("State", 1);
        }
    }

    public void LightDamage()
    {
        if (stamina < LightCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - LightCost;
            anim.SetInteger("State", 2);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < lightChance)
                {
                    playerFunction.TakeLightDamage();
                }
                else
                {
                    playerFunction.Block();
                }
            }
            else
            {
                playerFunction.Miss();
            }
            NextTurn();
        }
    }

    public void MediumDamage()
    {
        if (stamina < MediumCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - MediumCost;
            anim.SetInteger("State", 3);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < mediumChance)
                {
                    playerFunction.TakeMediumDamage();
                }
                else
                {
                    playerFunction.Block();
                }
            }
            else
            {
                playerFunction.Miss();
            }
            NextTurn();
        }
    }

    public void HeavyDamage()
    {
        if (stamina < HeavyCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - HeavyCost;
            anim.SetInteger("State", 4);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < heavyChance)
                {
                    playerFunction.TakeHeavyDamage();
                }
                else
                {
                    playerFunction.Block();
                }
            }
            else
            {
                playerFunction.Miss();
            }
            NextTurn();
        }
    }
    
    public void Dab()
    {
        if (stamina < DabCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - DabCost;
            anim.SetInteger("State", 5);
            StartCoroutine(ResetAnim());
        }
    }

    public void Sleep()
    {
        stamina = stamina + SleepCost;
        anim.SetInteger("State", 6);
        StartCoroutine(ResetAnim());
    }

    void NextTurn()
    {
        StartCoroutine(ResetAnim());
    }

    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(0.25f);
        anim.SetInteger("State", 0);
        yield return new WaitForSeconds(0.5f);
        damageUI.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        stamina = stamina + StaminaRegen;
        PlayerCombat.playerTurn = true;
        act = true;
    }

    #endregion

    #region Walk Animation

    IEnumerator WalkForwardAnim()
    {
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.5f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        NextTurn();
    }

    IEnumerator WalkBackAnim()
    {
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.5f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.left * movementSpeed / 25);
        NextTurn();
        yield return new WaitForSeconds(1f);
        transform.Rotate(0, 180, 0);
    }

    #endregion

    #region Damage Taken
    public void Miss()
    {
        damageUI.SetActive(true);
        damageTaken.text = "Miss";
    }

    public void Block()
    {
        damageUI.SetActive(true);
        damageTaken.text = "Block";
    }

    public void TakeLightDamage()
    {
        damageUI.SetActive(true);
        DamageDisplay();
        if (armour > 0)
        {
            armour = armour - playerFunction.lightDamage;
        }
        else
        {
            hp = hp - playerFunction.lightDamage;
        }
        TakesHit();
        damageTaken.text = playerFunction.lightDamage.ToString();
    }

    public void TakeMediumDamage()
    {
        damageUI.SetActive(true);
        DamageDisplay();
        if (armour > 0)
        {
            armour = armour - playerFunction.mediumDamage;
        }
        else
        {
            hp = hp - playerFunction.mediumDamage;
        }
        TakesHit();
        damageTaken.text = playerFunction.mediumDamage.ToString();
    }

    public void TakeHeavyDamage()
    {
        damageUI.SetActive(true);
        DamageDisplay();
        if (armour > 0)
        {
            armour = armour - playerFunction.heavyDamage;
        }
        else
        {
            hp = hp - playerFunction.heavyDamage;
        }
        TakesHit();
        damageTaken.text = playerFunction.heavyDamage.ToString();
    }

    void DamageDisplay()
    {
        if (armour > 0)
        {
            damageLogo.sprite = shield;
        }
        else
        {
            damageLogo.sprite = blood;
        }
    }

    #endregion

    #region sound
    void AttackSound()
    {
       //
    }

    void TakesHit()
    {
        ac.clip = attacks[Random.Range(0, attacks.Length)];
        ac.Play();
    }

    void BlockSound()
    {
       // blocks[Random.Range(0, blocks.Length)].ac.Play();
    }

    #endregion

}