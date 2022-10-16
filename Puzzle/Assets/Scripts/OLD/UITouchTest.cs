using UnityEngine;
using UnityEngine.UI;
using Pikky.Button;
using TMPro;

public class UITouchTest : PikkyDragButton
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    protected override void PointerEnter() { }
    protected override void PointerExit() { }
    protected override void PointerDown()
    {
        _transform.localScale = new Vector2(1.1f, 1.1f);
    }
    protected override void PointerUp()
    {
        _transform.localScale = Vector2.one;
        _text.text = "null";
    }
    protected override void ClickedOn()
    {
        _image.color = Color.black;
    }
    protected override void PointerDrag(Vector2 delta)
    {
        _text.text = string.Concat("Delta: X - ", delta.x.ToString("0.000"), ", Y - ", delta.y.ToString("0.000"));
    }
}