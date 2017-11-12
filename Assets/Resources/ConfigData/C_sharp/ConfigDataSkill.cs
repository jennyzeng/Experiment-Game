using System.Collections.Generic;
[System.Serializable]

public class ConfigDataSkill : IConfigData
{
    public int id { get; set; }
    public string name{get;set;}
    public string axis { get; set; }
    public float maxSpeed{get; set;}
    public float coolDownTime { get; set; }	// skill cooldown time

	
}
