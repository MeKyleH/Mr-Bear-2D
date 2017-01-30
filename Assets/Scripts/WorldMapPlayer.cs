using UnityEngine;
using System.Collections.Generic;

public class WorldMapPlayer : MonoBehaviour {
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float maxDistanceToGoal = 0.1f;
    [SerializeField]
    private float levelHeightDif = 2.5f;

    private LevelManager levelManager;
    private LevelSelect currentLevel;
    private PlatformPath playerMovePath;
    private IEnumerator<Transform> _currentPoint;
    private bool isMoving = false;
    private int numStops;
    private int currentStop = 0;
    private Animator animator;
    private GameObject mrBearMesh;

    void Awake()
    {
        gameObject.transform.position = new Vector3(PlayerPrefsManager.GetMapXPos(), PlayerPrefsManager.GetMapYPos(), PlayerPrefsManager.GetMapZPos());
    }
    
    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.Log(name + " couldn't find levelManager");
        }
        animator = GetComponent<Animator>();
        if(!animator)
        {
            Debug.Log(name + " couldn't find animator");
        }
        mrBearMesh = GameObject.Find("Mr Bear").gameObject;
        if(!mrBearMesh)
        {
            Debug.Log(name + " couldn't find Mr Bear Mesh");
        }
    }

    // Update is called once per frame
    void Update () {
        // Move player to next level
        if (isMoving)
        {
            animator.SetFloat("Forward", 0.5f);
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
            var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
            if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
            {
                _currentPoint.MoveNext();
                currentStop++;
                if (currentStop >= numStops)
                {
                    isMoving = false;
                }
                else
                {
                    mrBearMesh.transform.LookAt(_currentPoint.Current.position - new Vector3(0, levelHeightDif, 0f));
                }
            }
        }
        // check for input when not moving
        else
        {
            animator.SetFloat("Forward", 0f);
            // enter level if on the level and you press jump
            if (Input.GetButton("Jump"))
            {
                PlayerPrefsManager.SetMapXPos(transform.position.x);
                PlayerPrefsManager.SetMapYPos(transform.position.y);
                PlayerPrefsManager.SetMapZPos(transform.position.z);
                levelManager.LoadLevel(currentLevel.name);
            }

            // determine direction to move to next level
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (y > 0 && currentLevel.upPath)
            {
                playerMovePath = currentLevel.upPath;
                MovePlayer();
            }
            if (y < 0 && currentLevel.downPath)
            {
                playerMovePath = currentLevel.downPath;
                MovePlayer();
            }
            if (x > 0 && currentLevel.rightPath)
            {
                playerMovePath = currentLevel.rightPath;
                MovePlayer();
            }
            if (x < 0 && currentLevel.leftPath)
            {
                playerMovePath = currentLevel.leftPath;
                MovePlayer();
            }
        }
    }

    // Moves player to next level along the desired path
    void MovePlayer()
    {
        _currentPoint = playerMovePath.GetPathsEnumerator();
        _currentPoint.MoveNext();
        transform.position = _currentPoint.Current.position;
        isMoving = true;
        numStops = playerMovePath.pathPoints.Length;
        currentStop = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        playerMovePath = null;
        currentLevel = collider.GetComponent<LevelSelect>();
    }

    void OnTriggerExit(Collider collider)
    {
        currentLevel = null;
    }
}
