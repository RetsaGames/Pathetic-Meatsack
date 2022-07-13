using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Left/right moving speed")]
    [SerializeField] float speed;

    [Header("Initial vertical speed when jumping")]
    [SerializeField] float jumpForce;

    [Header("time going upwards")]
    [SerializeField] float jumpingTime = 2;

    [Header("fall velocity is fallForce * timeFalling")]
    [SerializeField] float fallForce;

    [Header("max time accelerating downwards")]
    [SerializeField] float maxTimeFalling = 2;

    [Header("Time allowed to jump after leaving ground")]
    [SerializeField] float coyoteTime;

    [Header("Time that can pass since pressing jump and touching ground")]
    [SerializeField] float jumpInputTime;

    [Header("layermask of jumpable surfaces")]
    [SerializeField] LayerMask layerMask;

    [Header("rigidbody")]
    [SerializeField] Rigidbody2D rb2d;


    float xInput = 0;
    float timeJumpingLeft = 0;
    float timeFalling = 0;
    float timeSinceJumpInput;
    List<Collider2D> touchingFloors = new List<Collider2D>();
    Vector2 lastVelocity;
    bool onCoyote = false;

    void Start()
    {
        timeSinceJumpInput = jumpInputTime;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            timeSinceJumpInput = 0;
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            timeJumpingLeft /= 2;
        }

        xInput = Input.GetAxis("Horizontal");

        //Mirror the player sprite when looking to the left
        if (xInput != 0)
        {
            if (xInput > 0)
            {
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(
                    -Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z);
            }
        }

        //Limit the maximum downward speed
        if (inFloor())
        {
            timeFalling = 0;
        }
        else if (timeJumpingLeft<=0 && timeFalling<maxTimeFalling)
        {
            timeFalling += Time.deltaTime;
        }

        if (isJumping())
        {
            Jump();
        }

        timeJumpingLeft -= Time.deltaTime;
        timeSinceJumpInput += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        float vSpeed;
        if (timeJumpingLeft > 0)
        {
            vSpeed = jumpForce * timeJumpingLeft;

            //crashing on ceiling
            if (rb2d.velocity.y==0 && lastVelocity.y > 0)
            {
                timeJumpingLeft = 0;
            }
        }
        else
        {
            vSpeed = timeFalling * fallForce * -1;
        }

        rb2d.velocity = new Vector2(
            xInput * speed,
            vSpeed);

        lastVelocity = rb2d.velocity;
    }

    void Jump()
    {
        timeJumpingLeft = jumpingTime;
        timeSinceJumpInput = jumpInputTime;
        timeFalling = 0;
    }

    bool isJumping()
    {
        if (timeSinceJumpInput < jumpInputTime)
        {
            if (inFloor() || onCoyote)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Util.isLayerInLayerMask(layerMask, collision.gameObject.layer)){
            touchingFloors.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Util.isLayerInLayerMask(layerMask, collision.gameObject.layer))
        {
            touchingFloors.Remove(collision);
            startCoyoteTime();
        }
    }

    public float getXInput()
    {
        return xInput;
    }

    public bool inFloor()
    {
        bool result;
        if (touchingFloors.Count > 0)
            result = true;
        else
            result = false;

        return result;
    }

    void startCoyoteTime()
    {
        if (!onCoyote && timeJumpingLeft<=0)
            StartCoroutine(coyoteRoutine());
    }

    IEnumerator coyoteRoutine()
    {
        onCoyote = true;
        yield return new WaitForSeconds(coyoteTime);
        onCoyote = false;
    }
}
