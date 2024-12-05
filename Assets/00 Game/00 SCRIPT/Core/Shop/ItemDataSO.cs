using UnityEngine;

// Create SO Items
[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]

public class ItemDataSO : ScriptableObject
{
    public int _ID;
    public string _name;
    public Sprite _image;
    public int _price;
    public int _healthIncrease;  // Tăng máu
    public int _armorIncrease;   // Tăng giáp
    public int _kickDamageIncrease;  // Tăng sát thương đá chân
    public int _meleeDamageIncrease; // Tăng sát thương đánh tay
}
