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

    [SerializeField]
    protected int Hp;
    [SerializeField]
    protected int dmgAmount;

    public virtual void dmg(Vector3 pos, float force)
    {

    }
    public virtual void dmg(Vector3 pos,float force,float dmg)
    {

    }
    public virtual int HpLeft()
    {
        return Hp;
    }
    public virtual int DmgDone()
    {
        return dmgAmount;
    }
}
