using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool loop = false;
    public bool Finish = false;
    //public bool Finish = false;

    private int index;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Finish = false;
        textComponent.text = string.Empty;
        StartDialogue();
        GameManager.instance.StopWaitMinute();
    }
    public void LoopText()
    {
        Finish = false;
        textComponent.text = string.Empty;
        StartDialogue();
        GameManager.instance.StopWaitMinute();
    }
    // Update is called once per frame
    void Update()
    {
        //left click to move to next message, if there is no more message text box will be remove
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //checking if there is a next message to show
        if (index < lines.Length - 1)
        {
            
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            GameManager.instance.StopWaitMinute();
        }
        else
        {
            GameManager.instance.Continue();
            Finish = true;
            gameObject.SetActive(false);
        }
    }
}
