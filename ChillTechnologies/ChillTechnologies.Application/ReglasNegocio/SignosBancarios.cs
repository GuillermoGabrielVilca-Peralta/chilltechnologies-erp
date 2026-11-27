namespace ChillTechnologies.Application.ReglasNegocio;

public static class SignosBancarios
{
    public static int Signo(string tipo) => tipo switch
    {
        "Deposito" => 1,
        "Interes" => 1,
        "Retiro" => -1,
        "Comision" => -1,
        "Transferencia" => -1,
        _ => 0
    };
}
