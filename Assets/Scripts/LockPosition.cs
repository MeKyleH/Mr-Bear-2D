using UnityEngine;
using System.Collections;

public class LockPosition : MonoBehaviour {
    [SerializeField]
    private float zLockPos = 0.0f;

	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        newPosition.z = zLockPos;
        transform.position = newPosition;
	}
}
