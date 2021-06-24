using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private Color tileColor = Color.red;

    public GameObject generateButton;
    public GameObject regenerateButton;


    private void Start()
    {
        toggleGroup = GameObject.FindGameObjectWithTag("ToggleGroup").GetComponent<ToggleGroup>();
    }


    public void TileColor()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        string toggleText = toggle.GetComponentInChildren<Text>().text;

        if (toggleText == "Red")
            tileColor = Color.red;            
        else if (toggleText == "Green")
            tileColor = Color.green;
        else if (toggleText == "Blue")
            tileColor = Color.blue;
        generateButton.SetActive(true);
        regenerateButton.SetActive(false);
    }

    public static Color GetNextPseudoRandomColor()
    {
        float red = Random.Range(0f, 0.9f);
        float green = Random.Range(0f, 0.9f);
        float blue = Random.Range(0f, 0.9f);
        Color c = new Color(red, green, blue);
        return c;
    }

    public void ChangeColorInitially()
    {
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i==1)
                    GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = tileColor;
                else
                    GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = GetNextPseudoRandomColor();
            }
        }
        generateButton.SetActive(false);
        regenerateButton.SetActive(true);
    }

    public void ClearGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<Tiles>().init();
        }
    }

    public void ChangeColorAfterwards()
    {
        int randomCondition = Random.Range(0, 4);

        int i, j;

        switch(randomCondition)
        {
            case 0: 
                int randomi = Random.Range(0, 3);
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if(i==randomi)
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = tileColor;
                        else
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = GetNextPseudoRandomColor();
                    }
                }
                break;

            case 1:
                int randomj = Random.Range(0, 3);
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (j == randomj)
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = tileColor;
                        else
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = GetNextPseudoRandomColor();
                    }
                }
                break;

            case 2:
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if(i==j)
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = tileColor;
                        else
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = GetNextPseudoRandomColor();
                    }
                }
                break;

            case 3:
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (i == 3-j-1)
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = tileColor;
                        else
                            GetComponent<GridManager>().spawnedTiles[i, j].GetComponent<SpriteRenderer>().color = GetNextPseudoRandomColor();
                    }
                }
                break;
        }
    }
}
