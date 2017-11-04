using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    public GameObject healthBarPrefab;
    [HideInInspector]
    public Slider healthBar;

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
    }
    protected override void DestroyAction()
    {
        Destroy(transform.parent.gameObject); // destroy the enemy and the route
    }


    protected override void OnHPchange(int HP)
    {

        healthBar.value = (float) curHP / maxHP;
        Debug.Log("set value " + curHP / maxHP);
    }

    public void FlipHealthCanvas()
    {
        Transform healthCanvas = healthBar.transform.parent;
        Vector3 sliderScale = healthCanvas.localScale;
        sliderScale.x *= -1;
        healthCanvas.localScale = sliderScale;
    }
}
