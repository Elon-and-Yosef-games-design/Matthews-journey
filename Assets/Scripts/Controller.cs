using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    [SerializeField] float JumpImpulse = 7f;
    [SerializeField] float SideSpeed = 2f;

    [SerializeField] InputAction move_right;
    [SerializeField] InputAction move_left;
    [SerializeField] InputAction jump;

    [SerializeField] private Vector3 startingPosition;
    public float minimumImpulseForce = 5f;

    public float slidingSpeed = 2f;
    private bool isSliding = false;
    private Rigidbody2D heroRigidbody;
    public float pillarEndY;




    public ContactFilter2D ContactFilter;

    private Rigidbody2D m_Rigidbody;
    private bool m_ShouldJump;
    private float m_SideSpeed;

    // We can check to see if there are any contacts given our contact filter
    // which can be set to a specific layer and normal angle.
    public bool IsGrounded => m_Rigidbody.IsTouching(ContactFilter);

    private void OnEnable()
    {
        move_left.Enable();
        move_right.Enable();    
        jump.Enable();
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    void Update()
    {
        // Set jump/
        if (jump.IsPressed())
            m_ShouldJump = true;

        // Set movement.
        m_SideSpeed = (move_left.IsPressed() ? -SideSpeed : 0f) + (move_right.IsPressed() ? SideSpeed : 0f);

        // Set sliding
        if (isSliding)
        {
            // Prevent horizontal movement while sliding
            move_left.Disable();
            move_right.Disable();
        }
        else
        {
            move_left.Enable();
            move_right.Enable();
        }
    }

    void FixedUpdate()
    {
        // Handle jump.
        // NOTE: If instructed to jump, we'll check if we're grounded.
        if (m_ShouldJump && IsGrounded)
            m_Rigidbody.AddForce(Vector2.up * JumpImpulse, ForceMode2D.Impulse);

        // Set sideways velocity.
        m_Rigidbody.velocity = new Vector2(m_SideSpeed, m_Rigidbody.velocity.y);

        // Reset movement.
        m_ShouldJump = false;
        m_SideSpeed = 0f;

        // sliding
        if (isSliding)
        {
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, -slidingSpeed);
            // Stop sliding when the hero reaches the end of the pillar
            if (transform.position.y <= pillarEndY)
            {
                isSliding = false;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Pillar"))
        {
            isSliding = true;
        }
        else if (collider.gameObject.CompareTag("PillarEnd"))
        {
            isSliding = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Pillar"))
        {
            isSliding = false;
        }
    }


    public void set_speed(float speed)
    {
        this.SideSpeed = speed;
    }


    public float get_speed()
    {
        return this.SideSpeed;
    }
    /**
     * set new impulse
     */
    public void set_impulse(float im)
    {
        this.JumpImpulse = im;
    }
    public float get_impulse()
    {
        return this.JumpImpulse;
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            Vector2 collisionNormal = collision.GetContact(0).normal;
            float angle = Vector2.Angle(collisionNormal, Vector2.up);

            if (angle < 45f) // Falling on the enemy
            {
                float verticalImpulse = Mathf.Abs(collision.relativeVelocity.y);

                // the hero will need to apply a strong enough impulse force when jumping on the enemy's head to destroy the enemy
                if (verticalImpulse > minimumImpulseForce)
                {
                    Destroy(collision.gameObject);
                }

            }
            else // Touching the enemy on the x-axis
            {
                transform.position = startingPosition;
            }
        }
    }
}
