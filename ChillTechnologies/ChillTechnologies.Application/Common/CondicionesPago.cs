namespace ChillTechnologies.Application.Common;

// Unico lugar donde vive esa tabla, para no repetir el mismo switch y corregir 3 en vez de 1
public static class CondicionesPago
{
    public static int Dias(string condicionPago) => condicionPago switch
    {
        "Credito 15" => 15,
        "Credito 30" => 30,
        "Credito 60" => 60,
        "Credito 90" => 90,
        _ => 0
    };
}
