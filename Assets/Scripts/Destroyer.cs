using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	
	void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("You died");
            //TODO: REMOVE A LIFE
            //TODO: RESPAWN AT SPAWN POINT
        }

        Destroy(collider.gameObject);
        
    }
	
}
