using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    Rigidbody2D body;
    Transform target;
    [SerializeField]
    float speed = 20;

    public void Setup(Transform target)
    {
        this.target = target;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2f);
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (target != null)
        {
            body.AddForce((target.position - transform.position) * speed);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
