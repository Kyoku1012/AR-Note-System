using UnityEngine;

[System.Serializable]
public class NoteData
{
    // 唯一ID（用于增删改查）
    public string noteID;

    // 基础文本信息
    public string title;
    public string content;

    // 任务状态（Member 2 用）
    public bool isCompleted;

    // 优先级（Member 3 用）
    public int priorityLevel;

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

}
