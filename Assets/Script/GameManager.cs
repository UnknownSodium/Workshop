using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public InventoryPanel inventoryPanel;

    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public float timeCounter = 30f;
    public ItemData targetItem;
    public int targetAmount = 5;
    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text  targetCurrentAmountText;
    public bool isPlayerWin = false;

    private void Start()
    {
        targetItemIcon.sprite = targetItem.itemIcon;
    }

    private void Update()
    {
        if(isPlayerWin){
            timeCounterText.text = "You win!!!";
            return;
        }

        if(timeCounter > 0f){
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();
            targetCurrentAmountText.text = (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();
            //player win
            if(InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount){
                Debug.Log("Player win!");
                isPlayerWin = true;
            }
        }
        // player lose
        else{
            SceneManager.LoadScene("MainScreen");
        }
    }

}
