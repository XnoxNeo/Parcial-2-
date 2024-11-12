using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class SetController : MonoBehaviour
{
    public TMP_InputField inputField;  

    public Button addToDynamicButton;
    public Button addToStaticButton;

    public Button removeFromDynamicButton;
    public Button removeFromStaticButton;

    public Button containsButton;
    public Button showButton;

    public Button cardinalityButton;

    public Button isEmptyButton;
    public Button unionButton;

    public Button intersectButton;
    public Button differenceButton;

    private ISet<string> dynamicSet = new DynamicSet<string>();
    private ISet<string> staticSet = new StaticSet<string>(5);

    void Start()
    {
        addToDynamicButton.onClick.AddListener(AddToDynamicSet);
        addToStaticButton.onClick.AddListener(AddToStaticSet);

        removeFromDynamicButton.onClick.AddListener(RemoveFromDynamicSet);
        removeFromStaticButton.onClick.AddListener(RemoveFromStaticSet);

        containsButton.onClick.AddListener(Contains);
        showButton.onClick.AddListener(Show);

        cardinalityButton.onClick.AddListener(Cardinality);

        isEmptyButton.onClick.AddListener(IsEmpty);
        unionButton.onClick.AddListener(Union);

        intersectButton.onClick.AddListener(Intersect);
        differenceButton.onClick.AddListener(Difference);
    }

    public void AddToDynamicSet()
    {
        string element = inputField.text;
        if (!string.IsNullOrEmpty(element))
        {
            dynamicSet.Add(element);
            Debug.Log("Element '" + element + "' has been added to dynamic set.");
        }
        else
        {
            Debug.Log("Please add an element for the dynamic set.");
        }
    }

    public void AddToStaticSet()
    {
        string element = inputField.text;
        if (!string.IsNullOrEmpty(element))
        {
            staticSet.Add(element);
            Debug.Log("Element '" + element + "' has been added to static set.");
        }
        else
        {
            Debug.Log("Please add an element for the static set.");
        }
    }

    public void RemoveFromDynamicSet()
    {
        string element = inputField.text;
        if (!string.IsNullOrEmpty(element) && dynamicSet.Contains(element))
        {
            dynamicSet.Remove(element);
            Debug.Log("Element '" + element + "' has been removed from dynamic set.");
        }
        else
        {
            Debug.Log("Element '" + element + "' is not in dynamic set");
        }
    }

    public void RemoveFromStaticSet()
    {
        string element = inputField.text;
        if (!string.IsNullOrEmpty(element) && staticSet.Contains(element))
        {
            staticSet.Remove(element);
            Debug.Log("Element '" + element + "' has been removed from static set.");
        }
        else
        {
            Debug.Log("Element '" + element + "' is not in static set");
        }
    }

    public void Contains()
    {
        string element = inputField.text;
        if (!string.IsNullOrEmpty(element))
        {
            bool containsDynamic = dynamicSet.Contains(element);
            bool containsStatic = staticSet.Contains(element);

            if (containsDynamic)
            {
                Debug.Log("The element '" + element + "' is present in dynamic set.");
            }
            else
            {
                Debug.Log("The element'" + element + "' is not present in dynamic set.");
            }

            if (containsStatic)
            {
                Debug.Log("The element '" + element + "' is present in static set.");
            }
            else
            {
                Debug.Log("The element'" + element + "' is not present in static set.");
            }
        }
        else
        {
            Debug.Log("Write an element in the text field.");
        }
    }

    public void Show()
    {
        string dynamicElements = string.Join(", ", dynamicSet.GetElements());
        string staticElements = string.Join(", ", staticSet.GetElements());

        Debug.Log("Elements in dynamic set: " + dynamicElements);
        Debug.Log("Elements in static set: " + staticElements);
    }

    public void Cardinality()
    {
        int dynamicCardinality = dynamicSet.Cardinality();
        int staticCardinality = staticSet.Cardinality();

        Debug.Log("Dynamic set cardinality: " + dynamicCardinality);
        Debug.Log("Static set cardinality " + staticCardinality);
    }

    public void IsEmpty()
    {
        bool isDynamicEmpty = dynamicSet.IsEmpty();
        bool isStaticEmpty = staticSet.IsEmpty();

        Debug.Log("Is dynamic set empty? " + isDynamicEmpty);
        Debug.Log("Is static set empty? " + isStaticEmpty);
    }

    public void Union()
    {
        var unionSet = dynamicSet.Union(staticSet);
        string unionElements = string.Join(", ", unionSet.GetElements());
        Debug.Log("Set union: " + unionElements);
    }

    public void Intersect()
    {
        var intersectSet = dynamicSet.Intersect(staticSet);
        string intersectElements = string.Join(", ", intersectSet.GetElements());
        Debug.Log("Sets intersection: " + intersectElements);
    }

    public void Difference()
    {
        var differenceSet = dynamicSet.Difference(staticSet);
        string differenceElements = string.Join(", ", differenceSet.GetElements());
        Debug.Log("Sets difference: " + differenceElements);
    }
}
