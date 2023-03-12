using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMonActive : MonoBehaviour
{
    [SerializeField] Enemy Mon;
    public StartDialogue dialogue;

    public AnotherText TextAnim;

    void Update()
    {
        if (dialogue != null)
        {
            if (dialogue.Finish)
            {
                if (TextAnim != null)
                {
                    if (TextAnim._Finish)
                    {
                        Mon.EnemyRun();
                    }
                }
                else
                    Mon.EnemyRun();

            }
        }

        if (TextAnim != null)
        {
            if (TextAnim._Finish)
            {
                Mon.EnemyRun();
            }
        }
    }
}
