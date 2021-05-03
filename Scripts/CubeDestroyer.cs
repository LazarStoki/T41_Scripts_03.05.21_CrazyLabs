using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CubeDestroyer : MonoBehaviour
{
    public int HP = 5;
    public Button plusHpButton;
    public Button minusHpButton;
    public Text healthDisplay;
    void Start()
    {
        minusHpButton.onClick.AddListener(TaskOnClickMinusHp);
        healthDisplay.text = $"Health:{HP}";
        plusHpButton.onClick.AddListener(TaskOnClickPlusHp);
    }
    
    void Update()
    {
        
    } 
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.tag == "Metak")
        {
            Destroy(other.gameObject);
        }
        if (this.tag == "Enemy")
        {
            HP -= 1;

            if (HP == 0)
            {
                Destroy(this.gameObject);
            }

        }

    }

    void TaskOnClickMinusHp()
    {
        HP--;
        healthDisplay.text = $"Health:{HP}";
    }

    void TaskOnClickPlusHp()
    {
        HP++;
        healthDisplay.text = $"Health:{HP}";
    }
}
