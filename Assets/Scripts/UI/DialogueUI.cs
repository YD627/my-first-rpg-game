using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class DialogueUI : MonoBehaviour
{
    // 单例模式，确保全局只有一个DialogueUI实例
    public static DialogueUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button nextButton;
    private List<string> contentList;
    private int contentIndex = 0;
    private void Awake()
    {
        // 如果已经存在一个实例，并且不是当前对象，则销毁当前对象，确保单例模式
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    private void Start()
    {
        Hide();
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }
    private void OnNextButtonClicked()
    {
        contentIndex++;
        if (contentIndex < contentList.Count)
        {
            dialogueText.text = contentList[contentIndex];
        }
        else
        {
            contentIndex = 0;
            Hide();
            return;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name, string[] content)
    {
        gameObject.SetActive(true);
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        dialogueText.text = contentList[0];
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
