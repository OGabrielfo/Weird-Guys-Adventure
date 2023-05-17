using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public GameObject stageController;

    private StageController _stageController;
    private Animator _anim;

    private void Awake()
    {
        _stageController = stageController.GetComponent<StageController>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player em colisão");
            _stageController.UpdatePosition(transform.position);
            _anim.SetBool("Active", true);
        }
    }
}
