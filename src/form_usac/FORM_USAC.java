
package form_usac;

import Analyzer.parser;
import readExcel.convertXlsToXlsx;  
import readExcel.readExcel;

/**
 *
 * @author joseph
 */
public class FORM_USAC {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//         al();
        readExcel re=new readExcel();
        System.out.println(re.leerEncuesta(0));
        
//        System.out.println("==============================================");
//        re.leer(1);
//        System.out.println("==============================================");
//        re.leer(2);
    }
    
    public static void convertirPrograma(){
        convertXlsToXlsx fileConversionXLSToXLXS = new convertXlsToXlsx();
        String xlsFilePath = "/home/joseph/Documentos/Compi2/Ejemplo - Arbol/arbol.xls";//Source File Path
        String xlsxFilePath = fileConversionXLSToXLXS.convertXLS2XLSX(xlsFilePath);
    }
    
    public static void analizar(){ 
        
    }
    
    public static void al(){  
        parser par=new parser();
        par.inicializar(" identificador3 ; 9 # $3+4; 5+6; /> >< *][- \\ // \"\"  > <<<<.poo009(((/%##Iniciar #%&/()=\t \n  \" < Agrupacion </ ");
    }
    
}
