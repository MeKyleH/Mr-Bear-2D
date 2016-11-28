using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private Text lifeText;
    private LevelManager levelManager;

    public int livesCount;

    // Use this for initialization
    void Start()
    {
        lifeText = GetComponent<Text>();
        livesCount = PlayerPrefsManager.GetNumLives();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if(!levelManager)
        {
            Debug.Log(name + " couldn't find LevelManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = livesCount.ToString();
    }

    public void GainLife()
    {
        livesCount++;
    }

    public void LoseLife()
    {
        livesCount--;
        if (livesCount <= 0)
        {
            PlayerPrefsManager.SetNumLives(5);
            levelManager.LoadLevel("01c Game Over");
        }
    }
}
