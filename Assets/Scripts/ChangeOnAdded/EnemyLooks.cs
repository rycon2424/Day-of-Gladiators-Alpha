using System.Collections;
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
        bodyE = Random.Range(0, 6);
        helmE = Random.Range(0, 6);
        shoulderE = Random.Range(0, 6);
        gloveE = Random.Range(0, 6);
        legsE = Random.Range(0, 6);
        shoesE = Random.Range(0, 6);

        hairE = Random.Range(0, 20);
        beardE = Random.Range(0, 12);

        if (PlayerCombat.tierWeapon == 1)
        {
            int[] numbers = new int[] { 1, 5, 9 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 2)
        {
            int[] numbers = new int[] { 2, 6, 10 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 3)
        {
            int[] numbers = new int[] { 3, 7, 11 };
            weaponE = numbers[Random.Range(0, numbers.Length)];
        }
        if (PlayerCombat.tierWeapon == 4)
        {
            int[] numbers = new int[] { 4, 8, 12 };
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
