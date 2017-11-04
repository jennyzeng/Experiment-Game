using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {


    HUDCanvas hUDCanvas;
    int score;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Initialize()
    {
        // TODO: load resources 
        curHP = maxHP;
        hUDCanvas = GameManager.Instance.GetManager<UIManager>().GetCanvas<HUDCanvas>();
        hUDCanvas.OnHPchange((float) curHP/maxHP);
    }   

    public void AddScore(int amount){
        score += amount;
        OnScoreChange(score);
    }

    void OnScoreChange(int score)
    {

    }
    protected override void OnHPchange(int HP)
    {
        hUDCanvas.OnHPchange((float) curHP/maxHP);
    }

}
