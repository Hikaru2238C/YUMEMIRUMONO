using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButtonSpawner : MonoBehaviour
{
    // Prefab���w��
    [SerializeField] GameObject HelpButtonPrefab;

    // �e�I�u�W�F�N�g���w��
    [SerializeField] Transform parentObject;

    //�N�G�X�g�f�[�^���w��
    [SerializeField] HintDataBase hintDataBase;

    private void Start()
    {
        SpawnHelpButton();
    }
    public void SpawnHelpButton()
    {
        Dictionary<string, TextAsset> dict = hintDataBase.HintData.ToDictionary();

        //    foreach (var kvp in dict)
        //    {
        //        Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        //        if (kvp.Value)
        //        {
        //            // id��ݒ�
        //            string id = $"{kvp.Key}";

        //            // ��������Prefab��ID�Ɋ�Â��đI��
        //            GameObject prefabToSpawn = null;
        //            if (id.StartsWith("�o�g��"))
        //            {
        //                prefabToSpawn = ButtleButtonPrefab;
        //            }
        //            else if (id.StartsWith("�V�i���I") || id.StartsWith("sumple"))
        //            {
        //                prefabToSpawn = ScenarioeButtonPrefab;
        //            }
        //            // Prefab�𐶐����A�e�I�u�W�F�N�g���w��
        //            GameObject childButton = Instantiate(prefabToSpawn, parentObject);
        //            //���O��ݒ�
        //            childButton.name = id;

        //            // ID���i�[����X�N���v�g������ꍇ�ɐݒ�
        //            GateButtonID childID = childButton.GetComponent<GateButtonID>();
        //            if (childID != null)
        //            {
        //                childID.SetID(id);
        //            }
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
    }
}
