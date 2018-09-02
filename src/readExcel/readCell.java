/*
=============================
    Leyendo las Celdas del documento
=============================
 */
package readExcel;
 
import Analyzer.Tree.Tablas.tablaErrores;
import org.apache.poi.ss.usermodel.Cell;

/**
 *
 * @author joseph
 */
public class readCell {

    private Cell currentCell;
    public tablaErrores tablaErrores;
    //otras columnas
    private String columna;
    private cell value;
    
//    private String tipo;
//    private String idPregunta;
//    private String etiqueta;
//    private String otraColumna;
    

    public readCell(String ambito,Cell currentCell) {
        this.tablaErrores =new tablaErrores();
        this.currentCell = currentCell; 
        
        
        this.value=new cell(ambito);
        this.leer();
        this.value.posX=currentCell.getColumnIndex(); 
    }

    public void leer() {
//System.out.print(currentRow.getRowNum());
//        System.out.print("-");
//        System.out.print(currentCell.getColumnIndex());
//        System.out.print(") ");
        
        if (null == currentCell.getCellTypeEnum()) {
            
            this.value.val="";
        } else {
            switch (currentCell.getCellTypeEnum()) {
                case STRING:
                    this.value.val=currentCell.getStringCellValue();
                    break;
                    
                case NUMERIC:
                    this.value.val=String.valueOf(currentCell.getNumericCellValue());
                    break;
                    
                case _NONE: 
                    this.value.val="";
                    break;
                    
                case BOOLEAN:
                    tablaErrores.println("[readCell]Boolean");
                    this.value.val=String.valueOf(currentCell.getBooleanCellValue()); 
                    break;
                    
                case BLANK:
                    this.value.val="";
                    break;
                case ERROR:
                    tablaErrores.println("[readCell]Formato_Error");
                    this.value.val="";
                    break;
                    
                case FORMULA:
                    tablaErrores.println("[readCell]Formato_Formula");
                    this.value.val="";
                    break;
                    
                default:
                    tablaErrores.println("[readCell]Formato_Desconocido");
                    this.value.val="";
                    break;
            }
        }
    }

    /*
=============================
    Getters and Setters
=============================
     */
    public Cell getCurrentCell() {
        return currentCell;
    }

    public void setCurrentCell(Cell currentCell) {
        this.currentCell = currentCell;
    }

    public cell getValue() {
        return value;
    }

    public void setValue(cell value) {
        this.value = value;
    } 

    public tablaErrores getTablaErrores() {
        return tablaErrores;
    }
    
    
}
