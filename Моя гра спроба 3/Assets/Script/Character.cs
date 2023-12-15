using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour

{


    public GameObject character;
    public string collisionTagTree;
    public string collisionTagStoon;
    public string collisionTagMob;
    public int Level = 1;
    public int Health;
    public int MaxHealth;
   
    public int DamageTree;
    public int DamageStoon;
    public int DamageMob;
    public int Speed;

   
    private void Start()
    {
        StatsUpdate();

    }
    public void StatsUpdate()
    {
        Speed = PlayerPrefs.GetInt("Speed");
        DamageTree = PlayerPrefs.GetInt("Damage Tree");
        DamageStoon = PlayerPrefs.GetInt("Damage Stoon");
        DamageMob = PlayerPrefs.GetInt("Damage Mob");
    }

   

    public void IncreaseSpeed(int speed)
    {
        this.Speed += speed;
    }

    public void DecreaseSpeed(int speed)
    {
        this.Speed -= speed;
    }

   

    public void TakeHit(int damege)
    {
        Health -= damege;
        if (Health <= 0)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);
            Debug.Log("Object was deleted");
        }
    }
    public void SetHealth(int bonusHealth)
    {
        Health += bonusHealth;
        if (Health <= 0)
        {
            Health = MaxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == collisionTagTree)
        {
            Health enemyHealth = coll.gameObject.GetComponent<Health>();
            enemyHealth.TakeHit(DamageTree);
           
        }
        if (coll.gameObject.tag == collisionTagStoon)
        {
            Health enemyHealth = coll.gameObject.GetComponent<Health>();
            enemyHealth.TakeHit(DamageStoon);
           
        }
        if (coll.gameObject.tag == collisionTagMob)
        {
            Health enemyHealth = coll.gameObject.GetComponent<Health>();
            enemyHealth.TakeHit(DamageMob);
           
        }
    }
   
}
