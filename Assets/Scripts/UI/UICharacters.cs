using UnityEngine;
using UnityEngine.UI;

public class UICharacters : MonoBehaviour
{
    [SerializeField] private RawImage imgCharacters;

    [SerializeField] private Texture textures;

    [SerializeField] private GameObject cameraGameObject;

    private Vector3 firstCharacter = new Vector3(-70f, 0f, 90f);
    private Vector3 secondCharacter = new Vector3(-70f, 3f, 90f);
    private Vector3 thirdCharacter = new Vector3(-70f, 6f, 90f);
    private Vector3 fourthCharacter = new Vector3(-70f, 9f, 90f); 
    private Vector3 fifthCharacter = new Vector3(-70f, 12f, 90f); 
    private Vector3 sixthCharacter = new Vector3(-70f, 15f, 90f); 

    void Start()
    {
        imgCharacters.texture = textures;
    }
    public void CharactersView(int index)
    {
        if (index == 0)
        {
            cameraGameObject.transform.position = firstCharacter;
        }
        else if (index == 1)
        {
            cameraGameObject.transform.position = secondCharacter;
        }
        else if (index == 2)
        {
            cameraGameObject.transform.position = thirdCharacter;
        }
        else if (index == 3)
        {
            cameraGameObject.transform.position = fourthCharacter;
        }
        else if (index == 4)
        {
            cameraGameObject.transform.position = fifthCharacter;
        }
        else if (index == 5)
        {
            cameraGameObject.transform.position = sixthCharacter;
        }
    }
}
