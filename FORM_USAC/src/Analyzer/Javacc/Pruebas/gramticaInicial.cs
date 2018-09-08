
PARSER_END(parser)

    /*
    |--------------------------------------------------------------------------
    | TOKENS
    |-------------------------------------------------------------------------- 
    */


        /*
        +-------------------------+
        |   Identificadores
        */

TOKEN : 
{
        <tNumero: (["0"-"9"])+ >
            {System.out.println("NUMERO->"+image);}
}

TOKEN : {
        <tIdentificador: <tLetra>(<tLetra>|<tNumero>)*>
            {System.out.println("Identificador->"+image);}
    |   <#tLetra: (["a"-"z","A"-"Z"])> 
}


        /*
        +-------------------------+
        |   Simbolos
        */

TOKEN :
{
         <tMayorQue      : ">" >
            {System.out.println("tMayorQue->"+image);}
    |    <tMenorQue      : "<" >
            {System.out.println("tMenorQue->"+image);}

    |    <tDosPuntos      : ":" >
            {System.out.println("tDosPntos->"+image);}

    |    <tAbreCorchete   : "[" >
            {System.out.println("tAbreCorchete->"+image);}
    |    <tCierraCorchete : "]" >
            {System.out.println("tCierraCorchete->"+image);}
         
}


        /*
        +-------------------------+
        |   SKIP
        */


SKIP    : { " " }
SKIP    : { "\n" | "\r" | "\r\n" }
SKIP   : { 
    <OTHER:   ~[]>{System.out.println("TokenDesconocido->"+image);}
}


        /*
        +-------------------------+
        |   Cadena
        */


TOKEN:
{
 <tCadena:  "/>" ( (~[]) | ("\\" ( ["n","t","b","r","f","\\"] ) ) )* "</" > {System.out.println("tString->"+image);}
}


    /*
    |--------------------------------------------------------------------------
    | GRAMATICA
    |-------------------------------------------------------------------------- 
    */

        /*
        +-------------------------+
        |   Programa
        */

int Programa() :
{

}
{
    CUERPO()
    < EOF > 
    {return 0;}
}

        /*
        +-------------------------+
        |   CUERPO
        */

void CUERPO() :
{

}
{   
    (
            (
                <tMenorQue>
                <tIdentificador>
                <tMayorQue>

                CUERPO()

                <tMenorQue>
                <tIdentificador>
                <tMayorQue>
            )
        |
            (
                LST_VALOR()
            )


    )* 
}

void LST_VALOR() :
{

}
{
    <tIdentificador> 
    <tDosPuntos>
    <tAbreCorchete>

    LST_ATRIBUTOS()
    
    <tCierraCorchete>
}

void LST_ATRIBUTOS():
{

}
{
    (
        <tMenorQue>
        <tIdentificador>

        <tCadena>
        
        <tIdentificador>
        <tMayorQue>
    )*
}