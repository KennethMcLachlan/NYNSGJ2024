using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float _duration = 0.25f;
    private float _magnitude = 0.15f;

    public void StartShake()
    {
        StartCoroutine(CameraShakeRoutine());
    }

    IEnumerator CameraShakeRoutine()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            float x = Random.Range(-1.5f, 1.5f) * _magnitude;
            float y = Random.Range(-1f, 1f) * _magnitude;

            transform.position = new Vector3(x, y, x - 10f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }


}
