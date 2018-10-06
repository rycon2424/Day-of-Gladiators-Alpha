using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextList : MonoBehaviour {

    public GameObject[] itemLists = new GameObject[3];
    public int currentList = 0;

    public GameObject forward, back;

    private void Start()
    {
        itemLists[currentList].SetActive(true);
    }

    private void Update()
    {
        if (currentList == itemLists.Length - 1)
        {
            forward.SetActive(false);
        }
        else
        {
            forward.SetActive(true);
        }

        if (currentList == 0)
        {
            back.SetActive(false);
        }
        else
        {
            back.SetActive(true);
        }
    }

    public void BackToListOne()
    {
        itemLists[currentList].SetActive(false);
        currentList = 0;
        itemLists[currentList].SetActive(true);
    }

    public void Next()
    {
        itemLists[currentList].SetActive(false);
        currentList++;
        itemLists[currentList].SetActive(true);
    }

    public void Back()
    {
        currentList--;
        itemLists[currentList + 1].SetActive(false);
        itemLists[currentList].SetActive(true);
    }

}
