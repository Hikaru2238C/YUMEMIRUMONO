using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string text;
    public float speed;
}

[System.Serializable]
public class ScenarioBlock
{
    public string Background;
    public float BlackOut;
    public float BlackIn;
    public float WhiteOut;
    public float WhiteIn;
    public float ScreenShake;
    public string CharacterName;
    public Dialogue Dialogue;
    public string Portrait;
    public string SE;
    public string BGM;
}

[System.Serializable]
public class ScenarioData
{
    public string id;
    public List<ScenarioBlock> Scenario;
}
