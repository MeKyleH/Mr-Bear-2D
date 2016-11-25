using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private PlayerSpawner spawner;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            spawner.reachedCheckpoint = true;
            boxCollider.enabled = false;
        }
    }
}
