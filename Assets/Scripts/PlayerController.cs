using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 4f;
    public float jumpForce = 6f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    // REFERENCES
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    // PRIVATE VARIABLES
    // Movement
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Jump();

        //Is Grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
        if (Input.GetButtonDown("Jump")) {
            _animator.SetTrigger("Jump");
        }

    }

    void PlayerMove()
        {
        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);

        //Flip character
        if (horizontalInput < 0f && _facingRight == true) {
            Flip();
        } else if (horizontalInput > 0f && _facingRight == false) {
            Flip();
        }

        // Movement
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    void Flip ()
    {
        _facingRight = !_facingRight;

        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump")) {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
