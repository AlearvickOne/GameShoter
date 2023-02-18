using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAddToPlayer : MonoBehaviour
{
    enum KeyType { redKey, blueKey, greenKey}

    [SerializeField] private KeyType _keyType;
    [SerializeField] private BoxCollider _playerColl;

    private void OnTriggerEnter(Collider other)
    {
        KeyAddParameters(other, KeyType.redKey);
        KeyAddParameters(other, KeyType.blueKey);
        KeyAddParameters(other, KeyType.greenKey);
    }
    void KeyAddParameters(Collider other, KeyType typeKey)
    {
        if(other == _playerColl && _keyType == typeKey)
        {
            KeyAdd(typeKey);
            Destroy(this.gameObject, 0.3f);
        }
    }

    void KeyAdd(KeyType keyType)
    {
        switch (keyType)
        {
            case KeyType.redKey:
                SaveParametersObjects._singleton._redKey = true;
                break;
            case KeyType.blueKey:
                SaveParametersObjects._singleton._blueKey = true;
                break;
            case KeyType.greenKey:
                SaveParametersObjects._singleton._greenKey = true;
                break;
        }
    }

}
