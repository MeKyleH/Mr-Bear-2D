using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    [SerializeField]
    private bool isWater = false;

    private PlayerSpawner spawner;
    private LivesManager livesManager;
    private LevelManager levelManager;
    private RisingWaterManager risingWaterManager;

    void Start()
    {
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
        if (!spawner)
        {
            Debug.Log(name + " did not find spawner at start");
        }
        livesManager = GameObject.FindObjectOfType<LivesManager>();
        if (!livesManager)
        {
            Debug.Log(name + " did not find livesManager at start");
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.Log(name + " did not find levelManager at start");
        }
        risingWaterManager = GameObject.FindObjectOfType<RisingWaterManager>();
    }

	void OnTriggerEnter(Collider collider)
    {
        if(isWater && collider.tag != "Player")
        {
            return;
        }
        if (collider.tag == "Player")
        {
            HandlePlayerDestruction();
        }
            Destroy(collider.gameObject);
    }

    void HandlePlayerDestruction()
    {
        livesManager.LoseLife();
        if (isWater)
        {
            if (livesManager.livesCount > 0)
            {
                risingWaterManager.TriggerWaterRising(false);
                PlayerPrefsManager.SetNumLives(livesManager.livesCount);
                levelManager.LoadLevel("01b World Map");
            }
        }
        else
        {
            spawner.SpawnPlayer();
        }
    }
}
