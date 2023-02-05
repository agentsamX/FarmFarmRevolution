using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;
    private void Awake()
    {
        Instance= this;
        CinemachineVirtualCamera= GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
              
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }

    public void ShakeCamera(float inten, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain= inten;

        startingIntensity = inten;
        shakeTimer = time;
        shakeTimerTotal = time;
    }
}
