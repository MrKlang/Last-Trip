using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayManager : MonoBehaviour {
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Slider brightnessSlider;
    public Button SaveSettingsButton;
    public Resolution[] resolutions;
    public DisplaySettings displaySettings;

    void OnEnable()
    {
        displaySettings = new DisplaySettings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionValueChanged(); });
        brightnessSlider.onValueChanged.AddListener(delegate { OnBrightnessChanged(); });
        resolutions = Screen.resolutions;
        SaveSettingsButton.onClick.AddListener(delegate { OnSaveSettingsButtonClick(); });
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        
        displaySettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionValueChanged()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height,Screen.fullScreen);
        displaySettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnBrightnessChanged()
    {
        displaySettings.brightness = brightnessSlider.value;
        RenderSettings.ambientLight = new Color(displaySettings.brightness, displaySettings.brightness, displaySettings.brightness, 1);
    }

    public void OnSaveSettingsButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(displaySettings, true);
        File.WriteAllText(Application.persistentDataPath + "/displaySettings.json",jsonData);
    }

    public void LoadSettings()
    {
        File.ReadAllText(Application.persistentDataPath + "/displaySettings.json");
        displaySettings = JsonUtility.FromJson<DisplaySettings>(File.ReadAllText(Application.persistentDataPath+"/displaySettings.json"));
        brightnessSlider.value = displaySettings.brightness;
        resolutionDropdown.value = displaySettings.resolutionIndex;
        fullscreenToggle.isOn = displaySettings.fullscreen;
        Screen.fullScreen = displaySettings.fullscreen;
        resolutionDropdown.RefreshShownValue();
    }
}
