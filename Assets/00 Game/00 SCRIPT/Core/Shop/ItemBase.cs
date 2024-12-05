using UnityEngine;

public abstract class ItemBase :MonoBehaviour
{
    [SerializeField]
    protected ItemDataSO _info;
    [SerializeField] 
    protected int _quantity;
    [SerializeField]
    protected int _price;
}