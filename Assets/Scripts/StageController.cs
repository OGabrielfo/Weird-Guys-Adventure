using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public bool activateCheckPoint;

    public int playerVisual = 1;

    private PlayerController _playerController;
    private PlayerVisual _playerVisual;
    private float _timer;

    private void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerVisual = _playerController.GetComponent<PlayerVisual>();
        _timer = 2f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_playerController.life <= 0)
        {
            if(_timer <= 0)
            {
                _timer = 2f;
                ResetScene();
            }
            else
            {
                _timer -= Time.deltaTime;
            }
            
        }

        _playerVisual.SetVisual(playerVisual);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Stage01");
    }
}
