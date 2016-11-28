using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {
    [SerializeField]
    private int unlockLevelNum;
    private LivesManager livesManager;
    private LevelManager levelManager;

	// Use this for initialization
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
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerPrefsManager.UnlockLevel(unlockLevelNum-1);
            PlayerPrefsManager.SetNumLives(livesManager.livesCount);
            levelManager.LoadLevel("01b World Map");
        }
    }
}
