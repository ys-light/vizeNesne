using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform character; // Karakterin Transform'u
    public Vector3 offset; // Kameranýn karaktere göre ofseti

    void LateUpdate()
    {
        // Kameranýn pozisyonunu karaktere göre güncelle
        transform.position = character.position + offset;

        // Kameranýn rotasyonunu sabitle
        transform.rotation = Quaternion.Euler(0, 0, 0); // Varsayýlan rotasyon (döndürmeyi engelle)
    }
}
