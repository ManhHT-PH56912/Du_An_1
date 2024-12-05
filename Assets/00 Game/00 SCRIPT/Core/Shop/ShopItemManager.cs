using System.Collections.Generic;
using UnityEngine;

public class ShopItemManager : MonoBehaviour
{
    public List<ItemDataSO> itemDataList;

    // Log Itims
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
    }
}