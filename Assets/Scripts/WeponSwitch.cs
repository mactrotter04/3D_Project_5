using System.Diagnostics;
using UnityEngine;

public class WeponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProccesKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon) //stops the player from switching to the current active weapon
        {
            SetWeaponActive();
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0; //sets the first wepon as defult

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false); //if the wepon is not currently being used it makes it flase 
            }

            weaponIndex++;
        }
    }

    void ProcessScrollWheel() //controlls the scrollling between wepons
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //is scrolling down on the scroll wheel
        {
            if(currentWeapon >= transform.childCount -1) //if at the last wepon go back to the first wepon
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) //this does the opisite
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    void ProccesKeyInput() ///this proscess swithcing guns with number keys
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //this is 1
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //this is 2
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //this is 3
        {
            currentWeapon = 2;
        }
    }
}
