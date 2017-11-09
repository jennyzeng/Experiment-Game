using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : PlayerAbility {

    public Transform bulletSpawnPoint;
    public Bullet bulletPrefab;
    // use Fire1 axis
    float lastTriggerTime;
    PlayerMovement playerMovement;
    protected override void Start()
    {
        base.Start();
        lastTriggerTime = Time.time;
        attackRange *= Mathf.Abs(transform.localScale.x);
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
            DetectHit();
            lastTriggerTime = Time.time;
            animator.SetTrigger("Hit");
        }
    }

    void DetectHit()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        if (!playerMovement.facingRight)
        {
            MathTools.Flip(bullet.transform);
            bullet.initialize(-outForce, attackAmount);
        }
        else
        {
            bullet.initialize(outForce, attackAmount);
        }
    }
	
}
