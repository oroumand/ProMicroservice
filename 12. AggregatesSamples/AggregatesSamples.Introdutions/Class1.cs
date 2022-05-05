using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesSamples.Introdutions;

public class Root
{
    public List<Level1> Level1s { get; set; }

}
public class Level1
{
    public List<Level2> Level2s { get; set; }

}
public class Level2
{

}
