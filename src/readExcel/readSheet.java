/*
=============================
    Leyendo las Hojas del documento
=============================
 */
package readExcel;

import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;

/**
 *
 * @author joseph
 */
public class readSheet {

    private Sheet datatypeSheet;
    public Map<Integer, String> encabezado = new HashMap<>();
    private String stringSheet="";
    
    public readSheet(Sheet datatypeSheet) {
        this.datatypeSheet = datatypeSheet;
    }
    
    public String leerEncuesta(){
         
        Iterator<Row> iterator = datatypeSheet.iterator();
        this.getEncabezado(iterator);
        this.getCuerpoEncuesta(iterator);
        return this.stringSheet;
                
    }
    public String leerOtros(){ 
        Iterator<Row> iterator = datatypeSheet.iterator();
        this.getEncabezado(iterator);
        this.getCuerpo(iterator);
        return this.stringSheet;
    }

    public void getEncabezado(Iterator<Row> iterator) {

        boolean primerFilaValida = false;
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(currentRow);
            if (primerFilaValida == false) {
                Map<Integer, String> temp = leerFila.leerFilaEncabezado();
                if (leerFila.isFilaValida()) {//encontré la primer fila válida
                    //llenando el arreglo encabezado 
                    this.encabezado = temp;
                    return;
                }
            }
        }
    }

    public void getCuerpo(Iterator<Row> iterator) {
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(currentRow);

            Map<String, String> fila = leerFila.leerFilaCuerpo(encabezado);
            if (leerFila.isFilaValida()) {
                this.imprimirHash(fila);
            }
            //luego hay que ordenar tipo, etiqueta, idPregunta  
        }
    }
    
    
    public void getCuerpoEncuesta(Iterator<Row> iterator) {
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(currentRow);

            Map<String, String> fila = leerFila.leerFilaCuerpo(encabezado);
            if (leerFila.isFilaValida()) {
                this.ordenarHash(fila);
            }
            //luego hay que ordenar tipo, etiqueta, idPregunta  
        }
    }
 
    public Map<String, String> imprimirHash(Map<String, String> filaHash){
        Map<String, String> retorno = new LinkedHashMap<>();
        Iterator it = filaHash.keySet().iterator();
        this.stringSheet+="\n\tfila:[";
        while (it.hasNext()) {
            String key = (String) it.next();
            this.stringSheet+="\n\t\t<"+key + ">" + filaHash.get(key)+"</"+key + ">";
        }
        this.stringSheet+="\n\t]";
        return retorno; 
    }
    
    public Map<String, String> ordenarHash(Map<String, String> filaHash) {
        Map<String, String> retorno = new LinkedHashMap<>();

        if (filaHash.get("tipo") != null) {
            String tipo=filaHash.get("tipo").toLowerCase();
           
            if (tipo.contains("iniciar") && tipo.contains("agrupacion")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet+="\n<grupo>"; 
                this.stringSheet+="\n\tgrupo:[";
            }else if (tipo.contains("iniciar") && tipo.contains("ciclo")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet+="\n<ciclo>";
                this.stringSheet+="\n\tciclo:[";
            }else if (tipo.contains("finalizar") && tipo.contains("ciclo")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet+="\n</ciclo>";
                this.stringSheet+="\n\tciclo:[";
                
            }else if (tipo.contains("finalizar") && tipo.contains("agrupacion")) {
                //System.out.println("hay agrupación finalizar");
                this.stringSheet+="\n</grupo>";
                this.stringSheet+="\n\tgrupo:[";
                
            }else{
                this.stringSheet+="\n\tpregunta:[";
            }  
        }
        
        
        
        this.stringSheet+="\n\t\t<tipo/>" + filaHash.get("tipo")+"</tipo>";
        this.stringSheet+="\n\t\t<etiqueta/>" + filaHash.get("etiqueta")+"</etiqueta>";
        this.stringSheet+="\n\t\t<idpregunta/>" + filaHash.get("idpregunta")+"</idpregunta>";
                
        filaHash.remove("tipo");
        filaHash.remove("etiqueta");
        filaHash.remove("idpregunta");

        Iterator it = filaHash.keySet().iterator();
        while (it.hasNext()) {
            String key = (String) it.next();
            
            this.stringSheet+="\n\t\t<"+key + "/>" + filaHash.get(key)+"</"+key + ">";
        }
        this.stringSheet+="\n\t]";
        
        return retorno;
    }
    

    /*
=============================
    Getters and Setters
=============================
     */
    public Sheet getDatatypeSheet() {
        return datatypeSheet;
    }

    public void setDatatypeSheet(Sheet datatypeSheet) {
        this.datatypeSheet = datatypeSheet;
    }

    public String getStringSheet() {
        return stringSheet;
    }

    public void setStringSheet(String stringSheet) {
        this.stringSheet = stringSheet;
    }
}
