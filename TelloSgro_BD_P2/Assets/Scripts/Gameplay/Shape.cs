using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Shape : MonoBehaviour, Idamageable
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 200;
    [Header("Life")]
    [SerializeField] int maxLife = 3;
    [SerializeField] bool invulnerabilityAfterHit = false;
    [SerializeField] float invulnerabilityTime = 3f;
    [SerializeField] float timeToDestroy = 2f;
    bool invulnerable = false;
    int currentLife = 0;

    public Action OnTakeDamage;
    public Action OnDestroy;

    Rigidbody rb = null;
    Animator anim = null;
    Collider col = null;

    bool alive = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        currentLife = maxLife;
    }

    public void Move(Vector3 dir)
    {
        if (!alive) { return; }
        transform.position += dir * movementSpeed * Time.deltaTime;
    }

    public void Aim(Vector3 dir)
    {
        if (!alive) { return; }
        transform.forward = dir;
    }

    public void TakeDamage()
    {
        if (invulnerable) return;
        currentLife--;
        anim.SetTrigger("Take Damage");
        if (currentLife <= 0)
        {
            OnDestroy?.Invoke();
            Destroy(gameObject, timeToDestroy);
            col.enabled = false;
            alive = false;
        }
        else
        {
            OnTakeDamage?.Invoke();
            if (invulnerabilityAfterHit) StartCoroutine(invulnerabilityCoroutine());
        }
    }

    IEnumerator invulnerabilityCoroutine()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        invulnerable = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (invulnerable) return;
        Idamageable damageable = collision.collider.GetComponent<Idamageable>();
        if (damageable != null) damageable.TakeDamage();
    }
}