using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAtrtributes : MonoBehaviour
{
    public int ZomDamage;

    void DestoryBalls()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerAttriibues>(). TakeDamage(ZomDamage);
            Destroy(gameObject);

        }
        else if(other.CompareTag("WizardZombie") && other.CompareTag("fireball"))
        {
            Destroy(gameObject);
        }
        Invoke("DestoryBalls",30);









    }

}
