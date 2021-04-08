using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScimitarSwordController scimitarSwordController;
    [SerializeField] private RapierSwordController rapierSwordController;
    [SerializeField] private AxeController axeController;

    [SerializeField] private GameObject scimitar;
    [SerializeField] private GameObject rapier;
    [SerializeField] private GameObject axe;
    
    [SerializeField] private GameObject scimitarImage;
    [SerializeField] private GameObject rapierImage;
    [SerializeField] private GameObject axeImage;


    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && rapierSwordController.weaponCheck)
        {
            rapier.SetActive(true);
            scimitar.SetActive(false);
            axe.SetActive(false);
            
            rapierImage.SetActive(false);
            scimitarImage.SetActive(true);
            axeImage.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.Alpha2) && scimitarSwordController.weaponCheck)
        {
            rapier.SetActive(false);
            scimitar.SetActive(true);
            axe.SetActive(false);
            
            rapierImage.SetActive(true);
            scimitarImage.SetActive(false);
            axeImage.SetActive(true);
        }
        
        else if (Input.GetKey(KeyCode.Alpha3) && axeController.weaponCheck)
        {
            rapier.SetActive(false);
            scimitar.SetActive(false);
            axe.SetActive(true);
            
            rapierImage.SetActive(true);
            scimitarImage.SetActive(true);
            axeImage.SetActive(false);
        }

    }
}
