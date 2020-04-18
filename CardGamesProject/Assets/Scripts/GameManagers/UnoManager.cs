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
        SetupCardVisuals();
    }

    private void SetupCardVisuals()
    {
        int tabX = 0; // Cosmetics... =D
        int tabZ = 0;
        GameObject card; //This will hold the card objects until they are added to the list;
        for (int n = 0; n < 2; n++)
        {
            for (int j = 0; j < 8; j++)
            {
                string color;
                string type;
                for (int i = 0; i < 10; i++)
                {
                    color = "Red";
                    if (j >= 2)
                        color = "Blue";
                    if (j >= 4)
                        color = "Yellow";
                    if (j >= 6)
                        color = "Green";

                    card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                    card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                    card.transform.localPosition = new Vector3(tabX * 0.5f, 0, tabZ * 0.1f); // setting local position, relative to the manager
                    card.AddComponent<Card>(); // adding the card script to the object.
                    card.GetComponent<Card>().build("UI/UNO/" + color + "_" + i, "UI/UNO/UNOBack", color + "_" + i); //Building the card. Sets the visuals.
                    tabX++;
                    tabZ++;
                }

                for (int i = 0; i < 3; i++)
                {
                    color = "Red";
                    type = "X";
                    if (j >= 2)
                        color = "Blue";
                    if (j >= 4)
                        color = "Yellow";
                    if (j >= 6)
                        color = "Green";
                    if (i == 1)
                        type = "R";
                    if (i == 2)
                        type = "P2";

                    card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                    card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                    card.transform.localPosition = new Vector3(tabX * 0.5f, 0, tabZ * 0.1f);// setting local position, relative to the manager
                    card.AddComponent<Card>(); // adding the card script to the object.
                    card.GetComponent<Card>().build("UI/UNO/" + color + "_" + type, "UI/UNO/UNOBack", color + "_" + type); //Building the card. Sets the visuals.
                    tabX++;
                    tabZ++;
                }
            }
            for (int j = 0; j < 4; j++)
            {
                string type = "Color";
                if (j >= 2)
                    type = "P4";

                card = Instantiate(CardPrefab); // Creating a clone of the card prefab
                card.transform.parent = transform; // Assigning the manager as its pareint in the scene hierarchy
                card.transform.localPosition = new Vector3(tabX * 0.5f, 0, tabZ * 0.1f); // setting local position, relative to the manager
                card.AddComponent<Card>(); // adding the card script to the object.
                card.GetComponent<Card>().build("UI/UNO/" + type, "UI/UNO/UNOBack", type); //Building the card. Sets the visuals.
                tabX++;
                tabZ++;
            }
        }
    }
}