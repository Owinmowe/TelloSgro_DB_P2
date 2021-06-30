using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform bulletSpawnPoint = null;
    [SerializeField] float launchSpeed = 50;
    [SerializeField] float cooldown = 1f;
    float currentCooldown = 0;

    public void Shoot()
    {
        if (currentCooldown < Mathf.Epsilon)
        {
            StartCoroutine(CooldownCoroutine());
            GameObject go = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            go.GetComponent<Projectile>().Launch(transform.forward, launchSpeed);
        }
    }

    IEnumerator CooldownCoroutine()
    {
        currentCooldown = cooldown;
        yield return null;
        while (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            yield return null;
        }
        currentCooldown = 0;
    }
}
