using AutomatizacionFicheros.Data.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace AutomatizacionFicheros.Data
{
    public class ProcessFile
    {

        private Dictionary<string, DateTime> archivosProcesados = new Dictionary<string, DateTime>();
        private readonly TimeSpan tiempoEspera = TimeSpan.FromMinutes(10); // Tiempo de espera mínimo entre procesamientos 
        private readonly TimeSpan tiempoLimpiarDiccionario = TimeSpan.FromHours(1); // Intervalo para limpiar el diccionario 

        public List<string> parametrosBuscados = new List<string>
        {
            "0",
            "1",
            "9",
            "C"
        };

        public async Task ProcesarArchivo(string filePath)
        {
            try
            {
                    using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        string nombreArchivo = Path.GetFileName(filePath);

                        // Verifica si el archivo ya ha sido procesado recientemente. Por si no le ha dado tiempo al programa a moverlo y lo intenta reprocesar
                        if (archivosProcesados.ContainsKey(nombreArchivo) && (DateTime.Now - archivosProcesados[nombreArchivo]) < tiempoEspera)
                        {
                            Console.WriteLine($"El archivo {nombreArchivo} ya ha sido procesado recientemente. Esperando al próximo archivo.");
                            return;
                        }

                        Console.WriteLine($"Procesando el archivo: {nombreArchivo}");

                        // Inicia el procesamiento del archivo
                        int contador = 0;
                        foreach (string linea in File.ReadLines(filePath))
                        {
                            contador++;
                            char tipoRegistro = linea.Length >= 15 ? linea[14] : throw new Exception($"La línea {contador} no posee la extensión esperada o no cumple con el formato requerido.");

                            // Procesa la línea según el tipo de registro
                            if (parametrosBuscados.Contains(tipoRegistro.ToString()))
                            {
                                var creator = ProcesarLinea(tipoRegistro);
                                var register = creator.FactoryMethod(linea);
                                register.GuardarDatos();
                            }
                            else
                            {
                                FileConfig.redireccionLineaMalFormateada(linea, contador, nombreArchivo);
                            }
                        }
                        // Registra el archivo como procesado
                        archivosProcesados[nombreArchivo] = DateTime.Now;
                        fs.Close();
                        Console.WriteLine($"Procesamiento del archivo {nombreArchivo} completado.");
                        //Mover el archivo procesado a otro directorio para evitar reprocesarlo.
                        await FileConfig.moverFicheroProcesado(filePath,nombreArchivo);

                 
                }
                
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se puede procesar el archivo {Path.GetFileName(filePath)} porque está siendo utilizado por otro programa.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar el archivo {Path.GetFileName(filePath)}: {ex.Message}");
            }
        }

        public Creator ProcesarLinea(char tipoRegistro)
        {
            switch (tipoRegistro)
            {
                case '0':
                    return new Registro0Creator();
                case '1':
                    return new Registro1Creator();
                case '9':
                    return new Registro9Creator();
                case 'C':
                    return new RegistroCCreator();

                default:
                    throw new Exception("La línea no contiene el carácter de control esperado");
            }
        }
        public void LimpiarDiccionario(object sender, ElapsedEventArgs e)
        {
            // Vaciar el diccionario
            archivosProcesados.Clear();
            Console.WriteLine("Diccionario de archivos procesados vaciado.");
        }
    }
}
