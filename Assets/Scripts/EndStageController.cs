using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStageController : MonoBehaviour
{
    public Transform startPoint;
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
            PlayerController _playerController;
            _stageController.UpdatePosition(startPoint.position);
            _stageController.tries = 0;
            _anim.SetBool("EndStage", true);
            _playerController = collision.gameObject.GetComponent<PlayerController>();
            _playerController.StartCoroutine("EndStage");
        }
    }
}
