using System.Collections.Generic;
[System.Serializable]

public class ConfigDataSkill : IConfigData
{
    public int id { get; set; }
    public string name{get;set;}
    public string axis { get; set; }
    public float maxSpeed{get; set;}
	public bool isAttackSkill{get;set;} // if this is a attack skill
    public float coolDownTime { get; set; }	// skill cooldown time
    public float attackRange { get; set; } // if >0, has range
    public int attackAmount { get; set; } // the damage amount
    public float outForce { get; set; } // for attack range >0 only
	
}
