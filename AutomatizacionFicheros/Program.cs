using AutomatizacionFicheros.Data;
using System;
using System.IO;

namespace ProcesadorArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verifica y crea los directorios si no existen.
            FileConfig.DirectoriosConfig();

            // Crea e inicia el observador de archivos
            var fileWatcher = new FileWatcher(FileConfig.directorioEntrada);
            fileWatcher.StartWatching();

            Console.WriteLine("Esperando archivos en la carpeta de entrada. Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}

