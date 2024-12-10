using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour
{
    private MeshRenderer mr;
    private Material material;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        material = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offsetM = material.mainTextureOffset;
        offsetM.x = transform.position.x / transform.localScale.x;
        offsetM.y = transform.position.y / transform.localScale.y;
        material.mainTextureOffset = offsetM;
    }
}
