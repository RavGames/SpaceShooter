using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [Header("Ship Attributes")]
    [SerializeField] float shipSpeed = 10f;
    [SerializeField] int health = 100;

    [Header("Projectile")]
    [SerializeField] GameObject laserProjectile;
    [SerializeField] float LaserSpeed = 5f;
    [SerializeField] float waitingPeriod = .2f;


    [Header("Boundary")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] int padding = 1;

    private Coroutine firingCoroutine;

    private Level level;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        Camera camera;

        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

       
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireLaser());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }

        Move();
    }


    private void Move()
    {
        float moveXPos = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime;
        float moveYPos = Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime;
        /*

        float newXPos = transform.position.x + moveXPos;
        float newYPos = transform.position.y + moveYPos;
        */

        float newXPos = Mathf.Clamp(transform.position.x + moveXPos, minX, maxX);
        float newYPos = Mathf.Clamp(transform.position.y + moveYPos, minY, maxY);


        transform.position = new Vector2(newXPos, newYPos);  
    }


    IEnumerator FireLaser()
    {
        do
        {
            GameObject laser = Instantiate(laserProjectile,
                            transform.position,
                            Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LaserSpeed);
            yield return new WaitForSeconds(waitingPeriod);
        }
        while (true);
        
    }


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        DamageDealer damageDealer = otherCollider.gameObject.GetComponent<DamageDealer>();
        if (!otherCollider.gameObject.GetComponent<DamageDealer>()) { return; }

        GotHit(damageDealer);
    }

    private void GotHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health == 0)
        {
            Die();
            damageDealer.Hit();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        level.LoadGameOver();
    }

   
    public int GetHealth()
    {
        return health;
    }


}//CLASS
