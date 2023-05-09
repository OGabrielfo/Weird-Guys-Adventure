using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public int life;
    public PlayerIdentifier attackArea;
    public float attackDelay;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private Animator _anim;
    private Transform _playerPosition;
    private float _timer = 0;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackArea.transform.position = new Vector2(transform.position.x, attackArea.transform.position.y);

        if (attackArea.playerInArea)
        {
            Vector2 direction = _playerPosition.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, -direction);
            transform.rotation = lookRotation;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }


        if (_timer <= 0)
        {
            if (attackArea.playerInArea)
            {
                _anim.SetTrigger("Attack");
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * bulletSpeed;
                _timer = attackDelay;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        
        
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
}
