using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private GameObject player;
    public float detectingRange;
    public float timeBetweenAttacks = 1f;
    private Animator anim;

    public float moveSpeed;
    public float attackRange;
    public bool isAttacking = false;

    public BossHealthbar bossHealthbar;

    public int currentHealth, maxHealth, damageAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        bossHealthbar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < detectingRange) {
            anim.SetBool("playerInRange", true);
            if (distance <= attackRange && !isAttacking) {
                StartCoroutine(AttackAfterDelay());
            }
            else if (!isAttacking) {
                moveTowardsPlayer();
            }
        }

        else {
            anim.SetBool("playerInRange", false);
        }


    }

    private void moveTowardsPlayer() {
        Vector2 playerPosition = new Vector2(player.transform.position.x, transform.position.y);
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

        if (direction.x > 0) {
            transform.localScale = new Vector3(1,1,1);
        } else if (direction.x < 0)  {
            transform.localScale = new Vector3(-1,1,1);
        }

        transform.Translate(direction*moveSpeed*Time.deltaTime);
    }

    IEnumerator AttackAfterDelay() {
        isAttacking = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    public void TakeDamage() {
        currentHealth -= damageAmount;
        bossHealthbar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
