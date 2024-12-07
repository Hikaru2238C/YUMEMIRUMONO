using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI; // 必要ならUIを使用

public class ScenarioPlayer: MonoBehaviour
{
    [SerializeField] GateIDData gateIDData;
    [SerializeField] ScenarioDataBase scenarioDataBase;
    TextAsset jsonFile; // 流すJSONファイル
    private ScenarioData scenarioData;
    private int currentIndex = 0;
    public UIManager uiManager;

    void Start()
    {
        Dictionary<string, TextAsset> dict = scenarioDataBase.ScenarioData.ToDictionary();

        foreach (var kvp in dict)
        {
            if(kvp.Key == gateIDData.questID)
            {
                jsonFile = kvp.Value;
            }
        }
        if(jsonFile == null)
        {
            //Debug.Log()
        }
        // JSONをデシリアライズ
        scenarioData = JsonUtility.FromJson<ScenarioData>(jsonFile.text);
        Debug.Log($"Loaded Scenario: {scenarioData.id}");

        if (scenarioData.Scenario != null && scenarioData.Scenario.Count > 0)
        {
            ShowCurrentScenarioBlock();
        }
    }

    void Update()
    {
        // クリック入力を検知
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            AdvanceScenario();
        }
    }

    private void ShowCurrentScenarioBlock()
    {
        if (currentIndex < scenarioData.Scenario.Count)
        {
            var block = scenarioData.Scenario[currentIndex];
            if (!string.IsNullOrEmpty(block.Background))
            {
                Debug.Log($"Background: {block.Background}");
                uiManager.UpdateBackground(block.Background);
            }
            if (block.BlackOut > 0)
            {
                Debug.Log($"BlackOut: {block.BlackOut}");
                uiManager.UpdateBlackOut(block.BlackOut);
            }
            if (block.BlackIn > 0)
            {
                Debug.Log($"BlackIn: {block.BlackIn}");
                uiManager.UpdateBlackIn(block.BlackIn);
            }
            if (block.WhiteOut > 0)
            {
                Debug.Log($"WhiteOut: {block.WhiteOut}");
                uiManager.UpdateWhiteOut(block.WhiteOut);
            }
            if (block.WhiteIn > 0)
            {
                Debug.Log($"WhiteIn: {block.WhiteIn}");
                uiManager.UpdateWhiteIn(block.WhiteIn);
            }
            if (block.ScreenShake > 0)
            {
                Debug.Log($"ScreenShake: {block.ScreenShake}");
                uiManager.UpdateScreenShake(block.ScreenShake);
            }
            //if (block.CharacterName != null)
            //{
            //    Debug.Log($"CharacterName: {block.CharacterName}");
            uiManager.UpdateNameText(block.CharacterName);
            //}
            if (block.Dialogue != null)
            {
                Debug.Log($"Dialogue: {block.Dialogue.text} (Speed: {block.Dialogue.speed})");
                uiManager.UpdateMainText(block.Dialogue.text,block.Dialogue.speed); // UI更新
            }
            //if (!string.IsNullOrEmpty(block.Portrait))
            //{
                Debug.Log($"Portrait: {block.Portrait}");
                uiManager.UpdatePortrait(block.Portrait);
            //}
            if (!string.IsNullOrEmpty(block.SE))
            {
                Debug.Log($"SE: {block.SE}");
                uiManager.UpdateSE(block.SE);
            }
            if (!string.IsNullOrEmpty(block.BGM))
            {
                Debug.Log($"SE: {block.BGM}");
                uiManager.UpdateBGM(block.BGM);
            }
        }
    }

    private void AdvanceScenario()
    {
        currentIndex++;
        if (currentIndex < scenarioData.Scenario.Count)
        {
            ShowCurrentScenarioBlock();
        }
        else
        {
            Debug.Log("End of Scenario");
            uiManager.ClearDialogue();
        }
    }
}
