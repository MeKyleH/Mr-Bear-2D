using UnityEngine;
using System.Collections;

public class CharacterControllerLogic : MonoBehaviour {
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float directionDampTime = 0.25f;

    private float speed = 1f;
    private float leftX = 0.0f;
    private float leftY = 0.0f;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        if(animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(animator)
        {
            if (Input.GetButton("Jump"))
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }

            leftX = Input.GetAxis("Horizontal");
            leftY = Input.GetAxis("Vertical");

            speed = new Vector2(leftX, leftY).sqrMagnitude;

            animator.SetFloat("Speed", speed);
            animator.SetFloat("Direction", leftX, directionDampTime, Time.deltaTime);
        }
	}
}
