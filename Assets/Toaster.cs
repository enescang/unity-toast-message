using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toaster : MonoBehaviour
{

    public static Toaster Instance;
    public enum ToastPosition { Top, Center, Bottom }
    public Image toastImageUI;
    public Text toastTextUI;
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
        SetScale();
    }

    public void Show(string message, ToastPosition pos)
    {
        img = Instantiate(toastImageUI,transform.position, Quaternion.identity);
        txt = Instantiate(toastTextUI);
        img.transform.SetParent(GameObject.Find("Canvas").transform, false);
        txt.transform.SetParent(GameObject.Find("Canvas").transform, false);
        SetPosition(pos);
        SetMessage(message);
        SetScale();

    }


    /**
    *   With ViewportToWorldPoint determine the same position for
    * every device.
    *
    */
    private void SetPosition(ToastPosition pos)
    {
        if (pos == ToastPosition.Bottom)
        {
            var bottom = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0 + 1 / 8f));
            img.transform.position = new Vector3(bottom.x, bottom.y, 0f);
            txt.transform.position = new Vector3(bottom.x, bottom.y, 0f);
        }
    }

    /**
    *   Auto scale img(UI) and txt(UI).
    * img and txt will be resized based on toast message string length
    *
    */
    private void SetScale()
    {
        img.rectTransform.sizeDelta = new Vector2(txt.fontSize * txt.text.Length * 2 / 3, txt.fontSize * 2);
        txt.rectTransform.sizeDelta = img.rectTransform.sizeDelta;
        Debug.Log("scale");
    }


    /**
    *   Toaster toast message string
    *
    */
    private void SetMessage(string message)
    {
        this.txt.text = message;
    }



    /**
    *   Toaster message background image(UI)
    * 
    */
    public void SetImage(Image image)
    {
        this.img = image;
    }

    /**
    *   Toaster message text(UI)
    *
    */
    public void SetText(Text text)
    {
        this.txt = text;
    }



}
