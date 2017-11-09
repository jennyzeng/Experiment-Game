using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigData {
	public Dictionary<string, ConfigDataPlayer> player;
	public Dictionary<string, ConfigDataMonster> monster;
	public Dictionary<string, ConfigDataItem> item;
	public Dictionary<string, ConfigDataSkill> skill;

	public ConfigData()
	{
		player = new Dictionary<string, ConfigDataPlayer>();
		monster = new Dictionary<string, ConfigDataMonster>();
		item = new Dictionary<string, ConfigDataItem>();
		skill = new Dictionary<string, ConfigDataSkill>();
	}
}
