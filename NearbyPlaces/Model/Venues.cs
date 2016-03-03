using System.Collections.Generic;

public class Location
{
    public string address { get; set; }
    public int distance { get; set; }
    public string cc { get; set; }
    public string city { get; set; }
    public string country { get; set; }
}

public class Icon
{
    public string prefix { get; set; }
    public string suffix { get; set; }
}

public class Category
{
    public string id { get; set; }
    public string name { get; set; }
    public Icon icon { get; set; }
}




public class Venue
{
    public string id { get; set; }
    public string name { get; set; }
    public Location location { get; set; }
    public List<Category> categories { get; set; }
    public double rating { get; set; }
}

public class Likes
{
    public int count { get; set; }
    public List<object> groups { get; set; }
    public string summary { get; set; }
}


public class User
{
    public string id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public Photo photo { get; set; }
    public string type { get; set; }
}

public class Tip
{
    public string id { get; set; }
    public string text { get; set; }
    public Likes likes { get; set; }
    public User user { get; set; }
}

public class Item2
{
    public Venue venue { get; set; }
    public List<Tip> tips { get; set; }
}

public class Group
{
    public List<Item2> items { get; set; }
}

public class Response
{
    public List<Group> groups { get; set; }
}

public class RootObject
{
    public Response response { get; set; }
}