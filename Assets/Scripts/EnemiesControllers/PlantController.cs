using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public int life;
    public Transform firePoint;
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
    void FixedUpdate()
    {
        Vector2 playerDirection = _playerPosition.position - transform.position;
        Vector2 selfDirection = firePoint.position - transform.position;
        bool sameDirection;

        if ((playerDirection.x < 0 && selfDirection.x < 0) || (playerDirection.x > 0 && selfDirection.x > 0))
        {
            sameDirection = true;
        }
        else
        {
            sameDirection = false;
        }

        if (_timer <= 0)
        {
            if (_playerPosition.position.y >= transform.position.y - 1.5f && _playerPosition.position.y <= transform.position.y + 1.5f && sameDirection)
            {
                _anim.SetTrigger("Attack");
                _timer = attackDelay;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
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
