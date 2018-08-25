/*
=============================
    Leyendo las Filas del documento
=============================
 */
package readExcel;

import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;

/**
 *
 * @author joseph
 */
public class readRow {

    private Row currentRow;
    private boolean filaValida = false;

    public readRow(Row currentRow) {
        this.currentRow = currentRow;
        /*
            Aquí tengo que ordenar la columna
                tipo
                idPregunta
                etiqueta
         */
        //fin de la fila
    }

    public Map<Integer, String> leerFilaEncabezado() {
        Map<Integer, String> retorno = new HashMap<>();;

        Iterator<Cell> cellIterator = currentRow.iterator();

        //iniciando recorrido de fila
        boolean filaVacia = true;

        Map<Integer, String> tempRetorno = new HashMap<>();
        while (cellIterator.hasNext()) {

            Cell currentCell = cellIterator.next();
            readCell leerCelda = new readCell(currentCell);

            if (!leerCelda.getValue().equals("")) {
                int indice = currentCell.getColumnIndex();
                String valor = leerCelda.getValue().toLowerCase();
                valor=valor.replace(" ", "");//quitando espacios en blanco

//                System.out.print(indice);
//                System.out.print("-> " + valor + "|");
                tempRetorno.put(indice, valor);
                filaVacia = false;
            }
        }
//        System.out.println("");

        if (!filaVacia) {
            this.filaValida = true;
            retorno = tempRetorno;
        }

        return retorno;
    }

    public Map<String, String> leerFilaCuerpo(Map<Integer, String> encabezado) {
        Map<String, String> retorno = new LinkedHashMap<>(); 
        Iterator<Cell> cellIterator = currentRow.iterator();

        //iniciando recorrido de fila
        boolean filaVacia = true;

        Map<String, String> tempRetorno = new LinkedHashMap<>();
        while (cellIterator.hasNext()) {

            Cell currentCell = cellIterator.next();
            readCell leerCelda = new readCell(currentCell);

            if (!leerCelda.getValue().equals("")) {
                String indice = encabezado.get(currentCell.getColumnIndex());
                String valor = leerCelda.getValue(); 
//                System.out.print(indice);
//                System.out.print("-> " + valor + "|");
                tempRetorno.put(indice, valor);
                filaVacia = false;
            }
        }
//        System.out.println("");

        if (!filaVacia) {
            this.filaValida = true;
            retorno = tempRetorno;
        }

        return retorno;
    }


    /*
=============================
    Getters and Setters
=============================
     */
    public Row getCurrentRow() {
        return currentRow;
    }

    public void setCurrentRow(Row currentRow) {
        this.currentRow = currentRow;
    }

    public boolean isFilaValida() {
        return filaValida;
    }

    public void setFilaValida(boolean filaValida) {
        this.filaValida = filaValida;
    }

}
