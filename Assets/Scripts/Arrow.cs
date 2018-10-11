using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    
    public SpriteRenderer skin;
    public Sprite[] skins = new Sprite[9];

    public float speed;

	void Start ()
    {
       skin.sprite = skins[PlayerLooks.bow];
	}
	
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}
