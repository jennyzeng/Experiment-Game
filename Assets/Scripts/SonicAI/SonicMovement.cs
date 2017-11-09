using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicMovement : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    private Vector3 currentDirection = Vector3.zero;
    void Start()
    {
       
       target = GameObjectManager.Instance.player;
        //GameManager.Instance.GetManager<TimerManager>().AddTimer;
    }
    void Update()
    {
        if (target == null)
            target = GameObjectManager.Instance.player;
        if (target == null) return;
        Vector3 targetDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        currentDirection = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }


}

