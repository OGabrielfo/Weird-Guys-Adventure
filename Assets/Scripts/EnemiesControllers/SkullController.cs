using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    public int life;
    public float speed;
    public PlayerIdentifier attackArea;
    public float minDefenseTimer;
    public float maxDefenseTimer;

    private float _timer;
    private bool _defense;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Defense");
    }

    // Update is called once per frame
    void Update()
    {
        if (_defense)
        {
            gameObject.layer = LayerMask.NameToLayer("DefensedEnemy");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }

    private void LateUpdate()
    {
        _anim.SetBool("ChasingPlayer", attackArea.playerInArea);
        _anim.SetInteger("Life", life);
        _anim.SetFloat("Velocity", speed);
        _anim.SetBool("Defense", _defense);
    }

    IEnumerator Defense()
    {
        _timer = Random.Range(minDefenseTimer, maxDefenseTimer);
        yield return new WaitForSeconds(_timer);
        _defense = !_defense;
        StartCoroutine("Defense");
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
