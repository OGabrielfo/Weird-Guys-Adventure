using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonController : MonoBehaviour
{
    public int life;
    //public PlayerIdentifier attackArea;
    public float attackDelay;
    public float playerDistance;

    private Transform _player;
    private BoxCollider2D _attackCol;
    private Animator _anim;
    private float _timer = 0;
    private bool _attacking = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _attackCol = GetComponent<BoxCollider2D>();
        _player = GameObject.FindWithTag("Player").transform;

        _attackCol.enabled = _attacking;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0)
        {
            float distancia = Vector2.Distance(transform.position, _player.position);
            if (distancia <= playerDistance )
            {
                _anim.SetTrigger("Attack");
                _timer = attackDelay;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
        _attackCol.enabled = _attacking;
    }

    void LateUpdate()
    {
        _anim.SetInteger("Life", life);
    }

    void Attack()
    {
        if (_attacking == true)
        {
            _attacking = false;
        }
        else
        {
            _attacking = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
        }
    }

    void Damage()
    {
        life--;
        _anim.SetTrigger("Damaged");
    }
}
