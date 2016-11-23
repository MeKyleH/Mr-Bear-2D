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
        Debug.Log(" entered the checkpoint");
        if(collider.gameObject.tag == "Player")
        {
            spawner.reachedCheckpoint = true;
            boxCollider.enabled = false;
        }
    }
}
