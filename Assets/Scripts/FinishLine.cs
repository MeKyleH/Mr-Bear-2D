using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {
    [SerializeField]
    private int unlockLevelNum;

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if(!levelManager)
        {
            Debug.Log(name + " couldn't find levelManager");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerPrefsManager.UnlockLevel(unlockLevelNum-1);
            levelManager.LoadLevel("01b World Map");
        }
    }
}
