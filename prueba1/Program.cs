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


        } while (b == true && num != 0);


    }


    static void Crear()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine($"Database path: {db.Database.ProviderName}.\n");

            String nombre;
            String grupo;

            do {
                Console.WriteLine("Introduce el nombre del departamento: \n");
                nombre = Console.ReadLine();

                Console.WriteLine("Introduce el nombre del grupo al que pertenece ese departamento: \n");
                grupo = Console.ReadLine();

                if (nombre == null || grupo == null)
                {
                    Console.WriteLine("Uno de los dos campos no ha sido rellenado, vuelve a insertar los valores por favor.\n");
                    
                }

            }while(nombre == null || grupo == null);
            

            Console.WriteLine("Creando nuevo departamento...\n");
            db.Departments.Add(new prueba1.Department { Name = nombre, GroupName = grupo, ModifiedDate = DateTime.Now});
            db.SaveChanges();

            Console.WriteLine("Creado.\n");

        }

    }

    static void Leer()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Leyendo...\n");

            var departamento = db.Departments.OrderBy(x => x.DepartmentId).First();
            Console.WriteLine(departamento.DepartmentId);
            Console.WriteLine(departamento.Name);
            Console.WriteLine(departamento.GroupName);
            Console.WriteLine(departamento.ModifiedDate);
            Console.WriteLine("\n");
        }
    }

    static void Actualizar()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Actualizar\n");
        }
    }

    static void Eliminar()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Eliminar\n");
        }
    }

}

