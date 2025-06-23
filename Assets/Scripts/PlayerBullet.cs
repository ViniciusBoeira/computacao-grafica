using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public float bulletSpeed;
    public Rigidbody2D rb;

    private Player playerController;
    private GameObject playerObj;

    private void Awake() {
        Destroy(gameObject, 2.5f);
    }

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObj.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (playerController.IsFacingRight()) {
            rb.linearVelocity=transform.right * bulletSpeed;
        }
        else {
            rb.linearVelocity= -transform.right * bulletSpeed;
        }
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
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}