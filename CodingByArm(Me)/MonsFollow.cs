using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsFollow : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] bool IsEnemyFollow = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsEnemyFollow)
            {
                enemy.EnemyRun();
            }
            else
            {
                enemy.EnemyStop();
            }
            
        }
    }
}
