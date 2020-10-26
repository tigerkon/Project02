using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    private float ViewRange = 360f;
    private float RayRange = 50f;
    private int vel = 20;
    private float timer = 3f;

    public RaycastHit LastPos;
    public Vector3 RayDirection = Vector3.zero;

    public GameObject target;
    public GameObject enemy;


    public Rigidbody Bullet;
    public Transform Muzzle;
    public Level01Controller level01Controller;

    int health = 20;

    

    public void Update()
    {
        RayDirection = Player.transform.position - transform.position;

            if (Vector3.Angle(RayDirection, transform.forward) < ViewRange)
        {
            if (Physics.Raycast(transform.position, RayDirection, out LastPos, RayRange))
            {
                if (LastPos.collider.tag == "Player")
                {
                    Attack();
                }
            }
        }
           if (health <= 0)
        {
            Death();
            level01Controller.IncreaseScore(10);
        }
    }

    public void TakeDamage(int _damageToTake)
    {
        health -=_damageToTake;
    }

    public void Attack()
    {
        transform.LookAt(LastPos.transform.position);
        if (RayDirection.magnitude > 20)
        {
            enemy.transform.position = Vector3.MoveTowards(transform.position, LastPos.transform.position, Time.deltaTime * vel);
        }

        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Rigidbody b = GameObject.Instantiate(Bullet, Muzzle.position, Muzzle.rotation) as Rigidbody;
                b.AddForce(750 * b.transform.forward);
                timer = 5f;
            }

            

        }

    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
