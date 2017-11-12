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
        SwitchBullet();
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
        Bullet bullet = GameObject.Instantiate(bulletPrefab,
             bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.initialize(playerMovement.facingRight);
    }

    public bool IsBulletAlreadyCollected(string id)
    {
        return bulletDict.ContainsKey(id);
    }

    public void AddBulletType(string id, Bullet bullet)
    {
        bulletDict.Add(id, bullet);
        RefreshBulletEnum();
    }
    public Bullet SwitchBullet()
    {
        if (!bulletEnum.MoveNext())
        {
            RefreshBulletEnum();
            bulletPrefab = bulletDict[bulletEnum.Current]; 
        }
        bulletPrefab = bulletDict[bulletEnum.Current];
        Bullet.ConfigBullet(bulletEnum.Current);
        return bulletDict[bulletEnum.Current];
    }

    public Bullet SwitchBullet(string id)
    {
        Bullet bullet;
        if (bulletDict.TryGetValue(id, out bullet))
        {
            bulletPrefab = bullet; 
            Bullet.ConfigBullet(id);
            RefreshBulletEnum();
        }
        return bullet;
    }

    void RefreshBulletEnum()
    {
        List<string> bulletlist = new List<string> ( bulletDict.Keys);
        bulletlist.Sort();
        bulletEnum = bulletlist.GetEnumerator();
        bulletEnum.MoveNext();
    }
	
}
