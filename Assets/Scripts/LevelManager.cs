using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
    public string autoLoadScene;

	void Start () {
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled, use a positive number in seconds");
		} else {
      	    Invoke (autoLoadScene != "" ? "AutoLoadScene" : "LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

    public void AutoLoadScene()
    {
        Debug.Log("New Level load: " + autoLoadScene);
        SceneManager.LoadScene(autoLoadScene);
    }

    public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene(Application.loadedLevel + 1);
	}

    public void StartNewGame()
    {
        PlayerPrefsManager.NewGame();
        PlayerPrefsManager.UnlockLevel(4);
        PlayerPrefsManager.SetMapXPos(-27.0f);
        PlayerPrefsManager.SetMapYPos(0.0f);
        PlayerPrefsManager.SetMapZPos(-9.0f);
        LoadLevel("01b World Map");
    }
}
