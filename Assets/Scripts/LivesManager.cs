using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private Text lifeText;
    private LevelManager levelManager;
    private RisingWaterManager risingWaterManager;

    public int livesCount;

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
        if (risingWaterManager)
        {
            risingWaterManager.TriggerWaterRising(false);
        }
        if (livesCount <= 0)
        {
            PlayerPrefsManager.SetNumLives(5);
            levelManager.LoadLevel("01c Game Over");
        }
        else
        {
            PlayerPrefsManager.SetNumLives(livesCount);
            levelManager.LoadLevel("01b World Map");
        }
    }
}
