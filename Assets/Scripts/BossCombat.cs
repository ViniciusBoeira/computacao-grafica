using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadius = 1f;
    public LayerMask playerLayer;
    public int playerDamageAmount;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time < nextAttackTime) {
            return;
        }
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);

        foreach (Collider2D player in hitPlayers) {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null) {
                playerHealth.DealDamage(playerDamageAmount);
            }
        }
        nextAttackTime = Time.time + attackCooldown;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
