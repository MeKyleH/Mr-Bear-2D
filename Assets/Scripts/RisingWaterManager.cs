using UnityEngine;
using System.Collections;

public class RisingWaterManager : MonoBehaviour {
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private Vector3 riseDirection;
    [SerializeField]
    private float riseSpeed;

    private Rigidbody waterRigidBody;
    private bool isWaterRising;

    void Start()
    {
        waterRigidBody = water.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(isWaterRising)
        {
            waterRigidBody.velocity = riseDirection.normalized * riseSpeed;
        }
    }

    public void TriggerWaterRising(bool isWaterRising)
    {
        this.isWaterRising = isWaterRising;
        if (!isWaterRising)
        {
            waterRigidBody.velocity = new Vector3(0, 0, 0);
        }
    }
}
