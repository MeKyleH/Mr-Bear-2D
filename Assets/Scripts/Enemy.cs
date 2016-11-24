using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    public int damage = 25;

    private PlayerHealthManager playerHealthManager;

	// Use this for initialization
	void Start () {
        playerHealthManager = GameObject.FindObjectOfType<PlayerHealthManager>();
        if (!playerHealthManager)
        {
            Debug.Log(name + " did not find healthManager at start");
        }
    }

    public void Attack(int damage)
    {
        playerHealthManager.TakeDamage(damage);
    }


    //TODO DELETE THIS AND USE THROUGH ANIMATION EVENT
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("deadling damage");
            playerHealthManager.TakeDamage(damage);
        }
    }
}
