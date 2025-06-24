using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public float bulletSpeed;
    public Rigidbody2D rb;

    private Player playerController;
    private GameObject playerObj;
    private Vector3 _direction;

    private void Awake() {
        Destroy(gameObject, 1.5f);
    }

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObj.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();

        _direction = playerController.IsFacingRight() ? transform.right : -transform.right;
    }

    void Update() {
        
        rb.linearVelocity=_direction * bulletSpeed;

        // rb.linearVelocity=transform.right * bulletSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag=="Enemy") {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage();
            }
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag=="Boss") {
            Boss boss = collision.GetComponent<Boss>();
            if (boss != null) {
                boss.TakeDamage();
            }
            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}