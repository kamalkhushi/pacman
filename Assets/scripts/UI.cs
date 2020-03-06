using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public float food = 0f;
    public Text foodtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodtext.text = "X" + food;
    }
    public void foodIncrease()
    {
        food = food + 10f;
    }
}
