using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class MainCamera : MonoBehaviour
{

    public Camera orthographicCamera;
    public Transform target1;
    public Transform target2;

    public float distance;

    void Start()
    {

    }

    void Update()
    {
        distance = Vector3.Distance(target1.position, target2.position);
        if (distance < 12.001f)
        {
            float exp;
            exp = (distance / 100 + 1.1f);
            orthographicCamera.orthographicSize = (4f * (exp));
        }
        else
        {
            float expMin = (1 + distance / 100);
            orthographicCamera.orthographicSize = (4.4f * (expMin));
        }
    }

}
