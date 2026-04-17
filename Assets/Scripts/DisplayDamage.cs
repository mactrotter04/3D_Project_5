using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] List<GameObject> bloodSplatterImages;
    [SerializeField] float impactTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(var bloodSplatterImage in bloodSplatterImages)
        {
            bloodSplatterImage.SetActive(false);
        }
    }

    IEnumerator ShowDamageImpact()
    {
        int randomIndex = Random.Range(0, bloodSplatterImages.Count);
        GameObject selectedImage = bloodSplatterImages[randomIndex];

        selectedImage.SetActive(true);
        yield return new WaitForSeconds(impactTime);
        selectedImage.SetActive(false);
    }

    public void DisplayBloodSplatters()
    {
        StartCoroutine(ShowDamageImpact());
    }
}
