using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField]
    FixedJoystick fixedJoystick;
    Vector2 moveVector;
    private float moveSpeed = 20f;
    private readonly int MoveSpeedMultiplier = 10;

    private float maxHP = 100;
    private float currentHP = 100;

    [SerializeField]
    private Image imgHP;

    [SerializeField]
    private GameObject playerBullet;
    private float bulletDuration = 0.5f;
    private float bulletTimer = 0f;

    [SerializeField]
    private List<GameObject> tails;

    [SerializeField]
    private GameObject tail;

    //private int moveSpeed = 0;
    [SerializeField]
    private Text txtLevel;
    private int  level = 0;

    public int Level { get => level; set => level = value; }
    [SerializeField]
    private GameObject destroyEffect;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //moveSpeed = level * 10;
        var tailObj = Instantiate(tail, transform.position, Quaternion.identity);
        tailObj.GetComponent<TailController>().Setup(body,playerBullet);
        tails.Add(tailObj);

        txtLevel.text = "Level:" + Level;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = fixedJoystick.Horizontal;
        moveVector.y = fixedJoystick.Vertical;
        if (fixedJoystick.JoystickPoinerDown)
        {
            Attack();
            TailAttack();
        }
        if (currentHP<=0)
        {
            Debug.Log("�ld�n!");
            //Time.timeScale = 0; 
            return; 
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (fixedJoystick.JoystickPoinerDown)
        {
            body.AddForce(moveVector * 20);
        }


    }

    private void HandleRotation()
    {
        float hAxis = fixedJoystick.Horizontal;
        float vAxis = fixedJoystick.Vertical;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -zAxis);


    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("enemyBullet"))
    //    {
    //        TakeDamage(10);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemyBullet"))
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
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            GameOver();
        }
    }

    private void GameOver()
    {

        //Yeniden ba�lat.
        SceneManager.LoadScene(0);
    }

    private void Attack()
    {
        //Enemy kontrol�
        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        if (enemy == null)
        {
            Debug.Log("Enemy yok, oyun durduruldu!");
            /*Time.timeScale = 0; */// Oyun durduruluyor
            return; // Fonksiyondan ��k
        }

        //E�er d��man varsa ate� et
        if (bulletTimer >= bulletDuration)
        {
            Instantiate(playerBullet, transform.position, Quaternion.identity).GetComponent<PlayerBullet>().Setup((enemy).transform);
            bulletTimer = 0;
        }

        bulletTimer += Time.deltaTime;

        //var enemy = GameObject.FindGameObjectWithTag("enemy");
        //if (enemy != null&& bulletTimer >= bulletDuration)
        //{
        //    Instantiate(playerBullet, transform.position, Quaternion.identity).GetComponent<PlayerBullet>().Setup(enemy.transform);
        //}
    }

    private void TailAttack()
    {

        foreach (GameObject tailObj in tails)
        {
            tailObj.GetComponent<TailController>().Attack();
        }
    }
    public void UpdateLevel()

    {
        var prevTail = tails[Level];
        var tailObj = Instantiate(tail, prevTail.transform.position, Quaternion.identity);
        tailObj.GetComponent<TailController>().Setup(prevTail.GetComponent<Rigidbody2D>(),playerBullet);
        tails.Add(tailObj);
        Level++;
        moveSpeed = Level * MoveSpeedMultiplier;
        txtLevel.text = "Level: "+Level;
    }
}

