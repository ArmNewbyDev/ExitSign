using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatform;

public class StartDialogue : MonoBehaviour
{
    public GameObject dialogue;
    public bool Finish = false;
    [SerializeField] GameManager gameManager;
    [SerializeField] bool OnStart = false;
    
    [SerializeField]bool PlaySound = false;
    [SerializeField]bool WaitForSecBStart = false;
    [SerializeField] float time = 1f;
    [SerializeField]SoundManager.SoundName soundName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Finish)
        {
            if (PlaySound)
            {
                SoundManager.instance.Play(soundName);
            }           
            dialogue.SetActive(true);
            Finish = true;
            
        }
    }
    IEnumerator WaitBeforeText()
    {
        yield return new WaitForSeconds(time);
        dialogue.SetActive(true);
        Finish = true;
    }
    private void Start()
    {
        if (WaitForSecBStart)
        {
            StartCoroutine(WaitBeforeText());
        }
        else if (OnStart)
        {
            dialogue.SetActive(true);
            Finish = true;
        }
        
    }

}
