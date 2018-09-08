using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using _COMPI_Proyecto1.Reporte;
namespace _COMPI_Proyecto1.Analizador
{
   public class grammar : Grammar
    {
        private List<ErrorEjecucion> lista = new List<ErrorEjecucion>();//Lista de errores
        public grammar() : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {


            #region ER
            //////////////////////////////////////////
            //------------COMENTARIOS-----------------

            CommentTerminal comentariobloque = new CommentTerminal("comentariobloque", "$#", "#$");
            CommentTerminal comentariolinea = new CommentTerminal("comentariolinea", "$$", "\n", "\r\n");
            /*Se ignoran los terminales solo se reconoce*/
            NonGrammarTerminals.Add(comentariobloque);
            NonGrammarTerminals.Add(comentariolinea);

            //////////////////////////////////////////
            //------------OTROS-----------------
            RegexBasedTerminal valBoolean = new RegexBasedTerminal("booleanDato", "(True|true|False|false)");

            StringLiteral valCaracter = new StringLiteral("caracter", "\'");
            StringLiteral valCadena = new StringLiteral("cadena", "\"");
            RegexBasedTerminal valNumero = new RegexBasedTerminal("numeroValor", "[0-9]+");
            RegexBasedTerminal valDecimal = new RegexBasedTerminal("decimalValor", "[0-9]+(.)[0-9]+");

            IdentifierTerminal valId = new IdentifierTerminal("id");

            #endregion

            #region Terminales
            /*
            =============================
             Simbolos
            =============================
             */


            var sMas = ToTerm("+");
            var sMenos = ToTerm("-");
            var sPor = ToTerm("*");
            var sDiv = ToTerm("/");

            //
            var sAbreParent = ToTerm("(");
            var sCierraParent = ToTerm(")");

            var sAbreLlave = ToTerm("{");
            var sCierraLlave = ToTerm("}");

            var sAbreCorchete = ToTerm("[");
            var sCierraCorchete = ToTerm("]");
            var sPunto = ToTerm(".");
            var sPuntoComa = ToTerm(";");

            /*
            =============================
             Palabras reservadas
            =============================
             */
            var tImport = ToTerm("importar");
            var tClase = ToTerm("clase");
            var tExtender = ToTerm("extender");
            var tPadre = ToTerm("padre");

            //tipos
            var tEntero = ToTerm("entero");
            var tCadena = ToTerm("cadena");
            var tDecimal = ToTerm("decimal");
            var tBooleano = ToTerm("booleano");
            var tfecha = ToTerm("fecha");
            var tHora = ToTerm("hora");
            var tFechaHora = ToTerm("fechahora");
            var tPregunta = ToTerm("pregunta");
            var tFormulario = ToTerm("formulario");
            var tRespuesta = ToTerm("respuesta");

            //visibilidad
            var tPublico = ToTerm("publico");
            var tPrivado = ToTerm("privado");
            var tProtegido = ToTerm("protegido");


            #endregion
            #region NoTerminales

            NonTerminal S = new NonTerminal("S"); 
            NonTerminal IMPORT = new NonTerminal("IMPORT");
            NonTerminal LST_IMPORT = new NonTerminal("LST_IMPORT");
            NonTerminal LST_CLASE = new NonTerminal("LST_CLASE");
            NonTerminal CLASE = new NonTerminal("CLASE");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal EXTENDER = new NonTerminal("EXTENDER");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal LST_PARAMETROS = new NonTerminal("LST_PARAMETROS");
            NonTerminal PARAMETRO = new NonTerminal("PARAMETRO");
            NonTerminal LST_VAL = new NonTerminal("CP_CLASE");
            NonTerminal CP_CLASE = new NonTerminal("CP_CLASE");
            NonTerminal CUERPO_CLASE = new NonTerminal("CUERPO_CLASE");
            NonTerminal METODO = new NonTerminal("METODO");
            NonTerminal SOBRESCRITURA = new NonTerminal("SOBRESCRITURA");
            NonTerminal MAIN = new NonTerminal("MAIN");
            NonTerminal CONSTRUCTOR = new NonTerminal("CONSTRUCTOR");
            NonTerminal FORMULARIO = new NonTerminal("FORMULARIO");
            NonTerminal PROCEDIMIENTOS_FORMULARIO = new NonTerminal("PROCEDIMIENTOS_FORMULARIO");
            NonTerminal DECLARAR_VARIABLE_GLOBAL = new NonTerminal("DECLARAR_VARIABLE_GLOBAL");
            NonTerminal DECLARAR_VARIABLE = new NonTerminal("DECLARAR_VARIABLE");
            NonTerminal VAL = new NonTerminal("VAL");
            NonTerminal LST_LLAVES_VAL = new NonTerminal("LST_LLAVES_VAL");
            NonTerminal LLAVES_VAL_P = new NonTerminal("LLAVES_VAL_P");
            NonTerminal VAR_ARREGLO = new NonTerminal("VAR_ARREGLO");
            NonTerminal LST_CORCHETES = new NonTerminal("LST_CORCHETES");
            NonTerminal LST_CORCHETES_VAL = new NonTerminal("LST_CORCHETES_VAL");
            NonTerminal ASIGNAR_VALOR = new NonTerminal("ASIGNAR_VALOR");
            NonTerminal USAR_VARIABLE = new NonTerminal("USAR_VARIABLE");
            NonTerminal USAR_VARIABLEP = new NonTerminal("USAR_VARIABLEP");
            NonTerminal USAR_METODO = new NonTerminal("USAR_METODO");
            NonTerminal USAR_METODOP = new NonTerminal("USAR_METODOP");
            NonTerminal LLAMADA_FORMULARIO = new NonTerminal("LLAMADA_FORMULARIO");
            NonTerminal LST_ID = new NonTerminal("LST_ID");
            NonTerminal LST_CUERPO = new NonTerminal("LST_CUERPO");



            #endregion
            
            #region Gramatica
 

            S.Rule = LST_IMPORT + LST_CLASE
                | LST_CLASE;

            LST_IMPORT.Rule = MakeStarRule(LST_IMPORT, IMPORT);

            IMPORT.Rule = tImport + sAbreParent + valId + sPunto + valId + sCierraParent + sPuntoComa;

            LST_CLASE.Rule = MakeStarRule(LST_CLASE, CLASE);

            CLASE.Rule = tClase + valId + VISIBILIDAD + EXTENDER + sAbreLlave + CP_CLASE + sCierraLlave;


            TIPO.Rule = tEntero
                | tCadena
                | tBooleano
                | tDecimal
                | tHora
                | tfecha
                | tFechaHora
                | valId
                | tPregunta
                | tFormulario
                | tRespuesta;

            EXTENDER.Rule = tPadre + valId
                | Empty;

            VISIBILIDAD.Rule = tPublico
                | tPrivado
                | tProtegido
                | Empty;

            //------------------+
            // Parametros
            LST_PARAMETROS.Rule = MakeStarRule(LST_PARAMETROS, PARAMETRO);

            PARAMETRO.Rule = TIPO + valId;



            CP_CLASE.Rule = MakeStarRule(CP_CLASE,CUERPO_CLASE) ;

            CUERPO_CLASE.Rule = CONSTRUCTOR
                // | DECLARAR_VARIABLE_GLOBAL
                //| METODO
                //| SOBRESCRITURA
                //| MAIN;
                ;

            CONSTRUCTOR.Rule = VISIBILIDAD + valId + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;


            LST_CUERPO.Rule = Empty;

             
            this.Root = S;
            #endregion
        }


        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;
            String tipo;
            int fila;
            int columna;

            if (error.Contains("Invalid character"))
            {
                tipo = "Error Lexico";
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido " + division[0];
            }
            else
                tipo = "Error Sintactico";

            fila = context.Source.Location.Line;
            columna = context.Source.Location.Column;
            ErrorEjecucion nuevo = new ErrorEjecucion(tipo, error, fila, columna, "sintactico");
            this.lista.Add(nuevo);
            Console.WriteLine("--------------Hay un error---------- ");
            Console.WriteLine("Tipo: " + nuevo.tipo);
            Console.WriteLine("Error:" + error);
            Console.WriteLine("Columna:" + columna);
            Console.WriteLine("fila:" + fila);
            base.ReportParseError(context);
        }

    }
}
