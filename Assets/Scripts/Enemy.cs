using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    public int damage = 25;

    private HealthManager healthManager;

	// Use this for initialization
	void Start () {
        healthManager = GameObject.FindObjectOfType<HealthManager>();
        if (!healthManager)
        {
            Debug.Log(name + " did not find healthManager at start");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack(int damage)
    {
        healthManager.HurtPlayer(damage);
    }


    //TODO DELETE THIS AND USE THROUGH ANIMATION EVENT
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Attack(damage);
        }
    }
}
