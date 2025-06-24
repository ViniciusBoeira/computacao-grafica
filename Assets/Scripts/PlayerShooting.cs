using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public GameObject bullet;
    public Transform firePos;

    public float timeBetweenShots;
    private bool canShoot = true;


    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && canShoot) {
            AudioManager.instance.PlaySFX(4);
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(bullet, firePos.position, firePos.rotation);
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}