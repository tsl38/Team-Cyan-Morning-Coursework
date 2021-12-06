using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    //An array to store some objects of the type Sounds.
    public Sounds[] arrayOfSounds;
    //Current theme and ambient sound.
    [HideInInspector]
    public string currentTheme;
    public string currentAmbientSound;

    //Instance of SoundManager for singleton pattern
    public static SoundManager _instance;

    // Start is called before the first frame update
    void Awake()
    {
        //Singleton pattern to make sure only one instance of SoundManager exists in a scene at one time.
        if (_instance == null)
        {
            _instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        
        //On initialization of the SoundManager object, and thus this script, loop through each Sounds objects in the array and set the AudioSource.
        foreach (Sounds soundsObj in arrayOfSounds) {
            soundsObj.source = gameObject.AddComponent<AudioSource>();
            soundsObj.source.clip = soundsObj.soundClip;
            soundsObj.source.volume = soundsObj.volume;
            soundsObj.source.pitch = soundsObj.pitch;
            soundsObj.source.loop = soundsObj.loop;
        }
    }

    //Start function to play the main menu theme.
    void Start() {
        //Play menu theme.
        Play("MainMenuTheme");
        currentTheme = "MainMenuTheme";
    }

    //Finds the name of the sound object and plays the AudioClip from the AudioSource.
    public void Play(string name) {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == name);
        //Plays the sound if the object is not null, i.e. if the object is found.
        if (soundsObj != null)
        {
            soundsObj.source.Play();
        }
        //else, print an error message and return from the function.
        else
        {
            Debug.Log("Error: Sound object with " + name + " cannot be found!");
            return;
        }
    }

    //Finds the name of the sound object and pauses the AudioClip from the AudioSource.
    public void Pause(string name)
    {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == name);
        //Plays the sound if the object is not null, i.e. if the object is found.
        if (soundsObj != null)
        {
            soundsObj.source.Pause();
        }
        //else, print an error message and return from the function.
        else
        {
            Debug.Log("Error: Sound object with " + name + " cannot be found!");
            return;
        }
    }

    //Stops playing the sound object with "name".
    public void Stop(string name) {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == name);
        //Plays the sound if the object is not null, i.e. if the object is found.
        if (soundsObj != null)
        {
            soundsObj.source.Stop();
        }
        //else, print an error message and return from the function.
        else
        {
            Debug.Log("Error: Sound object with " + name + " cannot be found!");
            return;
        }
    }

    //Finds the name of the sound object and resumes the AudioClip from the AudioSource.
    public void Resume(string name)
    {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == name);
        //Plays the sound if the object is not null, i.e. if the object is found.
        if (soundsObj != null)
        {
            soundsObj.source.UnPause();
        }
        //else, print an error message and return from the function.
        else
        {
            Debug.Log("Error: Sound object with " + name + " cannot be found!");
            return;
        }
    }

    //Stops playing the current sound clip.
    public void StopCurrent() {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentTheme);
        Sounds soundsObj2 = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentAmbientSound);
        if (soundsObj != null) {
            soundsObj.source.Stop();
        }
        if (soundsObj2 != null)
        {
            soundsObj2.source.Stop();
        }
    }

    //Pauses the current track.
    public void PauseCurrent() {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentTheme);
        Sounds soundsObj2 = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentAmbientSound);
        if (soundsObj != null)
        {
            soundsObj.source.Pause();
        }
        if (soundsObj2 != null)
        {
            soundsObj2.source.Pause();
        }
    }
  
    //Resumes the current track.
    public void ResumeCurrent() {
        Sounds soundsObj = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentTheme);
        Sounds soundsObj2 = Array.Find(arrayOfSounds, sound => sound.nameOfSound == currentAmbientSound);
        if (soundsObj != null)
        {
            soundsObj.source.UnPause();
        }
        if (soundsObj2 != null)
        {
            soundsObj2.source.UnPause();
        }
    }
}
