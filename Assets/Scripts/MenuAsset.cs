using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuAsset : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCount;

    public void Setup(Sprite icon, int count, string name)
    {
        image.sprite = icon;
        itemCount.text = $"x{count}";
        itemName.text = name;
        if (GetComponent<UnityEngine.UI.Button>() != null)
        {
            UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {

    }
}
