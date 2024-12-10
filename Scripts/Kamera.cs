using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform character; // Karakterin Transform'u
    public Vector3 offset; // Kameran�n karaktere g�re ofseti

    void LateUpdate()
    {
        // Kameran�n pozisyonunu karaktere g�re g�ncelle
        transform.position = character.position + offset;

        // Kameran�n rotasyonunu sabitle
        transform.rotation = Quaternion.Euler(0, 0, 0); // Varsay�lan rotasyon (d�nd�rmeyi�engelle)
    }
}
