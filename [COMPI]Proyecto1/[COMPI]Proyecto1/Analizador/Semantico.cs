using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using _COMPI_Proyecto1.Diagrama;
using _COMPI_Proyecto1.Reporte;

namespace _COMPI_Proyecto1.Analizador
{

    class auto
    {
        public String llaves;
    }
    class persona
    {
        String id;
        auto mazda=new auto();
        public auto getauto()
        {
            return mazda;
        }
    }
    class Semantico
    {

        public String[] ales= { "asd","ad"};

        public List<Clase> listaDeClases = new List<Clase>();

        public List<ErrorEjecucion> erroresSemanticos()
        {
            List<ErrorEjecucion> retorno = new List<ErrorEjecucion>();

            persona pe = new persona();

            pe.getauto().llaves = "asdf";


            String al = pe.getauto().llaves;



            foreach (Clase clase in listaDeClases)
            {

                //haciendo la validacion de las clases heredadas
                foreach (metodo heredado in clase.listaDeHeredados)
                {
                    

                    if (!devolverClase(listaDeClases, heredado.nombre))
                    {

                        //public ErrorEjecucion(String ClaseEjecutado, String Error, String ambiente, String tipo)
                        ErrorEjecucion nuevo = new ErrorEjecucion("Semantico", "El metodo  \""+heredado.nombre+"\" no existe en la clase padre", clase.nombre, "Error semantico");
                        retorno.Add(nuevo);
                    }
                    //hay que buscar el metodo en la clase padre
                }

                //clase.imprimir();
            }

            return retorno;

        }

        public String nad(String [] dos)
        {
            return "";
        }
        public void validacionSemantica()
        {
            bool NoOcurrioError = true;

            foreach (Clase clase in listaDeClases)
            {
                
                //haciendo la validacion de las clases heredadas
                foreach(metodo heredado in clase.listaDeHeredados)
                {

                    if (devolverClase(listaDeClases, heredado.nombre))
                    {
                        Console.WriteLine("Analisis semantico exitso");
                        NoOcurrioError = true;
                    }
                    else
                    {
                        NoOcurrioError = false;
                        Console.WriteLine("ERROR en analisis semantico :(");
                    }
                    //hay que buscar el metodo en la clase padre
                }
               
                //clase.imprimir();
            }
            if (NoOcurrioError)
            {
                foreach (Clase clas in listaDeClases)
                {
                    clas.imprimir();
                }

            }
        }
        public bool devolverClase(List<Clase> lstClase, string nombre)
        {
            bool retorno = false;
            foreach (Clase clase in lstClase)
            {
                foreach (metodo metodo in clase.listaDeMetodos)
                {
                    if (metodo.nombre == nombre)
                    {
                        return true;
                    }
                }
            }
            return retorno; 
        }
        public void S4(ParseTreeNode arbol)
        {

            //inicializo la lista de clases
            listaDeClases = new List<Clase>();


            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {                
                    CLASES(arbol.ChildNodes[0]);

                validacionSemantica();
            }
        }
        public void CLASES(ParseTreeNode arbol)//aquí esta la lista de clases.
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 2)
                {
                    Clase clase = new Clase();
                    CLASE(arbol.ChildNodes[0], clase);
                    listaDeClases.Add(clase);

                    CLASES(arbol.ChildNodes[1]);

                }
                else if (arbol.ChildNodes.Count == 1)
                {
                    Clase clase = new Clase();
                    CLASE(arbol.ChildNodes[0], clase);
                    listaDeClases.Add(clase);
                }
            }
        }
        public void CLASE(ParseTreeNode arbol, Clase clase)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {


                clase.acceso = VISIBILIDAD(arbol.ChildNodes[0]);
                clase.nombre = arbol.ChildNodes[2].Token.Text;
                //t_class
                //id
                clase.padre = EXTENDER(arbol.ChildNodes[3]);


                CP_CLASE(arbol.ChildNodes[5], clase);
            }
            
        }
        public string  TIPO(ParseTreeNode arbol)
        {
            string retorno = "";
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                retorno = arbol.ChildNodes[0].Token.Text;
                //Console.WriteLine(tipo);
                // t_int
                //| t_String
                //| t_boolean
                //| t_double
                //| t_char
                //| id;
            }
            return retorno;
        }
        public string EXTENDER(ParseTreeNode arbol)
        {
            string padre = "";
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                padre = arbol.ChildNodes[1].Token.Text;
                //t_extends + id
                //| Empty;
            }
            return padre;

        }
        public string VISIBILIDAD(ParseTreeNode arbol)
        {
            string retorno = "";
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                retorno = arbol.ChildNodes[0].Token.Text;
                //  t_public
                //| t_private
                //| t_protected
                //| Empty;
            }
            return retorno;
        }
        public string PARAMETROS(ParseTreeNode arbol)
        {
            string retorno = "";
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    retorno = retorno + PARAMETROS(arbol.ChildNodes[0]);

                    retorno = retorno  + ", ";

                    retorno = retorno +  PARAMETROS_P(arbol.ChildNodes[2]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                   retorno=retorno+  PARAMETROS_P(arbol.ChildNodes[0]);
                }
            }
            return retorno;
        }
        public string PARAMETROS_P(ParseTreeNode arbol)
        {
            string retorno = "";
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                string tipo = "";
                tipo=  TIPO(arbol.ChildNodes[0]);
                retorno= retorno+ tipo+" "+ arbol.ChildNodes[1].Token.Text;
               
                //id
            }
            return retorno;
        }
        public void CONSTRUCTOR(ParseTreeNode arbol, metodo constructor)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
               constructor.acceso= VISIBILIDAD(arbol.ChildNodes[0]);
                constructor.nombre = arbol.ChildNodes[1].Token.Text;
                //id
             constructor.parametros=   PARAMETROS(arbol.ChildNodes[3]);
                CUERPO(arbol.ChildNodes[6]);
            }
        }
        public void CP_CLASE(ParseTreeNode arbol, Clase clase)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count==2)
                {
                    CP_CLASE(arbol.ChildNodes[0], clase);
                    CUERPO_CLASE(arbol.ChildNodes[1], clase);

                }else if (arbol.ChildNodes.Count == 1)
                {
                    CUERPO_CLASE(arbol.ChildNodes[0], clase);
                }

            }
        }
        public void CUERPO_CLASE(ParseTreeNode arbol, Clase clase)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 2)//aquí vienen los atributos
                {
                    string visibilidad = "";

                    visibilidad=VISIBILIDAD(arbol.ChildNodes[0]);
                    DECLARAR_VARIABLE(arbol.ChildNodes[1], visibilidad, clase);


                }else if (arbol.ChildNodes.Count == 1)
                {
                    //arbol.ChildNodes[1].ToString()== "VALOR"
                    string elemento = arbol.ChildNodes[0].ToString();
                    if (elemento == "CONSTRUCTOR")
                    {
                        metodo constructor = new metodo();
                        CONSTRUCTOR(arbol.ChildNodes[0], constructor);
                        clase.listaDeMetodos.Add(constructor);
                    }else if (elemento=="PROCEDIMIENTOS")
                    {
                        metodo metodo = new metodo();
                       metodo=  PROCEDIMIENTOS(arbol.ChildNodes[0]);
                        clase.listaDeMetodos.Add(metodo);

                    }else if (elemento == "SOBRESCRITURA")
                    {
                        SOBRESCRITURA(arbol.ChildNodes[0], clase);
                    }
                }
            }
        }
        public metodo FUNCION(ParseTreeNode arbol)
        {
            metodo procedimiento = new metodo();
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                 procedimiento.acceso=VISIBILIDAD(arbol.ChildNodes[0]);
                procedimiento.tipo = TIPO(arbol.ChildNodes[1]);

                //id
                procedimiento.nombre = arbol.ChildNodes[2].Token.Text;
                procedimiento.parametros=PARAMETROS(arbol.ChildNodes[4]);
                CUERPO(arbol.ChildNodes[7]);
               
            }
            return procedimiento;
        }
        public void RETORNO(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
        public metodo METODO(ParseTreeNode arbol)
        {
            metodo procedimiento = new metodo();
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                 procedimiento.acceso = VISIBILIDAD(arbol.ChildNodes[0]);
                procedimiento.tipo = "void";
                procedimiento.nombre = arbol.ChildNodes[2].Token.Text;
                //id
                procedimiento.parametros=PARAMETROS(arbol.ChildNodes[4]);
                CUERPO(arbol.ChildNodes[7]);
                
            }
            return procedimiento;
        }
        public void SOBRESCRITURA(ParseTreeNode arbol, Clase clase)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                metodo heredado = new metodo();
               heredado=  PROCEDIMIENTOS(arbol.ChildNodes[2]);
                clase.listaDeHeredados.Add(heredado);
            }
        }
        public metodo PROCEDIMIENTOS(ParseTreeNode arbol)
        {
            metodo procedimiento = new metodo(); 

            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes[0].ToString() == "METODO")
                {
                    procedimiento= METODO(arbol.ChildNodes[0]);
                }
                else if (arbol.ChildNodes[0].ToString()=="FUNCION")
                {
                    procedimiento = FUNCION(arbol.ChildNodes[0]);
                }
            }
            return procedimiento;
        }
        public void CUERPO(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 2)
                {
                    CUERPO(arbol.ChildNodes[0]);
                    CUERPOP(arbol.ChildNodes[1]);
                }
            }
        }
        public void CUERPOP(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                string elemento = arbol.ChildNodes[0].ToString();
                ParseTreeNode hijo = arbol.ChildNodes[0];
                if (elemento == "DECLARAR_VARIABLE")
                {
                    //DECLARAR_VARIABLE(hijo);
                }
                else if (elemento == "ASIGNAR_VALOR")
                {
                    ASGINAR_VALOR(hijo);
                }
                else if (elemento == "SENTENCIAS")
                {
                    SENTENCIAS(hijo);
                }else if (elemento == "USAR_METODO")
                {
                    USAR_METODO(hijo);
                }else if (elemento == "USAR_VARIABLE")
                {
                    USAR_VARIABLE(hijo);
                }
            }
        }
        public void DECLARAR_VARIABLE(ParseTreeNode arbol, string visibilidad, Clase clase)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                atributo atri = new atributo();
               
                string tipo = "";
               tipo=  TIPO(arbol.ChildNodes[0]);


                atri.tipo = tipo;
                atri.acceso = visibilidad;
                try
                {
                    IDP(arbol.ChildNodes[1], atri, clase);
                    VAL(arbol.ChildNodes[2]);
                }
                catch (Exception)
                {


                }
                
            }
        }
        public void IDP(ParseTreeNode arbol, atributo atri, Clase clase)
        {
            

            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                   

                    IDP(arbol.ChildNodes[0], atri, clase);

                    atributo atri2 = new atributo();
                    atri2 = atri;

                    atri2.nombre = arbol.ChildNodes[2].Token.Text;
                    clase.listaDeAtributos.Add(atri2);
                   


                    //id

                }
                else if (arbol.ChildNodes.Count == 1)
                {
                    atributo atri2 = new atributo();
                    atri2 = atri;
                    atri2.nombre = arbol.ChildNodes[0].Token.Text;
                    clase.listaDeAtributos.Add(atri2);
                   
                    //id
                }
            }
        }

        public void VAL(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                PARTE2(arbol.ChildNodes[1]);
            }
        }
        public void PARTE2(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 2)
                {
                    //new
                    USAR_METODO(arbol.ChildNodes[1]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                    VALOR(arbol.ChildNodes[0]);
                }
            }

        }
        public void VALOR(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                string elemento = arbol.ChildNodes[0].ToString();

                if (elemento == "USAR_METODO")
                {
                    USAR_METODO(arbol.ChildNodes[0]);
                }else if (elemento == "USAR_VARIABLE")
                {
                    USAR_VARIABLE(arbol.ChildNodes[0]);
                }else if (elemento == "E")
                {
                    E(arbol.ChildNodes[0]);
                }else if (elemento == "RELACIONAL")
                {
                    RELACIONAL(arbol.ChildNodes[0]);
                }else if (elemento == "LOGICO")
                {
                    LOGICO(arbol.ChildNodes[0]);
                }
                else
                {
                    //cadena
                    //caracter dato
                    //boolean dato
                }
            }
        }
        public void USAR_METODO(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    
                    USAR_METODOP(arbol.ChildNodes[2]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                    USAR_METODOP(arbol.ChildNodes[0]);
                }
            }
        }
        public void USAR_METODOP(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    //id
                    USAR_METODOP(arbol.ChildNodes[2]);
                }else if (arbol.ChildNodes.Count == 4)
                {
                    //id
                    LISTA_DE_VALORES(arbol.ChildNodes[2]);

                }
            }
        }
        public void LISTA_DE_VALORES(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    LISTA_DE_VALORES(arbol.ChildNodes[0]);
                    VALOR(arbol.ChildNodes[2]);
                }
                else if (arbol.ChildNodes.Count == 1)
                {
                    VALOR(arbol.ChildNodes[0]);
                }
               
            }
        }
        public void USAR_VARIABLE(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {

                    USAR_VARIABLEP(arbol.ChildNodes[2]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                    USAR_VARIABLEP(arbol.ChildNodes[0]);
                }
            }
        }
        public void USAR_VARIABLEP(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    //id
                USAR_VARIABLEP(arbol.ChildNodes[2]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                    //id
                }
                
            }
        }
        public void ASGINAR_VALOR(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes[2].ToString() == "VALOR")
                {
                    USAR_VARIABLE(arbol.ChildNodes[0]);
                    VALOR(arbol.ChildNodes[2]);
                }
                else
                {
                    USAR_VARIABLE(arbol.ChildNodes[0]);
                    ///NO se sabe diferenciar entre ++ y --
                }

            }
        }
        public void LOGICO(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (arbol.ChildNodes.Count == 3)
                {
                    if (arbol.ChildNodes[1].ToString() == "LOGICO")
                    {
                        LOGICO(arbol.ChildNodes[1]);
                    }
                    else
                    {
                        if (arbol.ChildNodes[0].ToString() == "||(Key symbol)")
                        {
                            VALOR(arbol.ChildNodes[0]);
                            // OR
                            VALOR(arbol.ChildNodes[0]);
                        }
                        else//&& AND
                        {
                            VALOR(arbol.ChildNodes[0]);
                            // AND
                            VALOR(arbol.ChildNodes[0]);
                        }
                    }
                }else if (arbol.ChildNodes.Count == 2)
                {
                    //NOT
                    VALOR(arbol.ChildNodes[1]);
                }else if (arbol.ChildNodes.Count == 1)
                {
                    if (arbol.ChildNodes[0].ToString() == "VALOR")
                    {
                        VALOR(arbol.ChildNodes[0]);
                    }else if (arbol.ChildNodes[0].ToString() == "LOGICO")
                    {
                        LOGICO(arbol.ChildNodes[0]);
                    }
                }
            }
        }
        public void CONDICION(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {
                string elemento = arbol.ChildNodes[0].ToString();
                if (elemento=="RELACIONAL")
                {
                    RELACIONAL(arbol.ChildNodes[0]);
                }else if (elemento == "LOGICO")
                {
                    LOGICO(arbol.ChildNodes[0]);
                }else if (elemento == "USAR_METODO")
                {
                    USAR_METODO(arbol.ChildNodes[0]);
                }else if (elemento == "USAR_VARIABLE")
                {
                    USAR_VARIABLE(arbol.ChildNodes[0]);
                }
                else
                {
                    //boolean dato
                }
            }
        }
        public void RELACIONAL(ParseTreeNode arbol)
        {
            
        }
        public void E(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
        public void SENTENCIAS(ParseTreeNode arbol)
        {
            if (arbol.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
     


    
    }
}
