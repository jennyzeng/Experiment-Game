using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : PlayerAbility {

    public Transform bulletSpawnPoint;
    public BulletDictionary bulletDict;
    
    private Bullet bulletPrefab;
    // use Fire1 axis
    PlayerMovement playerMovement;
    private List<string>.Enumerator _bulletEnum;
        private float _lastTriggerTime;

    protected override void Start()
    {
        base.Start();
        _lastTriggerTime = Time.time;
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

        if (Time.time - _lastTriggerTime >= coolDownTime && Input.GetButtonDown(axis))
        {

            animator.SetTrigger("Hit");
            TriggerBullet();
            _lastTriggerTime = Time.time;
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
        if (!_bulletEnum.MoveNext())
        {
            RefreshBulletEnum();
            bulletPrefab = bulletDict[_bulletEnum.Current]; 
        }
        bulletPrefab = bulletDict[_bulletEnum.Current];
        Bullet.ConfigBullet(_bulletEnum.Current);
        return bulletDict[_bulletEnum.Current];
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
        _bulletEnum = bulletlist.GetEnumerator();
        _bulletEnum.MoveNext();
    }
	
}
