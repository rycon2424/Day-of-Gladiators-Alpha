using UnityEngine;
using System.Collections;

public class LeftOrRight : MonoBehaviour {

	public Transform target;
	public float dirNum;
    public static bool left;

    private void Start()
    {

    }

    void Update () {
		Vector3 heading = target.position - transform.position;
		dirNum = AngleDir(transform.forward, heading, transform.up);
	}
	
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
            left = true;
            return 1f;
		} else if (dir < 0f) {
            left = false;
            return -1f;
		} else {
			return 0f;
		}
	}
	
}
