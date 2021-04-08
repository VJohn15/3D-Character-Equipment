using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    [SerializeField] private GameObject swordToPick;
    [SerializeField] private GameObject pickedSword;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject swordCamera;
    [SerializeField] private GameObject rapierSword;
    [SerializeField] private GameObject scimitarSword;
    
    [SerializeField] private GameObject scimitarImage;
    [SerializeField] private GameObject rapierImage;
    [SerializeField] private GameObject axeImage;
    
    public bool check = false;
    public bool weaponCheck = false;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorial.SetActive(true);
            check = true;
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorial.SetActive(false);
            check = false;
        }
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.E) && check)
        {
            swordCamera.SetActive(true);
            StartCoroutine(WaitForSecond());
        }
    }

    private IEnumerator WaitForSecond()
    {
        rapierSword.SetActive(false);
        scimitarSword.SetActive(false);
        
        weaponCheck = true;

        yield return new WaitForSeconds(1.5f);
        swordToPick.SetActive(false);
        pickedSword.SetActive(true);
        
        rapierImage.SetActive(true);
        scimitarImage.SetActive(true);
        axeImage.SetActive(false);
        
        tutorial.SetActive(false);
        check = false;
        

    }
}
