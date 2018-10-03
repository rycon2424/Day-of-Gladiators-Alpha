using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfter : MonoBehaviour {

    public bool tournament;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        BeforeTheFight.isTournament = tournament;
	}

}
