using System;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Action OnPlayerCollided;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInput>()) OnPlayerCollided?.Invoke();
    }

}
