using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooks : MonoBehaviour {

    [Header("HairStyle")]
    public SpriteRenderer currentHair;
    public Sprite[] hairs = new Sprite[5];
    public int whatHair;

    [Header("Beards")]
    public SpriteRenderer currentBeard;
    public Sprite[] beards = new Sprite[5];
    public int whatBeard;

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
    public Sprite[] bows = new Sprite[4];
    public static bool useBow;
    public static int weapon;
    public static int bow;

    public static int helmNumber;
    public static int bodyNumber;
    public static int shouldersNumber;
    public static int glovesNumber;
    public static int legsNumber;
    public static int shoesNumber;
    public static int shieldNumber;

    void Start ()
    {
        Looks();
    }
	
	void Update ()
    {
        if (useBow)
        {
            firstWeapon.sprite = bows[bow];
        }
        if (!useBow)
        {
            firstWeapon.sprite = weapons[weapon];
        }
        secondWeapon.sprite = shields[shieldNumber];
        helm.sprite = helms[helmNumber];
        body.sprite = bodyarmours[bodyNumber];
        shoulderLeft.sprite = shoulders1[shouldersNumber];
        shoulderRight.sprite = shoulders2[shouldersNumber];
        gloveLeft.sprite = gloves1[glovesNumber];
        gloveRight.sprite = gloves2[glovesNumber];
        legLeft.sprite = legs1[legsNumber];
        legRight.sprite = legs2[legsNumber];
        shoeLeft.sprite = shoes1[shoesNumber];
        shoeRight.sprite = shoes2[shoesNumber];
    }

    void Looks()
    {
        whatBeard = CharacterCreation.beardNumberGlobal;
        whatHair = CharacterCreation.hairNumberGlobal;

        currentHair.sprite = hairs[whatHair];
        currentBeard.sprite = beards[whatBeard];
    }
}