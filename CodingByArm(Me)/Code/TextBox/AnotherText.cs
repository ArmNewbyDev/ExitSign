using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherText : MonoBehaviour
{
    [SerializeField] private StartDialogue dialogue;
    [SerializeField] private GameObject NextText;
    public static bool isCutSceneOn;
    [Header("If not have Let it null")]
    public Animator camAnim;
    public Enemy Mons;

    public bool _Finish = false;
    [SerializeField] private int timeStopForCam = 3;


    [SerializeField] bool NoText = false;
    // Update is called once per frame
    void Update()
    {

            if (dialogue.Finish)
            {
                if (!dialogue.dialogue.activeSelf)
                {
                    if (camAnim != null)
                    {
                        camAnim.SetBool("cutscene1", true);
                    }
                    isCutSceneOn = true;

                    if (Mons != null)
                    {
                        Mons.gameObject.SetActive(true);
                        Mons.EnemyStop();
                    }

                    CamForSec();
                    StartCoroutine(CamForSecond(timeStopForCam));
                }
            }
        

    }
    void CamForSec()
    {
        GameManager.instance.StopWaitMinute();
    }
    IEnumerator CamForSecond(int num)
    {
        yield return new WaitForSeconds(num);
        StopCutScene();
        GameManager.instance.Continue();
    }
    void StopCutScene()
    {
        isCutSceneOn = false;
        if (camAnim != null)
        {
            camAnim.SetBool("cutscene1", false);
        }
        if (Mons != null)
        {
            Mons.EnemyRun();
        }
        if (!NoText)
        {
            NextText.SetActive(true);
        }
        
        _Finish = true;
        gameObject.SetActive(false);
    }
}
