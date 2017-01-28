using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private Transform player;
    private Animator animator;
    private bool pursuing = false;
    private PlayerHealthManager playerHealthManager;

    [SerializeField]
    private int hitpoints = 25;
    [SerializeField]
    private int strength = 10;
    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private int detectionDistance = 10;


	// Use this for initialization
	void Start () {
        playerHealthManager = GameObject.FindObjectOfType<PlayerHealthManager>();
        if (!playerHealthManager)
        {
            Debug.Log(name + " did not find healthManager at start");
        }
        animator = GetComponent<Animator>();
        if(!animator)
        {
            Debug.Log(name + " couldn't find animator");
        }
    }

    void Update()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        SetAnimationState();
    }

    private void SetAnimationState()
    {
        //distance to player
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0; //prevents the character from falling over

        // viewing angle of the enemy to the player
        float angle = Vector3.Angle(direction, this.transform.forward);

        // sets animation state of the enemy
        if (Vector3.Distance(player.position, this.transform.position) < detectionDistance && (angle < 30 || pursuing))
        {
            pursuing = true;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude > 1)
            {
                this.transform.Translate(0, 0, moveSpeed / 100f);
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
            else
            {
                animator.SetBool("isAttacking", true);
                animator.SetBool("isWalking", false);
            }
        }
        else if (pursuing)
        {
            animator.SetTrigger("isIdle");
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            pursuing = false;
        }
    }

    public void Attack()
    {
        playerHealthManager.TakeDamage(strength);
    }
}
