using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDescription : MonoBehaviour {


    public GameObject stats;


    void OnMouseOver()
    {
        stats.SetActive(true);
    }

    void OnMouseExit()
    {
        stats.SetActive(false);
    }
}
