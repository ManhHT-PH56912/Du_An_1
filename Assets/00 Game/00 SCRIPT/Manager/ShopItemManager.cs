using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ShopItemManager : MonoBehaviour
{
    public List<ItemDataSO> itemDataList;

    [SerializeField] private TextMeshProUGUI totalScoreText;


    // Log Itims
    [System.Obsolete]
    void Start()
    {
        if (itemDataList != null && itemDataList.Count > 0)
        {
            foreach (var item in itemDataList)
            {
                Debug.Log($"ID: {item._ID}, Name: {item._name}, Price: {item._price}");
            }
        }
        else
        {
            Debug.LogWarning("No items found in the itemDataList.");
        }

        UpdateTotalScoreUI();
    }

    // Update TotalScore in UI
    [System.Obsolete]
    private void UpdateTotalScoreUI()
    {
        if (ScoreManager.Instance != null)
        {
            totalScoreText.text = $"{ScoreManager.Instance.TotalScore}";
        }
    }
}