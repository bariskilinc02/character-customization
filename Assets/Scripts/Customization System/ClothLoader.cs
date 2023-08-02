using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ClothLoader : MonoBehaviour
{
    public LoadingPanel loadingPanel;
    
    public AssetReference clothReference;

    public CharacterClothHandler clothHandler;
    void Awake()
    {
        
    }

    void Start()
    {
        Addressables.InitializeAsync();

    }

    private void AddressablesManage_Completed()
    {
        
        clothReference.LoadAssetAsync<GameObject>().Completed += (obje) =>
        {  
            clothHandler.clothPrefab = obje.Result.GetComponent<ClothSkinned>();
            clothHandler.CreateCloth();
        };
      
    }
    
    public void LoadAsset(AssetReference assetReference)
    {
        if (assetReference.IsValid())
        {
            GameObject cloth = assetReference.OperationHandle.Result as GameObject;

            if (cloth == null)return;
            
            clothHandler.clothPrefab = cloth.GetComponent<ClothSkinned>();
            clothHandler.CreateCloth();
        }
        else
        {
            loadingPanel.ShowPanel();
            assetReference.LoadAssetAsync<GameObject>().Completed += (cloth) =>
            {  
                loadingPanel.HidePanel();
                clothHandler.clothPrefab = cloth.Result.GetComponent<ClothSkinned>();
                clothHandler.CreateCloth();
            };
        }
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //AddressablesManage_Completed();
        }
    }
    
    IEnumerator Loadcoroutine()
    {
        string url = "gs://fit-union-221609.appspot.com/assettest1/myasset";
        WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;
        AssetBundle myasset = www.assetBundle;

        GameObject mya1 = myasset.LoadAsset("Barbarian Variant") as GameObject;

        Instantiate(mya1);
    }
}
