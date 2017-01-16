using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    private Image healthBar;
    private LivesManager livesManager;
    private PlayerSpawner playerSpawner;

    public float maxPlayerHealth;
    public bool isDead;

    public static float playerHealth;

	void Start () {
        healthBar = GetComponent<Image>();
        playerHealth = maxPlayerHealth;
        livesManager = GameObject.FindObjectOfType<LivesManager>();
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        isDead = false;
	}
	
	void UpdateHealth () {
        float ratio = playerHealth / maxPlayerHealth;
        healthBar.rectTransform.localScale = new Vector3(1, ratio, 1);
	}

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0 && !isDead)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player.gameObject);
            playerHealth = 0;
            livesManager.LoseLife();
            isDead = true;
            if(livesManager.livesCount > 0)
            {
                playerSpawner.SpawnPlayer();
            }
        }
        UpdateHealth();
    }

    public void HealPlayer(float heal)
    {
        playerHealth += heal;
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        UpdateHealth();
    }
}
