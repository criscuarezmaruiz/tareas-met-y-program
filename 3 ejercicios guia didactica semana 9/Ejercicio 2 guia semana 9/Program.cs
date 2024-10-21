using System;
using System.Collections.Generic;

class CuentaBancaria
{
    class Transaccion
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }

        public Transaccion(string tipo, decimal monto)
        {
            Tipo = tipo;
            Monto = monto;
        }

        public override string ToString()
        {
            return $"{Tipo}: {Monto:C}";
        }
    }

    static void Main(string[] args)
    {
        decimal saldo = 0;
        int opcion = 0;

        List<Transaccion> transacciones = new List<Transaccion>();

        do
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Ver historial de transacciones");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

       
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"Su saldo actual es: {saldo:C}");
                    break;

                case 2:
                    Console.Write("Ingrese la cantidad a depositar: ");
                    decimal deposito = Convert.ToDecimal(Console.ReadLine());
                    saldo += deposito;
                    transacciones.Add(new Transaccion("Depósito", deposito)); 
                    Console.WriteLine($"Depósito realizado. Su nuevo saldo es: {saldo:C}");
                    break;

                case 3:
                    Console.Write("Ingrese la cantidad a retirar: ");
                    decimal retiro = Convert.ToDecimal(Console.ReadLine());

                   
                    if (retiro > saldo)
                    {
                        Console.WriteLine("Fondos insuficientes.");
                    }
                    else
                    {
                        saldo -= retiro;
                        transacciones.Add(new Transaccion("Retiro", retiro)); 
                        Console.WriteLine($"Retiro realizado. Su nuevo saldo es: {saldo:C}");
                    }
                    break;

                case 4:
                    Console.WriteLine("Historial de transacciones:");
                    if (transacciones.Count == 0)
                    {
                        Console.WriteLine("No se han realizado transacciones.");
                    }
                    else
                    {
                        foreach (var transaccion in transacciones)
                        {
                            Console.WriteLine(transaccion);
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("Acciones ejecutadas correctamente. ¡Hasta pronto!");
                    break;

                default:
                    Console.WriteLine("Opción no válida, por favor intente nuevamente.");
                    break;
            }
        } while (opcion != 5);
    }
}
