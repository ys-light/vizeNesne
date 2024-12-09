using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D body;
    Transform playerTransform;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float speed =5;

    private float bulletDuration = 1f;
    private float bulletTimer = 0;

    private float maxHP = 100;
    private float currentHP = 100;

    [SerializeField]
    private Image imgHP;

    [SerializeField]
    private ScoreManager scoreManager;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (bulletTimer>=bulletDuration)
        {
            bulletTimer = 0;
            Shoot();
        }
        bulletTimer += Time.deltaTime;

    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        body.AddForce((playerTransform.position - transform.position) * speed);

    }

    private void Shoot() 
    {
      Instantiate(bullet, transform.position, Quaternion.identity);
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("playerBullet"))
        {
            TakeDamage(10);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHP -= damage;
        imgHP.fillAmount = currentHP / maxHP;
        if (currentHP <= 0)
        {
            scoreManager.UpdateScore(10);
          Destroy(this.gameObject);
        }
    }
}
