using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public string ID;
    float transparentAmount = 0.5f;
    float avoidDamageTimeDuration = 5f;
    float flashIntervalWhenDamge = 0.5f;
    float defendAmount = 0;
    HUDCanvas hUDCanvas;
    int score;
    Color normalColor;
    SpriteRenderer spriteRenderer;
    private Color transColor = new Color(1f, 1f, 1f, 0.5f);
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
        ConfigDataPlayer configData = new ConfigDataPlayer();

        if (ResourceManager.Instance.configData.player.TryGetValue(ID, out configData))
        {
            DataConfig(configData);
        }
        curHP = maxHP;
        hUDCanvas = UIManager.Instance.GetCanvas<HUDCanvas>();
        hUDCanvas.OnHPchange((float)curHP / maxHP);
        // transColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
        //                 transparentAmount);

    }
    void DataConfig(ConfigDataPlayer configData)
    {
        maxHP = configData.maxHP;
        timeDisappearAfterDie = configData.timeDisappearAfterDie;
        transparentAmount = configData.transparentAmount;
        transColor = new Color(1f, 1f, 1f, transparentAmount);
        avoidDamageTimeDuration = configData.avoidDamageTimeDuration;
        flashIntervalWhenDamge = configData.flashIntervalWhenDamge;
        defendAmount = configData.defendAmount;
        score = configData.score;
    }

    public override void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("amount should be positive");
            return;
        }

        amount = Mathf.Max(0, (int)Mathf.Ceil((1 - defendAmount) * amount));
        curHP -= amount;
        if (curHP <= 0)
        {
            curHP = 0;
            OnDie();
        }
        else
        {
            OnDamage();
        }
        OnHPchange(curHP);
    }

    public bool IsFullHP()
    {
        return curHP == maxHP;
    }
    public void AddHP(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("amount should be positive");
            return;
        }
        curHP += amount;
        if (curHP > maxHP) curHP = maxHP;
        OnGetHealth();

    }
    void OnGetHealth() { 
        // TODO: add anim in the future
        OnHPchange(curHP);
    }

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

    protected override void OnDie()
    {
        // base.OnDie();
        anim.SetTrigger("Die");
        GameManager.Instance.GameOver();
        foreach(PlayerAbility ability in GetComponents<PlayerAbility>())
        {
            ability.enabled = false;
        }
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

    protected override void OnHPchange(int HP)
    {
        hUDCanvas.OnHPchange((float)curHP / maxHP);
    }

}
