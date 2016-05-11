﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
    //Bullet
    public GameObject bullet;
    public Transform shotSpawn;
    public AudioClip bulletShot;
    public GameObject sprite;

    public float shotDelay = 2f;
    float shotTimer = 0f;

    float armRotation = 0;
<<<<<<< HEAD
    private bool canShoot;

    public bool GetCanShoot()
    {
        return canShoot;
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
=======
    
    void Start()
    {
        if (sprite != null)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
>>>>>>> origin/master
    }

	// Update is called once per frame
    void Update () {
        if (canShoot)
        {
            SetShotAngle();
            //for the bullet instantiation
            if (Input.GetButtonDown("Fire1") && shotTimer <= 0)
            {
                GameObject newBullet = (GameObject)Instantiate(bullet, shotSpawn.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(bulletShot, this.transform.position);
                newBullet.transform.Rotate(0, 0, armRotation - 90);
                shotTimer = shotDelay;
            }
            shotTimer -= Time.deltaTime;
        }        
	}

    void SetShotAngle() {
        RaycastHit hit;
        Ray shotRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 8;

        if (Physics.Raycast(shotRay, out hit, Mathf.Infinity, layerMask)) {
            armRotation = Mathf.Atan2(hit.point.y-shotSpawn.transform.position.y, hit.point.x - shotSpawn.transform.position.x) * Mathf.Rad2Deg;
            sprite.transform.position = hit.point;
            //Debug.Log(hit.point.ToString() + " : " + armRotation);
        }
    }

}
