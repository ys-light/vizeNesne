using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D connectedBody;
    private HingeJoint2D hingeJoint2D;

    private float bulletDuration = 0.5f;
    private float bulletTimer = 0f;
    private GameObject playerBullet;
    public void Setup(Rigidbody2D rigidbody2D, GameObject bullet)
    {
        connectedBody = rigidbody2D;
        this.playerBullet = bullet;
    }
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        hingeJoint2D.connectedBody = connectedBody;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {

        //if (bulletTimer >= bulletDuration)
        //{
        //    Instantiate(playerBullet, transform.position, Quaternion.identity).GetComponent<PlayerBullet>().Setup(GameObject.FindGameObjectWithTag("enemy").transform);
        //    bulletTimer = 0;
        //}


        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        if (enemy == null)
        {
            Debug.Log("Enemy yok, oyun durduruldu!");
           /* Time.timeScale = 0; */// Oyun durduruluyor
            return; // Fonksiyondan çýk
        }

        //Eðer düþman varsa ateþ et
        if (bulletTimer >= bulletDuration)
        {
            Instantiate(playerBullet, transform.position, Quaternion.identity).GetComponent<PlayerBullet>().Setup((enemy).transform);
            bulletTimer = 0;
        }

        bulletTimer += Time.deltaTime;
    }
}
