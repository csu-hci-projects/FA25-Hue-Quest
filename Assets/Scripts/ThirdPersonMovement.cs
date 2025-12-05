using System;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private CharacterController controller;
    public Transform cam;
    public float speed = 3.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float verticalVelocity;
    private float groundedTimer;
    public float jumpHeight = 1.0f;
    [SerializeField] private float gravity = 9.81f;
    private Animator anim;
    private ColorManager colorManager;

    // DASH
    public float dashSpeed = 10f;       // speed of dash
    public float dashDuration = 0.2f;   // how long dash lasts
    public float dashCooldown = 1f;     // cooldown between dashes

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private Vector3 dashDirection;

    // WALL STICK
    public float wallStickTime = 2.0f;  // how long can stick to wall
    private bool isStuckToWall = false;
    private float wallStickTimer = 0f;
    private Vector3 wallNormal;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        colorManager = GetComponent<ColorManager>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        
        //movement - declare early for use throughout method
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //animation control
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        //check player is grounded and grounded timer for jumping
        if (groundedPlayer)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundedTimer = 0.2f;
            isStuckToWall = false; // reset wall stick when grounded
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = -0f;
        }

        // WALL STICK - check if touching wall and holding J
        RaycastHit hit;
        bool isTouchingWall = Physics.Raycast(transform.position, transform.forward, out hit, 1f);
        
        if (isTouchingWall && Input.GetKey(KeyCode.J) && colorManager.hasYellow && !groundedPlayer)
        {
            if (!isStuckToWall)
            {
                // Just stuck to wall
                isStuckToWall = true;
                wallStickTimer = wallStickTime;
                wallNormal = hit.normal;
                verticalVelocity = 0; // stop falling
            }
        }
        else if (isStuckToWall && !Input.GetKey(KeyCode.J))
        {
            // Released J key, fall off
            isStuckToWall = false;
        }

        // STUCK TO WALL - freeze in place, count down timer
        if (isStuckToWall)
        {
            wallStickTimer -= Time.deltaTime;
            
            // Timer ran out, fall off wall
            if (wallStickTimer <= 0f)
            {
                isStuckToWall = false;
                // Don't reset verticalVelocity here so they start falling
            }
            
            if (isStuckToWall)
            {
                // Stay stuck - no gravity, no movement
                verticalVelocity = 0;
                
                // Can jump off wall
                if (Input.GetButtonDown("Jump"))
                {
                    isStuckToWall = false;
                    wallStickTimer = 0f;
                    
                    // Jump away from wall
                    verticalVelocity = Mathf.Sqrt(jumpHeight * 2 * gravity);
                    Vector3 awayFromWall = wallNormal * speed * 0.5f;
                    controller.Move(awayFromWall * Time.deltaTime * 10f); // push away from wall
                }
                
                return; // skip normal movement while stuck
            }
        }

        // apply gravity always, to let us track down ramps properly
        verticalVelocity -= gravity * Time.deltaTime;

        //movement
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        // allow jump as long as the player is on the ground
        if (Input.GetButtonDown("Jump"))
        {
            // must have been grounded recently to allow jump (and has red color)
            if (groundedTimer > 0 && (colorManager.hasRed == true))
            {
                // no more until we recontact ground
                groundedTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravity);
            }
        }



        //declar mofeDir
        Vector3 moveDir = Vector3.zero;

        // DASH INPUT
        // DASH INPUT
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        // ---- DASH INPUT ----
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f && !isDashing && colorManager.hasOrange == true)
        {
            if (moveDir.magnitude >= 0.1f)
                dashDirection = moveDir.normalized;   // dash in actual movement direction
            else
                dashDirection = transform.forward;    // dash forward if standing still

            isDashing = true;
            dashTimer = dashDuration;
            dashCooldownTimer = dashCooldown;

            anim.SetTrigger("DashFlip");

        }

        // ---- DASH ACTIVE ----
        if (isDashing)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
                isDashing = false;

            return; // skip normal movement & gravity while dashing
        }

        // ---- DASH COOLDOWN ----
        if (dashCooldownTimer > 0f)
            dashCooldownTimer -= Time.deltaTime;
        //movement 
        //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("Woah");
        }


        //add jumping
        Vector3 move = (moveDir * speed) + Vector3.up * verticalVelocity;
        controller.Move(move * Time.deltaTime);

        //controller.Move(moveDir * speed * Time.deltaTime);
    }
}
