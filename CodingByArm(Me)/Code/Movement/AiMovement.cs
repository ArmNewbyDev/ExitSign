using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float stoppingDistance;
    bool facingRight = true;

    public Animator animator;
    private Rigidbody2D rb;
    private Transform target;

    private Rigidbody2D _rbMonster;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = target.GetComponent<Rigidbody2D>();
        _rbMonster = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        animator.SetFloat("Speed",Mathf.Abs(_rbMonster.velocity.magnitude));
    }

    void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0f, 180f, 0f);
    }
}
