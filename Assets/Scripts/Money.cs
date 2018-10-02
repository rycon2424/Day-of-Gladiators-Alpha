using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public static int coin = 1300;
    public Text coinDisplay;
    public int startingMoney;
    
	void Start ()
    {

	}
	
	void Update ()
    {
        coinDisplay.text = coin.ToString();

        if (Input.GetKey(KeyCode.L))
        {
            coin = coin + 250;
        }

        if (coin < 0)
        {
            coin = 0;
        }
	}

}
