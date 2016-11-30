using UnityEngine;
using System.Collections;

public class CharacterControllerNoTurn : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float directionDampTime = 0.25f;
    [SerializeField]
    private float speed = 1f;

    private float x = 0.0f;
    private float leftY = 0.0f;
    private bool facingRight = true;
    private FaceDirection faceDirection;

    private enum FaceDirection
    {
            Right,
            Left,
            Default
    }

    // Use this for initialization
    void Start()
    {
        faceDirection = FaceDirection.Default;
        animator = GetComponent<Animator>();
        if (animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
        if(gameObject.transform.forward != Vector3.right && gameObject.transform.forward != Vector3.left)
        {
            gameObject.transform.forward = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animator)
        {
/* 
                        if (Input.GetButton("Jump"))
                        {
                            animator.SetBool("Jump", true);
                        }
                        else
                        {
                            animator.SetBool("Jump", false);
                        }
*/

            //get the power of the direction press
            x = Input.GetAxis("Horizontal");

            //determine the possible direction change based on the damped direction 
            if (x > 0)
            {
                faceDirection = FaceDirection.Right;
            }
            else if (x < 0)
            {
                faceDirection = FaceDirection.Left;
            }
            else
            {
                faceDirection = FaceDirection.Default;
            }

            //set absolute damped value and current direction of player
            x = Mathf.Abs(x);
            facingRight = gameObject.transform.forward == Vector3.right;
            
            //change diretion if necessary
            switch(faceDirection)
            {
                case FaceDirection.Left:
                    if(facingRight)
                    {
                        gameObject.transform.Rotate(0f, 180f, 0f, Space.World);
                    }
                    break;
                case FaceDirection.Right:
                    if (!facingRight)
                    {
                        gameObject.transform.Rotate(0f, 180f, 0f, Space.World);
                    }
                    break;
                default:
                    break;
            }
            
            animator.SetFloat("Direction", x, directionDampTime, Time.deltaTime);

            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward, Color.red);
            Debug.DrawRay(gameObject.transform.position, Vector3.right*2, Color.blue);

            Debug.Log("facingRight " + facingRight);
        }
    }
}
