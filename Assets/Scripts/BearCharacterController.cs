using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class BearCharacterController : MonoBehaviour {
    private Vector3 startScale;

    void Start()
    {
        startScale = gameObject.transform.localScale;
    }


    // TODO: ADD AN ICE, MUD, AND SPRINGY OPTION FOR PLATFORMS
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
