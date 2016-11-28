using UnityEngine;
using System.Collections;

public class RisingWater : MonoBehaviour {
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private Vector3 riseDirection;
    [SerializeField]
    private float riseSpeed;
    [SerializeField]
    private bool onSwitch = true;
    private static bool waterRise = false;
    private Rigidbody waterRigidBody;

    void Start()
    {
        waterRigidBody = water.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(waterRise)
        {
            Debug.Log("Raising water");
            waterRigidBody.velocity = riseDirection.normalized * riseSpeed;
        }
        else
        {
            Debug.Log("Water Staying");
            waterRigidBody.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            waterRise = onSwitch;
            Debug.Log("water is rising: " +waterRise);
        }
    }
}
