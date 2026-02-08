using System.Runtime.CompilerServices;
using UnityEngine;

public enum EvidenceCategory { Document, Physical, Policing }


public class Evidence : MonoBehaviour
{

    public EvidenceCategory koreEvi;
    //public Sprite examedDisplay;

    private Vector3 itemOffset;
    private bool isDragging = false;

    private SpriteRenderer koreSR;

    private void Awake()
    {
        koreSR = GetComponent<SpriteRenderer>();
        Debug.Log("Evidence Awake: " + gameObject.name);
    }


    private void OnMouseDown()
    {
        itemOffset = transform.position - GetMouseWorldPos();
        isDragging = true;
        Debug.Log("Evidence clicked: " + gameObject.name);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + itemOffset;

            koreSR.color = isDragging ? Color.gray : Color.white;

            transform.localScale = isDragging ? Vector3.one * 0.30f : Vector3.one * 0.28f;

            koreSR.sortingOrder = isDragging ? 100 : 0;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        koreSR.color = Color.white;
        transform.localScale = Vector3.one * 0.28f;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !isDragging)
        {
            //InterfaceManager.Instance.ExamineEvidence(this);
        }
    }


    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}
