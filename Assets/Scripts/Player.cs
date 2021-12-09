using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player {
    public int id;
    public string name;
    public string email;
    public string username;
    public int points;
    public int platformIndex;
    public string platformName;
    public IEnumerable<Object> countryIndex;
    public string countryName;
    public List<Heroes> heroes;
}