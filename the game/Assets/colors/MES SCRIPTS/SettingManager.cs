using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Slider musicVolumeSlider;
	public Resolution[] resolutions;
	public GameSettings gamesettings;


	void OnEnable()
	{
		gamesettings = new GameSettings();

		fullscreenToggle.onValueChanged.AddListener (delegate {	OnFullscreenToggle(); });

		musicVolumeSlider.onValueChanged.AddListener (delegate {OnMusicVolumeChange(); });
		resolutions = Screen.resolutions;

		for (int i = 0; i < resolutions.Length; i++) {
			resolutionDropdown.options [i].text = ResToString (resolutions [i]);
			resolutionDropdown.value = i;
		}
		for (int j = 0; j < resolutionDropdown.options.Capacity; j++) {
			if (resolutionDropdown.options[j].text == " ") {
				resolutionDropdown.options.RemoveAt (j);
				j--;
			}
		}

		resolutionDropdown.onValueChanged.AddListener (delegate {OnResolutionChange(); });

	}

	string ResToString(Resolution res)
	{
		return res.width + " x " + res.height;
	}

	public void OnFullscreenToggle()
	{
		gamesettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, fullscreenToggle.isOn);
	}

	public void OnMusicVolumeChange()
	{
		gamesettings.musicVolume = musicVolumeSlider.value;
	}
}
