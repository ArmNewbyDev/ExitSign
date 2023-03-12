using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatform;

public class Interact : MonoBehaviour
{
    public GameObject something;
    public bool loopText = false;

    Dialogue dialogue;

    [SerializeField] bool PlaySound = false;
    [SerializeField] SoundManager.SoundName soundName;
    [SerializeField] bool RemovethisThing = false;
    [SerializeField] GameObject ForRemove;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")

        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlaySound)
                {
                    SoundManager.instance.Play(soundName);
                }
                if (RemovethisThing)
                {
                    ForRemove.SetActive(false);
                }
                if (something.activeSelf == false)
                {
                    something.SetActive(true);
                    if (loopText)
                    {
                        dialogue.LoopText();
                    }
                }

            }
        }

    }
    private void Start()
    {
        if (loopText)
        {
            dialogue = something.GetComponent<Dialogue>();
        }
    }
    /*    private void OnTriggerExit2D(Collider2D collision)
        {
            something.SetActive(false);
        }*/
}
