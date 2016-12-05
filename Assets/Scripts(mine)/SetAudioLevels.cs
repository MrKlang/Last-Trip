using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

    public AudioMixer mainMixer;

    public void SetMusicLevel(float musicLvl)
    {
        mainMixer.SetFloat("musicVol",musicLvl);
    }

    public void SetSfxLevel(float sfxLvl)
    {
        mainMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMasterLevel(float masterLvl)
    {
        mainMixer.SetFloat("masterVol", masterLvl);
    }

    public void SetNarratorLevel(float narratorLvl)
    {
        mainMixer.SetFloat("narratorVol", narratorLvl);
    }
}
