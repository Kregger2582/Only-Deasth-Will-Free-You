using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_ZombiesAttributes : MonoBehaviour
{
    private Animator animator;

    public int health, armor, ZomDamage, ZombieAttackTime;

    public DropSpawner DropSpawner;

    public Transform player, attacker, Spawner, GOD;

    public float range = 5f;

    private bool CanZombieAttack;

    public bool HealthOnGround = false;

    public GameObject HealthPack;

    private void Awake()
    {
        MakeZombieAttack();
        animator = GetComponent<Animator>();
    }

    void MakeZombieAttack()
    {
        CanZombieAttack = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetBool("isDead", true);

            if (DropSpawner.ZombiesKilled == 10 && !HealthOnGround)
            {
                HealthOnGround = true;
                DropSpawner.ZombiesKilled = 0;
                Instantiate(HealthPack, attacker.position, attacker.rotation);
            }

            GOD.GetComponent<DropSpawner>().AddZombiesKilled();
            GOD.GetComponent<DropSpawner>().AddQuestZombiesKilled();
            Spawner.GetComponent<ZombieSpawner>().SubstractZombie();

            // Optional delay to allow death animation
            Destroy(gameObject, 2f);
        }
    }

    private void DealDamage()
    {
        CanZombieAttack = false;
        player.GetComponent<PlayerAttriibues>().TakeDamage(ZomDamage);
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(ZombieAttackTime);
        CanZombieAttack = true;
    }

    void DrawLine()
    {
        Vector3 direction = transform.forward;
        Ray theRay = new Ray(transform.position, direction);
        Debug.DrawRay(transform.position, direction * range, Color.red);

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Player") && CanZombieAttack)
            {
                DealDamage();
                
            }
        }
    }

    void Update()
    {
        if (health > 0)
        {
            // Make the zombie face the player while alive
            transform.LookAt(player);
        }

        DrawLine();

        float distance = Vector3.Distance(transform.position, player.position);

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);
            
        }
        else if (distance <= 2f)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);
        }
        else if (distance <= 15f)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
    }
}
