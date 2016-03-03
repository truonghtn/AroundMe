using System.Collections.Generic;


public class Photo
{
    public string prefix { get; set; }
    public string suffix { get; set; }
}


public class Item2Photo
{
    public string id { get; set; }
    public string prefix { get; set; }
    public string suffix { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public User user { get; set; }
}

public class Photos
{
    public List<Item2Photo> items { get; set; }
}

public class ResponsePhoto
{
    public Photos photos { get; set; }
}

public class RootObjectPhoto
{
    public ResponsePhoto response { get; set; }
}