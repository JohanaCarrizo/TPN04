using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPN04
{
    class Producto 
    {
        private int _codBarra;
        private string _nombre;
        private double _precio;
        private int _stock;
        public int CodBarra {
            
            get { return _codBarra; }
            set 
            {
                if (value > 0)
                {
                    _codBarra = value;
                }
                else 
                {
                    _codBarra = 0;
                    Console.WriteLine("El codigo de barra no puede ser negativo");
                }
            }
        }
        public string Nombre 
        { 
            get { return _nombre; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nombre = value;
                }
                else 
                {
                    _nombre = "Sin nombre";
                }
            }
        }
        public double Precio 
        { 
            get { return _precio; } 
            set 
            {
                if (value > 0)
                {
                    _precio = value;
                }
                else 
                { 
                    throw new Exception("El precio no puede ser negativo\n"); 
                }
            } 
        }
        public int Stock 
        { 
            get { return _stock; }
            set 
            {
                if (value > 0)
                {
                    _stock = value;
                }
                else 
                {
                    Console.WriteLine("El stock no puede ser negativo\n");
                }
            }
        }

        public Producto(int codBarra, string nombre, double precio, int stock)
        {
            CodBarra = codBarra;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
        public bool aumentarStock(int cantidad) 
        {
            if (cantidad > 0)
            {
                Stock += cantidad;
                return true;
            }
            
            return false;
        }

        public bool disminuirStock(int cantidad) 
        {
            if (cantidad <= _stock)
            {
                Stock -= cantidad;
                return true;
            }
            else 
            {
                return false;
            }
        }

        public string VerInformacion() 
        {
            return $"Codigo Barra: {_codBarra}, \nNombre: {_nombre}, \nPrecio: {_precio}, \nStock: {_stock}\n";
        }

    }
    class Program
    {
        static List<Producto> productos = new List<Producto>
        {
            new Producto(1, "Heladera", 100000, 5),
            new Producto(2, "Pava Electrica", 18000, 10),
            new Producto(3, "Batidora", 25000, 3)
        };
        static void Main(string[] args)
        {

            Console.WriteLine("LISTAR PRODUCTOS: \n");
            productos.ForEach(p => Console.WriteLine(p.VerInformacion()));
            Console.ReadKey();

            Console.WriteLine("INICIAR COMPRA\n");
            Console.WriteLine("Cantidad = 3");
            Console.WriteLine("Producto 1 - Heladera\n");
            ComprarProducto(1, 3);
            Console.ReadKey();

            Console.WriteLine("LISTAR PRODUCTOS: \n");
            productos.ForEach(p => Console.WriteLine(p.VerInformacion()));
            Console.ReadKey();

            Console.WriteLine("INICIAR VENTA\n");
            Console.WriteLine("Cantidad = 5");
            Console.WriteLine("Producto 2 - Pava Electrica\n");
            VenderProducto(2, 5);
            Console.ReadKey();

            Console.WriteLine("LISTAR PRODUCTOS: \n");
            productos.ForEach(p => Console.WriteLine(p.VerInformacion()));
            Console.ReadKey();

            Console.WriteLine("INICIAR VENTA\n");
            Console.WriteLine("Cantidad = 3");
            Console.WriteLine("Producto 3 - Batidora\n");
            VenderProducto(3, 3);
            Console.ReadKey();

            Console.WriteLine("LISTAR PRODUCTOS: \n");
            productos.ForEach(p => Console.WriteLine(p.VerInformacion()));
            Console.ReadKey();

            Console.WriteLine("INICIAR VENTA\n");
            Console.WriteLine("Cantidad = 1");
            Console.WriteLine("Producto 3 - Batidora\n");
            VenderProducto(3, 1);
            Console.ReadKey();
        }

        static public void ComprarProducto(int cod, int cant)
        {
            Producto prodEncontrado = productos.Find(p => p.CodBarra == cod);
            if (prodEncontrado != null)
            {
                if (prodEncontrado.aumentarStock(cant))
                {
                    Console.WriteLine($"Compra exitosa del producto {prodEncontrado.Nombre}. Stock actual: {prodEncontrado.Stock}\n");
                }
                else
                {
                    Console.WriteLine("La cantidad ingresada debe ser positiva\n");
                }   
            }
            else 
            {
                Console.WriteLine("El producto no existe.\n");
            }
        }

        static public void VenderProducto(int cod, int cant) 
        {
            Producto prodEncontrado = productos.Find(p => p.CodBarra == cod);
            if (prodEncontrado != null)
            {
                if (prodEncontrado.disminuirStock(cant))
                {
                    Console.WriteLine($"Venta exitosa del producto {prodEncontrado.Nombre}. Stock actual: {prodEncontrado.Stock}\n");
                }
                else
                {

                    Console.WriteLine($"No hay suficiente stock del producto {prodEncontrado.Nombre} para vender.");
                    //Console.WriteLine($"La cantidad {cant} a vender está dejando en negativo al stock del producto {prodEncontrado.Nombre}");
                }                
            }
            else
            {
                Console.WriteLine("El producto no existe.");
            }
        }
    }
}
