using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour {

    private void Start() {
        ReadFromJsonPlayer();
        
    }

    public WrapperData ReadFromJsonPlayer() {
        string content = ReadFilePlayer();
        
        if (string.IsNullOrEmpty(content) || content == "{}") {
            return new WrapperData();
        }
        WrapperData res = JsonUtility.FromJson<WrapperData>(content);

        return res;
    }
    
    private static string ReadFilePlayer() {
        string path = Application.dataPath + "/Resources/Saves/data11.json";
        
        if (File.Exists(path)) {
            using (StreamReader reader = new StreamReader(path)) {
                string content = reader.ReadToEnd();
                
                return content;
            }
        } else {
            return "";
        }
    }
    
    public Countries ReadFromJsonCountry() {
        string content = ReadFilePlayer();
        
        if (string.IsNullOrEmpty(content) || content == "{}") {
            return new Countries();
        }
        Countries res = JsonUtility.FromJson<Countries>(content);

        return res;
    }
    
    private static string ReadFileCountry() {
        string path = Application.dataPath + "/Resources/Saves/country.json";
        
        if (File.Exists(path)) {
            using (StreamReader reader = new StreamReader(path)) {
                string content = reader.ReadToEnd();
                
                return content;
            }
        } else {
            return "";
        }
    }
    
    
}