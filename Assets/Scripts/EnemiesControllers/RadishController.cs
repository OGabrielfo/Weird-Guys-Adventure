using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishController : MonoBehaviour
{
    public int life;
    public Transform leafsPoint;
    public GameObject leafsPrefab;

    private Animator _anim;
    private Rigidbody2D _rb;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 2)
        {
            _rb.gravityScale = 1f;
        }
    }

    private void LateUpdate()
    {
        _anim.SetInteger("Life", life);
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

    void LoseLeafs()
    {
        if (life >= 1)
        {
            GameObject leafs = Instantiate(leafsPrefab, leafsPoint.position, Quaternion.identity);
        }
    }
}
