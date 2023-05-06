using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public float life;
    public float jumpForce;
    public float distanciaMaximaDoPlayer;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private Rigidbody2D _rb;
    private Animator _anim;
    private GameObject _player;
    private int _jumpCount = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(_player.transform.position.x >= _rb.position.x - distanciaMaximaDoPlayer && _player.transform.position.x <= _rb.position.x + distanciaMaximaDoPlayer && IsGrounded())
        {
            Jump();
        }
    }

    private void LateUpdate()
    {
        _anim.SetFloat("VerticalVelocity", _rb.velocity.y);
        _anim.SetBool("Grounded", IsGrounded());
    }

    void Jump()
    {
        _jumpCount++;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _anim.SetTrigger("Jump");
    }

    bool IsGrounded()
    {
        
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage");
        }
    }

    void Damage()
    {
        life--;
        _anim.SetTrigger("Damaged");
    }
}
