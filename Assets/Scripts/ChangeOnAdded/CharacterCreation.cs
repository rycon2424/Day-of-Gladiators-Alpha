using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour {

    [Header("Name")]
    public InputField usernameInput;
    public static string username;
    [Header("HairStyle")]
    public SpriteRenderer currentHair;
    public Sprite[] hairs = new Sprite[5];
    public int whatHair;
    public static int hairNumberGlobal;
    [Header("Beards")]
    public SpriteRenderer currentBeard;
    public Sprite[] beards = new Sprite[5];
    public int whatBeard;
    public static int beardNumberGlobal;
    [Header("Skills")]
    public int availableSkillpoints;
    public int strenght;
    public static int STR;
    public int endurance;
    public static int END;
    public int dexterity;
    public static int DEX;
    public int vitality;
    public static int VIT;
    public int luck;
    public static int LUC;
    public int charisma;
    public static int CHAR;
    [Header("SkillsText")]
    public Text availableSkillpointsT;
    public Text strenghtT;
    public Text enduranceT;
    public Text dexterityT;
    public Text vitalityT;
    public Text luckT;
    public Text charismaT;

    void Start ()
    {
        availableSkillpoints = 10;
    }
	
	void Update ()
    {
        hairNumberGlobal = whatHair;
        beardNumberGlobal = whatBeard;

        availableSkillpointsT.text = availableSkillpoints.ToString();
        strenghtT.text = strenght.ToString();
        enduranceT.text = endurance.ToString();
        dexterityT.text = dexterity.ToString();
        vitalityT.text = vitality.ToString();
        luckT.text = luck.ToString();
        charismaT.text = charisma.ToString();
    }

    public void Done()
    {
        STR = strenght;
        END = endurance;
        DEX = dexterity;
        VIT = vitality;
        LUC = luck;
        CHAR = charisma;
        if (usernameInput.text == "")
        {
            username = "nonameretard";
        }
        else
        {
            username = usernameInput.text;
        }
        SceneManager.LoadScene("Village");
    }

    #region Style

    public void HairNext()
    {
        if (whatHair == hairs.Length - 1)
        {
            whatHair = 0;
            currentHair.sprite = hairs[whatHair];
            return;
        }
        whatHair = whatHair + 1;
        currentHair.sprite = hairs[whatHair];
    }

    public void HairPrev()
    {
        if (whatHair == 0)
        {
            whatHair = hairs.Length - 1;
            currentHair.sprite = hairs[whatHair];
            return;
        }
        whatHair = whatHair - 1;
        currentHair.sprite = hairs[whatHair];
    }

    public void BeardNext()
    {
        if (whatBeard == beards.Length - 1)
        {
            whatBeard = 0;
            currentBeard.sprite = beards[whatBeard];
            return;
        }
        whatBeard = whatBeard + 1;
        currentBeard.sprite = beards[whatBeard];
    }

    public void BeardPrev()
    {
        if (whatBeard == 0)
        {
            whatBeard = beards.Length - 1;
            currentBeard.sprite = beards[whatBeard];
            return;
        }
        whatBeard = whatBeard - 1;
        currentBeard.sprite = beards[whatBeard];
    }

    #endregion

    #region points;
    public void StrengthAdd()
    {
        if (availableSkillpoints > 0)
        {
            strenght = strenght + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void StrengthSub()
    {
        if (strenght > 1)
        {
            strenght = strenght - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    public void EnduranceAdd()
    {
        if (availableSkillpoints > 0)
        {
            endurance = endurance + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void EnduranceSub()
    {
        if (endurance > 1)
        {
            endurance = endurance - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    public void DexAdd()
    {
        if (availableSkillpoints > 0)
        {
            dexterity = dexterity + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void DexSub()
    {
        if (dexterity > 1)
        {
            dexterity = dexterity - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    public void VitAdd()
    {
        if (availableSkillpoints > 0)
        {
            vitality = vitality + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void VitSub()
    {
        if (vitality > 1)
        {
            vitality = vitality - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    public void LuckAdd()
    {
        if (availableSkillpoints > 0)
        {
            luck = luck + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void LuckSub()
    {
        if (luck > 1)
        {
            luck = luck - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    public void CharAdd()
    {
        if (availableSkillpoints > 0)
        {
            charisma = charisma + 1;
            availableSkillpoints = availableSkillpoints - 1;
        }
        else
        {
            return;
        }
    }
    public void CharSub()
    {
        if (charisma > 1)
        {
            charisma = charisma - 1;
            availableSkillpoints = availableSkillpoints + 1;
        }
        else
        {
            return;
        }
    }

    #endregion

}
