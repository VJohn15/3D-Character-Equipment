using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    
    [SerializeField] private GameObject rapierPickedSword;
    [SerializeField] private GameObject scimitarPickedSword;
    [SerializeField] private GameObject pickedAxe;

    [SerializeField] private RapierSwordController rapierSwordController;
    [SerializeField] private ScimitarSwordController scimitarSwordController;
    [SerializeField] private AxeController axeController;

    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        Move();
        
        PickTheObject();

        if (Input.GetMouseButtonDown(0))
        {
            RapierSwordAttack();
            ScimitarSwordAttack();
            AxeAttack();
        }
        
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        
        moveDirection = new Vector3(moveX ,0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveZ > 0)
            {
                if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {
                    Walk();
                }
                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }
            }

            if (moveZ < 0)
            {
                if (moveDirection != Vector3.zero)
                {
                    WalkBack();
                }
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            if (moveX > 0)
            {
                if (moveDirection != Vector3.zero)
                {
                    RightWalk();
                }
            }

            if (moveX < 0)
            {
                if (moveDirection != Vector3.zero)
                {
                    LeftWalk();
                }
            }
            
            moveDirection *= moveSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
    private void WalkBack()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0.2f, 0.1f, Time.deltaTime);
    }
    
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.4f, 0.1f, Time.deltaTime);
    }

    private void RightWalk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.6f, 0.1f, Time.deltaTime);
    }
    
    private void LeftWalk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.8f, 0.1f, Time.deltaTime);
    }
    
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void RapierSwordAttack()
    {
        if (rapierPickedSword.activeSelf)
        {
            anim.SetTrigger("RapierAttack");
        }
    }

    private void ScimitarSwordAttack()
    {
        if (scimitarPickedSword.activeSelf)
        {
            anim.SetTrigger("ScimitarAttack");
        }
    }
    
    private void AxeAttack()
    {
        if (pickedAxe.activeSelf)
        {
            anim.SetTrigger("AxeAttack");
        }
    }

    private void PickTheObject()
    {
        if (Input.GetKey(KeyCode.E) && rapierSwordController.check)
        {
            anim.SetTrigger("Pick");
        }
        
        if (Input.GetKey(KeyCode.E) && scimitarSwordController.check)
        {
            anim.SetTrigger("Pick");
        }
        
        if (Input.GetKey(KeyCode.E) && axeController.check)
        {
            anim.SetTrigger("Pick");
        }
    }
}
