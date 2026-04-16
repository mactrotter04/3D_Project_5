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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //chesks if the left mouse button is pressed
        {
            Shoot();
        }
    }

    void Shoot() // this manages the shooting mechanics
    {
        ProccessRayCast();
        PlayMuzzleFlash();
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
}
