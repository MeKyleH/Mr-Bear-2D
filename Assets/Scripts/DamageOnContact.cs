using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour
{
    private PlayerHealthManager playerHealthManager;
    private bool isRecoiling = false;

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

    void Update()
    {
        //prevent taking damage multiple times
        if (isRecoiling)
        {
            isRecoiling = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !isRecoiling)
        {
            //damage player and knock the player back
            playerHealthManager.TakeDamage(strength);

            Vector3 playerBlowbackForce = (collider.transform.up * 400) - (collider.transform.forward * 700);
            Debug.DrawRay(new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y, collider.gameObject.transform.position.z), playerBlowbackForce, Color.green);
            collider.GetComponent<Rigidbody>().AddRelativeForce(playerBlowbackForce);
            isRecoiling = true;
        }
    }
}
