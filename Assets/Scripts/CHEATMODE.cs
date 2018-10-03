using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHEATMODE : MonoBehaviour {

	
	void Update ()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Money.coin = Money.coin + 250;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerStatsSingleton.level = PlayerStatsSingleton.level + 1;
        }
    }
}
