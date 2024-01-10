using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour, IDamageObject
{
    [SerializeField] protected int _projectileMinDamage = 7122;
    [SerializeField] protected int _projectileMaxDamage = 10683;
    [SerializeField] protected int _projectileSpeed = 0;
    [SerializeField] protected int _pierceCount = 1;

    public int ProjectileMinDamage
    {
        get
        {
            return _projectileMinDamage;
        }
        set
        {
            _projectileMinDamage = value;
        }
    }
    
    public int ProjectileMaxDamage
    {
        get
        {
            return _projectileMaxDamage;
        }
        set
        {
            _projectileMaxDamage = value;
        }
    }
    
    public int ProjectileSpeed
    {
        get
        {
            return _projectileSpeed;
        }
        set
        {
            _projectileSpeed = value;
        }
    }
    
    public int PierceCount
    {
        get
        {
            return _pierceCount;
        }
        set
        {
            _pierceCount = value;
        }
    }
    
    public Projectile(int projectileDamage, int projectileSpeed, int pierceCount)
    {
        projectileDamage = _projectileMinDamage;
        projectileSpeed = _projectileSpeed;
        pierceCount = _pierceCount;
    }

    protected Projectile()
    {
        
    }

    public int GetDamageAmount()
    {
        return Random.Range(_projectileMinDamage, _projectileMaxDamage);
    }

    protected void TargetPierced()
    {
        if (_pierceCount >= 0) _pierceCount--;
        Debug.Log("I can pierce " + PierceCount+ " more targets");
        if (_pierceCount <= 0) Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter(Collider damageableObject)
    {
        if (damageableObject.gameObject.GetComponent<ICollisionObject>() == null) return;
        if (damageableObject.gameObject.GetComponent<IDamageable>() == null)
        {
            Destroy(this.gameObject);
            return;
        }
        TargetPierced();
    }
}
