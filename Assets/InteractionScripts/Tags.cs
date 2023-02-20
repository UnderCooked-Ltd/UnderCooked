using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public const string Raw_Beef_Tag       = "Raw_Beef";
    public const string Cooked_Beef_Tag    = "Cooked_Beef";
    public const string Pan_Tag            = "Pan";
    public const string Bread_Tag          = "Bread";
    public const string Knife_Tag          = "Knife";
    public const string Tomato_Tag         = "Tomato";
    public const string Sliced_Tomato_Tag  = "Sliced_Tomato";
    public const string Lettuce_Tag        = "Lettuce";
    public const string Sliced_Lettuce_Tag = "Sliced_Lettuce";
    public const string Plate_Tag          = "Plate";

    public const string Position_Tag = "Position";
    public const string Knife_Position_Tag = "Knife_Position";

    public const string Bread_Meat_Recipe_Tag = "Bread_Meat_Recipe";
    public const string Burger_Recipe_Tag = "Burger_Recipe";

    public static readonly List<string> Bread_Meat_Recipe = new List<string>()
    {
        Cooked_Beef_Tag, Bread_Tag
    };

    public static readonly List<string> Burger_Recipe = new List<string>()
    {
        Cooked_Beef_Tag, Bread_Tag, Sliced_Tomato_Tag, Sliced_Lettuce_Tag
    };

    public static readonly List<List<string>> Recipes = new List<List<string>>() { Bread_Meat_Recipe, Burger_Recipe };

}
