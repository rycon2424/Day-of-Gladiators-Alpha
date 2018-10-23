using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsSingleton : MonoBehaviour {

    public static int level;

    private static PlayerStatsSingleton instance = null;
    public static PlayerStatsSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
} 