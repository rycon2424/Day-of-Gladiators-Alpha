using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayer : MonoBehaviour {
    
    public SpriteRenderer skin;
    public Sprite[] skins = new Sprite[9];

    public float speed;

    public Transform targetTransform;
    public Vector3 target;
    public EnemyCombat enemyFunction;
    public PlayerCombat playerFunction;

    void Start ()
    {
       enemyFunction = GameObject.Find("EnemyCombat").GetComponent<EnemyCombat>();
        playerFunction = GameObject.Find("PlayerCombat").GetComponent<PlayerCombat>();
        targetTransform = GameObject.Find("EnemyCombat").transform;
       skin.sprite = skins[PlayerLooks.bow];
	}
	
	void Update ()
    {
        target = targetTransform.transform.position;
        if (Vector3.Distance(target, transform.position) < 1f)
        {
           int chance;
           chance = Random.Range(1, 100);
           if (chance < playerFunction.lightChance)
           {
                enemyFunction.TakeLightDamageRanged();
           }
           else
           {
                enemyFunction.Miss();
           }
           playerFunction.CallReset();
           Destroy(this.gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}
