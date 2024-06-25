using UnityEngine;

[CreateAssetMenu(fileName = "NewShipRoleData", menuName = "GameData/ShipRole")]
public class ShipRoleData : ScriptableObject
{

    public Sprite[] ManVariantsSprites;
    public Sprite[] WomanVariantsSprites;

    [Multiline]
    public string Description;

    private void OnValidate()
    {
        if (WomanVariantsSprites.Length != ManVariantsSprites.Length)
        {
            WomanVariantsSprites = new Sprite[ManVariantsSprites.Length];
        }
    }
}
