namespace spc2;

public class Feature
{
    public string type { get; set; }
    public Geometry geometry { get; set; }
    public Properties properties { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public List<List<List<List<double>>>> coordinates { get; set; }
}

public class Properties
{
    public int DN { get; set; }
    public string VALID { get; set; }
    public string EXPIRE { get; set; }
    public string ISSUE { get; set; }
    public string LABEL { get; set; }
    public string LABEL2 { get; set; }
    public string stroke { get; set; }
    public string fill { get; set; }
}

public class Root
{
    public string type { get; set; }
    public List<Feature> features { get; set; }
}