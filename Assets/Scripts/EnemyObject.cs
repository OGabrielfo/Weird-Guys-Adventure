using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New_Enemy", menuName ="Enemy/New Enemy")]
public class EnemyObject : ScriptableObject
{
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

    public RuntimeAnimatorController animController;
}
