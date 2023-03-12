using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject teleport;
    [SerializeField] GameObject cam;
    GameObject player;
    [SerializeField]Animator animator;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (cam != null)
            {
                if (cam.activeSelf == false)
                {
                    cam.SetActive(true);
                    player.transform.position = new Vector2(teleport.transform.position.x,teleport.transform.position.y);
                    animator.SetTrigger("Fade");
                }
                else
                {
                    cam.SetActive(false);
                    player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);
                    animator.SetTrigger("Fade");
                }
            }
            else
            {
                player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);
                animator.SetTrigger("Fade");
            }
        }
        
    }

}
