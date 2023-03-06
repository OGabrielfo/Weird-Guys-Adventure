using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPatrolUnsee : MonoBehaviour
{
    private Renderer render;

    void Awake()
    {
        render = GetComponent<Renderer>();

        render.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
