using UnityEngine;

/// <summary>
/// UNO Game Manager class
/// </summary>
public class UnoManager : GameManager {


    /// <summary>
    /// Unity uses this method to initialize objects. (Awake (creation) - Start (initialization) - Update(usual updates by frames))
    /// </summary>
    private void Start()
    {
        instance = this;

        GameObject card;
        for (int i = 0; i < 10; i++)
        {
            card = Instantiate(CardPrefab); // Creating a clone of the card prefab
            card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
            card.transform.localPosition = new Vector3(0, 0, i * 10); // setting local position, relative to the manager
            card.AddComponent<Card>(); // adding the card script to the object.
            card.GetComponent<Card>().build("UI/UNO/Red_" + i, "UI/UNO/UNOBack", "Red_" + i); //Kártya build. UI-t állít be.

            card = Instantiate(CardPrefab); // Creating a clone of the card prefab
            card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
            card.transform.localPosition = new Vector3(0, 0, i * 10 + 101); // setting local position, relative to the manager
            card.AddComponent<Card>(); // adding the card script to the object.
            card.GetComponent<Card>().build("UI/UNO/Blue_" + i, "UI/UNO/UNOBack", "Red_" + i); //Kártya build. UI-t állít be.

            card = Instantiate(CardPrefab); // Creating a clone of the card prefab
            card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
            card.transform.localPosition = new Vector3(0, 0, i * 10 + 201); // setting local position, relative to the manager
            card.AddComponent<Card>(); // adding the card script to the object.
            card.GetComponent<Card>().build("UI/UNO/Yellow_" + i, "UI/UNO/UNOBack", "Red_" + i); //Kártya build. UI-t állít be.

            card = Instantiate(CardPrefab); // Creating a clone of the card prefab
            card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
            card.transform.localPosition = new Vector3(0, 0, i * 10 + 301); // setting local position, relative to the manager
            card.AddComponent<Card>(); // adding the card script to the object.
            card.GetComponent<Card>().build("UI/UNO/Green_" + i, "UI/UNO/UNOBack", "Red_" + i); //Kártya build. UI-t állít be.
        }
    }
}