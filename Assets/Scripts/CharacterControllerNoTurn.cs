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
    [SerializeField]
    private float jumpMultiplier = 1f;
    [SerializeField]
    private CapsuleCollider capCollider;
    [SerializeField]
    private float jumpDist = 1f;

    private float x = 0.0f;
    private float leftY = 0.0f;
    private bool facingRight = true;
    private float capsuleHeight;
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
        capCollider = GetComponent<CapsuleCollider>();
        capsuleHeight = capCollider.height;
        animator = GetComponent<Animator>();
        if (animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
        if (gameObject.transform.forward != Vector3.right && gameObject.transform.forward != Vector3.left)
        {
            gameObject.transform.forward = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.forward != Vector3.right && gameObject.transform.forward != Vector3.left)
        {
            gameObject.transform.forward = Vector3.right;
        }
        if (animator)
        {

            if (Input.GetButton("Jump"))
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }

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
            switch (faceDirection)
            {
                case FaceDirection.Left:
                    if (facingRight)
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
        }
    }

    void FixedUpdate()
    {
        if (IsInJump())
        {
            float oldY = transform.position.y;
            transform.Translate(Vector3.up * jumpMultiplier * animator.GetFloat("JumpCurve"));
            if (IsInLocomotionJump())
            {
                transform.Translate(Vector3.forward * Time.deltaTime * jumpDist);
            }
            capCollider.height = capsuleHeight + (animator.GetFloat("CapsuleCurve") * 0.5f);
        }
    }

    public bool IsInJump()
    {
        return (IsInIdleJump() || IsInLocomotionJump());
    }

    public bool IsInIdleJump()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.IdleJump");
    }

    public bool IsInLocomotionJump()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.LocomotionJump");
    }
}
