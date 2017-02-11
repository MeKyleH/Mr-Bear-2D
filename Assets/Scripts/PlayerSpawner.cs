using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private int levelNum = 0;

    private Vector3[] spawnPoints;
    private Quaternion spawnRotation = new Quaternion(0, 0, 0, 0);
    private CameraFollow mainCamera;

    public bool reachedCheckpoint = false;

    private void Start()
    {
        reachedCheckpoint = PlayerPrefsManager.IsCheckPointReached(levelNum);
        mainCamera = GameObject.FindObjectOfType<CameraFollow>();
        spawnPoints = new Vector3[2] { this.gameObject.transform.GetChild(0).transform.position, this.gameObject.transform.GetChild(1).transform.position };
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, !reachedCheckpoint ? spawnPoints[0] : spawnPoints[1], spawnRotation);
        mainCamera.SpawnCamera();
    }

    public int getLevelNum()
    {
        return levelNum;
    }
}
