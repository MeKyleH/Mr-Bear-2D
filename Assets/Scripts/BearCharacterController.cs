using UnityEngine;
using System.Collections;

public class BearCharacterController : MonoBehaviour {
    private Vector3 startScale;

    void Start()
    {
        startScale = gameObject.transform.localScale;
    }

	void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.parent = collider.transform;
            gameObject.transform.localScale = startScale;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.parent = null;
            gameObject.transform.localScale = startScale;
        }
    }
}
