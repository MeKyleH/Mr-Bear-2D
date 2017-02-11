using UnityEngine;

public class Destroyer : MonoBehaviour {
    [SerializeField]
    private bool isWater = false;

    private PlayerSpawner spawner;
    private LivesManager livesManager;
    private LevelManager levelManager;

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
    }

	void OnTriggerEnter(Collider collider)
    {
        if(isWater && collider.tag != "Player")
        {
            return;
        }
        Destroy(collider.gameObject);
        if (collider.tag == "Player")
        {
            livesManager.LoseLife();
        }
    }
}
