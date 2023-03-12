using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameManager : MonoBehaviour
    {
        public static bool GameHasStop;
        public static bool GameHasPause;
        public static bool GhostIsCHARGE;
        public static GameManager instance;

        private void Awake()
        {
            GameHasStop = false;
            GameHasPause = false;
            GhostIsCHARGE = false;
            instance = this;

        }

        private void Update()
        {
            if (GameHasStop)
            {
                Time.timeScale = 0f;
            }
            else
                Time.timeScale = 1f;
        }
        public void CHARGE()
        {
            GhostIsCHARGE = true;
        }
        public void StopCharge()
        {
            GhostIsCHARGE= false;
        }
        public void TimeStop()
        {
            GameHasStop=true;
        }

        public void TimeStart()
        {
            GameHasStop = false;
        }
        public void StopWaitMinute()
        {
            GameHasPause = true;
        Debug.Log(GameHasPause);
        }

        public void Continue()
        {
            GameHasPause = false;
        }
        
    }
