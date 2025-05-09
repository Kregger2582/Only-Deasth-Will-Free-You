using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_GiantZombieBehiavor : MonoBehaviour
{
    public Transform Player, attacker, Spawner, shootPoint, God;

    public int Health, ZomDamage, shootforce;

    private bool AlreadySmashed, AlreadyThrew;

    public RockSmashAttack RockSmash;

    public GameObject Rock;

    private Animator animator;

    void Start()
    {
        resetRock();
        resetSmash();

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true); // Always walking by default
    }

    void resetRock() => AlreadyThrew = false;

    void resetSmash() => AlreadySmashed = false;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isThrowing", false);

            Spawner.GetComponent<ZombieSpawner>().SubtractGiant();
            God.GetComponent<DropSpawner>().AddZombiesKilled();
            God.GetComponent<DropSpawner>().AddQuestZombiesKilled();

            Destroy(gameObject, 3f); // Allow death animation
        }
    }

    public void ThrowRock()
    {
        if (Health <= 0) return;

        float dist = Vector3.Distance(Player.position, attacker.position);
        if (dist >= 20f && !AlreadyThrew)
        {
            AlreadyThrew = true;
            transform.LookAt(Player);

            animator.SetBool("isThrowing", true);
            animator.SetBool("isWalking", false);

            // Delay the actual throw to sync with the animation (adjust 1.2f as needed)
            Invoke("PerformRockThrow", 2f);

            // Reset throwing state after full animation (2.2 seconds)
            Invoke("StopThrowing", 2.2f);
            Invoke("resetRock", 7f);
        }
    }

    void PerformRockThrow()
    {
        GameObject bigrock = Instantiate(Rock, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bigrock.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(shootPoint.forward * shootforce, ForceMode.Impulse);
    }

    void StopThrowing()
    {
        animator.SetBool("isThrowing", false);
        if (Health > 0)
            animator.SetBool("isWalking", true);
    }

    public void DealDamageRockSmash()
    {
        if (Health <= 0) return;

        if (RockSmash.RockSmashCanAttack && !AlreadySmashed)
        {
            AlreadySmashed = true;

            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);

            Player.GetComponent<PlayerAttriibues>().TakeDamage(ZomDamage);

            Invoke("resetSmash", 10f);
            Invoke("StopAttacking", 1.5f);
        }
    }

    void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
        if (Health > 0)
            animator.SetBool("isWalking", true);
    }

    void Update()
    {
        if (Health > 0)
        {
            transform.LookAt(Player);
        }

        DealDamageRockSmash();
        ThrowRock();
    }
}