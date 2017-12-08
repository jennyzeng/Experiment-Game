using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public abstract class BossAI : MonoBehaviour
{
    public List<int> levelHPs; // in descending order
    public List<StageBehavior> stageBehaviors;
    EnemyHealth health;
    public bool facingRight;
    int curLevel;
    StageBehavior curStage;
    void Start()
    {
        if (levelHPs.Count != stageBehaviors.Count)
        {
            Debug.LogError("size of level hps should be the same as the size of routes");
        }
        health = GetComponent<EnemyHealth>();
        SetStageBehaviors();
        curLevel = 0;
        curStage = stageBehaviors[curLevel];
        // Debug.Log("Start: "+curStage.behaviors.Count);
    }
    protected abstract void SetStageBehaviors();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health.curHP <= 0)
        {
            enabled = false;
            return;
        }
        if (health.curHP < levelHPs[curLevel])
        {
            curLevel += 1;
            curStage = stageBehaviors[curLevel];
        }
        KeyValuePair<Transform, BehaviorOnPoint> pair = curStage.Cur();
        PairExcution(pair);
        if (ShouldUpdatePoint(pair.Key))
        {
            pair = curStage.Next();
            if ((facingRight && MathTools.IsOnLeft(transform.position, pair.Key.position)) || (
            !facingRight && !MathTools.IsOnLeft(transform.position, pair.Key.position
            )))
            {
                MathTools.Flip(transform);
                facingRight = !facingRight;
				health.FlipHealthCanvas();
            }
        }

    }

    protected abstract bool ShouldUpdatePoint(Transform curPoint);

    protected abstract void PairExcution(KeyValuePair<Transform, BehaviorOnPoint> pair);
}
