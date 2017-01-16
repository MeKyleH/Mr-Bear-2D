using UnityEngine;
using System.Collections;

public class LevelLockManager : MonoBehaviour {
    [SerializeField]
    public int levelNum;

    void Start()
    {
        if(!PlayerPrefsManager.IsLevelUnlocked(levelNum))
        {
            this.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        if (!PlayerPrefsManager.IsLevelUnlocked(levelNum))
        {
            this.gameObject.SetActive(false);
        }
    }
}
