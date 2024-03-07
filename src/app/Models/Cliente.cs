using System.Collections.Generic;

public class ClienteModel
{
    public List<Cliente> Clientes { get; set; }
}

public class Cliente
{
    public int ClienteID { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Logotipo { get; set; }
}
