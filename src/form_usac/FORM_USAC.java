package form_usac;

import Analyzer.Javacc.parser;
import Analyzer.Javacc_Exp.parser_exp;
import Analyzer.Tree.Tablas.tablaSimbolos;
import GUI.Principal;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.util.logging.Level;
import java.util.logging.Logger;
import readExcel.cell;
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
        //pruebaAnalizador();
        //pruebaExcel();
        //convertFile_to_InputStream();
        iniciarInterfaz(args);
//        analizar2();
    }

    public static void convertirPrograma() {
        convertXlsToXlsx fileConversionXLSToXLXS = new convertXlsToXlsx();
        String xlsFilePath = "/home/joseph/Documentos/Compi2/Ejemplo - Arbol/arbol.xls ";//Source File Path
        String xlsxFilePath = fileConversionXLSToXLXS.convertXLS2XLSX(xlsFilePath);
    }

 

    public static void pruebaAnalizador() {
        parser par = new parser();
        //par.inicializar(" identificador3 ; 9 # $3+4; 5+6; /> >< *][- \\ // \"\"  > <<<<.poo009(((/%##Iniciar #%&/()=\t \n  \" < Agrupacion </ ");
      //  par.inicializar("$%3+3;/> \\ \"comentario<><< </  /> omentario2</");
    }
 

    public static void al(String cadena) {
        parser par = new parser();
        //par.inicializar(" identificador3 ; 9 # $3+4; 5+6; /> >< *][- \\ // \"\"  > <<<<.poo009(((/%##Iniciar #%&/()=\t \n  \" < Agrupacion </ ");
       // par.inicializar(cadena);
    }

    public static void convertFile_to_InputStream()   {
        InputStream targetStream = null;
        try {
            File initialFile = new File("src/Analyzer/Entradas/entrada.txt");
            targetStream = new FileInputStream(initialFile);
            parser par = new parser();
            
            par.inicializar(targetStream);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(FORM_USAC.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                targetStream.close();
            } catch (IOException ex) {
                Logger.getLogger(FORM_USAC.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        
    }
    
    public static void iniciarInterfaz(String[] args){
        System.out.println("Inicializando...");
        Principal pri = new Principal();
        
        pri.correr(args);
    }

    public static void analizar2(){
        
        System.out.println("---Analisis expresion----");
        //String cadena=" !(!#[EDAD] != 10*3 div 8 mod 11 +33-12 >=33 || 33<21 && 32<=32 || identii > 32 && 32=43)";
        String cadena="° 3+3+luio MOD Posicion(..)+indice";
        tablaSimbolos tabla=new tablaSimbolos();
        InputStream stream = new ByteArrayInputStream(cadena.getBytes(StandardCharsets.UTF_8));
        parser_exp par = new parser_exp(); 
              cell celda=new cell("id");
        celda.posX=1;
        celda.posY=3;
        celda.ambito="3";
          
//        par.inicializar(tabla,stream, celda); 
    }
}
