using System;
using UnityEngine;

public class SendData : MonoBehaviour
{

    // static public string _example;
    static public int _fieldOfView;
    static public int _fastHDR;
    static public int _overallGraphicsQuality;
    static public int _postProcessQuality;
    static public int _resolutionW;
    static public int _resolutionH;

    static public int _resolutionScale;
    static public int _resolutionScaleMode;
    static public string _levelload;
    static public string _uniqueid;
    static public string _language = "PL-PL";
    static public bool _OnlineAccess;
    public static readonly string _File = "Language";

    static public bool _openmenu;
    static public bool _openchat;
    static public bool _livestatus;
#if UNITY_EDITOR
    static public float _master_Volume = 1f;
    static public float _volume_Music = 1f;
    static public int _FPSLimit = 30;
    static public bool _vsync = true;

#else
    static public float _master_Volume;
    static public float _volume_Music;
    static public int _FPSLimit;
    static public bool _vsync;
#endif
    static public string _simpleconfigplacehorder = @"{'Graphic.anisotropicFiltering': 0,
'Graphic.antiAliasing': 8, 
'Graphic.asyncUploadBufferSize': 0, 
'Graphic.asyncUploadTimeSlice': 0, 
'Graphic.billboardsFaceCameraPosition': 0, 
'Graphic.blendWeights': 0, 
'Graphic.lodBias': 150, 
'Graphic.masterTextureLimit': 0, 
'Graphic.maximumLODLevel': 0, 
'Graphic.maxQueuedFrames': 2, 
'Graphic.particleRaycastBudget': 0, 
'Graphic.realtimeReflectionProbes': 0, 
'Graphic.shadowCascade2Split': 0, 
'Graphic.shadowCascade4Split': 0, 
'Graphic.shadowCascades': 0, 
'Graphic.shadowDistance': 0, 
'Graphic.shadowNearPlaneOffset': 0, 
'Graphic.shadowProjection': 0, 
'Graphic.shadowResolution': 0, 
'Graphic.shadows': 0, 
'Graphic.softParticles': 0, 
'Graphic.softVegetation': 0, 
'Graphic.vSyncCount': 1, 
'Graphic.SetQualityLevel': 0, 
'Graphic.SetResolutionW': 1920, 
'Graphic.SetResolutionH': 1080, 
'Graphic.fullscreen': 1, 
'Graphic.preferredRefreshRate': 0,
'Graphic.fieldOfView': 90 ,
'Graphic.FastHDR':1,
'Graphic.OverallGraphicsQuality': 4,
'Graphic.PostProcessQuality': 4,
'Graphic.ResolutionScale': 1,
'Graphic.ResolutionScaleMode': 1,
'Graphic.FPSLock': 60,
'Graphic.FPSMaxRender': 60,
'Audio.Master_Volume': 1.000000,
'Audio.Volume_Music': 1.000000,
'Other.Lang': 'PL-PL',
'Other.DeveloperSettings':0
}";

}
