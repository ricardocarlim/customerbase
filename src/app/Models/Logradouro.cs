using System.Collections.Generic;

public class LogradouroModel
{
    public List<Logradouro> Logradouros { get; set; }
}

public class Logradouro
{
    public int LogradouroID { get; set; }
    public Cliente Cliente { get; set; }
    public string LogradouroRuaAV { get; set; }
    public bool EnderecoPrincipal { get; set; }
}
