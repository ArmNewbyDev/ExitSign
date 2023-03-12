using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTalkAndLoadScene : MonoBehaviour
{
    [SerializeField] private StartDialogue dialogue;
    [SerializeField] private GameObject Text;
    [SerializeField] private LoadScene scene;
    bool Stop = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.Finish)
        {
            if (!Text.activeSelf)
            {
                if (!Stop)
                {
                    scene.LoadScene_0();
                    Stop = true;
                }

            }
        }

    }
}
