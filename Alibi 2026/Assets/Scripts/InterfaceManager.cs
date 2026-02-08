using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
  public static InterfaceManager Instance { get; private set; }

    [Header("UI Components")]
    public GameObject examinationPanel;
    public Image examinationImage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        if (examinationPanel != null)
        {
            examinationPanel.SetActive(false);
        }


    }

    public void ExamineEvidence(Evidence evidence)
    {

        if (examinationPanel == null) return;

        examinationPanel.SetActive(true);

        examinationImage.sprite = evidence.examedDisplay;

        examinationImage.SetNativeSize();

        switch (evidence.koreEvi)
        {
            case EvidenceCategory.Document:
                examinationImage.transform.localScale = Vector3.one * 0.3f;
                Debug.Log("This is the classified document from 1980s.");
                break;

            case EvidenceCategory.Physical:
                examinationImage.transform.localScale = Vector3.one * 0.5f;
                Debug.Log("A flash drive containing a series of photos, nothing interesting appears.");
                break;

            case EvidenceCategory.Policing:
                examinationImage.transform.localScale = Vector3.one * 0.5f;
                Debug.Log("Your stuff, treat them carefully.");
                break;

            default:
                break;

        }



    }

    public void CloseExamination()
    {
        if (examinationPanel != null)
        {
            examinationPanel.SetActive(false);
        }
    }

}
