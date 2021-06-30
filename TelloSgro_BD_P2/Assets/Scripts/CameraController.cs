using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] float shakeDuration = 2f;
    [SerializeField] float shakeStrenght = .2f;

    public static CameraController instance = null;

    Vector3 startingLocation;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        startingLocation = transform.position;
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake(shakeDuration, shakeStrenght));
    }

    IEnumerator Shake(float duration, float strenght)
    {
        float currentShakeTime = 0;
        while (currentShakeTime < duration)
        {
            currentShakeTime += Time.deltaTime;
            float x = Random.Range(startingLocation.x - strenght / 2, startingLocation.x + strenght / 2);
            float y = Random.Range(startingLocation.y - strenght / 2, startingLocation.y + strenght / 2);
            transform.position = new Vector3(x, y, startingLocation.z);
            yield return null;
        }
        transform.position = startingLocation;
    }
}