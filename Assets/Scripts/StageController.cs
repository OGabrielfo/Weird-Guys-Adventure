using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public int points;
    public bool activateCheckPoint;

    public static int playerVisual;
    public int tries;

    public GameObject pointsUI;

    private PlayerController _playerController;
    private TextMeshProUGUI _textPoints;
    //private PlayerVisual _playerVisual;
    private float _timer;
    private static int _tries = 0;
    private static Vector2 _startPoint;
    private static int _savedPoints;
    

    private void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //_playerVisual = _playerController.GetComponent<PlayerVisual>();
        _timer = 2f;
        _tries++;
        tries = _tries;
        _textPoints = pointsUI.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = _startPoint;
        points = _savedPoints;
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
        //_playerVisual.SetVisual(playerVisual);
    }

    private void LateUpdate()
    {
        _textPoints.text = points.ToString();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void UpdatePosition(Vector2 position)
    {
        _startPoint = position;
        _savedPoints = points;
    }

    public void AddPoint()
    {
        points++;
    }
}
