using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class ButtonSFX
{
    public Button button;
    public AudioClip sfxClip;   // Âm thanh SFX tương ứng
}

public class ClickButtons : MonoBehaviour
{
    [Header("--- Button SFX Settings ---")]
    [SerializeField] private List<ButtonSFX> ButtonSFXList;

    [System.Obsolete]
    private void Start()
    {
        // Gắn sự kiện cho từng nút
        foreach (var tmpButtonSFX in ButtonSFXList)
        {
            if (tmpButtonSFX.button != null && tmpButtonSFX.sfxClip != null)
            {
                tmpButtonSFX.button.onClick.AddListener(
                    () => PlayButtonSFX(tmpButtonSFX.sfxClip));
            }
        }
    }

    [System.Obsolete]
    private void PlayButtonSFX(AudioClip clip)
    {
        AudioManager.Instance.PlaySFX(clip);
    }
}
