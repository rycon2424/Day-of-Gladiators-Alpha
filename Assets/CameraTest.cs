using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    public Transform[] targets;
    public float distance;
    public Vector3 center;

    public float zoomOutDistance;
    public float zoomInDistance;

    public Camera orthographicCamera;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        distance = Vector3.Distance(targets[0].position, targets[1].position);
        //Debug.Log(orthographicCamera.orthographicSize);

        center = ((targets[0].position - targets[1].position) / 2) - targets[0].position;
        center.z = center.z + 10;
        center = center * -1;
        orthographicCamera.transform.position = center;
        if (distance > zoomOutDistance)
        {
            orthographicCamera.orthographicSize = 5 + (distance - zoomOutDistance);
        }
    }
}
