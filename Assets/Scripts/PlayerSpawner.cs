using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject playerPrefab;

    private Vector3[] spawnPoints;
    private Quaternion spawnRotation = new Quaternion(0, 0, 0, 0);
    private CameraFollow mainCamera;
    private PlayerHealthManager playerHealthManager;

    public bool reachedCheckpoint = false;

    private void Start()
    {
        playerHealthManager = GameObject.FindObjectOfType<PlayerHealthManager>();
        mainCamera = GameObject.FindObjectOfType<CameraFollow>();
        spawnPoints = new Vector3[2] { this.gameObject.transform.GetChild(0).transform.position, this.gameObject.transform.GetChild(1).transform.position };
        Instantiate(playerPrefab, spawnPoints[0], spawnRotation);
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, !reachedCheckpoint ? spawnPoints[0] : spawnPoints[1], spawnRotation);
        mainCamera.SpawnCamera();
        playerHealthManager.HealPlayer(playerHealthManager.maxPlayerHealth);
        playerHealthManager.isDead = false;
    }
}
