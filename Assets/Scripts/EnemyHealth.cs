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
    public int enemyScore = 1;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameObject healthBarGo = Instantiate(healthBarPrefab, transform);
        healthBar = healthBarGo.GetComponentInChildren<Slider>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        if (transform.localScale.x < 0)
        {
            FlipHealthCanvas();
        }
    }
    protected override void OnDie()
    {
        base.OnDie();
        GetComponent<BaseAI>().enabled = false;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("DiedEnemies");
        GameManager.Instance.AddScore(enemyScore);
        Destroy(healthBar.transform.parent.gameObject);
    }
    protected override void DestroyAction()
    {
        // just stop there
        anim.enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparencyAfterDie);

        // Destroy(transform.parent.gameObject); // destroy the enemy and the route
    }


    protected override void OnHPchange(int HP)
    {

        healthBar.value = (float)curHP / maxHP;
    }

    public void FlipHealthCanvas()
    {
        Transform healthCanvas = healthBar.transform.parent;
        Vector3 sliderScale = healthCanvas.localScale;
        sliderScale.x *= -1;
        healthCanvas.localScale = sliderScale;
    }
}
