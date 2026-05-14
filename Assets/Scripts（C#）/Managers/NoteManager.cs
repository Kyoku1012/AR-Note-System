using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    public List<NoteData> allNotes =
        new List<NoteData>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddNote(NoteData note)
    {
        allNotes.Add(note);
    }

    public void RemoveNote(string noteID)
    {

    }

    public void SaveNotes()
    {

    }

    public void LoadNotes()
    {

    }
}