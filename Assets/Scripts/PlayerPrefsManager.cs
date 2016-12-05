using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    const string LEVEL_KEY = "level_unlocked_";
    const string NUM_LIVES = "number_of_lives_";
    const string MAPPLAYER_X_POS = "mapplayer_x_pos_";
    const string MAPPLAYER_Y_POS = "mapplayer_y_pos_";
    const string MAPPLAYER_Z_POS = "mapplayer_z_pos_";

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

    public static void SetMapXPos(float xPos)
    {
        PlayerPrefs.SetFloat(MAPPLAYER_X_POS, xPos);
    }

    public static float GetMapXPos()
    {
        return PlayerPrefs.GetFloat(MAPPLAYER_X_POS);
    }

    public static void SetMapYPos(float yPos)
    {
        PlayerPrefs.SetFloat(MAPPLAYER_Y_POS, yPos);
    }

    public static float GetMapYPos()
    {
        return PlayerPrefs.GetFloat(MAPPLAYER_Y_POS);
    }

    public static void SetMapZPos(float zPos)
    {
        PlayerPrefs.SetFloat(MAPPLAYER_Z_POS, zPos);
    }

    public static float GetMapZPos()
    {
        return PlayerPrefs.GetFloat(MAPPLAYER_Z_POS);
    }



    public static void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SetNumLives(5);
    }
}