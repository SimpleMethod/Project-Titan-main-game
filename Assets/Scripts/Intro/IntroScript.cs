using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(VideoClip))]

public class IntroScript : MonoBehaviour
{
    public VideoClip NazwaPliku;
    [SerializeField]
    private VideoPlayer Video;
    [SerializeField]
    private VideoSource Zrodlo;
    [SerializeField]
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
                Functions.RequestToServer(SendData._uniqueid, 2, 0);
                Functions.RequestToServer(SendData._uniqueid, 5, 10);
            }
        }
        catch
        {
            UnityEngine.Debug.LogError("Błąd otwarcia pliku INTRO");
            SendData._OnlineAccess = false;
        }
    }

    void Start()
    {
        GetID();
        GameObject camera = GameObject.Find("Main Camera");
        Video = camera.AddComponent<VideoPlayer>();
        Video.audioOutputMode = VideoAudioOutputMode.AudioSource;
        Video.source = VideoSource.VideoClip;
        Video.renderMode = VideoRenderMode.CameraNearPlane;
        Video.aspectRatio = VideoAspectRatio.NoScaling;
        Video.isLooping = false;
        Video.clip = NazwaPliku;
        // Video.Prepare();
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        audio.volume = SendData._master_Volume;
        audio.Play();
        Video.Play();
        Status = true;
    }

    void Update()
    {
        if ((Status == true && !Video.isPlaying) || CrossPlatformInputManager.GetButtonDown(KeyMap._Submit))
        {
            Functions.SelectLoadLevel("Menu");
        }
    }
}