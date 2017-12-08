using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class BatAI : BossAI
{

    public float speed = 4f;
    public float shootSpeed = 100f;
    public Rigidbody2D ballPrefab;
    public int numPerRow = 4;
    public int rowCount = 1;
    public float shootPeriod = 1f;
    float lastShootTime;

    protected override void PairExcution(KeyValuePair<Transform, BehaviorOnPoint> pair)
    {
        if (ArrivedAtPoint(pair.Key))
        {
            pair.Value(pair.Key);
        }
        FlyFast(pair.Key);
    }

    protected override void SetStageBehaviors()
    {
        // level 1
        StageBehavior level1 = stageBehaviors[0];
        List<BehaviorOnPoint> behaviors = new List<BehaviorOnPoint>();
        for (int i = 0; i < level1.route.Count; i++)
        {
            behaviors.Add(DoNothing);
        }
        level1.SetBehaviors(behaviors);
        // level 2
        StageBehavior level2 = stageBehaviors[1];
        List<BehaviorOnPoint> behaviors2 = new List<BehaviorOnPoint>();
        for (int i = 0; i < level2.route.Count; i++)
        {
            if ((i & 1) == 0)
                behaviors2.Add(ShootBall);
            else
            {
                behaviors2.Add(DoNothing);
            }
        }
        level2.SetBehaviors(behaviors2);
    }

    protected override bool ShouldUpdatePoint(Transform curPoint)
    {
        return Vector2.Distance(transform.position, curPoint.position) < Time.deltaTime;
    }

    bool ArrivedAtPoint(Transform point)
    {
        return Vector2.Distance(transform.position, point.position) < Time.deltaTime * 1.5;
    }
    void FlyFast(Transform nextPoint)
    {
        transform.position = Vector3.Lerp(transform.position, nextPoint.position, speed * Time.deltaTime);
    }
    void DoNothing(Transform point)
    {
        return;
    }
    void ShootBall(Transform point)
    {
        if (Time.time - lastShootTime > shootPeriod)
        {
            lastShootTime = Time.time;
        }
        else { return; }
        for (int i = 1; i <= rowCount; i++)
        {
            for (int j = 0; j < numPerRow; j++)
            {
                Rigidbody2D ball = Instantiate(ballPrefab, point.position, point.rotation);
                float angle = 2f * Mathf.PI / (float)numPerRow * j;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                ball.AddForce(direction * shootSpeed * i);
            }
        }
    }
}
