using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDelayer : MonoBehaviour
{
    private bool isDelayInProgress = false;

    // Property to check if the delay is in progress
    public bool IsDelayInProgress
    {
        get { return isDelayInProgress; }
    }

    // Method to start a time delay
    public void StartDelay(float delayInSeconds)
    {
        if (!isDelayInProgress)
        {
            StartCoroutine(DelayCoroutine(delayInSeconds));
        }
    }

    // Coroutine for the time delay
    private IEnumerator DelayCoroutine(float delayInSeconds)
    {
        isDelayInProgress = true;
        yield return new WaitForSeconds(delayInSeconds);
        isDelayInProgress = false;
    }
}
