using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    private Image healthBar;
    private LivesManager livesManager;

    public float maxPlayerHealth;

    public static float playerHealth;

	void Start () {
        healthBar = GetComponent<Image>();
        playerHealth = maxPlayerHealth;
        livesManager = GameObject.FindObjectOfType<LivesManager>();
	}
	
	void UpdateHealth () {
        float ratio = playerHealth / maxPlayerHealth;
        healthBar.rectTransform.localScale = new Vector3(1, ratio, 1);
	}

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            livesManager.LoseLife();
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
