using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public RuntimeAnimatorController[] animatorControllers;
    public Sprite[] sprites;

    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private static int _id;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void SetVisual(int id)
    {
        _id = id;
        _spriteRenderer.sprite = sprites[_id];
        _anim.runtimeAnimatorController = animatorControllers[_id];
    }
}
