using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnScript : MonoBehaviour
{
    private Button start;
    public GameObject prefab_Cube;
    public Text speedField;
    public Text Dist;
    public Text time;
    public GameObject menu;
    public List<GameObject> list;
    public Text count;
    public GameObject mess;

    private bool startGame;
    public float speed;
    public float Distance;
    public float timeToSpawn;
    private int countCube;

    private void Start()
    {
        start = GetComponent<Button>();
        start.onClick.AddListener(Spawn);
    }
    private void Update()
    {
        
    }
    IEnumerator Mess()
    {
        mess.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        mess.SetActive(false);
    }
    public void Spawn()
    { 
        if (startGame)
        {
            countCube = 0;
            count.text = null;
            StopAllCoroutines();
            OpenField();
            GetComponentInChildren<Text>().text = "Start";
            startGame = false;
            mess.SetActive(true);
        }
        else
        {
            AgreeTheNumb();
            CLoseField();
            CreateCube();
            GetComponentInChildren<Text>().text = "Stop";
            startGame = true;
            mess.SetActive(false);
        }
        
    }
    public IEnumerator Go(float Time)
    {
        yield return new WaitForSeconds(Time);
        FindObjectOfType<SpawnScript>().CreateCube();
    }
    public void CreateCube()
    {
        countCube++;
        count.text = countCube.ToString();
        prefab_Cube.GetComponent<MoveCube>().speed = speed;
        prefab_Cube.GetComponent<MoveCube>().distance = Distance;
        prefab_Cube.GetComponent<MoveCube>().isGo = true;
        Instantiate(prefab_Cube, new Vector3(0, 5, -200), Quaternion.identity);
        StartCoroutine(Go(timeToSpawn));
    }
    void CLoseField()
    {
        foreach (var item in list)
        {
            item.SetActive(false);
        }
    }
    void OpenField()
    {
        foreach (var item in list)
        {
            item.SetActive(true);
        }
    }
    private void AgreeTheNumb()
    {
        if (speed == 0 && Distance == 0 && timeToSpawn == 0)
        {
            string tempSpeed = speedField.text.ToString();
            string tempDist = Dist.text.ToString();
            string tempTime = time.text.ToString();
            speed = float.Parse(tempSpeed);
            Distance = float.Parse(tempDist);
            timeToSpawn = float.Parse(tempTime);
        }
    }
    
}
