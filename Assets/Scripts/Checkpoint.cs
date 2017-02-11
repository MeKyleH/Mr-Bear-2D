using UnityEngine;

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
            PlayerPrefsManager.ReachCheckPoint(spawner.getLevelNum());
            boxCollider.enabled = false;
        }
    }
}
