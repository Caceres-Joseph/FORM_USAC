using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _IMPORT : nodoModelo
    {
        public _IMPORT(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar()
        {
            if (hayErrores())
                return; 
            ejecutarHijos(); 
            importandoArchivos();

            

        }

        public void importandoArchivos()
        {
            if (extensionAceptable(lstAtributos.getToken(4)))
                cargarArchivo();
        }


        public void cargarArchivo()
        {


            String nombreArchivo = lstAtributos.getToken(2).val + "." + lstAtributos.getToken(4).val;
            String rutaArchivoImport = tablaSimbolos.getRutaProyecto()+"\\"+nombreArchivo;
            //println("importando " + rutaArchivoImport);
            try
            {
                string text = System.IO.File.ReadAllText(@rutaArchivoImport);
               // println(text); 
                tablaSimbolos.iniciarAnalisis(text, nombreArchivo);
                 
            }
            catch (FileNotFoundException e)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ecuentra el archivo:" + lstAtributos.getToken(2).val + " en la carpeta del proyecto", lstAtributos.getToken(2));
            }
            
            
            
        }

        public Boolean extensionAceptable(token extension)
        {
            Boolean retorno = false;

            if (extension.val.ToLower().Equals("xform"))
            {
                retorno = true;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSyntax("No se pueden importar archivos de tipo:"+extension.val, extension);
                retorno = false;

            }
            return retorno;
             
        }


    }
}
