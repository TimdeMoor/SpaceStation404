using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] [Range(10f, 100f)] private float scrollSpeed = 40f;
    [SerializeField] private float headerFontSize = 24f;
    [SerializeField] private float listFontSize = 18f;
    [SerializeField] private float lineSpacing = 30f;
    [SerializeField] private float listLineSpacing = 30f;
    
    private List<CreditsEntry> credits = new List<CreditsEntry>();
    private float _currentLine = 0f;
    void Start()
    {
        credits.Add(new CreditsEntry("Teachers", new List<string>{"Michael", "Geert-Jan", "Gerwin", "Erwin"}));
        credits.Add(new CreditsEntry("Programmers", new List<string>{"Tim", "Bart"}));
        credits.Add(new CreditsEntry("Local Tryhard", new List<string>{"Tim"}));
        credits.Add(new CreditsEntry("Media Boi", new List<string>{"Bart"}));
        credits.Add(new CreditsEntry("Testers", new List<string>{"Naam1", "Naam2"}));
        credits.Add(new CreditsEntry("Other stuff", new List<string>{"Stuff1", "Stuff2", "Stuff3", "Stuff4", "Stuff5", "Stuff6"}));
        credits.Add(new CreditsEntry("Food Provider", new List<string>{"Jumbo"}));
        

        credits.Add(new CreditsEntry("Thanks for playing", new List<string>{""}));

        CreateCredits();
        
        print(_currentLine * 1f);
        Invoke(nameof(QuitGame), _currentLine * 1f);
    }
    
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x,pos.y + Time.deltaTime * scrollSpeed, pos.z);
    }

    private GameObject CreateHeader(string text, Color color)
    {
        GameObject obj = new GameObject("Header");
        obj.transform.SetParent(transform);
        
        TextMeshProUGUI ui = obj.AddComponent<TextMeshProUGUI>();
        ui.text = text;
        ui.fontSize = headerFontSize;
        ui.alignment = TextAlignmentOptions.Center;
        ui.rectTransform.anchoredPosition = new Vector2(0f, -lineSpacing * _currentLine);
        ui.color = color;
        
        _currentLine++;
        return obj;
    }


    private void CreatePeopleList(GameObject HeaderParent, List<string> people, Color color)
    {
        GameObject obj = new GameObject("People");
        obj.transform.SetParent(HeaderParent.transform);
        
        TextMeshProUGUI ui = obj.AddComponent<TextMeshProUGUI>();
        ui.fontSize = listFontSize;
        ui.alignment = TextAlignmentOptions.Top;
        ui.rectTransform.anchoredPosition = new Vector2(0f, -listLineSpacing);
        ui.color = color;
        
        foreach (string s in people)
        {
            ui.text += "<br>" + s;
            _currentLine++;
        }

        _currentLine += 2;
    }
    
    class CreditsEntry
    {
        public string Function;
        public List<string> People;

        public CreditsEntry(string function, List<string> people)
        {
            Function = function;
            People = people;
        }
    }

    private void CreateCredits()
    {
        foreach (CreditsEntry entry in credits)
        {
            GameObject header = CreateHeader(entry.Function, Color.yellow);
            CreatePeopleList(header, entry.People, Color.white);
        }
    }

    private void QuitGame()
    {
        print("Stop");
        Application.Quit();
    }
}
