using UnityEngine;
using Pikky.Button;

public class ObjectTouchTest : SimplePikkyButton
{
    [SerializeField] private Transform _transform;
    [SerializeField] private MeshRenderer _meshRenderer;

    protected override void PointerEnter() { }
    protected override void PointerExit() { }
    protected override void PointerDown()
    {
        _transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    protected override void PointerUp()
    {
        _transform.localScale = Vector3.one;
    }
    protected override void ClickedOn()
    {
        _meshRenderer.material.color = Color.black;
    }
}