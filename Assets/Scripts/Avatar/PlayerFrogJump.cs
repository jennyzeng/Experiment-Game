using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogJump : MonoBehaviour
{

    // Use this for initialization
    public float maxJumpVelocity;
    public float addAmountEachTime;
    public float sensitivity;
    public KeyCode controlKey = KeyCode.Space;
    public Animator preparingEffectAnim;
    float pastTime;
    float curVelocity;
    bool isPreparing;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isPreparing = false;
		preparingEffectAnim.SetBool("blueFire", false);
        preparingEffectAnim.gameObject.SetActive(false);
        
    }
    void FixedUpdate()
    {
        if (!isPreparing && rigid.velocity.y == 0 && Input.GetKeyDown(controlKey))
        {
			Debug.Log("prepare");
                isPreparing = true;
                preparingEffectAnim.gameObject.SetActive(true);
                preparingEffectAnim.SetBool("blueFire", true);
                pastTime = Time.time;
                curVelocity = addAmountEachTime;
        }
        if (isPreparing && Input.GetKey(controlKey) && Time.time - pastTime >= sensitivity)
        {
			Debug.Log("add amount");
            curVelocity += addAmountEachTime;
            if (curVelocity > maxJumpVelocity) curVelocity = maxJumpVelocity;
            pastTime = Time.time;
        }
        if (isPreparing && Input.GetKeyUp(controlKey))
        {
			Debug.Log("jump");
            isPreparing = false;
            rigid.velocity = new Vector2(rigid.velocity.x, curVelocity);
            curVelocity = addAmountEachTime;
			preparingEffectAnim.SetBool("blueFire", false);
            preparingEffectAnim.gameObject.SetActive(false);
            
        }
    }
}
