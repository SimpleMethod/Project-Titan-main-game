using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.CrossPlatformInput;

public class IntroScript : MonoBehaviour
{
    public VideoClip NazwaPliku;
    private VideoPlayer Video;
    private VideoSource Zrodlo;
    private AudioSource Audio;
    private bool Status;
    private void Awake()
    {
        Functions.CreateConfig();
 

    }

    private void GetID()
    {
        try
        {
            if (Functions.StartProcess(Functions.CurrentDirectory(), "UserIdentification.exe") == 1)
            {
                Functions.Client();
            }
        }
        catch
        {
        //   UnityEngine.Debug.LogError("Błąd otwarcia pliku INTRO");
            SendData._OnlineAccess = false;
        }
    }

    void Start()
    {
        GetID();
        GameObject camera = GameObject.Find("Main Camera");
        Video = camera.AddComponent<VideoPlayer>();
        Audio = camera.AddComponent<AudioSource>();
        Audio.playOnAwake = false;
        Audio.Pause();
        Audio.volume = SendData._master_Volume;
        Video.audioOutputMode = VideoAudioOutputMode.AudioSource;
        Video.SetTargetAudioSource(0, Audio);
        Video.source = VideoSource.VideoClip;
        Video.renderMode = VideoRenderMode.CameraNearPlane;
        Video.aspectRatio = VideoAspectRatio.NoScaling;
        Video.isLooping = false;
        Video.clip = NazwaPliku;
       // Video.Prepare();

        Video.Play();
        Audio.Play();
        Status = true;




    }

    void Update()
    {
        if ((Status == true && !Video.isPlaying) || CrossPlatformInputManager.GetButtonDown(KeyMap._Submit))
        {
          //  Destroy(Video);
          //  Destroy(Audio);
            Functions.SelectLoadLevel("Menu");
        }
    }
}