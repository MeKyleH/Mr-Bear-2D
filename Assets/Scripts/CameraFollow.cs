using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Vector3 offsetPosition;
    [SerializeField]
    private bool orthographicMode = false;


    private Transform player;
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
        if (player == null)
        {
            SpawnCamera();
            return;
        }
        // compute position
        transform.position = Vector3.Lerp(camera.transform.position,player.position + offsetPosition, 2.5f*Time.deltaTime);
    }

    public void SpawnCamera()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
