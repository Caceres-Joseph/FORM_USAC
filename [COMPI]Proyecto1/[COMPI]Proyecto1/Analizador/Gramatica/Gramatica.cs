using _COMPI_Proyecto1.Analizador.Tablas;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Gramatica
{
      class gramatica : Grammar
    {
        tablaErrores tablaErrores ;
        public String nombreArchivo;
        public gramatica(tablaErrores tabla, String archivo) : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {
            this.tablaErrores = tabla;
            this.nombreArchivo = archivo;

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
            RegexBasedTerminal valBoolean = new RegexBasedTerminal("valBoolean", "(false|true|verdadero|falso)");

            StringLiteral valCaracter = new StringLiteral("valCaracter", "\'");
            StringLiteral valCadena = new StringLiteral("valCadena", "\"");
            var valCadena2 = new StringLiteral("valCadena2", "‘(.)*’");


            //RegexBasedTerminal valNumero = new RegexBasedTerminal("numeroValor", "[0-9]+");
            NumberLiteral valNumero = new NumberLiteral("valNumero");
            var valDecimal = new RegexBasedTerminal("valDecimal", "[0-9]+\\.[0-9]+");

            IdentifierTerminal valId = new IdentifierTerminal("valId");

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
            var sPot = ToTerm("^");
            var sMod = ToTerm("%");

            var sIgualacion = ToTerm("==");
            var sDiferenciacion = ToTerm("!=");
            var sMenorQue = ToTerm("<");
            var sMayorQue = ToTerm(">");
            var sMenorIgualQue = ToTerm("<=");
            var sMayorIgualQue = ToTerm(">=");
            var sAnd = ToTerm("&&");
            var sOr = ToTerm("||");
            var sNot = ToTerm("!");


            //
            var sAbreParent = ToTerm("(");
            var sCierraParent = ToTerm(")");

            var sAbreLlave = ToTerm("{");
            var sCierraLlave = ToTerm("}");

            var sAbreCorchete = ToTerm("[");
            var sCierraCorchete = ToTerm("]");
            var sPunto = ToTerm(".");
            var sComa = ToTerm(",");
            var sPuntoComa = ToTerm(";");
            var sArroba = ToTerm("@");
            var sIgual = ToTerm("=");
            /*
            =============================
             Palabras reservadas
            =============================
             */
            var tImport = ToTerm("importar");
            var tClase = ToTerm("clase");
            var tExtender = ToTerm("extender");
            var tPadre = ToTerm("padre");
            var tPrincipal = ToTerm("principal");
            var tOverride = ToTerm("sobrescribir");
            var tNuevo = ToTerm("nuevo");
            var tNulo = ToTerm("nulo");
            var tVacio = ToTerm("vacio");
            var tEste = ToTerm("este");
 

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
            NonTerminal LST_VAL = new NonTerminal("LST_VAL");
            NonTerminal CP_CLASE = new NonTerminal("CP_CLASE");
            NonTerminal CUERPO_CLASE = new NonTerminal("CUERPO_CLASE");
            NonTerminal METODO = new NonTerminal("METODO");
            NonTerminal SOBRESCRITURA = new NonTerminal("SOBRESCRITURA");
            NonTerminal MAIN = new NonTerminal("MAIN");
            NonTerminal CONSTRUCTOR = new NonTerminal("CONSTRUCTOR");
            NonTerminal FORMULARIO = new NonTerminal("FORMULARIO");
            NonTerminal PROCEDIMIENTOS_FORMULARIO = new NonTerminal("PROCEDIMIENTOS_FORMULARIO");
            NonTerminal DECLARAR_VARIABLE_GLOBAL = new NonTerminal("DECLARAR_VARIABLE_GLOBAL");
            NonTerminal DECLARAR_VARIABLE_SINVISIBI = new NonTerminal("DECLARAR_VARIABLE_SINVISIBI");
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


            NonTerminal CUERPO = new NonTerminal("CUERPO");
            NonTerminal RETORNA = new NonTerminal("RETORNA");
            NonTerminal ROMPER = new NonTerminal("ROMPER");
            NonTerminal CONTINUAR = new NonTerminal("CONTINUAR");
            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal IF = new NonTerminal("IF");
            NonTerminal SINO_SI = new NonTerminal("SINO_SI");
            NonTerminal SINO = new NonTerminal("SINO");
            NonTerminal SI_SIMPLIFICADO = new NonTerminal("SI_SIMPLIFICADO");
            NonTerminal CASE = new NonTerminal("CASE");
            NonTerminal CUERPO_CASE = new NonTerminal("CUERPO_CASE");
            NonTerminal WHILE = new NonTerminal("WHILE");
            NonTerminal DOWHILE = new NonTerminal("DOWHILE");
            NonTerminal REPETIR = new NonTerminal("REPETIR");
            NonTerminal FOR = new NonTerminal("FOR");
            NonTerminal FUNCIONES_NATIVAS = new NonTerminal("FUNCIONES_NATIVAS");
            NonTerminal IMPRIMIR = new NonTerminal("IMPRIMIR");
            NonTerminal MENSAJE = new NonTerminal("MENSAJE");
            NonTerminal OPE_TIPO = new NonTerminal("OPE_TIPO");

            NonTerminal OPE_ARITME = new NonTerminal("OPE_ARITME");
            NonTerminal TO_CADENA = new NonTerminal("TO_CADENA");
            NonTerminal SUB_CAD = new NonTerminal("SUB_CAD");
            NonTerminal POS_CAD = new NonTerminal("POS_CAD");
            NonTerminal TO_BOOLEAN = new NonTerminal("TO_BOOLEAN");
            NonTerminal TO_ENTERO = new NonTerminal("TO_ENTERO");
            NonTerminal HOY = new NonTerminal("HOY");
            NonTerminal AHORA = new NonTerminal("AHORA");
            NonTerminal TO_FECHA = new NonTerminal("TO_FECHA");
            NonTerminal TO_HORA = new NonTerminal("TO_HORA");
            NonTerminal TO_FECHAHORA = new NonTerminal("TO_FECHAHORA");
            NonTerminal TAM = new NonTerminal("TAM");
            NonTerminal RANDOM = new NonTerminal("RANDOM");
            NonTerminal MIN = new NonTerminal("MIN");
            NonTerminal MAX = new NonTerminal("MAX");
            NonTerminal POTENCIA = new NonTerminal("POTENCIA");
            NonTerminal LOGARITMO = new NonTerminal("LOGARITMO");
            NonTerminal LOGARITMO10 = new NonTerminal("LOGARITMO10");
            NonTerminal ABSOLUTO = new NonTerminal("ABSOLUTO");

            NonTerminal USAR_METO_VAR = new NonTerminal("USAR_METO_VAR");
            NonTerminal SENO = new NonTerminal("SENO");
            NonTerminal COSENO = new NonTerminal("COSENO");
            NonTerminal TANGENTE = new NonTerminal("TANGENTE");
            NonTerminal RAIZ = new NonTerminal("RAIZ");
            NonTerminal PI = new NonTerminal("PI");
            NonTerminal FUNC_MULTIMEDIA = new NonTerminal("FUNC_MULTIMEDIA");
            NonTerminal IMAGEN = new NonTerminal("IMAGEN");
            NonTerminal AUDIO = new NonTerminal("AUDIO");
            NonTerminal VIDEO = new NonTerminal("VIDEO");
            NonTerminal VALOR = new NonTerminal("VALOR");
            NonTerminal E = new NonTerminal("E");
            NonTerminal F = new NonTerminal("F");

            NonTerminal PAR_CORCHETES_VACIOS = new NonTerminal("PAR_CORCHETES_VACIOS"); 



            #endregion

            #region Gramatica


            S.Rule = LST_IMPORT + LST_CLASE
                | LST_CLASE;


            LST_IMPORT.Rule = MakeStarRule(LST_IMPORT, IMPORT);
               

            IMPORT.Rule = tImport + sAbreParent + valId + sPunto + valId + sCierraParent + sPuntoComa
                 | SyntaxError; 

            LST_CLASE.Rule = MakeStarRule(LST_CLASE, CLASE);

            CLASE.Rule = tClase + valId + EXTENDER + sAbreLlave + CP_CLASE + sCierraLlave
                | tClase + valId + VISIBILIDAD + EXTENDER + sAbreLlave + CP_CLASE + sCierraLlave;


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
                | tRespuesta
                | tVacio //Para el metodo void, tengo que validar que no lo acepten las variables
                ;

            EXTENDER.Rule = tPadre + valId
                | Empty;

            VISIBILIDAD.Rule = tPublico
                | tPrivado
                | tProtegido;

            //------------------+
            // Parametros
            LST_PARAMETROS.Rule = MakeStarRule(LST_PARAMETROS, sComa, PARAMETRO);

            PARAMETRO.Rule = TIPO + VAR_ARREGLO;

            LST_VAL.Rule = MakeStarRule(LST_VAL, sComa, VALOR);
            //------------------+
            //   Cuerpo de la clase
            CP_CLASE.Rule = MakeStarRule(CP_CLASE, CUERPO_CLASE);

            CUERPO_CLASE.Rule = CONSTRUCTOR
                | DECLARAR_VARIABLE_GLOBAL + sPuntoComa
                | METODO
                //| SOBRESCRITURA
                | MAIN
                | SyntaxError;
            ;

            //-----------------+
            // Funciones/Metodos

            METODO.Rule = VISIBILIDAD + TIPO + VAR_ARREGLO + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
                | TIPO + VAR_ARREGLO + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave; //metodo void

            //SOBRESCRITURA.Rule = sArroba + tOverride + METODO;

            MAIN.Rule = tPrincipal + sAbreParent + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

            CONSTRUCTOR.Rule = valId + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

            //------------------+
            // Declarar variable

            DECLARAR_VARIABLE_GLOBAL.Rule = TIPO + VISIBILIDAD + VAR_ARREGLO + VAL
                | TIPO + VISIBILIDAD + VAR_ARREGLO  //solo se declaro
                | DECLARAR_VARIABLE_SINVISIBI;



            DECLARAR_VARIABLE_SINVISIBI.Rule = TIPO + VAR_ARREGLO + VAL
                | TIPO + VAR_ARREGLO;//sin visibilidad y solo declarada



            VAL.Rule = sIgual + VALOR
               /* | sIgual + tNuevo + valId + sAbreParent + LST_VAL + sCierraParent //aqui tengo que reconocer el-> nuevo opciones()
                | sIgual + tNuevo + TIPO + LST_CORCHETES_VAL
                | sIgual + LST_LLAVES_VAL
                | sIgual + tNulo*/
                ;


            //llaves
            LST_LLAVES_VAL.Rule = MakePlusRule(LST_LLAVES_VAL, sComa, LLAVES_VAL_P);



            LLAVES_VAL_P.Rule = sAbreLlave + LST_LLAVES_VAL + sCierraLlave
                | sAbreLlave + LST_VAL + sCierraLlave;


            //Arreglos

            VAR_ARREGLO.Rule = valId
                | valId + LST_CORCHETES;

            LST_CORCHETES.Rule = MakePlusRule(LST_CORCHETES, PAR_CORCHETES_VACIOS);

            PAR_CORCHETES_VACIOS.Rule = sAbreCorchete + sCierraCorchete;


            LST_CORCHETES_VAL.Rule = MakePlusRule(LST_CORCHETES_VAL, sAbreCorchete + VALOR + sCierraCorchete);

            //------------------+
            // Asignar valor




            USAR_METO_VAR.Rule = USAR_VARIABLEP + USAR_METO_VAR
                | USAR_VARIABLE
                | USAR_METODO;


            //ASIGNAR_VALOR.Rule = VAL
            //    | 
            ///    |  ;


            //#Usar variable
            //USAR_VARIABLE.Rule = tEste + sPunto + USAR_VARIABLEP
            //    | USAR_VARIABLEP;

            USAR_VARIABLEP.Rule = valId + sPunto
                | valId + LST_CORCHETES_VAL + sPunto
                | valId + sAbreParent + LST_VAL + sCierraParent + sPunto
                ;

            USAR_VARIABLE.Rule = valId + VAL
                | valId + sMas + sMas
                | valId + sMenos + sMenos
                | valId + LST_CORCHETES_VAL + VAL;

            USAR_METODO.Rule = valId + sAbreParent + LST_VAL + sCierraParent;

            //#------------------+
            //# USAR  METODO

            /*
            USAR_METODO.Rule = tEste + sPunto + USAR_METODOP
                | USAR_VARIABLEP;

            USAR_VARIABLEP.Rule = valId + sPunto + USAR_VARIABLEP
                | valId + LST_CORCHETES_VAL + sPunto + USAR_VARIABLEP
                | valId + sAbreParent + LST_VAL + sCierraParent + sPunto + USAR_VARIABLEP
                | valId
                | valId + LST_CORCHETES_VAL;
            */

            LLAMADA_FORMULARIO.Rule = tNuevo + USAR_VARIABLEP; //aqui hay duda we

            //identificador


            //#------------------+
            //# Cuerpo



            LST_CUERPO.Rule = MakeStarRule(LST_CUERPO, CUERPO);
            //| RETORNA
            ;



            CUERPO.Rule = DECLARAR_VARIABLE_SINVISIBI + sPuntoComa
                | USAR_METO_VAR + sPuntoComa
                | Empty
                | SyntaxError
                //| FUNCIONES_NATIVAS
                //| SENTENCIAS
                //| USAR_METODO
                //| ROMPERra
                //| CONTINUAR
                //| PROCEDIMIENTOS_FORMULARIO
                //| FUNC_MULTIMEDIA
                ;


            

            VALOR.Rule = tNuevo + valId + sAbreParent + LST_VAL + sCierraParent //aqui tengo que reconocer el-> nuevo opciones()
                | tNuevo + TIPO + LST_CORCHETES_VAL
                | LST_LLAVES_VAL
                | tNulo
                | E;




            E.Rule =
                sMenos + E
                  //Aritemeticas
                |  E + sPot + E
                | E + sDiv + E
                | E + sPor + E
                | E + sMas + E
                | E + sMenos + E
                | E + sMod + E

                //Relacional

                | E + sIgualacion + E
                | E + sDiferenciacion + E
                | E + sMenorQue + E
                | E + sMenorIgualQue + E
                | E + sMayorQue + E
                | E + sMayorIgualQue + E

                //logicos

                | E + sAnd + E
                | E + sOr + E
                | sNot + E
                
                
                
                | sAbreParent + E + sCierraParent

                //| valId tiene que ser el metodo usar variable jejejeje
                | valBoolean
                | valCadena
                | valCadena2
                | valCaracter
                | valDecimal
                | valNumero;



            RegisterOperators(1, Associativity.Left, sOr);
            RegisterOperators(2, Associativity.Left, sAnd);
            RegisterOperators(3, Associativity.Left, sNot);
            RegisterOperators(4, Associativity.Left, sMayorQue, sMenorQue, sMayorIgualQue, sMenorIgualQue, sIgualacion, sDiferenciacion);
            RegisterOperators(5, Associativity.Left, sMas, sMenos);
            RegisterOperators(6, Associativity.Left, sPor, sDiv,sMod);
            RegisterOperators(7, Associativity.Left, sPot);


            this.Root = S;
            #endregion
        }

        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;
            int fila;
            int columna;

            fila = context.Source.Location.Line;
            columna = context.Source.Location.Column;

            if (error.Contains("Invalid character"))
            {
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido " + division[0];
                tablaErrores.insertErrorLexical(nombreArchivo, fila, columna, "Caractero no reconocido:" + division[0]);
            }
            else
            {

                fila = context.Source.Location.Line;
                columna = context.Source.Location.Column;
                tablaErrores.insertErrorSyntax(nombreArchivo, fila, columna, "No se esperaba token:" + error);
            }

            base.ReportParseError(context);
        }

    }
}
