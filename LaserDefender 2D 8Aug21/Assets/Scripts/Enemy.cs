using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;

    [SerializeField] GameObject enemyLaser;
    [SerializeField] float shotCounter;
    [SerializeField] float laserSpeed = -5f;

    [SerializeField] float min;
    [SerializeField] float max;


    GameSession gameSession;


    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        shotCounter = Random.Range(min, max);
    }

    private void Update()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            ShotFired();
            shotCounter = Random.Range(min, max);
        }
    }

    private void ShotFired()
    {
        GameObject laser = Instantiate(enemyLaser,
                                        transform.position,
                                        Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
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
            Destroy(gameObject);
            damageDealer.Hit();
            gameSession.AddScore(30);
        }
    }









}//CLASS

