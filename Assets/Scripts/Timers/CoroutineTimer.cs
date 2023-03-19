using System;
using System.Collections;
using UnityEngine;

namespace Timers
{
    /// <summary>
    /// Timer, based on Unity coroutines
    /// </summary>
    public class CoroutineTimer : MonoBehaviour, ITimer
    {
        public void DoWithDelay(float delay, Action action) => StartCoroutine(DoAfterSeconds(delay, action));

        IEnumerator DoAfterSeconds(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action.Invoke();
        }
    }
}