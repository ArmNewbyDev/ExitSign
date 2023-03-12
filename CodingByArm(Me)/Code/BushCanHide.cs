using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCanHide : MonoBehaviour
{
    public bool CanHide = false;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CanHide")
        {
            CanHide=true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CanHide")
        {
            CanHide = false;
        }
    }
}
