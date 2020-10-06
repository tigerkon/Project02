using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerFPS
            = other.gameObject.GetComponent<PlayerController>();

        if (playerFPS != null)
        {
            playerFPS.HealthLoss();
        }
    }
}
