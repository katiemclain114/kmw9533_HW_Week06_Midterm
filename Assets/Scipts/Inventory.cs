using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public GameObject invCanvas;
    public Text carrotText;
    public Text potatoText;
    public Text beanText;

    public Text carrotSeedText;
    public Text potatoSeedText;
    public Text beanSeedText;

    private const string DIR = "/Logs";
    private const string FILE_INV = DIR + "/InventoryFile.csv";
    private string FILE_PATH_INV;

    private int carrotsInv;
    public int CarrotsInv
    {
        get { return carrotsInv; }
        set
        {
            carrotsInv = value;
            carrotText.text = carrotsInv + "";
            UpdateFile();
        }
    }
    
    private int potatoesInv;
    public int PotatoesInv
    {
        get { return potatoesInv; }
        set
        {
            potatoesInv = value;
            potatoText.text = potatoesInv + "";
            UpdateFile();
        }
    }

    private int beansInv;
    public int BeansInv
    {
        get { return beansInv; }
        set
        {
            beansInv = value;
            beanText.text = beansInv + "";
            UpdateFile();
        }
    }

    private int carrotSeedsInv;
    public int CarrotSeedsInv
    {
        get { return carrotSeedsInv; }
        set
        {
            Debug.Log("changed");
            carrotSeedsInv = value;
            carrotSeedText.text = carrotSeedsInv + "";
            UpdateFile();
        }
    }

    private int potatoSeedsInv;
    public int PotatoSeedsInv
    {
        get { return potatoSeedsInv; }
        set
        {
            potatoSeedsInv = value;
            potatoSeedText.text = potatoSeedsInv + "";
            UpdateFile();
        }
    }

    private int beanSeedsInv;
    public int BeanSeedsInv
    {
        get { return beanSeedsInv; }
        set
        {
            beanSeedsInv = value;
            beanSeedText.text = beanSeedsInv + "";
            UpdateFile();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FILE_PATH_INV = Application.dataPath + FILE_INV;
        SplitInvFile();
    }

    void SplitInvFile()
    {
        string[] fileData = File.ReadAllLines(FILE_PATH_INV);

        for (int i = 0; i < fileData.Length; i++)
        {
            string[] row = fileData[i].Split(',');
            switch (row[0])
            {
                case "C":
                    CarrotsInv = Int32.Parse(row[1]);
                    break;
                case "P":
                    PotatoesInv = Int32.Parse(row[1]);
                    break;
                case "B":
                    BeansInv = Int32.Parse(row[1]);
                    break;
                case "c":
                    CarrotSeedsInv = Int32.Parse(row[1]);
                    break;
                case "p":
                    PotatoSeedsInv = Int32.Parse(row[1]);
                    break;
                case "b":
                    BeanSeedsInv = Int32.Parse(row[1]);
                    break;
            }
        }
    }

    void UpdateFile()
    {
        string fileData = "";
        fileData = "C," + CarrotsInv + "\n" +
                   "P," + PotatoesInv + "\n" +
                   "B," + BeansInv + "\n" +
                   "c," + CarrotSeedsInv + "\n" +
                   "p," + PotatoSeedsInv + "\n" +
                   "b," + BeanSeedsInv + "\n";
        File.WriteAllText(FILE_PATH_INV, fileData);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invCanvas.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            invCanvas.SetActive(false);
        }
    }
}
