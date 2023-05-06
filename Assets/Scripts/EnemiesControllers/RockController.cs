using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public int life;
    public Vector2[] offsets;
    public float[] radius;

    private Animator _anim;
    private CircleCollider2D _col;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _col = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _col.offset = offsets[life - 1];
        _col.radius = radius[life - 1];
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
