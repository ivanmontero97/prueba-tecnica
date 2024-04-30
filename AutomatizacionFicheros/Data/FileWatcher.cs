using System;
using System.IO;
using System.Threading;

namespace AutomatizacionFicheros.Data
{
    public class FileWatcher
    {
        private readonly string folderPath;
        private readonly ProcessFile processFile;

        public FileWatcher(string folderPath)
        {
            this.folderPath = folderPath;
            this.processFile = new ProcessFile();
        }

        public void StartWatching()
        {
            // Inicia un hilo para la observación continua de la carpeta
            Thread fileCheckThread = new Thread(CheckFilesAvailability);
            fileCheckThread.IsBackground = true;
            fileCheckThread.Start();
        }

        private void CheckFilesAvailability()
        {
            while (true)
            {
                // Obtener la lista de archivos en la carpeta de entrada
                string[] files = Directory.GetFiles(folderPath);

                // Procesa cada archivo encontrado
                foreach (var file in files)
                {
                    try
                    {
                        // Intenta procesar el archivo
                        processFile.ProcesarArchivo(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al procesar el archivo {file}: {ex.Message}");
                    }
                }

                // Esperar antes de volver a verificar la disponibilidad de los archivos
                Thread.Sleep(5000); // Esperar 5 segundos antes de volver a verificar
            }
        }
    }
}
