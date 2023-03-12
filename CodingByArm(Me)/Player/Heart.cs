using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyPlatform;


public class Heart : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private int life;
    private bool dead;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource MBG_NorSan;
    [SerializeField] private AudioSource MBG_LowSan;
    [SerializeField] private AudioSource GhostHunt;

    private void Start()
    {

        life = HeartCheck.instance.HMHeartLeft();
        CheckLifeLeft();

    }

    void Update()
    {
        if (!GameManager.GhostIsCHARGE)
        {
            GhostHunt.enabled = false;
            if (life > 0)
            {
                MBG_NorSan.enabled = true;
            }
/*            else if (life > 0)
            {
                MBG_LowSan.enabled = true;
                MBG_NorSan.enabled = false;
            }*/
            else
            {
                MBG_LowSan.enabled = false;
                MBG_NorSan.enabled = false;
            }
        }
        else
        {
            GhostHunt.enabled = true;
        }
        
    }
    private void CheckLifeLeft()
    {
        switch (life)
        {
            case 3:
                hearts[3].gameObject.SetActive(false);
                break;
                case 2:
                hearts[3].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                break;
                case 1:
                hearts[3].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                break ;
                

        }

    }
    public void takeDamage(int damage)
    {
        life -= damage;
        //Destroy(hearts[life].gameObject);
        hearts[life].gameObject.SetActive(false);
        
        animator.SetTrigger("Hit");
        if (life < 1)
        {
            dead = true;
        }
        //StartCoroutine(waitforsecond(1));
    }
    IEnumerator waitforsecond(int num)
    {
        yield return new WaitForSeconds(num);
    }
    
    public void Reborn()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
        dead = false;
        life = hearts.Length;
    }
    public void LoadSaveHeartLeft(int heartLeft)
    {
        life = heartLeft;
    }

    public int GetNumberHeartLeft()
    {
        return life;
    }

    public bool IsDeadYet()
    {
        return dead;
    }
}
