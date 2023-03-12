using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatform;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Heart life;
    //[SerializeField] private GameObject target;
    private PlayerController pc;
    [SerializeField] private int damage = 1;

    [SerializeField] private AudioSource audioWalk;
    [SerializeField]bool facingRight = true;

    [SerializeField] private bool ForShow = false;

    public Animator animator;

    [Header("Pathfinding")]
    public GameObject target;
    public float activateDistance = 50f;
    //public float pathUpdateSeconds = 0.5f;

    //[Header("Custom Behavior")]
    //public bool followEnabled = true;
   //public bool directionLookEnabled = true;

/*    private Path path;
    private int currentWaypoint = 0;
    Seeker seeker;
    Rigidbody2D rb;*/

    AIPath aipath;
    AnimationClip a;
    private void Start()
    {
        pc = target.GetComponent<PlayerController>();
        //rb = GetComponent<Rigidbody2D>();
        //seeker = GetComponent<Seeker>();
        
        aipath = GetComponent<AIPath>();

       //InvokeRepeating("UpdatePath", 0f ,pathUpdateSeconds);
        audioWalk.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D col)

     {

         if (col.CompareTag("Player"))
        {
            if (!life.IsDeadYet())
            {
                life.takeDamage(damage);
                HeartCheck.instance.GetDamage(damage);
                pc.OnHit();
                SoundManager.instance.Play(SoundManager.SoundName.M1_B_Hit);
            }

         }
         
     }

    private void FixedUpdate()
    {

        if (!ForShow) {
            
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (GameManager.GameHasPause)
            {
                aipath.enabled = false;
                audioWalk.enabled = false;
            }
            else
            {
                aipath.enabled = true;
            }
            if (direction.magnitude > 0.1)
            {
                audioWalk.enabled = true;
            }
            else
            {
                audioWalk.enabled = false;
            }
            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            if (direction.x < 0 && facingRight)
            {
                Flip();
            }
            animator.SetFloat("Speed", Mathf.Abs(direction.magnitude));

        }
        else
        {
            animator.SetFloat("Speed", 0);
            aipath.enabled = false;
            audioWalk.enabled = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0f, 180f, 0f);
    }

    public void EnemyStop()
    {
        
        ForShow = true;
    }
    public void EnemyRun()
    {
        ForShow = false;
    }

/*    void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
        }
    }

    void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }
    }

    bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }*/
}
