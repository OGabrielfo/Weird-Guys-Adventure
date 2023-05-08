using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public PlayerIdentifier attackArea;
    public float attackDelay;

    private Animator _anim;
    private float _timer = 0;

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
        

        if(_timer <= 0)
        {
            if (attackArea.playerInArea)
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

    private void FixedUpdate()
    {
        
        
    }
}
