using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float bulletSpeed = 50f;
    public int bulletDamage = 50;

    private float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(target);
            return;
        }

        Vector3 bulletDirection = target.position - transform.position;
        float distanceTraversed = bulletSpeed * Time.deltaTime;

        //if (bulletDirection.magnitude <= distanceTraversed)
        //{
        //    HitTarget();
        //    return;
        //}

        transform.Translate(bulletDirection.normalized * distanceTraversed, Space.World);

    }

    private void HitTarget()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }
    }

    public void FindTarget(Transform _target)
    {
        target = _target;
    }
}
