using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurtleController : MonoBehaviour
{
    public int life;
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
        if(_defense)
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
        _anim.SetBool("Defense", _defense);
        _anim.SetInteger("Life", life);
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
