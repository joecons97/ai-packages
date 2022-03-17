using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Josephus.AIPackages.Example
{
    public class TimeOfDay : MonoBehaviour
    {
        public static TimeOfDay Instance;

        public float DayTime = 0;
        public float Speed = 10;

        private void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            DayTime += Time.deltaTime * Speed;
            if(DayTime > 24)
                DayTime = 0;
        }

        private void OnGUI()
        {
            GUI.color = Color.red;
            GUILayout.Label(DayTime.ToString());
        }
    }
}