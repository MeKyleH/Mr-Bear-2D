using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offsetPosition;

    public void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

        // compute position
        transform.position = target.position + offsetPosition;
        

        // compute rotation
         //transform.rotation = offsetRotation;
    }
}
