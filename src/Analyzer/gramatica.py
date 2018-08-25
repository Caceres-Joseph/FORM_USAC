

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
    

    