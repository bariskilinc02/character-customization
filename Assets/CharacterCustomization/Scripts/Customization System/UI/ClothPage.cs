using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ClothPage : MonoBehaviour
{
    public List<AssetReference> Clothes;

    public Transform contentTransform;
    public Button buttonPrefab;

    public ClothLoader clothLoader;
    void Awake()
    {
        
    }

    void Start()
    {
        for (int i = 0; i < Clothes.Count; i++)
        {
            Button button = Instantiate(buttonPrefab, contentTransform);
            var i1 = i;
            button.onClick.AddListener(() =>  clothLoader.LoadAsset(Clothes[i1]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
