using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Config : MonoBehaviour
{


    private void Awake()
    {
        float[] ConfigTable = new float[100];
        string Path = File.ReadAllText(Functions.CurrentDirectory() + @"\config.json");
        JObject rss = JObject.Parse(Path);
        ConfigTable[0] = (int)rss["Graphic.anisotropicFiltering"]; // RD
        ConfigTable[1] = (int)rss["Graphic.antiAliasing"]; // RD
        ConfigTable[2] = (int)rss["Graphic.asyncUploadBufferSize"]; // RD
        ConfigTable[3] = (int)rss["Graphic.asyncUploadTimeSlice"]; // RD
        ConfigTable[4] = (int)rss["Graphic.billboardsFaceCameraPosition"];
        ConfigTable[5] = (int)rss["Graphic.blendWeights"]; // RD
        ConfigTable[6] = (float)rss["Graphic.lodBias"]; // RD
        ConfigTable[7] = (int)rss["Graphic.masterTextureLimit"]; // RD
        ConfigTable[8] = (int)rss["Graphic.maximumLODLevel"]; // RD
        ConfigTable[9] = (int)rss["Graphic.maxQueuedFrames"]; // RD
        ConfigTable[10] = (int)rss["Graphic.particleRaycastBudget"]; // RD
        ConfigTable[11] = (int)rss["Graphic.realtimeReflectionProbes"]; // RD
        ConfigTable[12] = (int)rss["Graphic.shadowCascade2Split"];//RD
        ConfigTable[13] = (int)rss["Graphic.shadowCascade4Split"];
        ConfigTable[14] = (int)rss["Graphic.shadowCascades"]; // RD
        ConfigTable[15] = (int)rss["Graphic.shadowDistance"]; // RD
        ConfigTable[16] = (int)rss["Graphic.shadowNearPlaneOffset"]; // RD
        ConfigTable[17] = (int)rss["Graphic.shadowProjection"];
        ConfigTable[18] = (int)rss["Graphic.shadowResolution"];// RD
        ConfigTable[19] = (int)rss["Graphic.shadows"];
        ConfigTable[20] = (int)rss["Graphic.softParticles"]; // RD
        ConfigTable[21] = (int)rss["Graphic.softVegetation"]; // RD
        ConfigTable[22] = (int)rss["Graphic.vSyncCount"]; // RD
        ConfigTable[23] = (int)rss["Graphic.SetQualityLevel"]; //RD
        ConfigTable[24] = (int)rss["Graphic.SetResolutionW"]; // RD
        ConfigTable[25] = (int)rss["Graphic.SetResolutionH"]; // RD
        ConfigTable[26] = (int)rss["Graphic.fullscreen"]; // RD
        ConfigTable[27] = (int)rss["Graphic.preferredRefreshRate"];
        ConfigTable[28] = (int)rss["Graphic.fieldOfView"]; // RD
        ConfigTable[29] = (int)rss["Graphic.FastHDR"]; // RD
        ConfigTable[30] = (int)rss["Graphic.OverallGraphicsQuality"]; // RD
        ConfigTable[31] = (int)rss["Graphic.PostProcessQuality"]; //RD
        ConfigTable[32] = (int)rss["Graphic.ResolutionScale"]; // RD
        ConfigTable[33] = (int)rss["Graphic.ResolutionScaleMode"]; // RD
        ConfigTable[34] = (int)rss["Graphic.FPSLock"]; // RD
        ConfigTable[35] = (int)rss["Graphic.FPSMaxRender"]; //RD
        ConfigTable[36] = (float)rss["Audio.Master_Volume"]; // RD
        ConfigTable[37] = (float)rss["Audio.Volume_Music"]; // RD
        ConfigTable[38] = (int)rss["Other.DeveloperSettings"]; // RD
        string lang = (string)rss["Other.Lang"];
        SendData._language = lang;
        SendData._fieldOfView = (int)ConfigTable[28];
        SendData._fastHDR = (int)ConfigTable[29];
        SendData._overallGraphicsQuality = (int)ConfigTable[30];
        SendData._postProcessQuality = (int)ConfigTable[31];
        SendData._master_Volume = ConfigTable[36];
        SendData._volume_Music = ConfigTable[37];
        SendData._resolutionScale = (int)ConfigTable[32];
        SendData._resolutionScaleMode = (int)ConfigTable[33];
        SendData._resolutionW = (int)ConfigTable[24];
        SendData._resolutionH= (int)ConfigTable[25];
        SendData._FPSLimit = (int)ConfigTable[35];

        QualitySettings.SetQualityLevel ((int)ConfigTable[30], true);
        QualitySettings.vSyncCount = (int)ConfigTable[22];
        Application.targetFrameRate = (int)ConfigTable[35];
        QualitySettings.antiAliasing = (int)ConfigTable[1];
        if (ConfigTable[22]==1)
        {
            SendData._vsync = true;
        }
        else
        {
            SendData._vsync = false;
        }
        if(ConfigTable[33]== 0)
        {
            if (ConfigTable[26] == 0)
            {
                Screen.SetResolution((int)ConfigTable[24], (int)ConfigTable[25], true, (int)ConfigTable[35]);
            }
            else
            {
                Screen.SetResolution((int)ConfigTable[24], (int)ConfigTable[25], true, (int)ConfigTable[35]);
            }

        }
      else
        {
            if (ConfigTable[26] == 0)
            {
                Screen.SetResolution((int)ConfigTable[24]* (int)ConfigTable[32], (int)ConfigTable[25] * (int)ConfigTable[32], false, (int)ConfigTable[35]);
            }
            else
            {
                Screen.SetResolution((int)ConfigTable[24] * (int)ConfigTable[32], (int)ConfigTable[25] * (int)ConfigTable[32], true, (int)ConfigTable[35]);
            }
        }


        // DEV OPTIONS
        if (ConfigTable[38] == 1)
        {
            if (ConfigTable[0] == 1)
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
            }
            else
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            }
            QualitySettings.asyncUploadBufferSize = (int)ConfigTable[2];
            QualitySettings.asyncUploadTimeSlice = (int)ConfigTable[3];

            if (ConfigTable[5] == 1)
            {
                QualitySettings.blendWeights = BlendWeights.OneBone;
            }
            else if (ConfigTable[5] == 2)
            {
                QualitySettings.blendWeights = BlendWeights.TwoBones;
            }
            else
            {
                QualitySettings.blendWeights = BlendWeights.FourBones;
            }
            QualitySettings.lodBias = ConfigTable[6];
            QualitySettings.masterTextureLimit = (int)ConfigTable[7];
            QualitySettings.maximumLODLevel = (int)ConfigTable[8];
            QualitySettings.maxQueuedFrames = (int)ConfigTable[9];
            QualitySettings.particleRaycastBudget = (int)ConfigTable[10];
            if (ConfigTable[11] == 1)
            {
                QualitySettings.realtimeReflectionProbes = true;
            }
            else
            {
                QualitySettings.realtimeReflectionProbes = false;
            }
            QualitySettings.shadowCascade2Split = ConfigTable[12];
            QualitySettings.shadowCascades = (int)ConfigTable[14];
            QualitySettings.shadowDistance = ConfigTable[15];
            QualitySettings.shadowNearPlaneOffset = ConfigTable[16];
            if (ConfigTable[20] == 1)
            {
                QualitySettings.softParticles = true;
            }
            else
            {
                QualitySettings.softParticles = false;
            }
            if (ConfigTable[21] == 1)
            {
                QualitySettings.softVegetation = true;
            }
            else
            {
                QualitySettings.softVegetation = false;
            }
        }


    }

}
