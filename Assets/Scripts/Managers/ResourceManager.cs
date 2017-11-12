using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceManager : SingletonBase<ResourceManager> {
    public ConfigData configData{get;private set;}
    string dataPath = "ConfigData/json/";
    protected override void Init()
    {
        transform.SetParent(GameManager.Instance.transform);
        if (configData==null)
            InitConfigData();
    }

    void InitConfigData()
    {
        configData = new ConfigData();
        configData.player = DataHelper.DeserializeObject(dataPath + "player", configData.player);
        configData.monster = DataHelper.DeserializeObject(dataPath+"monster", configData.monster);
        configData.skill = DataHelper.DeserializeObject(dataPath+"skill", configData.skill);
        configData.item = DataHelper.DeserializeObject(dataPath+"item", configData.item);
        configData.bullet = DataHelper.DeserializeObject(dataPath+"bullet", configData.bullet);
    }
}
