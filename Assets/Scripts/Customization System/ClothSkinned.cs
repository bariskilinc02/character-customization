using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothSkinned : Cloth
{
    public SkinnedMeshRenderer body;
    private SkinnedMeshRenderer skinnedMesh => GetComponent<SkinnedMeshRenderer>();
    
    private void SetBoneData()
    {
        skinnedMesh.bones = body.bones;
    }

    public void SetCloth(SkinnedMeshRenderer bodyMeshRenderer, Transform transform)
    {
 
        body = bodyMeshRenderer;
        skinnedMesh.rootBone = transform;
        SetBoneData();
    }
}
