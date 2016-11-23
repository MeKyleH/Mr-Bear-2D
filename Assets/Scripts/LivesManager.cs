using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int startingLives;

    private int lifeCounter;
    private Text lifeText;

    // Use this for initialization
    void Start()
    {
        lifeText = GetComponent<Text>();
        lifeCounter = startingLives;
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
            //TODO LOAD GAMEOVER SCREEN
        }
    }
}
