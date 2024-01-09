using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float CharacterdynamicFriction;
    private float CharacterstaticFriction;

    private void OnCollisionEnter(Collision other)
    {

        EvaluateCollision(other);
        RetrieveFriction(other);
    }
    private void OnCollisionStay(Collision other)
    {
        EvaluateCollision(other);
        RetrieveFriction(other);
    }
    private void OnCollisionExit(Collision other)
    {
        onGround = false;
        CharacterdynamicFriction = 0;
        CharacterstaticFriction = 0;

    }

    public void EvaluateCollision(Collision other)
    {
        for (int i = 0; i < other.contactCount; i++)
        {
            Vector3 normal = other.GetContact(i).normal;
            onGround |= normal.y > 0.9;
        }
    }
    public void RetrieveFriction(Collision other)
    {
        PhysicMaterial material = other.collider.material;

        CharacterdynamicFriction = 0;
        CharacterstaticFriction = 0;
        if (material != null)
        {
            CharacterstaticFriction = material.staticFriction;
            CharacterdynamicFriction = material.dynamicFriction;

        }
    }
    public bool GetOnGround()
    {
        return onGround;
    }

    public float GetDynamicFriction()
    {
        return CharacterdynamicFriction;
    }
    public float GetStaticFriction()
    {
        return CharacterstaticFriction;
    }
}
