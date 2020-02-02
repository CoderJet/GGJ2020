using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuAsset : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCount;
    int cost = 0;

    public void SetupCatalog(Sprite icon, int price, string name)
    {
        image.sprite = icon;
        itemCount.text = $"${price}";
        itemName.text = name;
        cost = price;
    }

    public void Setup(Sprite icon, int count, string name)
    {
        image.sprite = icon;
        itemCount.text = $"x{count}";
        itemName.text = name;
    }
}
