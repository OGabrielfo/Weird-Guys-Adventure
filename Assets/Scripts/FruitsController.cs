using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    private int _minValue = 0;
    private int _maxValue = 7;
    public int _randomValue;

    private GameObject stageControllerObject;
    private StageController stageController;
    private Animator _anim;

    private void Awake()
    {
        stageControllerObject = GameObject.FindGameObjectWithTag("StageController");
        stageController = stageControllerObject.GetComponent<StageController>();
        _anim = GetComponent<Animator>();
        _randomValue = Random.Range(_minValue, _maxValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        _anim.SetInteger("Id", _randomValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("Collected");
        }
    }

    void Collected()
    {
        stageController.AddPoint();
        Destroy(gameObject);
    }
}
