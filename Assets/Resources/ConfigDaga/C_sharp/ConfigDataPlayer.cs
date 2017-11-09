using System.Collections.Generic;
[System.Serializable]
public class ConfigDataPlayer : IConfigData {
	public int id { get; set; }
	public int maxHP { get; set; }
	public float transparentAmount {get;set;}
	public float avoidDamageTimeDuration {get;set;}
	public float flashIntervalWhenDamge {get;set;}
	public int defendAmount {get;set;}
	public int score {get;set;}
}
