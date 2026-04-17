using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoTypes ammoType;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //checks to see if player picks up ammo box
        {
            Debug.Log("Picked up ammo");
            FindFirstObjectByType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
