using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_behaviour : MonoBehaviour
{
    [Range(0, 10)]
    public float speed;
    [Range(0, 10)]
    public float GroundDetectionRayLength;
    [Range(0, 10)]
    public float WallDetectionRayLength;

    public Transform groundDetection;
    public Transform wallDetection;
    public GameObject flashLight;
    public GameObject target;

    public bool movingRight;

    

    private int PlayerMask = ~((1 << 10)-(1 << 11)-(1 << 9));
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(groundDetection.position, Vector2.down, GroundDetectionRayLength, PlayerMask);
        RaycastHit2D hitWall = Physics2D.Raycast(wallDetection.position, Vector2.left, WallDetectionRayLength, PlayerMask);

        if (hit.collider == false) // Raycast for ground detection
        {
            turnAround();
        }   
        if (hitWall.collider == true) // Raycast for wall detection
        {
            turnAround();
        }
    }

    private void turnAround()
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
}
