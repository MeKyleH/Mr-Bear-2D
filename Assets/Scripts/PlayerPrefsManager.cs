using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    const string LEVEL_KEY = "level_unlocked_";
    const string NUM_LIVES = "number_of_lives_";
    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }

    public static void SetNumLives(int lives)
    {
        PlayerPrefs.SetInt(NUM_LIVES, lives);
    }

    public static int GetNumLives()
    {
        return PlayerPrefs.GetInt(NUM_LIVES);
    }

    public static void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SetNumLives(5);
    }
}