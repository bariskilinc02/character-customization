using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClothHandler : MonoBehaviour
{
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    public Transform hipTransform;

    public Transform dressTransform;
    public Transform torsoTransform;
    public Transform legTransform;
    public Transform shoeTransform;
    public Transform topHeadTransform;
    
    private ClothSkinned currentDress;
    private ClothSkinned currentTorso;
    private ClothSkinned currentLeg;
    private ClothSkinned currentShoe;
    private ClothSkinned currentTopHead;
    
    public Cloth clothPrefab;
    
    public void CreateCloth()
    {
        Transform instantiateTransform = dressTransform;
        
        switch (clothPrefab.clothType)
        {
            case Cloth.ClothType.Torso:
                instantiateTransform = torsoTransform;
                break;
            case Cloth.ClothType.Leg:
                instantiateTransform = legTransform;
                break;
            case Cloth.ClothType.Shoe:
                instantiateTransform = shoeTransform;
                break;
            case Cloth.ClothType.TopHead:
                instantiateTransform = topHeadTransform;
                break;
        }

        Cloth cloth = Instantiate(clothPrefab, instantiateTransform);

        if (cloth is ClothSkinned clothSkinned)
        {
            clothSkinned.SetCloth(bodySkinnedMeshRenderer, hipTransform);
            RemoveCurrentCloth(clothSkinned.clothType);
            SetNewCloth(clothSkinned);
          
        }
        cloth.gameObject.SetActive(true);
    }

    private void RemoveCurrentCloth(Cloth.ClothType clothType)
    {
        switch (clothType)
        {
            case Cloth.ClothType.Torso:
                if (currentTorso != null)
                {
                    Destroy(currentTorso.gameObject);
                }
                currentTorso = null;
                break;
            case Cloth.ClothType.Leg:
                if (currentLeg != null)
                {
                    Destroy(currentLeg.gameObject);
                }
                currentLeg = null;
                break;
            case Cloth.ClothType.Shoe:
                if (currentShoe != null)
                {
                    Destroy(currentShoe.gameObject);
                }
                currentShoe = null;
                break;
            case Cloth.ClothType.TopHead:
                if (currentTopHead != null)
                {
                    Destroy(currentTopHead.gameObject);
                }
                currentTopHead = null;
                break;
        }
    }
    
    private void SetNewCloth(ClothSkinned clothSkinned)
    {
        switch (clothSkinned.clothType)
        {
            case Cloth.ClothType.Torso:
                currentTorso = clothSkinned;
                break;
            case Cloth.ClothType.Leg:
                currentLeg = clothSkinned;
                break;
            case Cloth.ClothType.Shoe:
                currentShoe = clothSkinned;
                break;
            case Cloth.ClothType.TopHead:
                currentTopHead = clothSkinned;
                break;
        }
    }
}
