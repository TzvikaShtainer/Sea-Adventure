using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIBase : MonoBehaviour
{
    [SerializeField] protected Image icon;
    [SerializeField] protected TextMeshProUGUI titleText;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected Button button;
    [SerializeField] protected TextMeshProUGUI description;

    protected ShopItem item;
    
    public delegate void OnItemSelected(ItemUIBase selectedItem);
    public event OnItemSelected onItemSelected;
    
    protected virtual void Start()
    {
        button.onClick.AddListener(OnItemSelectedHandler);
    }

    private void OnItemSelectedHandler()
    {
        onItemSelected?.Invoke(this);
    }

    public virtual void Init(ShopItem item)
    {
        this.item = item;
        icon.sprite = item.itemIcon;
        titleText.text = item.title;
        priceText.text = item.price.ToString();
        description.text = item.description;
    }

    public ShopItem GetItem() => item;
}
