using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hitscan : MonoBehaviour
{
    public int mag, bulletsLeft, damage, Reserves, gamblingNumber;
    private int ammotosubract;
    public bool HoldButton;
    public Text ammodisplay;
    public float ReloadTime, range;
    public Transform spawnPoint;
    private bool shooting, reloading, isChangingWeapon;
    private float lasttimeshot = 0f;
    public float FireRate;

    private Animator animator;
    public GameObject muzzleFlashPrefab;

    public GameObject[] weapons; // Add your hitscan weapons here
    private int currentWeaponIndex = 0;

    void Awake()
    {
        bulletsLeft = mag;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ammodisplay.text = $"{bulletsLeft} / {Reserves}";
        myInputs();
        UpdateMovementAnimation();
        HandleWeaponSwitchInput();
    }

    void myInputs()
    {
        if (HoldButton) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (shooting && bulletsLeft > 0 && !reloading && !isChangingWeapon)
        {
            if (Time.time > lasttimeshot + FireRate)
            {
                lasttimeshot = Time.time;
                bulletsLeft--;

                LineDrawer();

                // Trigger shoot animation
                animator.SetTrigger("isShooting");

                // === Muzzle Flash ===
                if (muzzleFlashPrefab != null)
                {
                    GameObject flash = Instantiate(muzzleFlashPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                    Destroy(flash, 0.05f); // short lifetime for flash effect
                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.R) && bulletsLeft < mag && !reloading && Reserves > 0) || bulletsLeft <= 0)
        {
            reloading = true;
            animator.SetBool("isReloading", true);
            Invoke("reload", ReloadTime);
        }
    }

    void reload()
    {
        ammotosubract = mag - bulletsLeft;

        if (ammotosubract > Reserves)
        {
            bulletsLeft += Reserves;
            Reserves = 0;
        }
        else
        {
            bulletsLeft = mag;
            Reserves -= ammotosubract;
        }

        reloading = false;
        animator.SetBool("isReloading", false);
    }

    void LineDrawer()
    {
        Vector3 direction = Vector3.forward;
        Ray myRay = new Ray(spawnPoint.position, spawnPoint.TransformDirection(direction * range));
        Debug.DrawRay(spawnPoint.position, spawnPoint.TransformDirection(direction * range));

        if (Physics.Raycast(myRay, out RaycastHit hit, range))
        {
            switch (hit.collider.tag)
            {
                case "Enemy":
                    hit.collider.GetComponent<ZombiesAttributes>().TakeDamage(damage);
                    break;

                case "GiantZombie":
                    hit.collider.GetComponent<GiantZombieBehiavor>().TakeDamage(damage);
                    break;

                case "Rock":
                    hit.collider.GetComponent<RockThrow>().TakeDamage(damage);
                    break;

                case "WizardZombie":
                    hit.collider.GetComponent<WizardAttributes>().TakeDamage(damage);
                    break;
            }
        }
    }

    void UpdateMovementAnimation()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        animator.SetBool("isWalking", isMoving);
        animator.SetBool("isIdle", !isMoving);
    }

    void HandleWeaponSwitchInput()
    {
        if (isChangingWeapon || reloading) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) TrySwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TrySwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TrySwitchWeapon(2);
    }

    void TrySwitchWeapon(int newIndex)
    {
        if (newIndex == currentWeaponIndex || newIndex >= weapons.Length) return;
        StartCoroutine(ChangeWeaponRoutine(newIndex));
    }

    IEnumerator ChangeWeaponRoutine(int newIndex)
    {
        isChangingWeapon = true;
        animator.SetBool("isChanging", true);

        yield return new WaitForSeconds(0.5f); // Adjust to animation duration

        weapons[currentWeaponIndex].SetActive(false);
        weapons[newIndex].SetActive(true);
        currentWeaponIndex = newIndex;

        animator.SetBool("isChanging", false);
        isChangingWeapon = false;
    }

    public void subtractdmg() => damage -= gamblingNumber;
    public void adddmg() => damage += gamblingNumber;
}
