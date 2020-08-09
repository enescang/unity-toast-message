using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Toaster.Instance.Show("hello world", Toaster.ToastPosition.Bottom);
    }

    // Update is called once per frame
    void Update()
    {
        //Toaster.Instance.Show("hello world", Toaster.ToastPosition.Bottom);
    }
}
