/*
=============================
    Leyendo las Celdas del documento
=============================
 */
package readExcel;
 
import org.apache.poi.ss.usermodel.Cell;

/**
 *
 * @author joseph
 */
public class readCell {

    private Cell currentCell;
    
    //otras columnas
    private String columna;
    private String value;
    
//    private String tipo;
//    private String idPregunta;
//    private String etiqueta;
//    private String otraColumna;
    

    public readCell(Cell currentCell) {
        this.currentCell = currentCell;
        this.leer();
        
    }

    public void leer() {
//System.out.print(currentRow.getRowNum());
//        System.out.print("-");
//        System.out.print(currentCell.getColumnIndex());
//        System.out.print(") ");
        if (null == currentCell.getCellTypeEnum()) {
            this.value="";
        } else {
            switch (currentCell.getCellTypeEnum()) {
                case STRING:
                    this.value=currentCell.getStringCellValue();
                    break;
                    
                case NUMERIC:
                    this.value=String.valueOf(currentCell.getNumericCellValue());
                    break;
                    
                case _NONE: 
                    this.value="";
                    break;
                    
                case BOOLEAN:
                    System.out.println("[readCell]Boolean");
                    this.value=String.valueOf(currentCell.getBooleanCellValue()); 
                    break;
                    
                case BLANK:
                    this.value="";
                    break;
                case ERROR:
                    System.out.println("[readCell]Formato_Error");
                    this.value="";
                    break;
                    
                case FORMULA:
                    System.out.println("[readCell]Formato_Formula");
                    this.value="";
                    break;
                    
                default:
                    System.out.println("[readCell]Formato_Desconocido");
                    this.value="";
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

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    } 
}
