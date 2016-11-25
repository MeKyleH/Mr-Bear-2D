using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private Transform player;
    private Animator animator;
    private bool pursuing = false;
    private PlayerHealthManager playerHealthManager;

    public int hitpoints = 25;
    public int strength = 10;
    public float moveSpeed = 2;


	// Use this for initialization
	void Start () {
        playerHealthManager = GameObject.FindObjectOfType<PlayerHealthManager>();
        if (!playerHealthManager)
        {
            Debug.Log(name + " did not find healthManager at start");
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(!player)
        {
            Debug.Log(name + " couldn't find player");
        }
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (Vector3.Distance(player.position, this.transform.position) < 5 && (angle < 30 || pursuing))
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


    //TODO DELETE THIS AND USE THROUGH ANIMATION EVENT
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerHealthManager.TakeDamage(hitpoints);
        }
    }
}
