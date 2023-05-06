using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
        // Life
    public int life;

        // Movement
    public float speed = 4f;
    public float jumpForce = 6f;
    public float dashForce = 15f;
    public int jumpLimit;

        // Dash
    public int dashLimit;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

        // Ground Check
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask enemyCheck;
    public float groundCheckRadius;

        // Wall Jump
    public Transform frontCheck;
    public float wallSlidingSpeed;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public bool canWallJump;

    // REFERENCES
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    // PRIVATE VARIABLES
        // Movement
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;
    private int _jumpCount = 0;

        // Dash
    private bool _canDash = true;
    private bool _isDashing;
    private int _dashCount = 0;

    // Wall Jump
    private bool _isTouchingFront;
    private bool _wallSliding;
    private bool _wallJumping;

    //Attack
    private bool _hitEnemy;
    private bool _hitedEnemy;

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
        // Is in enemy head?
        _hitEnemy = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, enemyCheck);

        // Stop if doing a Dash
        if (_isDashing || _wallJumping) {
            return;
        }

        PlayerMove();

        // Jump Control
        if (Input.GetButtonDown("Jump") && _jumpCount < jumpLimit) {
            Jump();
        }

        //Is Grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (_rigidbody.velocity.y < 1 && _isGrounded) {
            _jumpCount = 0;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && _dashCount < dashLimit) {
            StartCoroutine(Dash());
            _dashCount++;
        }
        if (_canDash && _isGrounded) {
            _dashCount = 0;
        }

        // Wall Jump
        _isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, groundCheckRadius, groundLayer);
        if (_isTouchingFront && !_isGrounded && _movement.x != 0 && canWallJump) {
            _wallSliding = true;
        } else {
            _wallSliding = false;
        }

        if (_wallSliding) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetButtonDown("Jump") && _wallSliding) {
            _wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (_wallJumping) {
            _rigidbody.velocity = new Vector2(xWallForce * -_movement.x, yWallForce);
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetBool("Dash", _isDashing);
        _animator.SetBool("Wall", _wallSliding);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        if (_wallJumping) {
            _animator.SetTrigger("DoubleJump");
        }
        if (Input.GetButtonDown("Jump")) {
            if (_jumpCount <= 1) {
                _animator.SetTrigger("Jump");
            } else {
                _animator.SetTrigger("DoubleJump");
            }
        }
        if (Input.GetButtonUp("Jump")) {
            _animator.ResetTrigger("Jump");
            _animator.ResetTrigger("DoubleJump");
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
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _jumpCount++;
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _rigidbody.gravityScale;
        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rigidbody.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        _canDash = true;
    }

    void SetWallJumpingToFalse() {
        _wallJumping = false;
    }

    void Damage()
    {
        if (!_hitEnemy)
        {
            life--;
            _animator.SetTrigger("Damaged");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _hitEnemy && !_hitedEnemy)
        {
            _jumpCount--;
            Jump();
            _hitedEnemy = true;
            collision.gameObject.SendMessage("Damage");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _hitedEnemy = false;
        }
    }
}
