using System;
using System.Collections.Generic;
using System.Linq;

public class PlayList
{
    public List<string> collection = new List<string>();
    public void SetList()
    {
        Console.WriteLine("Enter an path to audiofile (to end input 'exit'):");

        // Считывание элементов из консоли
        while (true)
        {
            string input = Console.ReadLine();           //reading user input
            if (input.ToLower() == "exit")                  //cheacking if user wanth to exit
                break;

            collection.Add(input);                       // Add the input to the a list

            Console.WriteLine(collection);
        }
    }

    public List<string> GetList()                 //getter method for a list value
    {
        return collection;
    }

    public void AddToList()
    {
        Console.WriteLine("Enter path to new audiofile:");

        string newElement = Console.ReadLine();
        collection.Add(newElement);                          //adding new track o a collection

        Console.WriteLine($"Track '{newElement}' was added to a playlist.");
    }

    public void ChangeList()
    {
        Console.WriteLine("Playlist: " + string.Join(", ", collection));         //print the conteining of the playlist

        Console.WriteLine("Enter new tracks order:");
        string indexesInput = Console.ReadLine();
        string[] indexes = indexesInput.Split(',');

        List<string> newCollection = new List<string>();                        //create a new collection to store tracks in the desired order

        foreach (string indextrack in indexes)
        {
            if (int.TryParse(indextrack.Trim(), out int index) && index >= 0 && index < collection.Count)      //try to parse the index as int
            {
                newCollection.Add(collection[index]);                               //add track to a new collection with a new index
            }
            else
            {
                Console.WriteLine($"Index {indextrack} is invalid.");
            }
        }

        foreach (string item in collection)
        {
            if (!newCollection.Contains(item))
            {
                newCollection.Add(item);              //adding every element to a new collection
            }
        }

        collection = newCollection;

        Console.WriteLine("new order: " + string.Join(", ", collection));

        Console.WriteLine(collection);
    }
}
