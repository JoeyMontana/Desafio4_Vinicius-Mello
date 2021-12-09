using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameController : MonoBehaviour {
    private WrapperData _data;
    
    public Text textRes1;
    public Text textRes2;
    public Text textRes3;
    public Text textRes4;
    public Text textRes5;
    public Text textRes6;

    private void Start() {
       _data = GetComponent<LoadData>().ReadFromJsonPlayer();
    }

    public void Questao1() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();
        
        textRes1.text = "";
        
        List<Player> res = _data.players.OrderByDescending(p => p.points).Take(3).ToList();
        foreach(Player p in res) {

            textRes1.text += (p.name + " - " + p.points + " | ");
        }
    }

    public void Questao2() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();

        textRes2.text = "";

        List<Player> res = _data.players.Where(p => p.heroes.Count == 0).OrderBy(p => p.countryName).ToList();

        foreach(Player p in res) {

            textRes2.text += (p.countryName + " - " + p.name + " | ");
        }
    }

    public void Questao3() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();
        
        textRes3.text = "";

        var res =
            from c in _data.players.SelectMany(p => p.heroes)
            group c by c.heroClassName into g
            orderby g.Count() ascending
            select new { Class = g.Key, Count = g.Count() };

        var resClass1 = res.Last().Class;
        var resClass2 = res.First().Class;
            

        textRes3.text = ("Classe mais criada " + resClass1 + " | " + "Classe menos criada " + resClass2 );
        
    }

    public void Questao4() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();

        textRes4.text = "";
        
        var res =
            from c in _data.players.Select(p => p.countryName)
            group c by c into g
            orderby g.Count() descending 
            select new { Country = g.Key, Count = g.Count()};

        textRes4.text = (res.First().Country);

    }

    public void Questao5() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();

        textRes5.text = "";
        
        var res = _data.players
            .GroupBy(p => new {p.platformName})
            .Select(g => new {
                Average = g.Average(p => p.points),
                platformName = g.Key.platformName
            }).OrderByDescending(o => o.Average);
        
        textRes5.text = (res.First().platformName);
        
    }
    
    public void Questao6() {
        _data = GetComponent<LoadData>().ReadFromJsonPlayer();

        textRes6.text = "";

        var res = _data.players.Select(p => new {
            name = p.name,
            gold = p.heroes.Sum(h => h.gold)
        }).OrderBy(o => o.gold).Take(10);

        foreach (var r in res) {
            textRes6.text += r.name + " | ";
        }
    }
}
