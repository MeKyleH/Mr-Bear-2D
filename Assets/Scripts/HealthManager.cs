using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private Text healthText;
    private LevelManager levelManager;
    private LivesManager livesManager;
    private PlayerSpawner playerSpawner;

    public int maxPlayerHealth;
    public bool isDead;

    public static int playerHealth;

	// Use this for initialization
	void Start () {
        healthText = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        livesManager = GameObject.FindObjectOfType<LivesManager>();
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            if(gameObject.tag == "Player")
            {
                isDead = true;
                playerSpawner.SpawnPlayer();
            } 
            else
            {
                Destroy(gameObject);
            }
        }
        healthText.text = playerHealth.ToString();
	}

    public void HurtPlayer(int damage)
    {
        playerHealth -= damage;
    }

    public void HealPlayer()
    {
        playerHealth = maxPlayerHealth;
    }
}
