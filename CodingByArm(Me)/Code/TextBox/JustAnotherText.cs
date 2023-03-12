using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustAnotherText : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject Text;
    [SerializeField] private bool ForOnce = false;
    public bool _Finish = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.Finish)
        {

            if (!ForOnce)
            {
                Text.SetActive(true);
            }
            else
            {
                if (!_Finish)
                {
                    Text.SetActive(true);
                    _Finish = true;
                }
            }
            
        }
    }
}
