﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLooks : MonoBehaviour {

    [Header("Special")]
    public bool specialEnemy;

    [Header("HairStyle")]
    public SpriteRenderer currentHair;
    public Sprite[] hairs = new Sprite[5];

    [Header("Beards")]
    public SpriteRenderer currentBeard;
    public Sprite[] beards = new Sprite[5];

    [Header("SpriteRendererWeapons")]
    public SpriteRenderer firstWeapon;
    public SpriteRenderer secondWeapon;

    [Header("Helm")]
    public Sprite[] helms = new Sprite[5];
    [Header("Body")]
    public Sprite[] bodyarmours = new Sprite[5];
    [Header("Shoulders")]
    public Sprite[] shoulders1 = new Sprite[5];
    public Sprite[] shoulders2 = new Sprite[5];
    [Header("Gloves")]
    public Sprite[] gloves1 = new Sprite[5];
    public Sprite[] gloves2 = new Sprite[5];
    [Header("Legs")]
    public Sprite[] legs1 = new Sprite[5];
    public Sprite[] legs2 = new Sprite[5];
    [Header("Shoes")]
    public Sprite[] shoes1 = new Sprite[5];
    public Sprite[] shoes2 = new Sprite[5];

    [Header("BossSpecific")]
    public Sprite[] BossWeapons = new Sprite[1];
    public Sprite[] Boss1 = new Sprite[9];

    [Header("Armours")]
    public SpriteRenderer helm;
    public SpriteRenderer body;
    public SpriteRenderer shoulderLeft;
    public SpriteRenderer shoulderRight;
    public SpriteRenderer gloveLeft;
    public SpriteRenderer gloveRight;
    public SpriteRenderer legLeft;
    public SpriteRenderer legRight;
    public SpriteRenderer shoeLeft;
    public SpriteRenderer shoeRight;

    [Header("Weapons")]
    public Sprite[] weapons = new Sprite[17];
    public Sprite[] shields = new Sprite[7];

    public static int shieldE;
    public static int shoulderE;
    public static int gloveE;
    public static int legsE;
    public static int shoesE;
    public static int helmE;
    public static int bodyE;

    public static int weaponE;
    public static int hairE;
    public static int beardE;

    void Start()
    {
        if (BeforeTheFight.isTournament)
        {
            specialEnemy = true;
        }
        else
        {
            specialEnemy = false;
        }
        if (!specialEnemy)
        {
            CasualEnemy();
        }
    }

    void CasualEnemy()
    {
        bodyE = Random.Range(0, bodyarmours.Length);
        helmE = Random.Range(0, helms.Length);
        shoulderE = Random.Range(0, shoulders1.Length);
        gloveE = Random.Range(0, gloves1.Length);
        legsE = Random.Range(0, legs1.Length);
        shoesE = Random.Range(0, shoes1.Length);
        shieldE = Random.Range(0, shields.Length);

        hairE = Random.Range(0, hairs.Length);
        beardE = Random.Range(0, beards.Length);

        if (PlayerCombat.tierWeapon == 1 || PlayerCombat.tierWeapon == 0)
        {
            int[] numbers = new int[] { 1,5,9 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 2)
        {
            int[] numbers = new int[] { 13, 17, 21 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 3)
        {
            int[] numbers = new int[] { 14, 6, 10 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 4)
        {
            int[] numbers = new int[] { 2, 7, 23 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 5)
        {
            int[] numbers = new int[] { 3, 18, 24 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 6)
        {
            int[] numbers = new int[] { 4, 8, 11 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 7)
        {
            int[] numbers = new int[] { 15, 19, 12 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 8)
        {
            int[] numbers = new int[] { 16, 20, 22 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
    }

    void Update()
    {
        if (!specialEnemy)
        {
            firstWeapon.sprite = weapons[weaponE];

            helm.sprite = helms[helmE];
            body.sprite = bodyarmours[bodyE];

            shoulderLeft.sprite = shoulders1[shoulderE];
            shoulderRight.sprite = shoulders2[shoulderE];
            gloveLeft.sprite = gloves1[gloveE];
            gloveRight.sprite = gloves2[gloveE];
            legLeft.sprite = legs1[legsE];
            legRight.sprite = legs2[legsE];
            shoeLeft.sprite = shoes1[shoesE];
            shoeRight.sprite = shoes2[shoesE];
            secondWeapon.sprite = shields[shieldE];

            currentHair.sprite = hairs[hairE];
            currentBeard.sprite = beards[beardE];
        }
        if (specialEnemy)
        {
            firstWeapon.sprite = BossWeapons[0];

            helm.sprite = Boss1[0];
            body.sprite = Boss1[1];

            shoulderLeft.sprite = Boss1[2];
            shoulderRight.sprite = Boss1[3];
            gloveLeft.sprite = Boss1[4];
            gloveRight.sprite = Boss1[5];
            legLeft.sprite = Boss1[6];
            legRight.sprite = Boss1[7];
            shoeLeft.sprite = Boss1[8];
            shoeRight.sprite = Boss1[9];

            currentHair.sprite = hairs[0];
            currentBeard.sprite = beards[0];
        }
    }
}
