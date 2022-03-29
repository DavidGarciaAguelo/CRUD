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
            Console.WriteLine("____________________________________________");
            Console.WriteLine("DEPARTAMENTO DE RECURSOS HUMANOS          ");
            Console.WriteLine("____________________________________________");
            Console.WriteLine("Selecciona la opcion que deseas realizar: ");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Leer");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Mostrar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("____________________________________________");

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
                case 5:
                    Mostrar();
                    break;

            }


        } while (b == true && num != 0);


    }


    static async void Crear()
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
            db.Departments.Add(new prueba1.Department { Name = nombre, GroupName = grupo});
            db.SaveChanges();

            Console.WriteLine("Creado.\n");

           

        }

        Console.WriteLine("\n");

    }

    static void Leer()
    {
        //String eleccion;
        //bool b;
        //int id;

        /*
          do {
                Console.WriteLine("Introduce el id del departamento: \n");
                eleccion = Console.ReadLine();

                b = int.TryParse(eleccion, out id);

                if (id == null)
                {
                    Console.WriteLine("Un campo no ha sido rellenado, vuelve a insertalo por favor.\n");
                    
                }

            }while(id == null); 
         
         */

        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Leyendo...\n");

            var departamento = db.Departments.OrderBy(x => x.DepartmentId).First();
            //^^^^^^^^^aqui tambien se puede poner: var departamento = db.Departments.AsEnumerable().ElementAt(id);

            Console.WriteLine(departamento.DepartmentId);
            Console.WriteLine(departamento.Name);
            Console.WriteLine(departamento.GroupName);
            Console.WriteLine(departamento.ModifiedDate);
            Console.WriteLine("\n");
        }
        Console.WriteLine("\n");
    }

    static void Actualizar()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            String nNombre;
            String nGrupo;
            String eleccion;
            bool b;
            int id;

            do
            {
                Console.WriteLine("Introduce el id del departamento: \n");
                eleccion = Console.ReadLine();

                b = int.TryParse(eleccion, out id);

                Console.WriteLine("Introduce el nuevo nombre del departamento: \n");
                nNombre = Console.ReadLine();

                Console.WriteLine("Introduce el nuevo nombre del grupo al que pertenece ese departamento: \n");
                nGrupo = Console.ReadLine();

                if (nNombre == null)
                {
                    Console.WriteLine("El campo nombre no ha sido rellenado, tendrás que volver a insertarlo.\n");

                }else if(nGrupo == null)
                {
                    Console.WriteLine("El campo nombreGrupo no ha sido rellenado, tendrás que volver a insertarlo.\n");

                }
                else if(id == null)
                {
                    Console.WriteLine("El campo id no ha sido rellenado, tendrás que volver a insertarlo.\n");
                }

            } while (nNombre == null || nGrupo == null || id == null);

            var departamento = db.Departments.AsEnumerable().ElementAt(id - 1);

            Console.WriteLine("Departamento a actualizar con los nuevos datos: \n");

            Console.WriteLine(departamento.DepartmentId);
            Console.WriteLine(departamento.Name);
            Console.WriteLine(departamento.GroupName);
            Console.WriteLine(departamento.ModifiedDate);
            Console.WriteLine("\n");

            Console.WriteLine("Actualizando...\n");

            departamento.Name = nNombre;
            departamento.GroupName = nGrupo;
            departamento.ModifiedDate = DateTime.Now;

            db.SaveChanges();

            
        }
        Console.WriteLine("\n");
    }

    static void Eliminar()
    {
        String eleccion;
        bool b;
        int id;

        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Introduce el id del departamento: \n");
            eleccion = Console.ReadLine();

            b = int.TryParse(eleccion, out id);

            var departamento = db.Departments.AsEnumerable().ElementAt(id - 1);

            db.Remove(departamento);
            db.SaveChanges();

            Console.WriteLine("Eliminando...\n");
           
        }
        Console.WriteLine("\n");
    }

    static void Mostrar()
    {
        using (var db = new prueba1.DepartamentoRecursos())
        {
            Console.WriteLine("Lista de todos los departamentos: \n");
    
            db.Departments.ToList().ForEach(de => Console.WriteLine(de.Name));

        }
        //await Task.Delay(4000);

        Console.WriteLine("\n");

    }
    
}

