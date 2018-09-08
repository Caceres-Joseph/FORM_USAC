/*
=============================
    Leyendo las Hojas del documento
=============================
 */
package readExcel;

import Analyzer.Tree.Tablas.tablaErrores;
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
    public Map<Integer, cell> encabezado = new HashMap<>();
    private String stringSheet = "";
    public tablaErrores tablaErrores;
    public String ambito = "";

    public readSheet(String ambito, Sheet datatypeSheet) {
        this.datatypeSheet = datatypeSheet;
        this.tablaErrores = new tablaErrores();
        this.ambito = ambito;
    }

    public String leerEncuesta() {

        Iterator<Row> iterator = datatypeSheet.iterator();
        this.getEncabezado(iterator);
        this.getCuerpoEncuesta(iterator);
        return this.stringSheet;

    }

    public String leerOtros() {
        Iterator<Row> iterator = datatypeSheet.iterator();
        this.getEncabezado(iterator);
        this.getCuerpo(iterator);
        return this.stringSheet;
    }

    public void getEncabezado(Iterator<Row> iterator) {

        boolean primerFilaValida = false;
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(ambito, currentRow);
            if (primerFilaValida == false) {
                Map<Integer, cell> temp = leerFila.leerFilaEncabezado();
                if (leerFila.isFilaValida()) {//encontré la primer fila válida
                    //llenando el arreglo encabezado 

                    this.encabezado = temp;
                    return;
                }
            }
            tablaErrores.concat(leerFila.getTablaErrores());

        }
    }

    public void getCuerpo(Iterator<Row> iterator) {
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(ambito, currentRow);

            Map<String, cell> fila = leerFila.leerFilaCuerpo(encabezado);
            if (leerFila.isFilaValida()) {
                this.imprimirHash(fila);
            }

            tablaErrores.concat(leerFila.getTablaErrores());

        }
    }

    public void getCuerpoEncuesta(Iterator<Row> iterator) {
        while (iterator.hasNext()) {
            Row currentRow = iterator.next();
            readRow leerFila = new readRow(ambito, currentRow);

            Map<String, cell> fila = leerFila.leerFilaCuerpo(encabezado);

            if (leerFila.isFilaValida()) {
                this.ordenarHash(fila);
            }

            tablaErrores.concat(leerFila.tablaErrores);

            //luego hay que ordenar tipo, etiqueta, idPregunta  
        }
    }

    public Map<String, cell> imprimirHash(Map<String, cell> filaHash) {
        Map<String, cell> retorno = new LinkedHashMap<>();
        this.stringSheet += "\n\tfila:[";
        Iterator it = filaHash.keySet().iterator();
        while (it.hasNext()) {
            String key = (String) it.next();
            cell temp = filaHash.get(key);
            this.stringSheet += "\n\t\t<  _ambito:" + temp.ambito + " posX:" + String.valueOf(temp.posX) + " posY:" + String.valueOf(temp.posY) + " " + key + " />" + temp.val + " </ " + key + ">";
        }
        this.stringSheet += "\n\t]";

        return retorno;
    }

    public Map<String, cell> ordenarHash(Map<String, cell> filaHash) {
        Map<String, cell> retorno = new LinkedHashMap<>();
        boolean columnaObligatorio = true;
        cell cellTipo = this.hashGet(filaHash, "tipo");
        if (cellTipo == null) {
            for (String key : filaHash.keySet()) {
                cell temp = filaHash.get(key);
                tablaErrores.insertErrorSyntax(ambito, temp.posY,
                        temp.posX, "La celda con valor :" + temp.val + " no tiene la columna obligatoria   'tipo'");
            }
            columnaObligatorio = false;
        } else {
//            String tipo = cellTipo.val.toLowerCase();
//            if (tipo.contains("final") && tipo.contains("ciclo")) {
//
//            } else if (tipo.contains("final") && tipo.contains("agrupacion")) {
//
//            } else if (tipo.contains("inici") && tipo.contains("ciclo")) {
//
//            } else if (tipo.contains("inici") && tipo.contains("agrupacion")) {
//
//            } else {
//                if (this.hashGet(filaHash, "etiqueta") == null && (true)) {
//                    for (String key : filaHash.keySet()) {
//                        cell temp = filaHash.get(key);
//                        tablaErrores.insertErrorSyntax(ambito, temp.posY,
//                                temp.posX, "La celda con valor :" + temp.val + " no tiene la columna obligatoria   'etiqueta'");
//                    }
//                    columnaObligatorio = false;
//                }
//            }

        }

        if (this.hashGet(filaHash, "idpregunta") == null) {
            for (String key : filaHash.keySet()) {
                cell temp = filaHash.get(key);
                tablaErrores.insertErrorSyntax(ambito, temp.posY,
                        temp.posX, "La celda con valor :" + temp.val + " no tiene la columna obligatoria  'idpregunta'");
            }
            columnaObligatorio = false;
        }

//        (filaHash.get("tipo") != null)&&(filaHash.get("tipo") != null)&&filaHash.get("tipo") != null
        if (columnaObligatorio) {
            String tipo = cellTipo.val.toLowerCase();

            if (tipo.contains("inici") && tipo.contains("agrupacion")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet += "\n<grupo->[";
//                this.stringSheet+="\n\t->[";
            } else if (tipo.contains("inici") && tipo.contains("ciclo")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet += "\n<ciclo->[";
//                this.stringSheet+="\n\t->[";
            } else if (tipo.contains("final") && tipo.contains("ciclo")) {
                //System.out.println("hay agrupación iniciar");
                this.stringSheet += "\n&ciclo->[";
//                this.stringSheet+="\n\t->[";

            } else if (tipo.contains("final") && tipo.contains("agrupacion")) {
                //System.out.println("hay agrupación finalizar");
                this.stringSheet += "\n&grupo->[";
//                this.stringSheet+="\n\t->[";

            } else {
                this.stringSheet += "\n\tpregunta:[";
            }
            Iterator it = filaHash.keySet().iterator();
            while (it.hasNext()) {
                String key = (String) it.next();
                cell temp = filaHash.get(key);
                this.stringSheet += "\n\t\t< _ambito:" + temp.ambito + " posX:" + String.valueOf(temp.posX) + " posY:" + String.valueOf(temp.posY) + " " + key + " />" + temp.val + "</ " + key + ">";
            }
            this.stringSheet += "\n\t]";

        }
        

//        this.stringSheet+="\n\t\t<tipo/> " + filaHash.get("tipo").val+" </tipo>";
//        this.stringSheet+="\n\t\t<etiqueta/> " + filaHash.get("etiqueta").val+" </etiqueta>";
//        this.stringSheet+="\n\t\t<idpregunta/> " + filaHash.get("idpregunta").val+" </idpregunta>";
//                
//        filaHash.remove("tipo");
//        filaHash.remove("etiqueta");
//        filaHash.remove("idpregunta");
        return retorno;
    }

    public cell hashGet(Map<String, cell> lstCell, String contenido) {
        cell retorno = null;

        for (String key : lstCell.keySet()) {

            if (key.contains(contenido)) {
                return lstCell.get(key);
            }

        }
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

    public tablaErrores getTablaErrores() {
        return tablaErrores;
    }

}
