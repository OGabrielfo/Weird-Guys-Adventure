using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPatrolUnsee : MonoBehaviour
{
    private SpriteRenderer render;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();

        render.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
