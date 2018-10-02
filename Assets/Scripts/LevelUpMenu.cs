using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour {

    public int pointsToSpend;
    public Text pointsToSpendT;

    public Text strengthText;
    public Text enduranceText;
    public Text dexterityText;
    public Text vitalityText;
    public Text luckText;
    public Text magickaText;

	void Start ()
    {

    }
	
	void Update ()
    {
        pointsToSpendT.text = pointsToSpend.ToString();

        strengthText.text = CharacterCreation.STR.ToString();
        enduranceText.text = CharacterCreation.END.ToString();
        dexterityText.text = CharacterCreation.DEX.ToString();
        vitalityText.text = CharacterCreation.VIT.ToString();
        luckText.text = CharacterCreation.LUC.ToString();
        magickaText.text = CharacterCreation.CHAR.ToString();
    }

    public void STR()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.STR = CharacterCreation.STR + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

    public void END()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.END = CharacterCreation.END + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

    public void DEX()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.DEX = CharacterCreation.DEX + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

    public void VIT()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.VIT = CharacterCreation.VIT + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

    public void LUCK()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.LUC = CharacterCreation.LUC + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

    public void MAG()
    {
        if (pointsToSpend > 0)
        {
            CharacterCreation.CHAR = CharacterCreation.CHAR + 1;
            pointsToSpend = pointsToSpend - 1;
        }
    }

}
