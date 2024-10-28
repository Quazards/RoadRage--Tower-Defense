using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    public float turretRange = 15f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    public Transform rotationPart;
    private float rotationSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if(distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null && closestDistance <= turretRange)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion rotateTurret = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, rotateTurret, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCooldown <= 0)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject turretBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = turretBullet.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.FindTarget(target);
        }    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
