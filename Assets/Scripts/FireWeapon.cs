using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 50f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] int weaponDamage;

    RaycastHit objectHit;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 rayDirection = cameraController.transform.forward;

        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.blue, 1f);

        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance))
        {
            Debug.Log("You Hit the " + objectHit.transform.name);
            visualFeedbackObject.transform.position = objectHit.point;
            EnemyController enemyController = objectHit.transform.gameObject.GetComponent<EnemyController>();
            if(enemyController != null)
            {
                enemyController.TakeDamage(weaponDamage);
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
