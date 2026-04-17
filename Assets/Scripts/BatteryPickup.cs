using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 5f;
    [SerializeField] float restoreIntecity = 1f;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<FlashLight>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLight>().RestoreLightIntencity(restoreIntecity);
            Destroy(gameObject);
        }
    }
}
