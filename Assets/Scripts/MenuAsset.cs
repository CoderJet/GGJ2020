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
    }
}
