using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DisplayHealth : MonoBehaviour
{
     TextMeshProUGUI playerHealth;

    private PlayerShip playerShip;

    private void Start()
    {
        playerHealth = GetComponent<TextMeshProUGUI>();
        playerShip = FindObjectOfType<PlayerShip>();
    }

    public void Update()
    {
        playerHealth.text = playerShip.GetHealth().ToString();
    }
}
