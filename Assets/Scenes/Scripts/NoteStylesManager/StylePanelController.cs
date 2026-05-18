using UnityEngine;

public class StylePanelController : MonoBehaviour
{
    // public NoteStyleManager selectedNote;
    
    // private NoteData currentData = new NoteData
    // {
    //     id = "Note001",
    //     title = "Test Note",
    //     content = "This is a test note.",
    //     isVisible = true,

    //     colorName = "yellow",
    //     iconId = "",
    //     priorityId = ""
    // };
    public NoteStyleManager selectedNote;
    private NoteData currentData;

    public void SetSelectedNote(NoteStyleManager note)
    {
        selectedNote = note;

        currentData = new NoteData
        {
            id = "Note001",
            title = "Test Note",
            content = "This is a test note.",
            isVisible = true,
            colorName = "yellow",
            iconId = "",
            priorityId = ""
        };

        ApplyCurrentStyle();
    }
    private void Awake()
    {
        if (selectedNote == null)
        {
            selectedNote = GetComponent<NoteStyleManager>() ?? GetComponentInChildren<NoteStyleManager>();
            if (selectedNote == null)
            {
                Debug.LogWarning("StylePanelController: selectedNote is not assigned in Inspector and no NoteStyleManager was found on the same GameObject or children.");
            }
        }
    }

    private void Start()
    {
        ApplyCurrentStyle();
    }

    private void ApplyCurrentStyle()
    {
        if (selectedNote == null)
        {
            Debug.LogWarning("StylePanelController: selectedNote is not assigned in Inspector.");
            return;
        }

        selectedNote.ApplyStyle(currentData);
    }

    // Note Color Setters
    public void SetYellow()
    {
        Debug.Log("Yellow button clicked in StylePanelController.");
        currentData.colorName = "yellow";
        ApplyCurrentStyle();
    }

    public void SetPink()
    {
            Debug.Log("Pink button clicked in StylePanelController.");
        currentData.colorName = "pink";
        ApplyCurrentStyle();
    }

    public void SetBlue()
    {
        currentData.colorName = "blue";
        ApplyCurrentStyle();
    }
    public void SetGreen()
    {
        currentData.colorName = "green";
        ApplyCurrentStyle();
    }


    // Note Icon Setters
    public void SetStarIcon()
    {
        Debug.Log("Star Icon button clicked in StylePanelController.");
        currentData.iconId = "star";
        ApplyCurrentStyle();
    }

    public void SetFinishIcon()
    {
        currentData.iconId = "finish";
        ApplyCurrentStyle();
    }

    public void SetInProcessIcon()
    {
        currentData.iconId = "inprocess";
        ApplyCurrentStyle();
    }

       public void SetReminderIcon()
    {
        currentData.iconId = "reminder";
        ApplyCurrentStyle();
    }

       public void SetWorkIcon()
    {
        currentData.iconId = "work";
        ApplyCurrentStyle();
    }

       public void SetStudyIcon()
    {
        currentData.iconId = "study";
        ApplyCurrentStyle();
    }

       public void SetShoppingIcon()
    {
        currentData.iconId = "shopping";
        ApplyCurrentStyle();
    }

    public void HideIcon()
    {
        currentData.iconId = "";
        ApplyCurrentStyle();
    }

    // Note Priority Setters
    public void SetHighPriority()
    {
        Debug.Log("High Priority button clicked in StylePanelController.");
        currentData.priorityId = "high";
        ApplyCurrentStyle();
    }

    public void SetMediumPriority()
    {
        currentData.priorityId = "medium";
        ApplyCurrentStyle();
    }

    public void SetLowPriority()
    {
        currentData.priorityId = "low";
        ApplyCurrentStyle();
    }

    public void HidePriority()
    {
        currentData.priorityId = "";
        ApplyCurrentStyle();
    }
}
