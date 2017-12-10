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
    Color normalColor;
    SpriteRenderer spriteRenderer;
    private Color transColor = new Color(1f, 1f, 1f, 0.5f);
    protected void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
                        spriteRenderer.color.a);
        ActivateCollision(false);
    }

    public void SyncHealth(PlayerHealth anotherBodyHealth)
    {
        transparentAmount = anotherBodyHealth.transparentAmount;
        avoidDamageTimeDuration = anotherBodyHealth.avoidDamageTimeDuration;
        flashIntervalWhenDamge = anotherBodyHealth.flashIntervalWhenDamge;
        defendAmount = anotherBodyHealth.defendAmount;
        maxHP= anotherBodyHealth.maxHP;
        curHP = anotherBodyHealth.curHP;
        hUDCanvas = anotherBodyHealth.hUDCanvas;
        OnHPchange(curHP);
        GetComponent<Rigidbody2D>().velocity = anotherBodyHealth.GetComponent<Rigidbody2D>().velocity;
        
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
        OnHPchange(curHP);

        // transColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
        //                 transparentAmount);
    }

    // void OnEnable()
    // {
    //     // Debug.Log("on enable");
    //     // hUDCanvas = UIManager.Instance.GetCanvas<HUDCanvas>();
    //     // hUDCanvas.OnHPchange((float)curHP / maxHP);
    // }
    void DataConfig(ConfigDataPlayer configData)
    {
        maxHP = configData.maxHP;
        timeDisappearAfterDie = configData.timeDisappearAfterDie;
        transparentAmount = configData.transparentAmount;
        transColor = new Color(1f, 1f, 1f, transparentAmount);
        avoidDamageTimeDuration = configData.avoidDamageTimeDuration;
        flashIntervalWhenDamge = configData.flashIntervalWhenDamge;
        defendAmount = configData.defendAmount;
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
    public void ResetToFullHP()
    {
        curHP = maxHP;
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
        if (anim)
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
        if (anim!=null)
            anim.SetTrigger("Die");
        ActivateCollision(true);
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
        UIManager.Instance.GetCanvas<HUDCanvas>().OnHPchange((float)curHP / maxHP);
        // hUDCanvas.
    }

}
