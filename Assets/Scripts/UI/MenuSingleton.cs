using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSingleton : MonoBehaviour
{
    public static MenuSingleton instance;
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

}
