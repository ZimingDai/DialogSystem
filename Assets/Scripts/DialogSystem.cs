using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")] public Text textLabel;
    public Image faceImage;

    [Header("文本文件")] public TextAsset textFile;

    public int index;

    public float textSpeed;
    private bool textFinished;
    private bool isJump;

    [Header("头像")] public Sprite face01, face02;
    

    private List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable() // 在start之前调用
    {
        //  textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished && !isJump)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinished && !isJump)
            {
                isJump = !isJump;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "A":
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                faceImage.sprite = face02;
                index++;
                break;    
        }
        int letter = 0;
        while (!isJump && letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        isJump = false;
        textFinished = true;
        index++;
    }
}