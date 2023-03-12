using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatform;
public class EndDemo : MonoBehaviour
{
    [SerializeField] private Animator BlackFade;
    [SerializeField] private StartDialogue dialogue;
    [SerializeField] private GameObject cam;
    
    public Animator camAnim;
    public GameObject UIPlayer;

    bool FinishPlayDeadSound = false;
    bool FinishPlaySoundReverse = false;
    bool FinishLoadScene = false;
    bool FinishFade = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.Finish)
        {
            if (!dialogue.dialogue.activeSelf)
            {
                UIPlayer.SetActive(false);
                cam.SetActive(true);
                if (!FinishPlaySoundReverse)
                {
                    SoundManager.instance.Play(SoundManager.SoundName.ReversePiano);
                    camAnim.SetBool("Zoom", true);
                    FinishPlaySoundReverse = true;
                }
                
                
                StartCoroutine(WaitForCam());
                
            }
        }
    }

    IEnumerator WaitForCam()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(PlaySoundBeforeDead());
        if (!FinishFade)
        {
            BlackFade.SetTrigger("Fade");
            FinishFade = true;
        }
    }
    IEnumerator PlaySoundBeforeDead()
    {
        yield return new WaitForSeconds(3);
        if (!FinishPlayDeadSound)
        {
            SoundManager.instance.Play(SoundManager.SoundName.P_Dead);
            FinishPlayDeadSound = true;
        }
        
        StartCoroutine(DeadScene());
    }
    IEnumerator DeadScene()
    {
        yield return new WaitForSeconds(3);
        if (!FinishLoadScene)
        {
            
            LoadingScreenController.instance.LoadNextScene("End_Demo");
            FinishLoadScene = true;
        }
        
    }

}
