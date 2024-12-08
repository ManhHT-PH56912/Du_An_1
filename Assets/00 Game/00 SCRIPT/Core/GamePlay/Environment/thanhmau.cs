using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhmau : MonoBehaviour
{
    public Image _thanhmau;

    public void capNhatThanhMau(float luongMauHienTai,float luongMauToiDa)
    {
        _thanhmau.fillAmount = luongMauHienTai/luongMauToiDa;
    }    

}
