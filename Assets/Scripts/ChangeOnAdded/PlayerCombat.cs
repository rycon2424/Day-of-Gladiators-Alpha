using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : StatsBehaviour {
    
    [Header("Random")]
    public static bool playerTurn;
    public Animator anim;
    public static int tierWeapon;
    public static int tierRanged;
    public Transform arrowShot;

    [Header("Buttons")]
    public GameObject buttons;
    public GameObject walkBackButton;
    public GameObject walkForwardButton;
    public GameObject displayChance;
    public GameObject swapWeapon;
    public GameObject melee, ranged;

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
    public Text arrowsText;
    public int arrows;
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
    private int maxArmourInt;
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

    public static int helmArmour;
    public static int bodyArmour;
    public static int shoulderArmour;
    public static int glovesArmour;
    public static int legsArmour;
    public static int shoesArmour;
    public static int shieldArmour;

    public float backWalkClamp;

    public EnemyCombat enemyFunction;

    void Start ()
    {
        damageUI.SetActive(false);

        playerTurn = true;

        #region Stats Calculation
        hp = baseHp + (15 * CharacterCreation.VIT);
        stamina = baseStamina + (10 * CharacterCreation.END);
        movementSpeed = baseSpeed + (0.4f * CharacterCreation.DEX);
        magicDamage = baseMgcDamage + (10 * CharacterCreation.CHAR);
        
        DamageBasedOnTiers();

        #region Damage
        lightDamage = baseDamage + (1 * CharacterCreation.STR) + weaponDamage;
        mediumDamage = baseDamage + (3 * CharacterCreation.STR) + weaponDamage;
        heavyDamage = baseDamage + (7 * CharacterCreation.STR) + weaponDamage;
        #endregion

        armour = helmArmour + bodyArmour + shoulderArmour + glovesArmour + legsArmour + shoesArmour + shieldArmour;

        #endregion

        #region Set Strings & Max Values
        maxHP.text = hp.ToString();
        maxStamina.text = stamina.ToString();

        maxHealthInt = hp;
        maxArmourInt = armour;
        maxStaminaInt = stamina;

        maxArmour.text = maxArmourInt.ToString();
        maxHPB.text = hp.ToString();
        maxStaminaB.text = stamina.ToString();
        strengthText.text = CharacterCreation.STR.ToString();

        if (armour < 1)
        {
            shieldIcon.SetActive(false);
        }

        #endregion

        #region LuckChance
        lightChance = 70 + CharacterCreation.LUC - 1;
        mediumChance = 50 + CharacterCreation.LUC - 1;
        heavyChance = 30 + CharacterCreation.LUC - 1;
        #endregion

    }

    private void Update()
    {
        if (hp < 1)
        {
            int chance;
            chance = Random.Range(100, 105);
            anim.SetInteger("State", chance);
        }
        target = enemy.transform.position;
        UIinfo();
        ArmourCalc();
        HealthControl();
        StaminaControl();
        arrowsText.text = "Arrows: " + arrows.ToString();
        if (PlayerLooks.bow == 0)
        {
            swapWeapon.SetActive(false);
        }
        if (PlayerLooks.useBow)
        {
            melee.SetActive(false);
            ranged.SetActive(true);
        }
        if (!PlayerLooks.useBow)
        {
            melee.SetActive(true);
            ranged.SetActive(false);
        }
        if (transform.position.x < backWalkClamp)
        {
            walkBackButton.SetActive(false);
        }
        else
        {
            walkBackButton.SetActive(true);
        }
        if (Vector3.Distance(target, transform.position) < 2.5f)
        {
            walkForwardButton.SetActive(false);
        }
        else
        {
            walkForwardButton.SetActive(true);
        }
    }

    #region  Health Stamina Ui Armour Damage Misc.
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

    void DamageBasedOnTiers()
    {
        if (tierWeapon == 1)
        {
            weaponDamage = 2;
        }
        if (tierWeapon == 2)
        {
            weaponDamage = 5;
        }
        if (tierWeapon == 3)
        {
            weaponDamage = 10;
        }
        if (tierWeapon == 4)
        {
            weaponDamage = 18;
        }

        if (tierWeapon == 5)
        {
            weaponDamage = 25;
        }
        if (tierWeapon == 6)
        {
            weaponDamage = 30;
        }
        if (tierWeapon == 7)
        {
            weaponDamage = 35;
        }
        if (tierWeapon == 8)
        {
            weaponDamage = 50;
        }
        if (tierRanged == 1)
        {
            arrowDamageLight = 2 + Mathf.RoundToInt(1.5f * CharacterCreation.DEX);
        }
        if (tierRanged == 2)
        {
            arrowDamageLight = 3 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 3)
        {
            arrowDamageLight = 5 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 4)
        {
            arrowDamageLight = 7 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 5)
        {
            arrowDamageLight = 9 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 6)
        {
            arrowDamageLight = 12 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 7)
        {
            arrowDamageLight = 15 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
        if (tierRanged == 8)
        {
            arrowDamageLight = 20 + Mathf.RoundToInt(1.3f * CharacterCreation.DEX);
        }
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
    #endregion

    #region Button Functions
    public void WalkBack()
    {
        if (stamina < WalkCost)
        {
            Sleep();
        }
        else
        {
            stamina = stamina - WalkCost;
            buttons.SetActive(false);
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
            buttons.SetActive(false);
            StartCoroutine(WalkForwardAnim());
            anim.SetInteger("State", 1);
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
            buttons.SetActive(false);
            anim.SetInteger("State", 5);
            StartCoroutine(Resetturn());
        }
    }

    public void Swap()
    {
        buttons.SetActive(false);
        PlayerLooks.useBow = !PlayerLooks.useBow;
        anim.SetInteger("State", 8);
        StartCoroutine(Resetturn());
    }

    public void Sleep ()
    {
        stamina = stamina + SleepCost;
        buttons.SetActive(false);
        anim.SetInteger("State", 6);
        StartCoroutine(Resetturn());
    }

    #region Ranged

    public void LightShot()
    {
        if (arrows == 0)
        {
            swapWeapon.SetActive(false);
            Swap();
            return;
        }
        if (stamina < lightShotCost)
        {
            Sleep();
            return;
        }
        arrows = arrows - 1;
        stamina = stamina - lightShotCost;
        StartCoroutine(ShootAnimLight());
        buttons.SetActive(false);
    }
    
    IEnumerator ShootAnimLight()
    {
        anim.SetInteger("State", 9);
        yield return new WaitForSeconds(0.4f);
        Instantiate(arrowShot, new Vector3(transform.position.x, -0.8f, transform.position.z), transform.rotation);
    }

    #endregion

    #region Melee Attacks
    public void LightDamage()
    {
        if (stamina < LightCost)
        {
            Sleep();
        }
        else
        {
            DemoEndStats.lightCounter++;
            stamina = stamina - LightCost;
            buttons.SetActive(false);
            anim.SetInteger("State", 2);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < lightChance)
                {
                    enemyFunction.TakeLightDamage();
                }
                else
                {
                    enemyFunction.Block();
                }
            }
            else
            {
                enemyFunction.Miss();
            }
            StartCoroutine(Resetturn());
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
            DemoEndStats.mediumCounter++;
            stamina = stamina - MediumCost;
            buttons.SetActive(false);
            anim.SetInteger("State", 3);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < mediumChance)
                {
                    enemyFunction.TakeMediumDamage();
                }
                else
                {
                    enemyFunction.Block();
                }
            }
            else
            {
                enemyFunction.Miss();
            }
            StartCoroutine(Resetturn());
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
            DemoEndStats.heavyCounter++;
            stamina = stamina - HeavyCost;
            buttons.SetActive(false);
            anim.SetInteger("State", 4);
            if (Vector3.Distance(target, transform.position) < 2.5f)
            {
                int chance;
                chance = Random.Range(1, 100);
                if (chance < heavyChance)
                {
                    enemyFunction.TakeHeavyDamage();
                }
                else
                {
                    enemyFunction.Block();
                }
            }
            else
            {
                enemyFunction.Miss();
            }
            StartCoroutine(Resetturn());
        }
    }
    #endregion

    #endregion

    #region Turn and Button Misc.

    public void CallReset()
    {
        StartCoroutine(Resetturn());
    }

    IEnumerator Resetturn()
    {
        StartCoroutine(ButtonVis());
        displayChance.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        anim.SetInteger("State", 0);
        yield return new WaitForSeconds(0.25f);
        playerTurn = false;
    }

    IEnumerator ButtonVis()
    {
        yield return new WaitForSeconds(1.5f);
        damageUI.SetActive(false);
        stamina = stamina + StaminaRegen;
        buttons.SetActive(true);
    }
    #endregion

    #region Walk Animation
    IEnumerator WalkForwardAnim()
    {
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.5f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        StartCoroutine(Resetturn());
    }

    IEnumerator WalkBackAnim()
    {
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.5f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        yield return new WaitForSeconds(0.01f);
        transform.Translate(Vector2.right * movementSpeed / 25);
        StartCoroutine(Resetturn());
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
            armour = armour - enemyFunction.lightDamage;
        }
        else
        {
            hp = hp - enemyFunction.lightDamage;
        }
        TakesHit();
        damageTaken.text = enemyFunction.lightDamage.ToString();
    }

    public void TakeMediumDamage()
    {
        damageUI.SetActive(true);
        DamageDisplay();
        if (armour > 0)
        {
            armour = armour - enemyFunction.mediumDamage;
        }
        else
        {
            hp = hp - enemyFunction.mediumDamage;
        }
        TakesHit();
        damageTaken.text = enemyFunction.mediumDamage.ToString();
    }

    public void TakeHeavyDamage()
    {
        damageUI.SetActive(true);
        DamageDisplay();
        if (armour > 0)
        {
            armour = armour - enemyFunction.heavyDamage;
        }
        else
        {
            hp = hp - enemyFunction.heavyDamage;
        }
        TakesHit();
        damageTaken.text = enemyFunction.heavyDamage.ToString();
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
       // blocks[Random.Range(0, blocks.Length)].Play();
    }

    #endregion

}