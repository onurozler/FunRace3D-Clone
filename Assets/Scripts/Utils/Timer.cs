using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance
        {
            get
            {
                var instance = FindObjectOfType<Timer>();
                if (instance == null)
                {
                    instance = new GameObject("Timer").AddComponent<Timer>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private IEnumerator WaitForAction(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            if(callback != null)
                callback.Invoke();
        }
        
        public Coroutine TimerWait(float time, Action callback)
        {
            return StartCoroutine(WaitForAction(time, callback));
        }
    }
}

