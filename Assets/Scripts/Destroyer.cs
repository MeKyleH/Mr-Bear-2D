using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    private PlayerSpawner spawner;
    private LivesManager livesManager;

    void Start()
    {
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
        if (!spawner)
        {
            Debug.Log(name + " did not find spawner at start");
        }
        livesManager = GameObject.FindObjectOfType<LivesManager>();
        if (!livesManager)
        {
            Debug.Log(name + " did not find livesManager at start");
        }

    }
	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            livesManager.LoseLife();
            spawner.SpawnPlayer();
        }
            Destroy(collider.gameObject);
    }
}
