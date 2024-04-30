using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AutomatizacionFicheros.Data
{
    public static class FileConfig
    {
        public static string directorioEntrada  {get; set; } = Environment.GetEnvironmentVariable("DIRECTORIO_ENTRADA"); //Las variables de entorno deben tener este nombre
        public static string directorioSalida { get; set; }= Environment.GetEnvironmentVariable("DIRECTORIO_SALIDA");
        public static string errorFilePath { get; set; } = Path.Combine(FileConfig.directorioSalida, "lineaMalProcesadas.txt");
        //const string posibleNuevaCarpeta = "nombreCarpeta"

        public static async Task VerificarDirectorioEntradaYSalida(string rutaDirectorio)
        {
            if (!Directory.Exists(rutaDirectorio))
            {
                try
                {
                     Directory.CreateDirectory(rutaDirectorio);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al crear el directorio {rutaDirectorio}: {ex.Message}");
                }
            }
        }


        public static async Task DirectoriosConfig()
        {
            if (string.IsNullOrEmpty(directorioEntrada) || string.IsNullOrEmpty(directorioSalida))
            {
                Console.WriteLine("Por favor, defina las variables de entorno con las rutas de los directorios de entrada y salida. Los nombres de las variables deberán ser: DIRECTORIO_ENTRADA y DIRECTORIO_SALIDA.");
                return; 
            }
            else if (!Directory.Exists(directorioEntrada) || !Directory.Exists(directorioSalida))
            {
                // Se crearan los directorios si existe una ruta en el path de la variable de entorno
                await VerificarDirectorioEntradaYSalida(directorioEntrada);
                await VerificarDirectorioEntradaYSalida(directorioSalida);
            }

        }

        public static async Task moverFicheroProcesado(string filePath,string nombreArchivo)
        {
            string directorioProcesados = Path.Combine(Path.GetDirectoryName(filePath), "Procesados");
            if (!Directory.Exists(directorioProcesados))
                Directory.CreateDirectory(directorioProcesados);
            string nuevoPath = Path.Combine(directorioProcesados, nombreArchivo);
            File.Move(filePath, nuevoPath);
            Console.WriteLine($"El archivo {nombreArchivo} ha sido movido a {directorioProcesados}.");

        }
        public static void redireccionLineaMalFormateada(string linea,int contador,string archivo)
        {
            using (StreamWriter writer = new StreamWriter(errorFilePath, true))
            {
                writer.WriteLine(linea);
            }
            Console.WriteLine($"La linea {contador}, del fichero {archivo} no contiene el carácter de control buscados y se ha añadido al fichero {errorFilePath}");
        }
    }
}
