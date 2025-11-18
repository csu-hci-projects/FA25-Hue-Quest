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
    private float gravity = 9.81f;
    private Animator anim;
    private ColorManager colorManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        colorManager = GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
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

        // apply gravity always, to let us track down ramps properly
        verticalVelocity -= gravity * Time.deltaTime;

        //movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
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


        if (direction.magnitude >= 0.1f)
        {
            //rotation angle
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //movement 
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        //movement 
        //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //add jumping
        Vector3 move = (moveDir * speed) + Vector3.up * verticalVelocity;
        controller.Move(move * Time.deltaTime);

        //controller.Move(moveDir * speed * Time.deltaTime);
    }
}
