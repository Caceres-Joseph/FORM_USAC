using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using _COMPI_Proyecto1.Reporte;

namespace _COMPI_Proyecto1.Analizador
{

    class gammar2: Grammar
    {
        public List<ErrorEjecucion> lista = new List<ErrorEjecucion>();//Lista de errores
        public gammar2() : base(caseSensitive: false)//Diferencia entre mayusculas y minusculas
        {
            #region ER
            //////////////////////////////////////////
            //------------COMENTARIOS-----------------

            CommentTerminal comentariobloque = new CommentTerminal("comentariobloque", "/*", "*/");
            CommentTerminal comentariolinea = new CommentTerminal("comentariolinea", "//", "\n", "\r\n");
            /*Se ignoran los terminales solo se reconoce*/
            NonGrammarTerminals.Add(comentariobloque);
            NonGrammarTerminals.Add(comentariolinea);

            //////////////////////////////////////////
            //------------OTROS-----------------
            RegexBasedTerminal booleanDato = new RegexBasedTerminal("booleanDato", "(True|true|False|false)");


            StringLiteral caracter = new StringLiteral("caracter", "\'");
            StringLiteral cadena = new StringLiteral("cadena", "\"");
            RegexBasedTerminal numeroValor = new RegexBasedTerminal("numeroValor", "[0-9]+");
            RegexBasedTerminal decimalValor = new RegexBasedTerminal("decimalValor", "[0-9]+(.)[0-9]+");
       
            IdentifierTerminal id = new IdentifierTerminal("id");
            

            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");

            var t_class = ToTerm("class");
            var t_int = ToTerm("int");
            var t_String = ToTerm("String");
            var t_boolean = ToTerm("boolean");
            var t_double = ToTerm("double");
            var t_char = ToTerm("char");

            var t_extends = ToTerm("extends");

            var t_public = ToTerm("public");
            var t_private = ToTerm("private");
            var t_protected = ToTerm("protected");

            var t_return = ToTerm("return");
            var t_void = ToTerm("void");
            var t_Override = ToTerm("Override");

            var t_this = ToTerm("this");
            var t_and = ToTerm("&&");
            var t_or = ToTerm("||");
            var t_not = ToTerm("!");

            var t_igual = ToTerm("==");
            var t_diferente = ToTerm("!=");
            var t_menor_que = ToTerm("<");
            var t_mayor_que = ToTerm(">");
            var t_mayor_igual = ToTerm(">=");
            var t_menor_igual = ToTerm("<=");

            var t_if = ToTerm("if");
            var t_else = ToTerm("else");
            var t_switch = ToTerm("switch");
            var t_case = ToTerm("case");
            var t_break = ToTerm("break");
            var t_continue = ToTerm("continue");
            var t_default = ToTerm("default");
            var t_while = ToTerm("while");
            var t_do = ToTerm("do");
            var t_for = ToTerm("for");

            var t_new = ToTerm("new");
            //Simbolos
            var punto = ToTerm(".");
            var coma = ToTerm(",");
            var dosPuntos = ToTerm(":");
            var puntoComa = ToTerm(";");
            var abreParent = ToTerm("(");
            var cierraParent = ToTerm(")");
            var abreLlave = ToTerm("{");
            var cierraLlave = ToTerm("}");

            #endregion

            #region NoTerminales

            //////////////////////////////////////////
            //------------No terminales-----------------

            NonTerminal S = new NonTerminal("S");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal EXTENDER = new NonTerminal("EXTENDER");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal PARAMETROS = new NonTerminal("PARAMETROS");
            NonTerminal PARAMETROS_P = new NonTerminal("PARAMETROS_P");
            NonTerminal CONSTRUCTOR = new NonTerminal("CONSTRUCTOR");
            NonTerminal CP_CLASE = new NonTerminal("CP_CLASE");
            NonTerminal CUERPO_CLASE = new NonTerminal("CUERPO_CLASE");
            NonTerminal FUNCION = new NonTerminal("FUNCION");
            NonTerminal RETORNO = new NonTerminal("RETORNO");
            NonTerminal METODO = new NonTerminal("METODO");
            NonTerminal SOBRESCRITURA = new NonTerminal("SOBRESCRITURA");
            NonTerminal PROCEDIMIENTOS = new NonTerminal("PROCEDIMIENTOS");
            NonTerminal CUERPO = new NonTerminal("CUERPO");
            NonTerminal CUERPOP = new NonTerminal("CUERPOP");
            NonTerminal DECLARAR_VARIABLE = new NonTerminal("DECLARAR_VARIABLE");
            NonTerminal IDP = new NonTerminal("IDP");
            NonTerminal VAL = new NonTerminal("VAL");
            NonTerminal VALOR = new NonTerminal("VALOR");
            NonTerminal USAR_METODO = new NonTerminal("USAR_METODO");
            NonTerminal USAR_METODOP = new NonTerminal("USAR_METODOP");
            NonTerminal LISTA_DE_VALORES = new NonTerminal("LISTA_DE_VALORES");
            NonTerminal USAR_VARIABLE = new NonTerminal("USAR_VARIABLE");
            NonTerminal USAR_VARIABLEP = new NonTerminal("USAR_VARIABLEP");
            NonTerminal ASIGNAR_VALOR = new NonTerminal("ASIGNAR_VALOR");
            NonTerminal LOGICO = new NonTerminal("LOGICO");
            NonTerminal CONDICION = new NonTerminal("CONDICION");
            NonTerminal RELACIONAL = new NonTerminal("RELACIONAL");
            NonTerminal E = new NonTerminal("E");
            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal IF = new NonTerminal("IF");
            NonTerminal ELSEIF = new NonTerminal("ELSEIF");
            NonTerminal ELSEIFP = new NonTerminal("ELSEIFP");
            NonTerminal ELSE = new NonTerminal("ELSE");
            NonTerminal SWITCH = new NonTerminal("SWITCH");
            NonTerminal CASE = new NonTerminal("CASE");
            NonTerminal CASEP = new NonTerminal("CASEP");
            NonTerminal DEFAULT = new NonTerminal("DEFAULT");
            NonTerminal EXPRESION = new NonTerminal("EXPRESION");
            NonTerminal WHILE = new NonTerminal("WHILE");
            NonTerminal DO = new NonTerminal("DO");
            NonTerminal FOR = new NonTerminal("FOR");
            NonTerminal EXPRESION2 = new NonTerminal("EXPRESION2");
            NonTerminal ASIGNAR_VALOR2 = new NonTerminal("ASIGNAR_VALOR2");
            NonTerminal PARTE2 = new NonTerminal("PARTE2");
            NonTerminal CLASE = new NonTerminal("CLASE");
            NonTerminal CLASES = new NonTerminal("CLASES");

            #endregion

            #region gammar2

            //S.Rule = VISIBILIDAD + t_class + id + EXTENDER + abreLlave + CONSTRUCTOR + CP_CLASE + cierraLlave;
            S.Rule = CLASES;

            CLASES.Rule = CLASE + CLASES
                 | CLASE;

            CLASE.Rule= VISIBILIDAD + t_class + id + EXTENDER + abreLlave + CP_CLASE + cierraLlave
                | SyntaxError; 
            //S.Rule = VISIBILIDAD + t_class + id + EXTENDER + abreLlave+CP_CLASE +cierraLlave;

            TIPO.Rule = t_int
                | t_String
                | t_boolean
                | t_double
                | t_char
                | id;

            EXTENDER.Rule = t_extends + id
                | Empty;

            VISIBILIDAD.Rule = t_public
                 | t_private
                 | t_protected
                 | Empty;

            PARAMETROS.Rule = PARAMETROS + coma + PARAMETROS_P
                 | PARAMETROS_P
                 | Empty;

            PARAMETROS_P.Rule = TIPO + id;


            CONSTRUCTOR.Rule = VISIBILIDAD + id + abreParent + PARAMETROS + cierraParent + abreLlave + CUERPO + cierraLlave
                |Empty;//por si no viene contructor 

            CP_CLASE.Rule = CP_CLASE + CUERPO_CLASE
                 | CUERPO_CLASE
                 |Empty;

            CUERPO_CLASE.Rule = VISIBILIDAD + DECLARAR_VARIABLE
               |CONSTRUCTOR
               | PROCEDIMIENTOS
               | SOBRESCRITURA
               | SyntaxError;

            FUNCION.Rule = VISIBILIDAD + TIPO + id + abreParent + PARAMETROS + cierraParent + abreLlave + CUERPO + RETORNO + cierraLlave
                | SyntaxError;

            RETORNO.Rule = t_return + VALOR+puntoComa
                |t_return+puntoComa
                |t_break +puntoComa
                |t_continue+puntoComa
                | Empty;

            METODO.Rule = VISIBILIDAD + t_void + id + abreParent + PARAMETROS + cierraParent + abreLlave + CUERPO + cierraLlave
                | SyntaxError;

            SOBRESCRITURA.Rule = ToTerm("@") + t_Override + PROCEDIMIENTOS;

            PROCEDIMIENTOS.Rule = METODO
                | FUNCION
                | SyntaxError;


            CUERPO.Rule = CUERPO + CUERPOP
                 | CUERPOP
                 |Empty;

            //CUERPOP.Rule = DECLARAR_VARIABLE;

            CUERPOP.Rule = DECLARAR_VARIABLE
                 | ASIGNAR_VALOR
                 | SENTENCIAS
                 | USAR_METODO + puntoComa
                 | USAR_VARIABLE+puntoComa
                 | RETORNO
                 | SyntaxError;



            DECLARAR_VARIABLE.Rule = TIPO + IDP + VAL+puntoComa
                | SyntaxError; 

            IDP.Rule = IDP + coma + id
                | id;

            VAL.Rule = ToTerm("=") + PARTE2
                | Empty;

            PARTE2.Rule = VALOR 
                | t_new + USAR_METODO;

            VALOR.Rule = cadena
                | caracter
                | booleanDato
                | USAR_METODO
                | USAR_VARIABLE
                | E
                | RELACIONAL
                | LOGICO
                ; 

            USAR_METODO.Rule = t_this + punto + USAR_METODOP
                | USAR_METODOP;

            USAR_METODOP.Rule = id + punto + USAR_METODOP
                | id + abreParent + LISTA_DE_VALORES + cierraParent ;

            LISTA_DE_VALORES.Rule = LISTA_DE_VALORES + coma + VALOR
                | VALOR
                | Empty;

            USAR_VARIABLE.Rule = t_this + punto + USAR_VARIABLEP
                | USAR_VARIABLEP;

            USAR_VARIABLEP.Rule=id+punto+USAR_VARIABLEP
                |id;

            ASIGNAR_VALOR.Rule = USAR_VARIABLE + ToTerm("=") + VALOR + puntoComa
                | USAR_VARIABLE +mas+mas+puntoComa
                |USAR_VARIABLE+menos+menos+puntoComa;

            

            LOGICO.Rule = VALOR + t_and + VALOR
                | VALOR + t_or + VALOR
                | t_not + VALOR
                | VALOR
                |LOGICO
                | abreParent+LOGICO+cierraParent
                ;

            CONDICION.Rule = RELACIONAL
                | LOGICO
                | booleanDato
                | USAR_METODO
                |USAR_VARIABLE;

            RELACIONAL.Rule = E + t_igual + E//
                | cadena + t_igual + cadena
                | cadena + t_igual + USAR_VARIABLE //Para la igualación con cadenas y variables
                | USAR_VARIABLE + t_igual + cadena
                | cadena + t_igual + USAR_METODO
                | USAR_METODO + t_igual + cadena
                | USAR_METODO + t_igual + USAR_METODO
                | USAR_VARIABLE + t_igual + USAR_VARIABLE


                | E + t_diferente + E
                | cadena + t_diferente + cadena
                | E + t_menor_que + E
                | E + t_mayor_que + E
                | E + t_menor_igual + E
                | E + t_mayor_igual + E
                | abreParent + RELACIONAL + cierraParent
              
                
                | cadena + t_diferente + USAR_VARIABLE //Para la igualación con cadenas y variables
                | USAR_VARIABLE + t_diferente + cadena
                | USAR_VARIABLE + t_diferente + USAR_VARIABLE
                
                | USAR_METODO + t_diferente+USAR_METODO
                
                | cadena + t_diferente + USAR_METODO
                | USAR_METODO + t_diferente + cadena
                | SyntaxError;

            E.Rule = E + mas + E
                | E + menos + E
                | E + por + E
                | E + div + E
                |cadena+mas+cadena//Cuando se concatenan las cadenas
                | menos + E
                | numeroValor
                | decimalValor
                | abreParent + E + cierraParent
                | USAR_VARIABLE
                | USAR_METODO
                | SyntaxError;

            SENTENCIAS.Rule = IF
                | SWITCH
                | WHILE
                | DO
                | FOR;

            IF.Rule = t_if + abreParent + CONDICION + cierraParent + abreLlave + CUERPO + cierraLlave +ELSEIF;

            ELSEIF.Rule = ELSEIFP + ELSEIF
                | ELSEIFP
                | Empty;//por si no viene el elseif

            ELSEIFP.Rule = t_else + t_if + abreParent + CONDICION + cierraParent + abreLlave + CUERPO + cierraLlave
               | t_else + abreLlave + CUERPO + cierraLlave;

            ELSE.Rule = t_else + abreLlave + CUERPO + cierraLlave
                |Empty;//por si no viene el else


            SWITCH.Rule = t_switch + abreParent + VALOR + cierraParent + abreLlave + CASE + DEFAULT + cierraLlave
                | SyntaxError;

            CASE.Rule = CASE + CASEP
                | CASEP
                | Empty;

            CASEP.Rule = t_case + VALOR + dosPuntos + CUERPO
                | SyntaxError;

            DEFAULT.Rule = t_default + dosPuntos + CUERPO 
                |Empty;

            EXPRESION.Rule = USAR_VARIABLE
                | USAR_METODO;

            WHILE.Rule = t_while + abreParent + CONDICION + cierraParent + abreLlave + CUERPO + cierraLlave
                | SyntaxError;

            DO.Rule = t_do + abreLlave + CUERPO + cierraLlave + t_while + abreParent + CONDICION + cierraParent + puntoComa
                | SyntaxError;

            FOR.Rule = t_for + abreParent + EXPRESION2 + puntoComa + CONDICION + puntoComa + ASIGNAR_VALOR2 + cierraParent + abreLlave + CUERPO + cierraLlave
                | SyntaxError;

            EXPRESION2.Rule = TIPO + IDP + VAL//DECLARAR_VARIABLE
                | ASIGNAR_VALOR2;

            ASIGNAR_VALOR2.Rule = USAR_VARIABLE + ToTerm("=") + VALOR
                | USAR_VARIABLE + mas + mas
                | USAR_VARIABLE + menos + menos
                | SyntaxError;


            #endregion



            RegisterOperators(1, Associativity.Left, "||");
            RegisterOperators(2, Associativity.Left, "&&");
            RegisterOperators(3, Associativity.Left, "!");
            RegisterOperators(4, Associativity.Left, ">","<",">=","<=");
            RegisterOperators(5, Associativity.Left, "+", "-");
            RegisterOperators(6, Associativity.Left, "*", "/");
            



            this.Root = S;
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
