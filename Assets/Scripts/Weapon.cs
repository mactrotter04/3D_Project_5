using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

//physics.Raycast raycatHit
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject impactSparks;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] AmmoTypes ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] float reloadTime = 3f;

    bool canShoot = true;


    void OnEnable()
    {
        canShoot = true; //this stops the guns not working when you switch while shooting
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot == true) //chesks if the left mouse button is pressed
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() // this manages the shooting mechanics
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) //only allows you to shoot if you have ammo
        {
            ProccessRayCast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            StartCoroutine(Reload());
        }
    }

    void ProccessRayCast() //procceses raycast
    {
        RaycastHit hit; //checks to see if the raycast has hit a collider 

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit)) //this is the raycast
        {
            PlayImpactSparks(hit);
            Debug.Log("hit " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); //refers to any game object with enemy health script 
            if (target == null) return; //checks to see if the enemy is already dead and if it is to skip 
            target.TakeDamage(damage); //applys damage for this certian wepon
        }
        else
        {
            return; //means nothing will be exicuted
        }
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.green);
    }

    void PlayMuzzleFlash() // plays the muzzle flash paricle effects
    {
        muzzleflash.Play();
    }

    void PlayImpactSparks(RaycastHit hit) //responsible for playing impact sparks
    {
        GameObject impact = Instantiate(impactSparks, hit.point, Quaternion.LookRotation(hit.normal)); //allows to check the surface the raycast hits and plays the particle system towards the player
        Destroy(impact, 0.5f);
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Reload()
    {
        canShoot = false;
        //TODO add animation
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
