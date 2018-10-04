using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoEndStats : MonoBehaviour {

    public Text STR;
    public Text END;
    public Text DEX;
    public Text VIT;
    public Text LUCK;
    public Text MAG;

   
	// Update is called once per frame
	void Update ()
    {
        STR.text = CharacterCreation.STR.ToString();
        END.text = CharacterCreation.END.ToString();
        DEX.text = CharacterCreation.DEX.ToString();
        VIT.text = CharacterCreation.LUC.ToString();
        LUCK.text = CharacterCreation.LUC.ToString();
        MAG.text = CharacterCreation.CHAR.ToString();
    }
}
