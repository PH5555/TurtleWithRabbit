using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shakeOn = false;

    private float shakeAmount = 2.0f;
    private float shakeDuration = 1.0f;

    
    float shakePercentage;
    float startAmount;
    float startDuration;

    bool isRunning = false; 

   

    void Start() {

        if (shakeOn) ShakeCamera();
    }

    void Update() {

        if (shakeOn) ShakeCamera();

    }


    void ShakeCamera() {

        startAmount = shakeAmount;
        startDuration = shakeDuration;
        if (!isRunning) StartCoroutine(Shake());
    }

    public void ShakeCamera(float amount, float duration) {

        shakeAmount += amount;
        startAmount = shakeAmount;
        shakeDuration += duration;
        startDuration = shakeDuration;

        if (!isRunning) StartCoroutine(Shake());
    }


    IEnumerator Shake() {
        isRunning = true;

        while (shakeDuration > 0.01f) {
            Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;
            rotationAmount.z = 0;

            shakePercentage = shakeDuration / startDuration;

            shakeAmount = startAmount * shakePercentage;
            shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);
            transform.localRotation = Quaternion.Euler(rotationAmount);

            yield return null;
        }
        transform.localRotation = Quaternion.identity;
        isRunning = false;
    }
}
