using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public Image selectIcon;
    public TMP_Text descriptionText;
    public Transform rightPanelTransform;
    public GameObject itemBtnPrefab;

    public void OnOpen(){
        for(int i = rightPanelTransform.childCount-1; i >= 0; i--){
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }
        
        for(int i = 0; i < InventoryManager.instance.inventoryList.Count; i++){
            GameObject itemBtnObj = Instantiate(itemBtnPrefab, rightPanelTransform);
            ItemBtn itemBtnComp = itemBtnObj.GetComponent<ItemBtn>();
            itemBtnComp.data = InventoryManager.instance.inventoryList[i];
            itemBtnComp.icon.sprite = itemBtnComp.data.itemIcon;
            
            //get listener
            Button button = itemBtnObj.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                selectIcon.sprite = itemBtnComp.data.itemIcon;
                descriptionText.text = itemBtnComp.data.description;
            });
        }
    }
}
