using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : State
{
    [SerializeField] float fRunnerSpeed = 5;
    [SerializeField] float fLimitSpeed = 75;
    [SerializeField] float fIncreaseTime = 0.5f;
    [SerializeField] float fIncreaseSpeed = 1f;

    public float Speed
    {
        get { return fRunnerSpeed; }
    }

    public void Awake()
    {
        fLimitSpeed = 40;
        StartCoroutine(SpeedUp());
    }

    public void Start()
    {
        //fLimitSpeed = 40;
    }

    public IEnumerator SpeedUp()
    {
       // Debug.Log($"SpeedUp Start: {fRunnerSpeed}, {fLimitSpeed}");

        while ((state == true) && (fRunnerSpeed < fLimitSpeed))
        {
            fRunnerSpeed += fIncreaseSpeed;

            yield return CoroutineCache.waitForSeconds(0.5f);
        }
    }
}