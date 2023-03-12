using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockForBlockWay : MonoBehaviour
{
    [SerializeField] private GameObject rockBlockTheWay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rockBlockTheWay.SetActive(true);
        }
    }
}
