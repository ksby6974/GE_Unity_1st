using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float fRunnerSpeed = 5;
    [SerializeField] float fLimitSpeed = 75;

    [SerializeField] float fIncreaseTime = 0.5f;
    [SerializeField] float fIncreaseSpeed = 1f;

    public float Speed
    {
        get { return fRunnerSpeed; }
    }

    public IEnumerator SpeedUp()
    {
        while (fRunnerSpeed < fLimitSpeed)
        {
            fRunnerSpeed += fIncreaseSpeed;

            yield return CoroutineCache.waitForSeconds(0.5f);
        }
    }
}