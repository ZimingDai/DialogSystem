# DialogSystem

> 根据教程：[Unity教程：对话系统](https://space.bilibili.com/370283072/channel/detail?cid=99057)
>
> 项目下载地址（包含素材）: 链接: https://pan.baidu.com/s/1dQWUhhriE-rPz8AwHyJHew 提取码: vk7w 
>
> 素材下载地址： https://bakudas.itch.io/generic-rpg-pack

### 学到

* UGUI
* TextAsset
* **Startcoroutine 携程处理**



### 技巧

#### 添加聊天框

1. 添加UI：Panel

2. canvas设置为world space，并将sorting layer设置为最靠上

3. reset `Rect Transform`

4. 用main Camera当做`Event Camera`

5. 设置不透明度为255，放入`source Image`

6. 在panel上面添加UI：Text

7. 在Panel上面添加UI：Image

8. 然后取消其Active，具体操作

   ```c#
    private void Update()
       {
           if (Button.activeSelf && Input.GetKeyDown(KeyCode.R))
           {
                talkUI.SetActive(true);
           }
       }



#### 获取外部文档

```c#
 [Header("文本文件")] 
    public TextAsset textFile;
```

有Text方法，将其转换为String

```c#
void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split('\n');//根据回车分割
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }
```



使其一开始显示第一句话

```c#
 private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }
```



#### startCoroutine
