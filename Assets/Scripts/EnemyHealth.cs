using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    private Renderer enemyRender;
    private Color enemyStartColor;


    private void Start()
    {
        enemyRender = GetComponentInChildren<Renderer>();
        enemyStartColor = enemyRender.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            int damage = other.GetComponent<Bullet>().bulletDamage;

            TakeDamage(damage);
            //StartCoroutine(flashRed());
        }
    }

    private void TakeDamage (int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerManager.Currency += 100;
        Destroy(transform.root.gameObject);
    }

    private IEnumerator flashRed()
    {
        enemyRender.material.color = Color.red;
        yield return new WaitForSeconds(1);
        enemyRender.material.color = enemyStartColor;
    }
}
