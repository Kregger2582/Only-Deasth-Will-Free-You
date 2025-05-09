using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int damage, mag, bulletsLeft, Reserves, gamblingNumber;
    private int ammotosubract;
    public float range, ReloadTime;
    public bool HoldBotton;
    private bool shooting, reloading, readyToShoot, isChangingWeapon;
    public Text ammodisplay;

    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 20f;

    private Animator animator;

    // Weapon switching references
    public GameObject[] weapons; // Assign all your weapons here in the inspector
    private int currentWeaponIndex = 0;

    private void Awake()
    {
        bulletsLeft = mag;
        readyToShoot = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ammodisplay.text = $"{bulletsLeft} / {Reserves}";
        MyInput();

        if (!shooting && bulletsLeft > 0)
        {
            readyToShoot = true;
        }

        UpdateMovementAnimation();
        HandleWeaponSwitchInput(); // NEW
    }

    private void MyInput()
    {
        if (HoldBotton) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < mag && !reloading && Reserves > 0 || bulletsLeft <= 0)
        {
            reloading = true;
            animator.SetBool("isReloading", true);
            Invoke("reload", 2f);
        }

        if (readyToShoot && shooting && !reloading && !isChangingWeapon)
        {
            shoot();
        }
    }

    private void reload()
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

    private void shoot()
    {
        if (!HoldBotton) readyToShoot = false;

        animator.SetTrigger("isShooting");

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        bulletsLeft--;

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }

    private void UpdateMovementAnimation()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (isMoving)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
    }

    // ========================
    // NEW: Weapon Switching Logic
    // ========================
    private void HandleWeaponSwitchInput()
    {
        if (isChangingWeapon || reloading) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) TrySwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TrySwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TrySwitchWeapon(2);
    }

    private void TrySwitchWeapon(int newIndex)
    {
        if (newIndex == currentWeaponIndex || newIndex >= weapons.Length) return;

        StartCoroutine(ChangeWeaponRoutine(newIndex));
    }

    private IEnumerator ChangeWeaponRoutine(int newIndex)
    {
        isChangingWeapon = true;
        animator.SetBool("isChanging", true);

        // Wait for animation to play (adjust this based on your actual animation length)
        yield return new WaitForSeconds(0.5f);

        // Deactivate current weapon
        weapons[currentWeaponIndex].SetActive(false);

        // Activate new weapon
        weapons[newIndex].SetActive(true);
        currentWeaponIndex = newIndex;

        animator.SetBool("isChanging", false);
        isChangingWeapon = false;
    }

    public void subtractdmg() => damage -= gamblingNumber;
    public void adddmg() => damage += gamblingNumber;
}