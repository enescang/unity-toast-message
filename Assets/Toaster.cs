using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toaster : MonoBehaviour
{

    public static Toaster Instance;
    public enum ToastPosition { Top, Center, Bottom }
    private Image img;
    private Text txt;
    private string str;
    private float second;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string message, ToastPosition pos)
    {
        SetPosition(pos);
        SetMessage(message);
        SetScale();
    }

    private void SetPosition(ToastPosition pos)
    {
        if (pos == ToastPosition.Bottom)
        {
            var bottom = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0 + 1 / 8f));
            img.transform.position = new Vector3(bottom.x, bottom.y, 0f);
            txt.transform.position = new Vector3(bottom.x, bottom.y, 0f);
        }
    }

    private void SetScale()
    {
        img.rectTransform.sizeDelta = new Vector2(txt.fontSize * txt.text.Length * 2 / 3, txt.fontSize*2-40);
        txt.rectTransform.sizeDelta = img.rectTransform.sizeDelta;
    }

    private void SetMessage(string message)
    {
        this.txt.text = message;
    }




    public void SetImage(Image image)
    {
        this.img = image;
    }

    public void SetText(Text text)
    {
        this.txt = text;
    }



}
