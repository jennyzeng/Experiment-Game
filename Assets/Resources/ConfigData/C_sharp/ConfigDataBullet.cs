using System.Collections.Generic;
[System.Serializable]

public class ConfigDataBullet : IConfigData {
	public int id {get;set;}
	public int damageAmount {get;set;}
	public int outForce {get;set;}
	public float duration {get;set;}
	public string sound  {get;set;}
	public string bulletPrefab  {get;set;}
	public float coolDownTime{get;set;}
}
