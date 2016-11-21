using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offsetPosition;
    [SerializeField]
    private bool orthographicMode = false;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (orthographicMode)
        {
            camera.orthographic = true;
        }
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);
            return;
        }

        // compute position
        transform.position = target.position + offsetPosition;
    }
}
