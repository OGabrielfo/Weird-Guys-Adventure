using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public float jumpForce;

    private Animator _anim;
    private Rigidbody2D _playerRb;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerRb.velocity = Vector2.zero;
            _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetTrigger("Jump");
        }
    }
}
