package form_usac;

import Analyzer.Javacc.parser;
import GUI.Principal;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
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
    }

    public static void convertirPrograma() {
        convertXlsToXlsx fileConversionXLSToXLXS = new convertXlsToXlsx();
        String xlsFilePath = "/home/joseph/Documentos/Compi2/Ejemplo - Arbol/arbol.xls ";//Source File Path
        String xlsxFilePath = fileConversionXLSToXLXS.convertXLS2XLSX(xlsFilePath);
    }

    public static void analizar() {

//         al();
        readExcel re = new readExcel();
        String cadena = re.leerEncuesta(0);
        System.out.println(cadena);
        String cad = ""
                + "<grupo>\n"
                + "	grupo:[\n" + "\n"
                + "		<tipo /> Iniciar Agrupacion </ tipo>\n"
                + "		<etiqueta />Agrupación 1</ etiqueta>\n"
                + "		<idpregunta />info1</ idpregunta>"
                + "	]grupo:[\n" + "\n"
                + "		<tipo /> Iniciar Agrupacion </ tipo>\n"
                + "		<etiqueta />Agrupación 1</ etiqueta>\n"
                + "		<idpregunta />info1</ idpregunta>"
                + "	]"
                + "<:grupo>";
        //al(cadena);

//        System.out.println("==============================================");
//        re.leer(1);
//        System.out.println("==============================================");
//        re.leer(2);
    }

    public static void pruebaAnalizador() {
        parser par = new parser();
        //par.inicializar(" identificador3 ; 9 # $3+4; 5+6; /> >< *][- \\ // \"\"  > <<<<.poo009(((/%##Iniciar #%&/()=\t \n  \" < Agrupacion </ ");
      //  par.inicializar("$%3+3;/> \\ \"comentario<><< </  /> omentario2</");
    }

    public static void pruebaExcel() {
        readExcel re = new readExcel();
        String cadena = re.leerEncuesta(0);
        System.out.println(cadena);
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

}
