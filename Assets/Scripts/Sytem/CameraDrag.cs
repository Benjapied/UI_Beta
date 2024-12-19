using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2f; // Vitesse du d�placement
    private Vector3 dragOrigin; // Position d'origine du clic
    private bool isDragging = false; // Indique si la souris est maintenue enfonc�e

    void Update()
    {
        // D�tection du clic gauche
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.CurrentWindow == null)
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        // D�tection de la fin du clic gauche
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Si la souris est maintenue enfonc�e, d�placer la cam�ra
        if (isDragging)
        {
            Vector3 difference = dragOrigin - Input.mousePosition; // Calcul de la diff�rence
            dragOrigin = Input.mousePosition; // Met � jour la position d'origine

            // D�placer la cam�ra en fonction de la diff�rence
            Vector3 move = new Vector3(difference.x, 0, difference.y) * dragSpeed * Time.deltaTime;
            GameManager.Instance._mainCamera.transform.Translate(move, Space.World);

            Vector3 pos = GameManager.Instance._mainCamera.transform.position;
            pos.x = Mathf.Clamp(pos.x, -75, 75);
            pos.z = Mathf.Clamp(pos.z, -100, 75);
            GameManager.Instance._mainCamera.transform.position = pos;

        }

        

    }
}