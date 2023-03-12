using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    private SpriteRenderer _renderer;
    private bool canHide;
    private bool hiding;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
        if (canHide && Input.GetKey(KeyCode.Space))
        {
            Physics2D.IgnoreLayerCollision(8 ,9,true);
            _renderer.sortingOrder = 0;
            hiding = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8 ,9,false);
            _renderer.sortingOrder = 2;
            hiding = false;
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Bush"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Bush"))
        {
            canHide = false;
        }
    }
}
