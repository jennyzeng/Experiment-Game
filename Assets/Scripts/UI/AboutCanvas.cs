using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AboutCanvas : MonoBehaviour
{
    public Text rightPanelText;
    string datapath = "ConfigData/json/about";
    ConfigDataAbout configData;

    void Start()
    {
        configData = DataHelper.DeserializeObject(datapath, new ConfigDataAbout());
		SwitchText(configData.defaultContent);
    }
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnIntro()
    {
        SwitchText(configData.introduction);
    }

    public void OnTeam()
    {
        SwitchText(configData.team);
    }

    public void OnReference()
    {
        SwitchText(configData.reference);
    }

    public void OnNotes()
    {
        SwitchText(configData.notes);
    }
    public void OnWebsite(string websitelink)
    {
        Application.OpenURL(websitelink);
    }

    void SwitchText(string newText)
    {
        rightPanelText.text = newText;
    }
}
