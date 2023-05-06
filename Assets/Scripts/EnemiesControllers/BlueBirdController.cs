using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdController : MonoBehaviour
{
    public int life;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
