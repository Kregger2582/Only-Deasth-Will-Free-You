using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_WizardAttributes : MonoBehaviour
{
    public int health, ZomDamage;
    public float range, shootforce;

    public Transform Player, shootPoint;
    public GameObject FireBall, God, Spawner;

    private bool attacking;

    private Animator animator;

    void Start()
    {
        resetattack();
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
    }

    void resetattack()
    {
        attacking = false;
    }

    void CanWizShoot()
    {
        float distance = Vector3.Distance(Player.position, shootPoint.position);

        if (distance < range && !attacking)
        {
            FireBallShoot();
        }

        // Animation state updates
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isCasting", false);
        }
        else if (distance < range && !attacking)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isCasting", false);
        }
        else if (!attacking)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isCasting", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isCasting", false);

            Spawner.GetComponent<ZombieSpawner>().SubtractWizard();
            God.GetComponent<DropSpawner>().AddZombiesKilled();
            God.GetComponent<DropSpawner>().AddQuestZombiesKilled();

            Destroy(gameObject, 3f); // delay for death animation
        }
    }

    void FireBallShoot()
    {
        attacking = true;

        animator.SetBool("isCasting", true);
        animator.SetBool("isIdle", false);

        // Delay the fireball so it matches the animation casting timing
        Invoke("PerformFireballCast", 1.0f); // adjust to match animation
        Invoke("resetattack", 3f); // cooldown
        Invoke("StopCasting", 2.2f); // end casting animation after animation ends
    }

    void PerformFireballCast()
    {
        GameObject fireball = Instantiate(FireBall, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootforce, ForceMode.Impulse);
        }
    }

    void StopCasting()
    {
        if (health > 0)
        {
            animator.SetBool("isCasting", false);
            animator.SetBool("isIdle", true);
        }
    }

    void Update()
    {
        if (health > 0)
        {
            transform.LookAt(Player);
        }

        CanWizShoot();
    }
}
