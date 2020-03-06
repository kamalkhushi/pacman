using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterswitch : MonoBehaviour
{
    private GameObject[] charachterList;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        charachterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            charachterList[i] = transform.GetChild(i).gameObject;

        }
        foreach (GameObject go in charachterList)
        {
            go.SetActive(false);
        }
        if (charachterList[index])
        {
            charachterList[index].SetActive(true);
        }
    }
    public void toggelLeft()
    {
        Debug.Log(index);
        charachterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = charachterList.Length - 1;
        }
        charachterList[index].SetActive(true);
    }
    public void toggelRight()
    {
        Debug.Log(index);
        charachterList[index].SetActive(false);
        index++;
        if (index == charachterList.Length)
        {
            index = 0;
        }
        charachterList[index].SetActive(true);

    }
    public void confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("level1");
    }



    // Update is called once per frame
    void Update()
    {

    }
}
