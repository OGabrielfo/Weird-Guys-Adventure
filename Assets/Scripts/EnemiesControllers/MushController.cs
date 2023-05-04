using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushController : MonoBehaviour
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
        
    }
}
