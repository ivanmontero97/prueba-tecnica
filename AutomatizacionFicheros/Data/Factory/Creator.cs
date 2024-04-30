using AutomatizacionFicheros.Data.Interfaces;
using AutomatizacionFicheros.DTO.TiposRegistro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomatizacionFicheros.Data.Factory
{
    public abstract class Creator
    {
        public abstract IExcelWritter FactoryMethod(string linea);
        public virtual string ObtenerValorSeguro(string linea, int indice)
        {
            return indice >= 0 && indice < linea.Length ? linea[indice].ToString() : "";
        }

        public virtual string ObtenerSubstringSeguro(string linea, int inicio, int longitud)
        {
            return inicio >= 0 && inicio + longitud <= linea.Length ? linea.Substring(inicio, longitud) : "";
        }

    }
}
