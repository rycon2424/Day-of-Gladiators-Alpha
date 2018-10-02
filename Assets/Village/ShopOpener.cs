using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpener : MonoBehaviour {

    public GameObject glow;
    public GameObject shopUI;
    public static bool inShop;

    private void Start()
    {
        inShop = false;
        glow.SetActive(false);
        shopUI.SetActive(false);
    }

    void OnMouseOver()
    {
        glow.SetActive(true);
        if (!inShop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shopUI.SetActive(true);
                inShop = true;
            }
        }
    }

    void OnMouseExit()
    {
        glow.SetActive(false);
    }

    public void ShopCloser()
    {
        inShop = false;
        shopUI.SetActive(false);
    }
}
