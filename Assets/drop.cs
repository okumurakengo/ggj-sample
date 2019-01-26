using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    private Sprite nowSprite;

    void Start()
    {
        nowSprite = null;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null) return;
        Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();

        string filename = craftedIfMatchingPair(droppedImage, iconImage);

        //iconImage.sprite = droppedImage.sprite;
        iconImage.sprite = Resources.Load<Sprite>("jewelry");
        iconImage.color = Vector4.one * 0.6f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null) return;
        //iconImage.sprite = nowSprite;
        iconImage.sprite = Resources.Load<Sprite>("jewelry");
        if (nowSprite == null)
            iconImage.color = Vector4.zero;
        else
        iconImage.color = Vector4.one;
    }
    public void OnDrop(PointerEventData pointerEventData)
    {
        Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
        //iconImage.sprite = droppedImage.sprite;
        iconImage.sprite = Resources.Load<Sprite>("jewelry");
        nowSprite = droppedImage.sprite;
        iconImage.color = Vector4.one;
    }

    private string craftedIfMatchingPair(Image tmpDroppedImage, Image tmpIconImage)
    {
        string filename;
        // ここで画像判定
        if (iconImage.sprite.name == "hoge" && tmpIconImage.sprite.name == "fuga") {
            filename = "new image";
        } else {
            filename = "none";
        }
        return filename;
    }
}
