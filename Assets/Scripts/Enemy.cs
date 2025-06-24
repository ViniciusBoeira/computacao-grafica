using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public Transform pointA, pointB;
    public int Speed;
    private Vector3 currentTarget;
    private SpriteRenderer sr;

    public int health = 1;
    public float bounceForce = 5f;

    public int currentHealth, maxHealth, damageAmount;


    void Start() {
        sr=GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }
    void Update() {
        if (transform.position == pointA.position) {
            currentTarget=pointB.position;
            sr.flipX = false;
        }
        else if (transform.position == pointB.position) {
            currentTarget=pointA.position;
            sr.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, Speed*Time.deltaTime);
    }

    public void TakeDamage() {
        currentHealth-=damageAmount;
        if (currentHealth <= 0) {
            AudioManager.instance.PlaySFX(2);
            Die();
        }
    }

    public void Die() {
        Debug.Log("Enemy is dead");
        Destroy(gameObject);
    }
}