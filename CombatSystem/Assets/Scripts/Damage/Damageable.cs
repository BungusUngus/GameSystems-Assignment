using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
public class Damageable : MonoBehaviour
{
    [SerializeField] private float healthMax;

    [SerializeField] private UnityEvent onHealthZero;

    private float healthCurrent;

    private bool isDead;

    void Start()
    {
        healthCurrent = healthMax;
        isDead = false;
    }


    public void TakeDamage(float amount)
    {
        if (isDead)
        {
            //if we're dead, stop early.
            return;
        }

        Debug.Log($"The agent {name} took {amount} damage!");

        healthCurrent -= amount;

        if (healthCurrent <= 0)
        {
            HealthZero();
        }
    }

    public void RestoreHealth(float amount)
    {
        isDead = false;
        healthCurrent += amount;
        if (healthCurrent > healthMax)
        {
            healthCurrent = healthMax;
        }
    }

    private void HealthZero()
    {
        isDead = true;
        healthCurrent = 0;
        onHealthZero.Invoke();
        Debug.Log($"The agent {name} has died!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TryGetComponent will return true or false. If true, it will also "out" the component it found
        if (collision.gameObject.TryGetComponent<DamageSource>(out DamageSource damageSource))
        {

            //if the tags match...
            if (collision.gameObject.CompareTag(tag))
            {
                //do nothing
                return;
            }

            // if we get here, tags don't match, so we should take damage
            TakeDamage(collision.gameObject.GetComponent<DamageSource>().GetDamage());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DamageSource>(out DamageSource damageSource))
        {
            if (other.CompareTag(tag))
            {
                return;
            }
            TakeDamage(damageSource.GetDamage());
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<DamageSource>(out DamageSource damageSource))
        {
            if (other.CompareTag(tag))
            {
                return;
            }
            TakeDamage(damageSource.GetDamage());
        }
    }

    private void CheckForDamage(GameObject possibleSource)
    {
        if(possibleSource.TryGetComponent<DamageSource>(out DamageSource damageSource))
        {
            if (possibleSource.CompareTag(tag))
            {
                return;
            }
            TakeDamage(damageSource.GetDamage());
        }
    }


    /// <summary>
    /// Returns the percent of health this Damageable has, between 0-1
    /// </summary>
    /// <returns></returns>
    public float GetHealthPercent()
    {
        return healthCurrent / healthMax;
    }
}
