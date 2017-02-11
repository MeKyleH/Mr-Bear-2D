using UnityEngine;

public class HealthPickup : MonoBehaviour {
    [SerializeField]
    private int healAmount = 25;

    private PlayerHealthManager playerHealth;

	void Start () {
        playerHealth = GameObject.FindObjectOfType<PlayerHealthManager>();
        if(!playerHealth)
        {
            Debug.Log(name + " couldn't find PlayerHealthManager");
        }
	}

    void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0f, 1f, 0f));
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
           playerHealth.HealPlayer(healAmount);
           Destroy(gameObject);
        }
    }
}
