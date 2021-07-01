using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] ParticleSystem particles = null;
    [SerializeField] float timeToDestroy = 2f;

    Rigidbody rb;
    MeshRenderer mr;
    Vector3 direction = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }

    public void Launch(Vector3 dir, float vel)
    {
        rb.AddForce(dir * vel, ForceMode.Impulse);
        direction = dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Idamageable damageable = collision.collider.GetComponent<Idamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage();
        }
        rb.Sleep();
        mr.enabled = false;
        Destroy(gameObject, timeToDestroy);
        if (particles != null)
        {
            particles.Play();
            particles.gameObject.transform.forward = Vector3.Reflect(direction, collision.GetContact(0).normal);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Idamageable damageable = other.GetComponent<Idamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage();
        }
        rb.Sleep();
        mr.enabled = false;
        Destroy(gameObject, timeToDestroy);
    }
}
