using UnityEngine;
using System.Collections;

public class IcePusher : MonoBehaviour {
    private bool spawnPushers = false;

    public GameObject pushPrefab;
    public GameObject pushSpawner;

    void Update()
    {
        if(spawnPushers)
        {
            Instantiate(pushPrefab, pushSpawner.transform);
        }
    }

	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spawnPushers = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spawnPushers = false;
        }
    }
}
