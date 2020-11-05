using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;



public class AIRatController : MonoBehaviour
{
    public float speed;
    private bool following;
    private float thyme = 1.0f;

    private bool movingRight = true;

    public GameObject PlayerDetector;
    public GameObject behindPos;
    public GameObject Follower;

    public GameObject target;

    public Vector2 startPos;

    public LayerMask pipes;
    public LayerMask escalatorRight;
    public LayerMask escalatorLeft;

    private Animator m_Anim;
    private Collider2D myCollider;
    private Rigidbody2D myrigidbody;
    private Transform m_transform;


    private void Awake()
    {
        m_Anim = Follower.GetComponent<Animator>();

    }

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {

        m_Anim.enabled = false;

        if (PlayerDetector.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>()))
        {
            following = true;
        }

        else if (PlayerDetector.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Flashlight"))
         && following == true)
        {

            thyme -= Time.deltaTime;

            if (thyme < 0)
            {
                transform.position = startPos;
                //Debug.Log("Hey you fuck, go back where you came from you piece of shiiiiiiieeeeet");
                following = false;
                thyme = 1.0f;
            }

        }

        if (following == true)
        {
            ApproachPlayer();
        }
    }

    void ApproachPlayer() // when player is less than 5 untis, approach with greater speed
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");


        if (Vector2.Distance(transform.position, target.transform.position) > 1
        && Vector2.Distance(transform.position, target.transform.position) < 15)
        {

            if (behindPos.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>()))
            {

                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }

            m_Anim.enabled = true;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, target.transform.position) <= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0 * Time.deltaTime);
            //speed = 0;

        }

        else if (Vector2.Distance(transform.position, target.transform.position) >= 10 && following == true)
        {
            transform.position = startPos;
            //Debug.Log("Hey you fuck, go back where you came from you piece of shiiiiiiieeeeet");
            following = false;
            thyme = 1.0f;
            //speed = 0;

        }

        if (target.GetComponent<Collider2D>().IsTouchingLayers(pipes))
        {
           

            if (Input.GetKey(KeyCode.S) || v < 0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2);
                Debug.Log("Hey fuckin god damn move you terrible asshole");
            }

        }

        if (target.GetComponent<Collider2D>().IsTouchingLayers(escalatorLeft) && following == true)
        {
            if (Input.GetKey(KeyCode.W) || v > 0)
            {
                transform.position = new Vector2(transform.position.x - 4, transform.position.y + 3);
                Debug.Log("Hey fuckin god damn move you terrible asshole");
            }

        }

        if (target.GetComponent<Collider2D>().IsTouchingLayers(escalatorRight) && following == true)
        {
            if (Input.GetKey(KeyCode.W) || v > 0)
            {
                transform.position = new Vector2(transform.position.x +4, transform.position.y + 3);
                Debug.Log("Hey fuckin god damn move you terrible asshole");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "trap")
        {

        }
    }
}
