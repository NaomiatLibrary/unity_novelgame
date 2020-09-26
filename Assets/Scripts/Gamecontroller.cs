using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    [SerializeField]
    Text scenarioMessage;
    List<Scenario> scenarios = new List<Scenario>();

    Scenario currentScenario;
    int index=0;
    class Scenario{
        public string ScenarioID;
        public List<string> Texts;
        public List<string> Options;
        public string NextScenarioID;
    }
    // Start is called before the first frame update
    void Start()
    {
        var scenario01 = ReadScenario("scenario01");
        SetScenario(scenario01);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetNextMessage();
            }
        }
    }
    void SetScenario(Scenario scenario){
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }
    void SetNextMessage(){
        if(currentScenario.Texts.Count>index+1){
            index++;
            scenarioMessage.text=currentScenario.Texts[index];
        }else{
            ExitScenario();
        }
    }
    void ExitScenario(){
        scenarioMessage.text="";
        index=0;
        if(string.IsNullOrEmpty(currentScenario.NextScenarioID)){
            currentScenario=null;
        }else{
            var nextScenario = scenarios.Find(s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
        }
    }
    Scenario ReadScenario(string scenarioName){
        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + scenarioName);
        if (scenarioText == null){
            Debug.LogError("シナリオファイルが見つかりません。");
            return null;
        }
        var serifs = scenarioText.text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Resources.UnloadAsset(scenarioText);
        return new Scenario(){
            ScenarioID=scenarioName,
            Texts=new List<string>(serifs)
        };
    }
}
