// See https://aka.ms/new-console-template for more information
/*int a = 42;
int b = 119;
int c = a + b;
Console.WriteLine(c);
Console.ReadKey();*/

using System;
using System.Linq;

internal class Program
{

    private static void Main()
    {
        String eleccion;
        bool b;
        int num;

        using(var db = new DepartamentoRecursos())
        {
            Console.WriteLine($"Database path: {db.}.");
        }

        do {
            Console.WriteLine("Selecciona la opcion que deseas realizar: \n");
            Console.WriteLine("1. Crear\n");
            Console.WriteLine("2. Leer\n");
            Console.WriteLine("3. Actualizar\n");
            Console.WriteLine("4. Eliminar\n");
            Console.WriteLine("0. Salir\n");

            eleccion = Console.ReadLine();

            b = int.TryParse(eleccion, out num);

            switch (num) {
                case 1:
                    Crear();
                    break;
                case 2:
                    Leer();
                    break;
                case 3:
                    Actualizar();
                    break;
                case 4:
                    Eliminar();
                    break;

            }


        }while(b == true && num != 0);
        

    }


    static void Crear()
    {
        Console.WriteLine("Creando...\n");
    }

    static void Leer()
    {
        Console.WriteLine("Leer\n");
    }

    static void Actualizar()
    {
        Console.WriteLine("Actualizar\n");
    }

    static void Eliminar()
    {
        Console.WriteLine("Eliminar\n");
    }



