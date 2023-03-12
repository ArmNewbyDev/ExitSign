using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyPlatform;



    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private SceneName NextScene;
        private string _sceneName;
    private bool Reset = false;
    private void Start()
    {
        _sceneName = NextScene.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Reset)
            {
                HeartCheck.instance.ResetGame();
            }
            LoadingScreenController.instance.LoadNextScene(_sceneName);
            
        }
    }

    public void LoadNextSceneTo(string name)
    {
        LoadingScreenController.instance.LoadNextScene(name);

    }
    public void Dead()
    {
        LoadingScreenController.instance.LoadNextScene("DeadScene");
    }
    public void LoadMenu()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.LoadNextScene("Menu");
    }
    public void LoadScene_Story()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.LoadNextScene("Story");
        HeartCheck.instance.ResetGame();
        
    }
    public void LoadScene_0()
    {
        LoadingScreenController.instance.LoadNextScene("Scene_0");
        GameManager.instance.Continue();
    }
    public void LoadScene_1()
    {
        LoadingScreenController.instance.LoadNextScene("Scene_1");
        
    }
    public void LoadSaveGame()
    {

    }
    public void Exit()
    {
        SoundManager.instance.Play(SoundManager.SoundName.UISoundMenu);
        LoadingScreenController.instance.ExitGame();
        Application.Quit();
    }
    public enum SceneName
        {
            End_Demo,
            DeadScene,
            Scene_0 ,
            Scene_1,
            Scene_2,
            Scene_3,
        Scene_4_EndDemo,
    }


    }
