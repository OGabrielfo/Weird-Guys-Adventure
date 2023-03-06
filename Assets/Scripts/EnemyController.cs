using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyObject enemySettings;

    public string name;
    public float health;
    public float speed;

    public bool canPatrol;
    public bool canJump;
    public bool canFly;
    public bool canShoot;
    public bool canGuard;
    public bool canAttack;
    public bool canFollow;

    private Animator anim;
    private Rigidbody2D rb;

    private void Awake() {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = enemySettings.animController;

        name = enemySettings.name;
        health = enemySettings.health;
        speed = enemySettings.speed;

        canPatrol = enemySettings.canPatrol;
        canJump = enemySettings.canJump;
        canFly = enemySettings.canFly;
        canShoot = enemySettings.canShoot;
        canGuard = enemySettings.canGuard;
        canAttack = enemySettings.canAttack;
        canFollow = enemySettings.canFollow;

        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CanFly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CanFly() {
        if (canFly) {
            rb.gravityScale = 0;
        }
    }
}
