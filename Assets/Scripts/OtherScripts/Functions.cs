using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

class CreateFileHelper : Functions
{
    public Boolean CreateFile(string FileName)
    {
        string path = CurrentDirectory() + @"\" + FileName;
        if (!File.Exists(path))
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("");
                    return true;
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("Błąd:" + ex);
                return false;

            }
        }
        else
        {
            return false;
        }
    }

    public Boolean CreateFile(string FileName, string Content)
    {
        string path = CurrentDirectory() + @"\" + FileName;
        if (!File.Exists(path))
        {
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Content);
                    return true;
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("Błąd:" + ex);
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

class ReadJsonFileHelper : Functions
{
    public string ReadJsonFile(string FileName, string Language, string SearchRequest, int NumberOfElements, string SearchRequestChildren)
    {
        string Path = File.ReadAllText(Application.dataPath + "/LanguageDataBase/" + FileName + ".json");
        JObject rss = JObject.Parse(Path);
        string itemTitle = (string)rss[Language + "." + SearchRequest][NumberOfElements][SearchRequestChildren];
        return itemTitle;
    }
    public string ReadJsonFile(string FileName, string Language, string SearchRequest)
    {
        string Path = File.ReadAllText(Application.dataPath + "/LanguageDataBase/" + FileName + ".json");
        JObject rss = JObject.Parse(Path);
        string itemTitle = (string)rss[Language + "." + SearchRequest];
        return itemTitle;
    }
}



public class Functions : MonoBehaviour
{
    static public int SelectLoadLevel(string level)
    {
        SendData._levelload = level;
        SceneManager.LoadScene("LoadLevel");
        return 1;
    }

    static public string CurrentDirectory()
    {
        return Environment.CurrentDirectory;
    }

    static public int StartProcess(string Data, string ProcessName)
    {
        Process.Start(Data + "\\" + ProcessName);

        int fileExtPos = ProcessName.LastIndexOf(".");
        if (fileExtPos >= 0)
        {
            ProcessName = ProcessName.Substring(0, fileExtPos);
        }
        Process[] pname = Process.GetProcessesByName(ProcessName);
        if (pname.Length == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }

    }

    static public void Client()
    {

        int status = 0;
        if (SendData._uniqueid == null && status != 2)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("127.0.0.1", 9997);
                UnityEngine.Debug.LogWarning("Connected");
                String str = "UnityInquiry";
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                stm.Write(ba, 0, ba.Length);
                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                for (int i = 0; i < k; i++)
                {
                    Convert.ToChar(bb[i]);
                }
                SendData._uniqueid = Encoding.UTF8.GetString(bb, 0, bb.Length);
                SendData._OnlineAccess = true;
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Błąd:" + e.StackTrace);
                Client();
                status += 1;
            }
        }
    }


    static public bool CheckFileExits(string NameFile, string Path)
    {
        string PathHelper = Path + @"\" + NameFile;
        if (File.Exists(PathHelper))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static public bool CreateConfig()
    {
        CreateFileHelper FileCreate = new CreateFileHelper();
        if (!CheckFileExits("config.json", CurrentDirectory()))
        {
            if (FileCreate.CreateFile("config.json", SendData._simpleconfigplacehorder))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }

    }

    static public bool UpdateConfig(string name, float value)
    {
        string Path = File.ReadAllText(CurrentDirectory() + @"\config.json");
        JObject Code = JObject.Parse(Path);
        Code[name] = value;
        string result = Code.ToString();
        File.WriteAllText(CurrentDirectory() + @"\config.json", String.Empty);
        File.WriteAllText(CurrentDirectory() + @"\config.json", result);
        return true;
    }
    static private string CreateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    static public void RequestToServer(string nick, int options, int value)
    {
        string html = string.Empty;
        string url = @"http://46.101.144.157/index.php?nick=" + nick + "&opt=" + options + "&value=" + value + "&hash=" + HashURL(nick);
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        request.AutomaticDecompression = System.Net.DecompressionMethods.GZip;

        using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

    }

    static public string HashURL(string nick)
    {
        string data = DateTime.Now.ToString("yyyy.MM");
        string hash = CreateMD5(data + nick);
        UnityEngine.Debug.LogError("Pre hash data:"+data + nick+" post hash:"+hash);
        return hash;
    }

    static public void OpenURL(string nick)
    {
        string data = DateTime.Now.ToString("yyyy.MM");
        string hash = CreateMD5(data + nick);
        UnityEngine.Debug.LogError("Pre hash data:" + data + nick + " post hash:" + hash);
        string tmp = System.String.Format(@"http://46.101.144.157/?hash={0}&opt=1&nick={1}", hash, nick);
        UnityEngine.Debug.LogError(tmp);
        Application.OpenURL(tmp);
    }

}