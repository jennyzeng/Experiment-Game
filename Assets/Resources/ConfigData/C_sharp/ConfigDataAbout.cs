using System.Collections.Generic;
[System.Serializable]

public class ConfigDataAbout : IConfigData
{

    public string defaultContent{get;set;}
    public string introduction { get; set; }
    public string team { get; set; }
    public string reference { get; set; }
    public string notes { get; set; }

}
