using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private Text lifeText;
    private LevelManager levelManager;

    public int startingLives;
    public int lifeCounter;

    // Use this for initialization
    void Start()
    {
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if(!levelManager)
        {
            Debug.Log(name + " couldn't find LevelManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = lifeCounter.ToString();
    }

    public void GainLife()
    {
        lifeCounter++;
    }

    public void LoseLife()
    {
        lifeCounter--;
        if (lifeCounter <= 0)
        {
            levelManager.LoadLevel("01c Game Over");
        }
    }
}
