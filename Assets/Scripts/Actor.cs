using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected Vector3 Playerpos;
    protected  Vector3 EnemyPos;
    protected  Vector3 pushDir;
    protected float pushTime=0f;
    [SerializeField]
    protected float pushRecovery;
    [SerializeField]
    protected float pushForce;

    protected virtual void Knockback(Collision2D other)
    {

    }
}
