using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicDetection : MonoBehaviour
{

    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 500;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    private float _sleepTime = 1;

    public bool _moveRight = true;
    private Vector3 currentDirection = Vector3.zero;
    //public GameObject target; //the enemy's target



    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
    }


    public void Update()
    {

        if (_moveRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime * 3);
            if (!_isFacingRight)
                Flip();
            EnemySpeed = EnemySpeed - 1;
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime);
            if (_isFacingRight)
                Flip();
            EnemySpeed = EnemySpeed - 1;
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;

        



    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentDirection = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
