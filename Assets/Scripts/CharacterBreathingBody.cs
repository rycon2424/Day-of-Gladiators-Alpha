using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBreathingBody : MonoBehaviour {

    public float speed;
    public float lowest;
    public float highest;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate (Vector2.up * speed); 

        if (transform.localPosition.y < lowest)
        {
            speed = speed * -1;
        }

        if (transform.localPosition.y > highest)
        {
            speed = speed * -1;
        }
    }
}
