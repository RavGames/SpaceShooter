using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{

    private Material renderer;
    Vector2 offSet;
    [SerializeField] float scroolSpeed = 1f;

    private void Awake()
    {
        int currentGameObject = FindObjectsOfType<BackGroundScrolling>().Length;

        if (currentGameObject > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        renderer = GetComponent<Renderer>().material;
        offSet = new Vector2(0, scroolSpeed);
    }

    private void Update()
    {
        ScroolBckground();
    }

    private void ScroolBckground()
    {
        renderer.mainTextureOffset += offSet * Time.deltaTime;
    }

}//CLASS
