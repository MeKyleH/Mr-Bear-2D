using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour
{
    private PlayerHealthManager playerHealthManager;

    public int strength = 25;

    // Use this for initialization
    void Start()
    {
        playerHealthManager = GameObject.FindObjectOfType<PlayerHealthManager>();
        if (!playerHealthManager)
        {
            Debug.Log(name + " did not find healthManager at start");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //damage player 
            Debug.Log("PLAYER TOOK DAMAGE FROM " + name);
            playerHealthManager.TakeDamage(strength);

            // knock the player back
            Rigidbody playerRB = collider.GetComponent<Rigidbody>();
            Vector3 playerBlowbackForce = (collider.transform.up * 400) - (collider.transform.forward * 700);
            Debug.DrawRay(new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y, collider.gameObject.transform.position.z), playerBlowbackForce, Color.green);
            playerRB.AddRelativeForce(playerBlowbackForce);
        }
    }
}
