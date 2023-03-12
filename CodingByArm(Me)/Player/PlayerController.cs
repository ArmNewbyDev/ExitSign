using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatform;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float NormalSpeed = 2;
    [SerializeField] private float RunSpeed = 5;
    [SerializeField] private float DuckSpeed = 1;
    //[SerializeField] private float Sanity = 100f;
    [SerializeField] private AudioSource WalkSound;
    [SerializeField] private AudioSource RunSound;

    private float Speed = 3;
    private int stamina = 0;
    private bool CanHide = false;

    private bool IsRun = false;
    bool OneTimeDead = false;
    private bool IsDead = false;
    private bool IsDuck = false;
    private bool IsHide = false;
    private Rigidbody2D rb;
    private Vector2 movementNewInput;
    private Animator animator;

    [SerializeField] private Heart Heart;

    private int _HeartLeft = 0;
    [SerializeField] private GameObject _gameObjectCanHide;
    [SerializeField] private LoadScene _loadScene;
    private BushCanHide _BushCanHide;

    bool GameIsPause = false;
    [SerializeField] GameObject pauseMenuUI;

    private float moveX;
    private float moveY;
    private bool DieOneTimeIsEnough = false;

    [SerializeField]bool facingRight = true;


    private void Start()
    {
        Speed = NormalSpeed;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _BushCanHide = _gameObjectCanHide.GetComponent<BushCanHide>();
        //_HeartLeft = Heart.GetComponent<Heart>().GetNumberHeartLeft();
        //_HeartLeft = Heart.GetNumberHeartLeft();

    }


    void OnMove()
    {
        //moveX = Input.GetAxisRaw("Horizontal");
        //moveY = Input.GetAxisRaw("Vertical");
        //movementNewInput = new Vector2(moveX, moveY).normalized;
        if (!IsDead && GameManager.GameHasPause == false)
        {
            animator.SetBool("StandStill", false);
            if (!IsHide)
            {
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");
                if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
                {
                    if (!IsRun || !IsDuck)
                    {
                       WalkSound.enabled = true;
                    }
                    else
                    {
                        WalkSound.enabled = false;
                    }
                    if (moveX > 0 && !facingRight)
                    {
                        Flip();
                    }
                    if (moveX < 0 && facingRight)
                    {
                        Flip();
                    }
                    if (!IsDuck)
                    {
                        if(StaminaBar.instance != null)
                        {
                            if (Input.GetKey(KeyCode.LeftShift) && stamina != 0)
                            {
                                Speed = RunSpeed;
                                StaminaBar.instance.UseStamina(1);
                                animator.SetBool("IsRun", true);
                                IsRun = true;
                                //SoundManager.instance.Play(SoundManager.SoundName.P_Run);
                                RunSound.enabled = true;

                            }
                            else
                            {
                                animator.SetBool("IsRun", false); Speed = NormalSpeed;
                                IsRun = false;
                                RunSound.enabled = false;
                            }
                        }

                        
                    }
                    else
                    {
                        animator.SetFloat("SpeedOnDuck", Mathf.Abs(moveX) + MathF.Abs(moveY));
                        Speed = DuckSpeed;

                    }

                    if (Input.GetKeyDown(KeyCode.V)) //Player Duck
                    {
                        Duck();


                    }
                }
                else
                {
                    WalkSound.enabled = false;
                    RunSound.enabled = false;
                }
                animator.SetFloat("Speed", Mathf.Abs(moveX) + MathF.Abs(moveY));
                movementNewInput = new Vector2(moveX, moveY).normalized;
                rb.velocity = new Vector2(movementNewInput.x * Speed, movementNewInput.y * Speed);
            }
            else
            {
                rb.velocity = Vector2.zero;
                RunSound.enabled = false;
                WalkSound.enabled = false;
            }

        }
        else
        {
            rb.velocity = Vector2.zero;

            if (!IsDead)
            {
                animator.SetBool("IsRun", false);
                animator.SetFloat("Speed", 0);
                animator.SetBool("StandStill",true);
            }

            RunSound.enabled = false;
            WalkSound.enabled = false;
        }
        
    }
    IEnumerator waitforDead(int num)
    {
        yield return new WaitForSeconds(num);
        GotoDeadScene();
    }

    void Dead()
    {
        //IsDead = true;

        if (!IsDead)
        {
            animator.SetBool("IsDead",false);
        }
        else 
        {
            if (!OneTimeDead)
            {
                SoundManager.instance.Play(SoundManager.SoundName.P_Dead);
                OneTimeDead = true;
            }
            animator.SetBool("IsDead", true);
            StartCoroutine(waitforDead(3));
            
        }

    }
    void GotoDeadScene()
    {
        if (!DieOneTimeIsEnough)
        {
            _loadScene.Dead();
            DieOneTimeIsEnough = true;
        }
        
    }
    public void OnHit()
    {
        //_HeartLeft -= 1;
        SoundManager.instance.Play(SoundManager.SoundName.P_B_Hit);
        
        if (_HeartLeft>1)
        {
            animator.SetTrigger("Hit");
            
        }
        
    }

    void Duck()
    {
        if (!IsDuck)
        {
            animator.SetBool("IsDuck", true);
            IsDuck = true;

        }
        else
        {
            animator.SetBool("IsDuck", false);
            IsDuck = false;
        }
        SoundManager.instance.Play(SoundManager.SoundName.P_Bent);
    }

    void Hide()
    {
        if (!IsHide) 
        {
            animator.SetBool("IsHide",true);
            IsHide = true;
            gameObject.transform.localScale = new Vector3(0.04f,0.04f,0.04f);
            if (!facingRight)
            {
                facingRight = true;
            }
            
        }
        else
        {
            animator.SetBool("IsHide", false);
            IsHide = false;
            gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }

        SoundManager.instance.Play(SoundManager.SoundName.P_Bush);
    }
    public void Rebirth()
    {
        IsDead=false;
        _HeartLeft = Heart.GetNumberHeartLeft();
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameManager.instance.Continue();
        GameIsPause = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        GameManager.instance.StopWaitMinute();
        GameIsPause = true;
    }

    void LoadSavePlayer()
    {
        Heart.LoadSaveHeartLeft(_HeartLeft);
    }

    private void Update()
    {
        if (StaminaBar.instance != null)
        {
            stamina = StaminaBar.instance.staminaLeft();
        }
        
        //
        if (!PauseMenu.GameIsPause)
        {
            OnMove();

        }
        
        //
        CanHide = _BushCanHide.CanHide;
        _HeartLeft = Heart.GetNumberHeartLeft();
        IsDead = Heart.IsDeadYet();

        if (IsDead)
        {
            Dead();
        }
        else
        {
            Dead();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        if (CanHide)
        {
            if (Input.GetKeyDown(KeyCode.C)) // Player Hide
            {
                
                Hide();
            }
        }

    }


}
