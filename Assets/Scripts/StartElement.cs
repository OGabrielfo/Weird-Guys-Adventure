using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartElement : MonoBehaviour
{
    public Transform startPoint;
    public GameObject stageController;

    private StageController _stageController;

    private void Awake()
    {
        _stageController = stageController.GetComponent<StageController>();

        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_stageController.tries <= 1)
        {
            _stageController.UpdatePosition(startPoint.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
