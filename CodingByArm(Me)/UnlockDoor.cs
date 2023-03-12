using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject UnlockDoorSomeWhere;
    public GameObject RemoveOldDialogeAtDoor;
    public GameObject DialogeHere;
    public GameObject MonsRunTracker;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (MonsRunTracker != null)
            {
                MonsRunTracker.SetActive(true);
            }

            UnlockDoorSomeWhere.SetActive(true);
            RemoveOldDialogeAtDoor.SetActive(false);
            DialogeHere.SetActive(true);

            sprite.enabled = false;
        }
    }


}
