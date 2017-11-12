using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : PlayerAbility {

    public Transform bulletSpawnPoint;
    public BulletDictionary bulletDict;
    
    private Bullet bulletPrefab;
    // use Fire1 axis
    float lastTriggerTime;
    PlayerMovement playerMovement;
    List<string>.Enumerator bulletEnum;

    protected override void Start()
    {
        base.Start();
        lastTriggerTime = Time.time;
        if (bulletDict.Count == 0) 
            Debug.LogError("Please add at least one bullet for the player");
        RefreshBulletEnum();
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public override void Action()
    {

        if (Time.time - lastTriggerTime >= coolDownTime)
        {
            animator.SetTrigger("Hit");
            TriggerBullet();
            lastTriggerTime = Time.time;
            
        }
    }

    void TriggerBullet()
    {
        Bullet bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.initialize(playerMovement.facingRight);
    }

    public void AddBulletType(string id, BulletScriptable bullet)
    {
        bulletDict.Add(id, bullet);
        RefreshBulletEnum();
    }
    public BulletScriptable SwitchBullet()
    {
        if (bulletEnum.MoveNext())
        {
            bulletPrefab = bulletDict[bulletEnum.Current].bulletPrefab;
            Bullet.ConfigBullet(bulletEnum.Current);
        }
        else
        {
            RefreshBulletEnum();
            bulletPrefab = bulletDict[bulletEnum.Current].bulletPrefab;
        }
        return bulletDict[bulletEnum.Current];
    }

    void RefreshBulletEnum()
    {
        List<string> bulletlist = new List<string> ( bulletDict.Keys);
        bulletlist.Sort();
        bulletEnum = bulletlist.GetEnumerator();
        bulletEnum.MoveNext();
    }
	
}
