using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Programa
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public int Salario_base { get; set; }
        public Empleado(string nombre, int edad, int salario_base)
        {
            Nombre = nombre;
            Edad = edad;
            Salario_base = salario_base;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Nombre : { Nombre} Edad : {Edad} Salario: {Salario_base}");
        }
    }

    public class Diseniadores : Empleado
    {
        public string Especialidad_cargo { get; set; }    
        public Diseniadores(string especialidad, string nombre, int edad, int salario_base):base(nombre, edad,salario_base)
        {
            Especialidad_cargo = especialidad;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Especialidad: {Especialidad_cargo}");
        }
    }

    public class Desarrolladores : Empleado
    {
        public string Lenguaje_cargo { get; set; }
        public Desarrolladores(string especialidad, string nombre, int edad, int salario_base) : base(nombre, edad, salario_base)
        {
            Lenguaje_cargo = especialidad;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Especialidad: {Lenguaje_cargo}");
        }
    }

    public static Empleado AgregarEmpleado(string especialidad)
    {
        Console.WriteLine("Nombre:");
        string nuevoNombre = Console.ReadLine();
        Console.WriteLine("Edad:");
        string nuevoEdad = Console.ReadLine();
        int.TryParse( nuevoEdad, out int Edad); 

        Console.WriteLine("Salario:");
        string nuevoSalario = Console.ReadLine();
        int.TryParse(nuevoSalario, out int newSalario);

        if (especialidad == "1")
        {
            Console.WriteLine("Especialidad del diseñador:");
            string nuevoEspecialidad = Console.ReadLine();
            return new Diseniadores(nuevoEspecialidad, nuevoNombre, Edad,newSalario);
        }
        else if(especialidad == "2") 
        {
            Console.WriteLine("Lenguaje del programador:");
            string nuevoEspecialidad = Console.ReadLine();
            return new Diseniadores(nuevoEspecialidad, nuevoNombre, Edad, newSalario);
        }
        else
        {
            return null;
        }
    }
    static void Main(string[] args)
    {
        List<Empleado> empleados = new List<Empleado>();

        bool continuar_programa = true;

        while( continuar_programa )
        {
            Console.WriteLine("Bienvenido al programa\n______________________________________\nEscriba:\n1: Diseñadores\n2:Desarrolladores\n3: Finalizar\n______________________________________");
            string opcion_empleado = Console.ReadLine();
            switch ( opcion_empleado )
            {
                case "1":
                    Empleado newObject1 = AgregarEmpleado("1");
                    if (newObject1 != null)
                    {
                        Console.WriteLine("Se ha agregado un nuevo diseñador.\n ______________________________________\n ");
                        empleados.Add( newObject1 );
                    }
                    else
                    {
                        Console.WriteLine("Información no válidad, intente de nuevo\n ______________________________________\n ");
                    }
                    break;

                case "2":
                    Empleado newObject2 = AgregarEmpleado("2");
                    if (newObject2 != null)
                    {
                        Console.WriteLine("Se ha agregado un nuevo programador.\n ______________________________________\n ");
                        empleados.Add(newObject2);
                    }
                    else
                    {
                        Console.WriteLine("Información no válidad, intente de nuevo\n ______________________________________\n  ");
                    }
                    break;

                case "3":
                    continuar_programa = false;
                    break;

            }
        }
        Console.WriteLine("\n------------Lista de empleados----------\n");
        foreach (Empleado item in empleados)
        {
            Console.WriteLine("_______________\n");
            item.MostrarInfo();
            Console.WriteLine("_______________\n");
        }
        Console.WriteLine("\n------------Fin de la lista----------\n");
        Console.WriteLine("Fin del programa");
    }


}
    
