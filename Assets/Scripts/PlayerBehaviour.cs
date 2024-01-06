using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehavior
{
    [SerializeField] HealthBar _healthBar;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerTakeHeal(15);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.TakeDmg(dmg);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
    
    private void PlayerTakeHeal(int healing)
    {
        GameManager.gameManager._playerHealth.TakeHeal(healing);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    private void OnTriggerEnter(Collider damagingObject)
    {
        if (damagingObject.gameObject.GetComponent<IDamageObject>() == null) return;
        Debug.Log("I touch Damageable object");
        PlayerTakeDmg(damagingObject.gameObject.GetComponent<IDamageObject>().GetDamageAmount());
        Debug.Log("I take "+ damagingObject.gameObject.GetComponent<IDamageObject>().GetDamageAmount() + " damage");
        //some effects
        //some particles
    }
}
