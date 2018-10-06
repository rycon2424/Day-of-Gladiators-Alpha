using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alleyway : MonoBehaviour {

    public Text info;
    public GameObject Canvas;
    public GameObject villageCamera;
    public GameObject glow;
    
	void Start ()
    {
        Canvas.SetActive(false);
        glow.SetActive(false);
    }
    
    void OnMouseOver()
    {
        glow.SetActive(true);
        if (!ShopOpener.inShop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                villageCamera.SetActive(false);
                Canvas.SetActive(true);
                info.text = "Nothing here maybe I should return later.";
            }
        }
    }

    void OnMouseExit()
    {
        glow.SetActive(false);
    }

    public void ReturntoVillage()
    {
        Canvas.SetActive(false);
        villageCamera.SetActive(true);
    }

}
