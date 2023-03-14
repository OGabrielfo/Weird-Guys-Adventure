using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyObject enemySettings;

    public string name;
    public float health;
    public float speed;
    public float waitingTime;

    public Vector2 colliderOffset;
    public Vector2 colliderSize;

    public bool canPatrol;
    public bool canJump;
    public bool canFly;
    public bool canShoot;
    public bool canGuard;
    public bool canAttack;
    public bool canFollow;

    private Animator _anim;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider;

    private bool _facingRight;
    private float _actualSpeed;

    private void Awake() {
        _anim = GetComponent<Animator>();
        _anim.runtimeAnimatorController = enemySettings.animController;

        name = enemySettings.name;
        health = enemySettings.health;
        speed = enemySettings.speed;
        waitingTime = enemySettings.waitingTime;

        colliderOffset = enemySettings.colliderOffset;
        colliderSize = enemySettings.colliderSize;

        canPatrol = enemySettings.canPatrol;
        canJump = enemySettings.canJump;
        canFly = enemySettings.canFly;
        canShoot = enemySettings.canShoot;
        canGuard = enemySettings.canGuard;
        canAttack = enemySettings.canAttack;
        canFollow = enemySettings.canFollow;

        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();

        _facingRight = false;
        _actualSpeed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {

        CanFly();
        DefineCollider();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPatrol) {
            EnemyPatrol();
        }
    }

    void FixedUpdate() {
        _anim.SetFloat("Health", health);
        _anim.SetFloat("HorizontalVelocity", _rb.velocity.x);
        _anim.SetFloat("VerticalVelocity", _rb.velocity.y);
        _anim.SetBool("Idle", _actualSpeed == 0);
    }

    void LateUpdate() {
        
    }

    #region CONFIGURAÇÕES DINÂMICAS
    void DefineCollider() {
        _capsuleCollider.offset = colliderOffset;
        _capsuleCollider.size = colliderSize;
    }

    #endregion

    #region MECÂNICAS

    #region Voar
    void CanFly() {
        if (canFly) {
            _rb.gravityScale = 0;
        }
    }

    #endregion

    #region Patrulha
    //---------------------------------------ENEMY PATROL MOVEMENT---------------------------------------
    void Flip() {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void EnemyPatrol() {
        if (_actualSpeed != 0) {
            if (!_facingRight) {
            _actualSpeed = speed * -1;
            } else {
            _actualSpeed = speed;
            }
            _rb.velocity = new Vector2(_actualSpeed, _rb.velocity.y);
        }
    }

    private IEnumerator WaitingTime() {
        _actualSpeed = 0;
        _rb.velocity = new Vector2(_actualSpeed, _rb.velocity.y);
        yield return new WaitForSeconds(waitingTime);
        Flip();
        _actualSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PatrolLimiter")) {
            StartCoroutine("WaitingTime");
        }
    }

    #endregion

    #region Pulo

    #endregion

    #region Atirar

    #endregion

    #region Defender

    #endregion

    #region Atacar

    #endregion

    #region Perseguir

    #endregion


    #endregion
}
