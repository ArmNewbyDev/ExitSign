using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatform
{
    public class HeartCheck : Singleton<HeartCheck>
    {
        private int Heart = 4;




        public void ResetGame()
        {
            Heart = 4;
        }

        public void GetDamage(int dmg)
        {
            if (Heart > 0)
            {
                Heart -= dmg;
            }
        }

        public int HMHeartLeft()
        {
            return Heart;
        }

    }
}
