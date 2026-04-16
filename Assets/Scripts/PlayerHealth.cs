using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hP = 100f;
    
    public void TakeDamage(float damage)
    {
        hP -= damage;

        if (hP <= 0 )
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
