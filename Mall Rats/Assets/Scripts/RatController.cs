using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class RatController : MonoBehaviour
{


    public float moveSpeed;

    private bool faceright;
    private float deathTimer = 1.7F;
    public bool die;
    public float health;

    private Rigidbody2D myRigidbody;
    private Animator m_Anim;
    private Transform mytransform;

    public bool grounded;
    public LayerMask whatIsGround;
    public LayerMask pipes;
    public LayerMask escalatorRight;
    public LayerMask escalatorLeft;


    private Collider2D myCollider;



    private void Awake()
    {
        // Setting up references.

        m_Anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mytransform = GetComponent<Transform>();
        health = 200;
    }


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();


        myCollider = GetComponent<Collider2D>();

    }

    void FixedUpdate()
    {

        //Detects whether the player is on the ground
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //Controls character movement
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (myCollider.IsTouchingLayers(pipes))
        {
            //Debug.Log("Hey fuckin god damn move you terrible asshole");

            if (Input.GetKey(KeyCode.S) || v < 0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y-1);
                //Debug.Log("Hey fuckin god damn move you terrible asshole");
            }
        }

        if (myCollider.IsTouchingLayers(escalatorLeft))
        {
            //Debug.Log("Hey fuckin god damn move you terrible asshole");

            if (Input.GetKey(KeyCode.W) || v > 0)
            {
                transform.position = new Vector2(transform.position.x - 4, transform.position.y + 3);
                //Debug.Log("Hey fuckin god damn move you terrible asshole");
            }
        }

        if (myCollider.IsTouchingLayers(escalatorRight))
        {
            //Debug.Log("Hey fuckin god damn move you terrible asshole");

            if (Input.GetKey(KeyCode.W) || v > 0)
            {
                transform.position = new Vector2(transform.position.x + 4, transform.position.y + 3);
                //Debug.Log("Hey fuckin god damn move you terrible asshole");
            }
        }

        CharacterMovement(h);
    }




    void CharacterMovement(float m)
    {
        //m_Anim.SetFloat("Speed", Mathf.Abs(m));
        //m_Anim.SetBool("FaceRight", faceright);

        if (Input.GetKey(KeyCode.D) || m > 0)
        {
            faceright = true;
            mytransform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A) || m < 0)
        {
            faceright = false;
            mytransform.eulerAngles = new Vector2(0, 180);
        }

        if (m > 0 && faceright)
        {
            myRigidbody.velocity = new Vector2(m * moveSpeed, myRigidbody.velocity.y);
        }

        if (m < 0 && !faceright)
        {
            myRigidbody.velocity = new Vector2(m * moveSpeed, myRigidbody.velocity.y);

        }
    }

    


}