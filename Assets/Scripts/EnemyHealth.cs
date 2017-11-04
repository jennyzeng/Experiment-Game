using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    public GameObject healthBarPrefab;
    [HideInInspector]
    public Slider healthBar;
    public float transparencyAfterDie = 0.5f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameObject healthBarGo = Instantiate(healthBarPrefab, transform);
        healthBar = healthBarGo.GetComponentInChildren<Slider>();
    }

    protected override void OnDie()
    {
        base.OnDie();
        GetComponent<BaseAI>().enabled = false;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        enabled = false;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), 
            GameManager.Instance.GetManager<GameObjectManager>().player.GetComponent<Collider2D>(), true);
        Destroy(healthBar.transform.parent.gameObject);
    }
    protected override void DestroyAction()
    {
        // just stop there
        anim.enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, transparencyAfterDie);
        
        // Destroy(transform.parent.gameObject); // destroy the enemy and the route
    }


    protected override void OnHPchange(int HP)
    {

        healthBar.value = (float) curHP / maxHP;
    }

    public void FlipHealthCanvas()
    {
        Transform healthCanvas = healthBar.transform.parent;
        Vector3 sliderScale = healthCanvas.localScale;
        sliderScale.x *= -1;
        healthCanvas.localScale = sliderScale;
    }
}
