

lstSumas -> lstSumas + lstNumeros + ";"
          | lstNumeros + ";" 



lstNumeros -> lstNumeros + "+" + num 
            | num 



lstSumas    ->  lstNumeros + ";" + lstSumasP
lstSumasP   ->  lstNumeros + ";" + lstSumasP
            | e
             
""" INICIO """

lstSumas    ->  lstNumeros + ";" + lstSumas
            | e

lstNumeros  -> num lstNumerosP
lstNumerosP -> "+" + num lstNumerosP
            |e



 
    
    #|--------------------------------------------------------------------------
    #| GRAMATICA
    #|-------------------------------------------------------------------------- 
    


S               -> CUERPO



CUERPO          -> "<" tIdentificador ">" CUERPO "<"  tIdentificador ">"  CUERPO
                |  LST_VALOR CUERPO
                | e
 

CUERPO2         -> < tIdentificador > CUERPO2 <Identifi >

LST_VALOR       ->tIdentificador ":" "[" LST_ATRIBUTOS "]"

LST_ATRIBUTOS   -> "<" tIdentificador "/>   </" tIdentificador ">" LST_ATRIBUTOS
                |e
                

 
                


S               ->CUERPO

CUERPO          ->DAT CUERPO
                |e

DAT             -> LST_VALOR
                | "<" tIdentificador ">" CUERPO "<"  tIdentificador ">"  CUERPO