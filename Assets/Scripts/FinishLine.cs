using UnityEngine;

public class FinishLine : MonoBehaviour {
    [SerializeField]
    private int unlockLevelNum;

    private LivesManager livesManager;
    private LevelManager levelManager;
    private PlayerSpawner spawner;

    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if(!levelManager)
        {
            Debug.Log(name + " couldn't find levelManager");
        }
        livesManager = GameObject.FindObjectOfType<LivesManager>();
        if (!livesManager)
        {
            Debug.Log(name + " couldn't find livesManager");
        }
        spawner = GameObject.FindObjectOfType<PlayerSpawner>();
        if(!spawner)
        {
            Debug.Log(name + " couldn't find spawner");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerPrefsManager.UnlockLevel(unlockLevelNum);
            PlayerPrefsManager.ClearLevel(spawner.getLevelNum());
            PlayerPrefsManager.SetNumLives(livesManager.livesCount);
            levelManager.LoadLevel("01b World Map");
        }
    }
}
