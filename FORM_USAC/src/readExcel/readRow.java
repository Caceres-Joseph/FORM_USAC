/*
=============================
    Leyendo las Filas del documento
=============================
 */
package readExcel;

import Analyzer.Tree.Tablas.tablaErrores;
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
    public tablaErrores tablaErrores;
    public String ambito="";
    public readRow(String ambito,Row currentRow) {
        this.tablaErrores =new tablaErrores();
        this.currentRow = currentRow;
        this.ambito=ambito;
        /*
            Aquí tengo que ordenar la columna
                tipo
                idPregunta
                etiqueta
         */
        //fin de la fila
    }

    public Map<Integer, cell> leerFilaEncabezado() {
        Map<Integer, cell> retorno = new HashMap<>();;

        Iterator<Cell> cellIterator = currentRow.iterator();

        //iniciando recorrido de fila
        boolean filaVacia = true;

        Map<Integer, cell> tempRetorno = new HashMap<>();
        while (cellIterator.hasNext()) {

            Cell currentCell = cellIterator.next();
            readCell leerCelda = new readCell(ambito,currentCell);

            if (!leerCelda.getValue().val.equals("")) {
                int indice = currentCell.getColumnIndex();
                cell vale=leerCelda.getValue();
               
                vale.val =vale.val.toLowerCase();
                vale.val=vale.val.replace(" ", "");//quitando espacios en blanco
                vale.posY=indice;
//                System.out.print(indice);
//                System.out.print("-> " + vale.val + "|");

//Verificando si existe otra fila con el mismo nombre prro

    
                tempRetorno.put(indice, vale);
                filaVacia = false;
            }
            
            tablaErrores.concat(leerCelda.getTablaErrores()); 
        }
//        System.out.println("");

        if (!filaVacia) {
            this.filaValida = true;
            retorno = tempRetorno;
        }

        return retorno;
    }

    public Map<String, cell> leerFilaCuerpo(Map<Integer, cell> encabezado) {
        Map<String, cell> retorno = new LinkedHashMap<>(); 
        Iterator<Cell> cellIterator = currentRow.iterator();

        //iniciando recorrido de fila
        boolean filaVacia = true;

        Map<String, cell> tempRetorno = new LinkedHashMap<>();
        while (cellIterator.hasNext()) {

            Cell currentCell = cellIterator.next();
            readCell leerCelda = new readCell(ambito,currentCell);
            
            if (!leerCelda.getValue().val.equals("")) {
                
                
                cell te=encabezado.get(currentCell.getColumnIndex());
                if(te==null){
                    tablaErrores.insertErrorSemantic(ambito,currentCell.getRowIndex(),
                            currentCell.getColumnIndex()
                            , "La celda con valor "+ leerCelda.getValue().val+" no tiene encabezado :(");
                      
                }else{
                    String indice = te.val;


                    cell valor = leerCelda.getValue(); 

                    valor.posY=currentCell.getRowIndex();

    //                System.out.print(currentCell.getRowIndex());
    //                System.out.print("]");
    //                System.out.print(indice);
    //                System.out.print("-> " + valor.val + "|");

                    if(tempRetorno.get(indice)==null){
                        tempRetorno.put(indice, valor);                         
                    }else{
                        tablaErrores.insertErrorSyntax(ambito ,valor.posY, valor.posX, "La celda con valor "+ valor.val+" tiene la celda de cabecera  "+indice+ " duplicada.");
                    }

                }
                filaVacia = false;
            } 
            this.tablaErrores.concat(leerCelda.getTablaErrores());
            
        }
      //System.out.println("");

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

    public tablaErrores getTablaErrores() {
        return tablaErrores;
    }
    
    
    

}
