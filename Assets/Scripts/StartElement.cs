using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartElement : MonoBehaviour
{
    public Transform startPoint;
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        _player.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
