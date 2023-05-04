using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BatController : MonoBehaviour
{
    public int life;
    public float speed;
    public GameObject ceilingPoint;
    public PlayerIdentifier attackArea;

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
        _anim.SetBool("ChasingPlayer", attackArea.playerInArea);
        _anim.SetInteger("Life", life);
        _anim.SetFloat("Velocity", speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CeilingPoint") && _anim.GetBool("ChasingPlayer") == false)
        {
            _anim.SetBool("Idle", true);
        }
    }
}
