using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;

    public void TakeDamage(float damage) // responsible for the enemey taking damage 
    {
        healthPoints -= damage;

        if (healthPoints <= 0) //resposible for the enemys death
        {
            Destroy(gameObject);
        }
    }
}

