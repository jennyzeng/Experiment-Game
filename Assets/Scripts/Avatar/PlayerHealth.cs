using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public float transparentAmount = 0.5f;
    public float avoidDamageTimeDuration = 5f;
    public float flashIntervalWhenDamge = 0.5f;
    public int defendAmount = 0;
    HUDCanvas hUDCanvas;
    int score;
    Color normalColor;
    SpriteRenderer spriteRenderer;
    private Color transColor= new Color(1f,1f,1f,0.5f);
    protected override void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
                        spriteRenderer.color.a);
    }
    public void Initialize()
    {
        // TODO: load resources 
        curHP = maxHP;
        hUDCanvas = UIManager.Instance.GetCanvas<HUDCanvas>();
        hUDCanvas.OnHPchange((float)curHP / maxHP);
        // transColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
        //                 transparentAmount);

    }
    public override void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            curHP -= Mathf.Max(0, (amount - defendAmount));
            if (curHP <= 0)
            {
                curHP = 0;
                OnDie();
            }
            else
            {
                OnDamage();
            }
        }
        else
        {// add health
            curHP -= amount;
            if (curHP > maxHP) curHP = maxHP;
            OnGetHealth();
        }
        OnHPchange(curHP);
    }
    void OnGetHealth() { }

    protected override void OnDamage()
    {
        anim.SetTrigger("Hurt");
        ActivateCollision(true);
        TimerManager timerManager = TimerManager.Instance;
        // flash effect
        timerManager.AddTimer(0, gameObject, Flash, flashIntervalWhenDamge,
        (int)(avoidDamageTimeDuration / flashIntervalWhenDamge));
        // reset to normal state, no longer invulnerable
        timerManager.AddTimer(avoidDamageTimeDuration, gameObject, ResetToNormal);
    }

    void ActivateCollision(bool ignore)
    {
        int playerLayer = LayerMask.NameToLayer("Players");
        int enemyLayer = LayerMask.NameToLayer("Enemies");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, ignore);
    }

    void ResetToNormal()
    {
        spriteRenderer.color = normalColor;
        ActivateCollision(false);
    }
    void Flash()
    {
        if (spriteRenderer.color.Equals(normalColor))
        {
            spriteRenderer.color = transColor;
        }
        else
        {
            spriteRenderer.color = normalColor;
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChange(score);
    }

    void OnScoreChange(int score)
    {

    }
    protected override void OnHPchange(int HP)
    {
        hUDCanvas.OnHPchange((float)curHP / maxHP);
    }

}
