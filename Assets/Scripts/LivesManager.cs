using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private Text lifeText;
    private LevelManager levelManager;
    private RisingWaterManager risingWaterManager;

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
        risingWaterManager = GameObject.FindObjectOfType<RisingWaterManager>();
        if (!risingWaterManager)
        {
            Debug.Log(name + " did not find risingWaterManager at start");
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
            risingWaterManager.TriggerWaterRising(false);
            levelManager.LoadLevel("01c Game Over");
        }
    }
}
