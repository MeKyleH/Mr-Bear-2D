using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    private PlayerSpawner spawner;

    void Start()
    {
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
        if (!spawner)
        {
            Debug.Log(name + " did not find spawner at start");
        }

    }
	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //TODO: REMOVE A LIFE
            spawner.SpawnPlayer();
        }
            Destroy(collider.gameObject);
    }
}
