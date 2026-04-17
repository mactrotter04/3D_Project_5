using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 10f;

    Light myLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.spotAngle = myLight.innerSpotAngle + 10f;
    }

    // Update is called once per frame
    void Update()
    {
        DecreseLightAngle();
        DecreseIntencity();
    }

    void DecreseIntencity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    void DecreseLightAngle()
    {
        if (myLight.spotAngle <= minAngle) return;

        else
        {
            myLight.innerSpotAngle -= angleDecay * Time.deltaTime;
            myLight.spotAngle = myLight.innerSpotAngle + 10f;
        }
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle += restoreAngle;
        myLight.innerSpotAngle = myLight.spotAngle + 10f;
    }

    public void RestoreLightIntencity(float restoreIntencity)
    {
        myLight.intensity += restoreIntencity;
    }
}
