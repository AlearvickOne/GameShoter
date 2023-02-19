using UnityEngine;

public class KeyAddToPlayer : MonoBehaviour
{
    private enum KeyType { redKey, blueKey, greenKey }

    [SerializeField] private KeyType _keyType;
    private BoxCollider _playerColl;

    private void Start()
    {
        _playerColl = SaveParametersObjects._singleton._playerColl;
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyAddParameters(other, KeyType.redKey);
        KeyAddParameters(other, KeyType.blueKey);
        KeyAddParameters(other, KeyType.greenKey);
    }

    private void KeyAddParameters(Collider other, KeyType typeKey)
    {
        if (other == _playerColl && _keyType == typeKey)
        {
            KeyAdd(typeKey);
            Destroy(this.gameObject, 0.3f);
        }
    }

    private void KeyAdd(KeyType keyType)
    {
        switch (keyType)
        {
            case KeyType.redKey:
                SaveParametersObjects._redKey = true;
                break;
            case KeyType.blueKey:
                SaveParametersObjects._blueKey = true;
                break;
            case KeyType.greenKey:
                SaveParametersObjects._greenKey = true;
                break;
        }
    }

}
