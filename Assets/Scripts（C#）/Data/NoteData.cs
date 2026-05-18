using UnityEngine;

[System.Serializable]
public class NoteData
{
    public bool isVisible;

    // 唯一ID（用于增删改查）
    public string id;

    // 基础文本信息
    public string title;
    public string content;

    // 任务状态（Member 2 用）
    public bool isCompleted;

    // 颜色标签（Member 3 用）
    public string colorLabel;

    // 提醒功能（Member 4 用）
    public bool hasReminder;
    public string reminderTime;

    // 语音便签（Member 5 用）
    public bool hasVoiceNote;
    public string voiceFilePath;

    // AR 位置信息（核心）
    public Vector3 worldPosition;


    // Member 3 
    // Note Customization
    public string colorName;   // e.g. "Yellow", "Pink", "Blue"
    public string iconId;      // e.g. "Study", "Shopping", "Reminder"
    public string priorityId;  // e.g. "High", "Medium", "Low"

}
