using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GateButtonSpawner : MonoBehaviour
{
    // Prefab���w��
    [SerializeField] GameObject ButtleButtonPrefab;
    [SerializeField] GameObject ScenarioeButtonPrefab;

    // �e�I�u�W�F�N�g���w��
    [SerializeField] Transform parentObject;

    //�N�G�X�g�f�[�^���w��
    [SerializeField] QuestDataBase questDataBase;

    private void Start()
    {
        SpawnChild();
    }
    public void SpawnChild()
    {
        Dictionary<string, bool> dict = questDataBase.QuestData.ToDictionary();

        foreach (var kvp in dict)
        {
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
            if ( kvp.Value)
            {
                // id��ݒ�
                string id = $"{kvp.Key}";

                // ��������Prefab��ID�Ɋ�Â��đI��
                GameObject prefabToSpawn = null;
                if (id.StartsWith("�o�g��"))
                {
                    prefabToSpawn = ButtleButtonPrefab;
                }
                else if (id.StartsWith("�V�i���I")|| id.StartsWith("sumple"))
                {
                    prefabToSpawn = ScenarioeButtonPrefab;
                }                
                // Prefab�𐶐����A�e�I�u�W�F�N�g���w��
                GameObject childButton = Instantiate(prefabToSpawn, parentObject);
                //���O��ݒ�
                childButton.name = id;

                // ID���i�[����X�N���v�g������ꍇ�ɐݒ�
                GateButtonID childID = childButton.GetComponent<GateButtonID>();
                if (childID != null)
                {
                    childID.SetID(id);
                }
            }
            else
            {
                break;
            }
        }
    }
}
